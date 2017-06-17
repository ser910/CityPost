using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalcService
{
    public class ChartSeries: ViewModelBase
    {
        private string _title;
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
        public ObservableCollection<KeyValuePair<double, double>> Series { get; set; }
    }
}
