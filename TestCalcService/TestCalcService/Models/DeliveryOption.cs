using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestCalcService.ServiceCalculator;

namespace TestCalcService
{
    public class DeliveryOption:ViewModelBase, INotifyPropertyChanged
    {
        private string _comboBoxText;
        private DelivType _delivType;
        public string ComboBoxText
        {
            get { return _comboBoxText; }
            set
            {
                _comboBoxText = value;
                switch(value)
                {
                    case "Склад-Склад":
                        _delivType = DelivType.Warehouse_Warehouse;
                        break;
                    case "Дверь-Склад":
                        _delivType = DelivType.Door_Warehouse;
                         break;
                    case "Склад-Дверь":
                        _delivType = DelivType.Warehouse_Door;
                        break;
                    case "Дверь-Дверь":
                        _delivType = DelivType.Door_Door;
                        break;
                    default:
                        break;
                }
                OnPropertyChanged("DelivType");
                OnPropertyChanged();
            }
        }
        public DelivType DelivType
        {
            get { return _delivType; }
        }

    }
}
