using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Input;
using TestCalcService.ServiceCalculator;

namespace TestCalcService
{
    public class ChartModel:ViewModelBase, INotifyPropertyChanged
    {
        private TrackingServiceClient svc;
        private double _startWeight = 0.001;
        private double _endWeight=50;
        private double _deltaWeight = 0.1;
        private double _curWeight = 0;
        private bool _visible = true;
        private bool _chartVisible = false;
        private ICommand _calcCommand;
        private ICommand _cancelCommand;
        private ReceiptInfo _receipt = new ReceiptInfo();
        private ObservableCollection<ChartSeries> _series;
        private ObservableCollection<KeyValuePair<double, double>> _series1 = new ObservableCollection<KeyValuePair<double, double>>();
        private ServiceInfo _service;
        private BackgroundWorker _worker;
        
        private string _title;
        public ChartModel(TrackingServiceClient svc)
        {
            this.svc = svc;
            _series = new ObservableCollection<ChartSeries>();
            _series.Add(new ChartSeries()
                {
                    Title = "Стандарт",
                    Series = new ObservableCollection<KeyValuePair<double, double>>()
                });
            _series.Add(new ChartSeries()
            {
                Title = "Эконом",
                Series = new ObservableCollection<KeyValuePair<double, double>>()
            });
            _series.Add(new ChartSeries()
            {
                Title = "Экспресс",
                Series = new ObservableCollection<KeyValuePair<double, double>>()
            });
            Calc = new RelayCommand(arg => StartCalc(arg));
            Cancel = new RelayCommand(arg => CancelCalc());
            _worker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _worker.DoWork += CalcProcess;
            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        public ICommand Calc
        {
            get { return _calcCommand; }
            set
            {
                if (value != _calcCommand)
                {
                    _calcCommand = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand Cancel
        {
            get { return _cancelCommand; }
            set
            {
                if (value != _cancelCommand)
                {
                    _cancelCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<KeyValuePair<double, double>> Series1
        {
            get { return _series1; }
            set
            {
                _series1 = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ChartSeries> Series
        {
            get { return _series; }
            set
            {
                if (value != _series)
                {
                    _series = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if(value != _title)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }
        public string StartWeight
        {
            get { return _startWeight.ToString(); }
            set
            {
                if (double.TryParse(value, out _startWeight))
                {
                    if (_startWeight <= 0)
                        _startWeight = 1e-3;
                    OnPropertyChanged();
                }
            }
        }
        public string EndWeight
        {
            get { return _endWeight.ToString(); }
            set
            {
                if (double.TryParse(value, out _endWeight))
                {
                    OnPropertyChanged();
                }
            }
        }
        public string DeltaWeight
        {
            get { return _deltaWeight.ToString(); }
            set
            {
                if (double.TryParse(value, out _deltaWeight))
                {
                    if (_deltaWeight <= 0)
                        _deltaWeight = 1e-3;
                    else if (_deltaWeight >= _endWeight)
                        _deltaWeight = _endWeight - _startWeight;
                    OnPropertyChanged();
                }
            }
        }
        public string CurrentWeight
        {

            get { return _curWeight.ToString(); }
            set
            {
                if (double.TryParse(value, out _curWeight))
                {
                    OnPropertyChanged();
                }
            }
        }
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if(value != _visible)
                {
                    _visible = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ChartVisible
        {
            get { return _chartVisible; }
            set
            {
                if(value != _chartVisible)
                {
                    _chartVisible = value;
                    OnPropertyChanged();
                }
            }
        }
        public void StartCalc(object arg)
        {
            SetReceiptInputParams(arg);
            CurrentWeight = StartWeight;
            //Series1.Clear();
            ClearAllChartSeries();
            if (!_worker.IsBusy)
            {
                _worker.RunWorkerAsync(arg);
            }
            Visible = !_worker.IsBusy;
            ChartVisible = true;
        }

        public void CancelCalc()
        {
            _worker.CancelAsync();
        }

        private void SetReceiptInputParams(object arg)
        {
            InputParamsVM param = arg as InputParamsVM;
            _receipt.CityFromID = param.SelectedFromAddress.CityID;
            _receipt.CityFromName = param.SelectedFromAddress.Name;
            _receipt.CityToID = param.SelectedToAddress.CityID;
            _receipt.CityToName = param.SelectedToAddress.Name;
            _receipt.DeliveryType = param.SelectedDeliveryOption.DelivType;
            _service = param.SelectedService;
        }

        private void ClearAllChartSeries()
        {
            foreach (var item in Series)
            {
                item.Series.Clear();
            }
        }

        #region BackgroundWorker Events
        // Note: This event fires on the background thread.
        private void CalcProcess(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            double curWeight;
            KeyValuePair<double, double> item;
            ProgressItem pitem;
            List<ProgressItem> pcoll;
            ReceiptCollection coll = new ReceiptCollection();
            for (curWeight = _startWeight; curWeight < _endWeight; curWeight += _deltaWeight)
            {
                CargoUnitInfo cargo = new CargoUnitInfo();
                cargo.Weight = (decimal)curWeight;
                cargo.Volume = 0.0M;
                _receipt.CargoUnits = new CargoUnitInfo[1];
                _receipt.CargoUnits[0] = cargo;
                coll = svc.CalculateReceipt(_receipt);
                pcoll = new List<ProgressItem>();
                for(int i=0; i< coll.Receipts.Count(); i++)
                {
                    pitem = new ProgressItem();
                    pitem.Title = Series[i].Title;
                    pitem.CurWeight = curWeight;
                    if (coll.Receipts[i].Price != null)
                    {
                        pitem.Title = coll.Receipts[i].ServiceName;
                        pitem.Item = new KeyValuePair<double, double>(curWeight, (double)coll.Receipts[i].Price);
                    }
                    else
                    {
                        item = new KeyValuePair<double, double>(curWeight, 0);
                    }
                    pcoll.Add(pitem);
                }

                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                if (worker.WorkerReportsProgress)
                {
                    int percentComplete = (int)(100 * (curWeight - _startWeight) / (_endWeight - _startWeight));
                    worker.ReportProgress(percentComplete, pcoll);
                }
            }
        }
        // Note: This event fires on the UI thread.
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var item = (List<ProgressItem>)e.UserState;
            for (int i = 0; i < item.Count; i++)
            {
                Series[i].Title = item[i].Title;
                Series[i].Series.Add(item[i].Item);
            }
        }
        // Note: This event fires on the UI thread.
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            Visible = !_worker.IsBusy;
            
        }

        #endregion BackgroundWorker Events

    }
}
