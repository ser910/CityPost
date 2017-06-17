using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestCalcService.ServiceCalculator;

namespace TestCalcService
{
    public class CargoVM: CargoUnitInfo, INotifyPropertyChanged
    {
        private decimal _length=0;
        private decimal _width=0;
        private decimal _height=0;
        private string _btnText = "Отменить(Esc)";
        private bool _btnEnabled = true;
        private string _selEgType = "Груз";
        private bool _fieldsEnabled = true;
        public CargoVM()
        {
            Weight = 0.0M;
        }
        public string SelEgType
        {
            get { return _selEgType; }
            set
            {
                _selEgType = value;
                if (value == "Конверт 0,25кг")
                {
                    Weight = 0.25M;
                    Length = "30";
                    Width = "21";
                    Height = "1";
                    FieldsEnabled = false;
                }
                else if (value == "Конверт 0,50кг")
                {
                    Weight = 0.5M;
                    Length = "44";
                    Width = "34";
                    Height = "1";
                    FieldsEnabled = false;
                }
                else if(value == "Груз")
                {
                    Weight = 0.0M;
                    Length = "0";
                    Width = "0";
                    Height = "0";
                    FieldsEnabled = true;
                }
                this.RaisePropertyChanged("WeightStr");
                this.RaisePropertyChanged("SelEgType");
            }
        }
        public string Length
        {
            get { return _length.ToString(); }
            set
            {
                if (decimal.TryParse(value, out _length))
                {
                    CalcVolume();
                    this.RaisePropertyChanged("Length");
                    this.RaisePropertyChanged("Volume");
                }
            }
        }
        public string Width
        {
            get { return _width.ToString(); }
            set
            {
                if (decimal.TryParse(value, out _width))
                {
                    CalcVolume();
                    this.RaisePropertyChanged("Width");
                    this.RaisePropertyChanged("Volume");
                }
            }
        }
        public string Height
        {
            get { return _height.ToString(); }
            set
            {
                if (decimal.TryParse(value, out _height))
                {
                    CalcVolume();
                    this.RaisePropertyChanged("Height");
                    this.RaisePropertyChanged("Volume");
                }
            }
        }
        public string WeightStr
        {
            get { return Weight.ToString(); }
            set
            {
                double outval;
                if (double.TryParse(value, out outval))
                {
                    Weight = (decimal)outval;
                    this.RaisePropertyChanged("WeightStr");
                }
            }
        }
        public string BtnText
        {
            get { return _btnText; }
            set
            {
                _btnText = value;
                this.RaisePropertyChanged("BtnText");
            }
        }
        public bool BtnEnabled
        {
            get { return _btnEnabled; }
            set
            {
                _btnEnabled = value;
                this.RaisePropertyChanged("BtnEnabled");
            }
        }
        public bool FieldsEnabled
        {
            get { return _fieldsEnabled; }
            set
            {
                _fieldsEnabled = value;
                this.RaisePropertyChanged("FieldsEnabled");
            }
        }
        private void CalcVolume()
        {
            Volume = _length * _width * _height/1000000;
        }
        
    }
}
