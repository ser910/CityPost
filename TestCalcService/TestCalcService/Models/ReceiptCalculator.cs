using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestCalcService.ServiceCalculator;

namespace TestCalcService
{
    public class ReceiptCalculator : ViewModelBase, INotifyPropertyChanged
    {
        private TrackingServiceClient svc;
        private ICommand _calcCommand;
        private CargoVM _selectedCargoUnit;
        private BindingList<CargoVM> _cargoUnits;
        private ReceiptCollection _receiptColl;
        private Visibility _recCalulated = Visibility.Hidden;
        private bool _btnEnabled = false;
        private string _price;
        private ReceiptInfo _receipt;
        public ReceiptCalculator(TrackingServiceClient svc)
        {
            this.svc = svc;
            _cargoUnits = new BindingList<CargoVM>();
            _cargoUnits.ListChanged += _cargoUnits_ListChanged;
            _selectedCargoUnit = new CargoVM();

            BtnEnabled = Enabled();
            Calc = new RelayCommand(arg => CalcMethod(arg));
        }

        public bool BtnEnabled
        {
            get { return _btnEnabled; }
            set
            {
                _btnEnabled = value;
                OnPropertyChanged();
            }
        }
        
        public CargoVM SelectedCargoUnit
        {
            get { return _selectedCargoUnit; }
            set
            {
                    _selectedCargoUnit = value;
                    OnPropertyChanged();
            }
        }
        public ReceiptInfo Receipt
        {
            get { return _receipt; }
            set
            {
                if(value!=_receipt)
                {
                    _receipt = value;
                    OnPropertyChanged();
                }
            }
        }
        public BindingList<CargoVM> CargoUnits
        {
            get { return _cargoUnits; }
            set
            {
                if (value != null)
                {
                    _cargoUnits = value;
                    OnPropertyChanged();
                }
                else _cargoUnits = new BindingList<CargoVM>();
            }
        }
        public Visibility Calculated
        {
            get { return _recCalulated; }
            set
            {
                _recCalulated = value;
                OnPropertyChanged();
            }
        }

        public ReceiptCollection RecColl
        {
            get { return _receiptColl; }
            set
            {
                _receiptColl = value;
                OnPropertyChanged();
                if (value != null && (value as ReceiptCollection).Err == "OK")
                {
                    decimal price = 0;
                    if ((value as ReceiptCollection).Receipts != null)
                    {
                        (value as ReceiptCollection).Receipts.ToList().ForEach(rec =>
                        {
                            price += rec.Price.HasValue ? rec.Price.Value : 0;
                        });
                    }
                    Price = "Цена: " + price.ToString("F2") + " руб.";
                }

            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }
        public ICommand Calc
        {
            get { return _calcCommand; }
            set
            {
                if (value != null)
                {
                    _calcCommand = value;
                    OnPropertyChanged();

                }
            }
        }

        public void CalcMethod(object arg)
        {
            InputParamsVM param = arg as InputParamsVM;
            Receipt = new ReceiptInfo();
            Receipt.DeliveryType = param.SelectedDeliveryOption.DelivType;
            Receipt.ServiceID = param.SelectedService.Id;
            Receipt.ServiceName = param.SelectedService.Name;
            Receipt.CityToID = param.SelectedToAddress.CityID;
            Receipt.CityToName = param.SelectedToAddress.Name;
            Receipt.CityFromID = param.SelectedFromAddress.CityID;
            Receipt.CityFromName = param.SelectedFromAddress.Name;
            Receipt.CargoUnits = new CargoUnitInfo[CargoUnits.Count];
            for (int i = 0; i < CargoUnits.Count; i++)
            {
                Receipt.CargoUnits[i] = new CargoUnitInfo();
                Receipt.CargoUnits[i].Weight = CargoUnits[i].Weight;
                Receipt.CargoUnits[i].Volume = CargoUnits[i].Volume;
            }
            try
            {
                RecColl = svc.CalculateReceipt(Receipt);
                if (RecColl.Err == "OK")
                {
                    Calculated = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка сервиса расчета|{0}", ex.Message));
            }

        }

        private void HideResult()
        {
            Calculated = Visibility.Hidden;
            OnPropertyChanged("Calculated");
        }

        private void _cargoUnits_ListChanged(object sender, ListChangedEventArgs e)
        {
            BtnEnabled = Enabled();
        }

        private bool Enabled()
        {
            return (CargoUnits.Count > 0);
        }
    }
}
