using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DpdService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IdpdProxy
    {
        [OperationContract]
        [WebGet(UriTemplate = "/getCitiesDPD/", 
            ResponseFormat = WebMessageFormat.Json)]
        city[] getCitiesDPD();

        [OperationContract]
        [WebGet(UriTemplate = "/needUpdate/",
            ResponseFormat = WebMessageFormat.Json)]
        bool needUpdate();

        [OperationContract]
        [WebInvoke(Method ="POST",
            UriTemplate = "/getServiceCost2/",
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        serviceCost[] getServiceCost2(serviceCostRequest request);
    }

    [DataContract]
    public struct city
    {
        [DataMember]
        public long cityId;
        [DataMember]
        public int regionCode;
        [DataMember]
        public string countryCode;
        [DataMember]
        public string countryName;
        [DataMember]
        public string regionName;
        [DataMember]
        public string cityName;
    }

    [DataContract]
    public struct auth
    {
        [DataMember]
        public long clientNumber;
        [DataMember]
        public string clientKey;
    }

    [DataContract]
    public struct serviceCost
    {

        [DataMember]
        public string serviceCode;

        [DataMember]
        public string serviceName;

        [DataMember]
        public double cost;

        [DataMember]
        public int days;

    }

    [DataContract]
    public struct cityRequest
    {

        [DataMember]
        public long cityId;

        [DataMember]
        public int index;

        [DataMember]
        public int regionCode;

        [DataMember]
        public string cityName;

        [DataMember]
        public string countryCode;

    }

    [DataContract]
    public struct serviceCostRequest
    {

        [DataMember]
        public bool selfPickup;
        [DataMember]
        public bool selfDelivery;
        [DataMember]
        public bool volumeSpecified;
        [DataMember]
        public bool pickupDateSpecified;
        [DataMember]
        public int  maxDays;
        [DataMember]
        public double maxCost;
        [DataMember]
        public double declaredValue;
        [DataMember]
        public double weight;
        [DataMember]
        public double volume;
        [DataMember]
        public string serviceCode;
        [DataMember]
        public DateTime pickupDate;
        [DataMember]
        public auth auth;
        [DataMember]
        public cityRequest pickup;
        [DataMember]
        public cityRequest delivery;

    }

}
