﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProxyTest.Proxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="city", Namespace="http://schemas.datacontract.org/2004/07/DpdService")]
    [System.SerializableAttribute()]
    public partial struct city : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long cityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cityNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string countryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string countryNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int regionCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string regionNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long cityId {
            get {
                return this.cityIdField;
            }
            set {
                if ((this.cityIdField.Equals(value) != true)) {
                    this.cityIdField = value;
                    this.RaisePropertyChanged("cityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cityName {
            get {
                return this.cityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.cityNameField, value) != true)) {
                    this.cityNameField = value;
                    this.RaisePropertyChanged("cityName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string countryCode {
            get {
                return this.countryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.countryCodeField, value) != true)) {
                    this.countryCodeField = value;
                    this.RaisePropertyChanged("countryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string countryName {
            get {
                return this.countryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.countryNameField, value) != true)) {
                    this.countryNameField = value;
                    this.RaisePropertyChanged("countryName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int regionCode {
            get {
                return this.regionCodeField;
            }
            set {
                if ((this.regionCodeField.Equals(value) != true)) {
                    this.regionCodeField = value;
                    this.RaisePropertyChanged("regionCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string regionName {
            get {
                return this.regionNameField;
            }
            set {
                if ((object.ReferenceEquals(this.regionNameField, value) != true)) {
                    this.regionNameField = value;
                    this.RaisePropertyChanged("regionName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="serviceCostRequest", Namespace="http://schemas.datacontract.org/2004/07/DpdService")]
    [System.SerializableAttribute()]
    public partial struct serviceCostRequest : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProxyTest.Proxy.auth authField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double declaredValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProxyTest.Proxy.cityRequest deliveryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double maxCostField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int maxDaysField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProxyTest.Proxy.cityRequest pickupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime pickupDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool pickupDateSpecifiedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool selfDeliveryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool selfPickupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string serviceCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double volumeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool volumeSpecifiedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double weightField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProxyTest.Proxy.auth auth {
            get {
                return this.authField;
            }
            set {
                if ((this.authField.Equals(value) != true)) {
                    this.authField = value;
                    this.RaisePropertyChanged("auth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double declaredValue {
            get {
                return this.declaredValueField;
            }
            set {
                if ((this.declaredValueField.Equals(value) != true)) {
                    this.declaredValueField = value;
                    this.RaisePropertyChanged("declaredValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProxyTest.Proxy.cityRequest delivery {
            get {
                return this.deliveryField;
            }
            set {
                if ((this.deliveryField.Equals(value) != true)) {
                    this.deliveryField = value;
                    this.RaisePropertyChanged("delivery");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double maxCost {
            get {
                return this.maxCostField;
            }
            set {
                if ((this.maxCostField.Equals(value) != true)) {
                    this.maxCostField = value;
                    this.RaisePropertyChanged("maxCost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int maxDays {
            get {
                return this.maxDaysField;
            }
            set {
                if ((this.maxDaysField.Equals(value) != true)) {
                    this.maxDaysField = value;
                    this.RaisePropertyChanged("maxDays");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProxyTest.Proxy.cityRequest pickup {
            get {
                return this.pickupField;
            }
            set {
                if ((this.pickupField.Equals(value) != true)) {
                    this.pickupField = value;
                    this.RaisePropertyChanged("pickup");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime pickupDate {
            get {
                return this.pickupDateField;
            }
            set {
                if ((this.pickupDateField.Equals(value) != true)) {
                    this.pickupDateField = value;
                    this.RaisePropertyChanged("pickupDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool pickupDateSpecified {
            get {
                return this.pickupDateSpecifiedField;
            }
            set {
                if ((this.pickupDateSpecifiedField.Equals(value) != true)) {
                    this.pickupDateSpecifiedField = value;
                    this.RaisePropertyChanged("pickupDateSpecified");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool selfDelivery {
            get {
                return this.selfDeliveryField;
            }
            set {
                if ((this.selfDeliveryField.Equals(value) != true)) {
                    this.selfDeliveryField = value;
                    this.RaisePropertyChanged("selfDelivery");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool selfPickup {
            get {
                return this.selfPickupField;
            }
            set {
                if ((this.selfPickupField.Equals(value) != true)) {
                    this.selfPickupField = value;
                    this.RaisePropertyChanged("selfPickup");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string serviceCode {
            get {
                return this.serviceCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.serviceCodeField, value) != true)) {
                    this.serviceCodeField = value;
                    this.RaisePropertyChanged("serviceCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double volume {
            get {
                return this.volumeField;
            }
            set {
                if ((this.volumeField.Equals(value) != true)) {
                    this.volumeField = value;
                    this.RaisePropertyChanged("volume");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool volumeSpecified {
            get {
                return this.volumeSpecifiedField;
            }
            set {
                if ((this.volumeSpecifiedField.Equals(value) != true)) {
                    this.volumeSpecifiedField = value;
                    this.RaisePropertyChanged("volumeSpecified");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double weight {
            get {
                return this.weightField;
            }
            set {
                if ((this.weightField.Equals(value) != true)) {
                    this.weightField = value;
                    this.RaisePropertyChanged("weight");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="auth", Namespace="http://schemas.datacontract.org/2004/07/DpdService")]
    [System.SerializableAttribute()]
    public partial struct auth : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string clientKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long clientNumberField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string clientKey {
            get {
                return this.clientKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.clientKeyField, value) != true)) {
                    this.clientKeyField = value;
                    this.RaisePropertyChanged("clientKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long clientNumber {
            get {
                return this.clientNumberField;
            }
            set {
                if ((this.clientNumberField.Equals(value) != true)) {
                    this.clientNumberField = value;
                    this.RaisePropertyChanged("clientNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="cityRequest", Namespace="http://schemas.datacontract.org/2004/07/DpdService")]
    [System.SerializableAttribute()]
    public partial struct cityRequest : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long cityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string cityNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string countryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int indexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int regionCodeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long cityId {
            get {
                return this.cityIdField;
            }
            set {
                if ((this.cityIdField.Equals(value) != true)) {
                    this.cityIdField = value;
                    this.RaisePropertyChanged("cityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string cityName {
            get {
                return this.cityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.cityNameField, value) != true)) {
                    this.cityNameField = value;
                    this.RaisePropertyChanged("cityName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string countryCode {
            get {
                return this.countryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.countryCodeField, value) != true)) {
                    this.countryCodeField = value;
                    this.RaisePropertyChanged("countryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int index {
            get {
                return this.indexField;
            }
            set {
                if ((this.indexField.Equals(value) != true)) {
                    this.indexField = value;
                    this.RaisePropertyChanged("index");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int regionCode {
            get {
                return this.regionCodeField;
            }
            set {
                if ((this.regionCodeField.Equals(value) != true)) {
                    this.regionCodeField = value;
                    this.RaisePropertyChanged("regionCode");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="serviceCost", Namespace="http://schemas.datacontract.org/2004/07/DpdService")]
    [System.SerializableAttribute()]
    public partial struct serviceCost : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double costField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int daysField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string serviceCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string serviceNameField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double cost {
            get {
                return this.costField;
            }
            set {
                if ((this.costField.Equals(value) != true)) {
                    this.costField = value;
                    this.RaisePropertyChanged("cost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int days {
            get {
                return this.daysField;
            }
            set {
                if ((this.daysField.Equals(value) != true)) {
                    this.daysField = value;
                    this.RaisePropertyChanged("days");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string serviceCode {
            get {
                return this.serviceCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.serviceCodeField, value) != true)) {
                    this.serviceCodeField = value;
                    this.RaisePropertyChanged("serviceCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string serviceName {
            get {
                return this.serviceNameField;
            }
            set {
                if ((object.ReferenceEquals(this.serviceNameField, value) != true)) {
                    this.serviceNameField = value;
                    this.RaisePropertyChanged("serviceName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IdpdProxy")]
    public interface IdpdProxy {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdpdProxy/getCitiesDPD", ReplyAction="http://tempuri.org/IdpdProxy/getCitiesDPDResponse")]
        ProxyTest.Proxy.city[] getCitiesDPD();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdpdProxy/getCitiesDPD", ReplyAction="http://tempuri.org/IdpdProxy/getCitiesDPDResponse")]
        System.Threading.Tasks.Task<ProxyTest.Proxy.city[]> getCitiesDPDAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdpdProxy/needUpdate", ReplyAction="http://tempuri.org/IdpdProxy/needUpdateResponse")]
        bool needUpdate();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdpdProxy/needUpdate", ReplyAction="http://tempuri.org/IdpdProxy/needUpdateResponse")]
        System.Threading.Tasks.Task<bool> needUpdateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdpdProxy/getServiceCost2", ReplyAction="http://tempuri.org/IdpdProxy/getServiceCost2Response")]
        ProxyTest.Proxy.serviceCost[] getServiceCost2(ProxyTest.Proxy.serviceCostRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdpdProxy/getServiceCost2", ReplyAction="http://tempuri.org/IdpdProxy/getServiceCost2Response")]
        System.Threading.Tasks.Task<ProxyTest.Proxy.serviceCost[]> getServiceCost2Async(ProxyTest.Proxy.serviceCostRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IdpdProxyChannel : ProxyTest.Proxy.IdpdProxy, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IdpdProxyClient : System.ServiceModel.ClientBase<ProxyTest.Proxy.IdpdProxy>, ProxyTest.Proxy.IdpdProxy {
        
        public IdpdProxyClient() {
        }
        
        public IdpdProxyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IdpdProxyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IdpdProxyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IdpdProxyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ProxyTest.Proxy.city[] getCitiesDPD() {
            return base.Channel.getCitiesDPD();
        }
        
        public System.Threading.Tasks.Task<ProxyTest.Proxy.city[]> getCitiesDPDAsync() {
            return base.Channel.getCitiesDPDAsync();
        }
        
        public bool needUpdate() {
            return base.Channel.needUpdate();
        }
        
        public System.Threading.Tasks.Task<bool> needUpdateAsync() {
            return base.Channel.needUpdateAsync();
        }
        
        public ProxyTest.Proxy.serviceCost[] getServiceCost2(ProxyTest.Proxy.serviceCostRequest request) {
            return base.Channel.getServiceCost2(request);
        }
        
        public System.Threading.Tasks.Task<ProxyTest.Proxy.serviceCost[]> getServiceCost2Async(ProxyTest.Proxy.serviceCostRequest request) {
            return base.Channel.getServiceCost2Async(request);
        }
    }
}
