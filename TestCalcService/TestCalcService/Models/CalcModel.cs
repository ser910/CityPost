using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using TestCalcService.ServiceCalculator;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;

namespace TestCalcService
{
    public class CalcModel :ViewModelBase, INotifyPropertyChanged
    {
        #region Fields
        private TrackingServiceClient svc;
        private InputParamsVM _inputParams;
        private ReceiptCalculator _recCalc;
        private ChartModel _chart;
        #endregion Fields

        public CalcModel()
        {
            svc = new TrackingServiceClient();
            _inputParams = new InputParamsVM(svc);
            
            _chart = new ChartModel(svc);
            _recCalc = new ReceiptCalculator(svc);
        }

        public InputParamsVM InputParams
        {
            get { return _inputParams; }
            set
            {
                if(value != _inputParams)
                {
                    if(value != null)
                        _inputParams = value;
                    else
                        _inputParams = new InputParamsVM(svc);
                    Chart = new ChartModel(svc);
                    OnPropertyChanged();
                }
                
            }
        }
        public ReceiptCalculator RecCalc
        {
            get { return _recCalc; }
            set
            {
                _recCalc = value;
                OnPropertyChanged();
            }
        }
        public ChartModel Chart
        {
            get { return _chart; }
            set
            {
                _chart = value;
                OnPropertyChanged();
            }
        }
    }
}
