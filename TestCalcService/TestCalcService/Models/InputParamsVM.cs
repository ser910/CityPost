using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestCalcService.ServiceCalculator;

namespace TestCalcService
{
    public class InputParamsVM : ViewModelBase, INotifyPropertyChanged
    {
        private DeliveryOption _selectedDeliveryOption;
        private ObservableCollection<DeliveryOption> _deliveryOptions;
        private ServiceInfo _selectedService;
        private string _labelFrom;
        private string _labelTo;
        private string _fromText;
        private string _toText;
        private CityInfo _selectedFromAddress = new CityInfo();
        private CityInfo _selectedToAddress = new CityInfo();
        private ObservableCollection<CityInfo> _fromAddress;
        private ObservableCollection<CityInfo> _toAddress;
        private ObservableCollection<ServiceInfo> _services;
        private List<CityInfo> _wh;
        private List<CityInfo> _geo;
        private List<CityInfo> _from;
        private List<CityInfo> _to;
        private TrackingServiceClient svc;
        private bool _visible = false;

        public InputParamsVM(TrackingServiceClient svc)
        {
            this.svc = svc;
            _selectedDeliveryOption = new DeliveryOption() { ComboBoxText = "Дверь-Дверь" };
            _geo = GeographyMethod();
            _wh = WarehouseMethod();
            _selectedService = new ServiceInfo();
            _fromAddress = new ObservableCollection<CityInfo>();
            _toAddress = new ObservableCollection<CityInfo>();
            _services = new ObservableCollection<ServiceInfo>();
            _services.Add(new ServiceInfo());
            _deliveryOptions = new ObservableCollection<DeliveryOption>();
            _from = _geo;
            _to = _geo;
            SelectedDeliveryOption = new DeliveryOption() { ComboBoxText = "Дверь-Дверь" };
            _deliveryOptions.Add(SelectedDeliveryOption);
            _deliveryOptions.Add(new DeliveryOption() { ComboBoxText = "Дверь-Склад" });
            _deliveryOptions.Add(new DeliveryOption() { ComboBoxText = "Склад-Дверь" });
            _deliveryOptions.Add(new DeliveryOption() { ComboBoxText = "Склад-Склад" });
            try
            {
                var SeviceColls = svc.GetServices(string.Empty);
                if (SeviceColls != null)
                {
                    foreach (var item in SeviceColls.Items.ToList())
                    {
                        Services.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка сервиса|{0}", ex.Message));
            }
        }
        public string LabelFrom
        {
            get { return _labelFrom; }
            set
            {
                _labelFrom = value;
                OnPropertyChanged();
            }
        }
        public string LabelTo
        {
            get { return _labelTo; }
            set
            {
                _labelTo = value;
                OnPropertyChanged();
            }
        }
        public string FromText
        {
            get { return _fromText; }
            set
            {
                if (value != _fromText)
                {
                    _fromText = value;
                    FromAddress = new ObservableCollection<CityInfo>();
                    _from.Where(item => item.Name.ToLower().Contains(value.ToLower())).ToList().ForEach(city =>
                    {
                        FromAddress.Add(city);
                    });
                    //OnPropertyChanged("FromAddress");
                    OnPropertyChanged();
                }
            }
        }
        public string ToText
        {
            get { return _toText; }
            set
            {
                if (value != _toText)
                {
                    _toText = value;
                    ToAddress = new ObservableCollection<CityInfo>();
                    _to.Where(item => item.Name.ToLower().Contains(value.ToLower())).ToList().ForEach(city =>
                    {
                        ToAddress.Add(city);
                    });
                    //OnPropertyChanged("ToAddress");
                    OnPropertyChanged();
                }
            }
        }
        public DeliveryOption SelectedDeliveryOption
        {
            get { return _selectedDeliveryOption; }
            set
            {
                _selectedDeliveryOption = value;
                switch (value.DelivType)
                {
                    case DelivType.Warehouse_Warehouse:
                        LabelFrom = "Из ПВЗ:";
                        LabelTo = "В ПВЗ:";
                        _from = _wh;
                        _to = _wh;
                        break;
                    case DelivType.Door_Warehouse:
                        LabelFrom = "Из города:";
                        LabelTo = "В ПВЗ:";
                        _from = _geo;
                        _to = _wh;
                        break;
                    case DelivType.Warehouse_Door:
                        LabelFrom = "Из ПВЗ:";
                        LabelTo = "В город:";
                        _from = _wh;
                        _to = _geo;
                        break;
                    case DelivType.Door_Door:
                        LabelFrom = "Из города:";
                        LabelTo = "В город:";
                        _from = _geo;
                        _to = _geo;
                        break;
                    default:
                        break;
                }
                OnPropertyChanged();
                ClearAdressSelections();
            }
        }
        public CityInfo SelectedFromAddress
        {
            get { return _selectedFromAddress; }
            set
            {
                if (value != _selectedFromAddress)
                {
                    _selectedFromAddress = value;
                    CheckSelections();
                    OnPropertyChanged();
                }
            }
        }
        public CityInfo SelectedToAddress
        {
            get { return _selectedToAddress; }
            set
            {
                if (value != _selectedToAddress)
                {
                    _selectedToAddress = value;
                    CheckSelections();
                    OnPropertyChanged();
                }
            }
        }
        public ServiceInfo SelectedService
        {
            get { return _selectedService; }
            set
            {
                _selectedService = value;
                OnPropertyChanged();
            }
        }
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnPropertyChanged();
            }

        }
        public ObservableCollection<DeliveryOption> DeliveryOptions
        {
            get { return _deliveryOptions; }
        }
        public ObservableCollection<CityInfo> FromAddress
        {
            get { return _fromAddress; }
            set
            {
                if (_fromAddress != value)
                {
                    _fromAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<CityInfo> ToAddress
        {
            get { return _toAddress; }
            set
            {
                if (_toAddress != value)
                {
                    _toAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<ServiceInfo> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                OnPropertyChanged();
            }
        }

        private List<CityInfo> GeographyMethod()
        {
            List<CityInfo> items = new List<CityInfo>();
            try
            {
                var ServiceCollection = svc.GetGeography(string.Empty, _selectedDeliveryOption.DelivType);
                if (ServiceCollection != null && ServiceCollection.Count > 0)
                {
                    foreach (var item in ServiceCollection.Items.Select(val => new CityInfo() { CityID = val.Id, Name = val.City }).Distinct().ToList())
                    {
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка сервиса|{0}", ex.Message));
            }
            return items;
        }

        private List<CityInfo> WarehouseMethod()
        {
            List<CityInfo> items = new List<CityInfo>();
            try
            {
                var ServiceCollection = svc.GetWarehouse(string.Empty);

                if (ServiceCollection != null && ServiceCollection.Count > 0)
                {
                    foreach (var item in ServiceCollection.Items.Select(val => new CityInfo() { CityID = val.CityId, Name = val.CityName }).GroupBy(city => city.CityID).Select(x => x.First()).ToList())
                    {
                        items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка сервиса|{0}", ex.Message));
            }
            return items;
        }

        private void ClearAdressSelections()
        {
            FromText = string.Empty;
            ToText = string.Empty;
        }
        private void CheckSelections()
        {
            if ((_selectedFromAddress != null) && (_selectedToAddress != null))
            {
                Visible = ((_selectedFromAddress.Name != null) && (_selectedToAddress.Name != null));
            }
        }

    }
}
