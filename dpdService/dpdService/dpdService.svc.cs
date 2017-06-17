using System;
using DpdService.calculator2Proxy;
using DpdService.geographyProxy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DpdService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    public class dpdService : IdpdProxy
    {
        private const int UPDATE_DAY_NUMBER = 7;// Число обозначает через сколько дней обновится список городов 
        private static DPDCalculator proxyc;
        private static DPDGeography proxyg;
        private static city[] _city;
        private static DateTime _updateDate;

        static dpdService()
        {
            _updateDate = DateTime.Now;
            proxyc = new DPDCalculatorClient();
            proxyg = new DPDGeographyClient();
            _city = getCitiesCashPay();
        }

        public bool needUpdate()
        {
            if((DateTime.Now - _updateDate).Days > UPDATE_DAY_NUMBER)
            {
                city[] response = getCitiesCashPay();
                lock (_city.SyncRoot)
                {
                    _city = new city[response.Length];
                    response.CopyTo(_city, 0);
                }
                _updateDate = DateTime.Now;
                return true;
            }
            return false;
        }

        public city[] getCitiesDPD()
        {
            city[] result ;
            lock (_city.SyncRoot) //т.к. _city статическая Блокируем ее пока 
            {
                result = new city[_city.Length];
                _city.CopyTo(result, 0);
            }
      
            return result;
        }

        private static city[] getCitiesCashPay()
        {
            //Жестко зашил ключ и номер для скрытия их в браузере.
            geographyProxy.auth _auth = new geographyProxy.auth();
            _auth.clientKey = "1D665F95C980912A35E66BF194BE106C2136C4FB";
            _auth.clientNumber = 1001038951;
            getCitiesCashPayRequest request = new getCitiesCashPayRequest(_auth);
            geographyProxy.city[] response;
            try
            {
                response = proxyg.getCitiesCashPay(request).@return;
            }
            catch (FaultException)
            {
                return new city[0];
            }
            city[] _return = new city[0];
            if (response != null && response.Length > 0)
            {
               _return = new city[response.Length];
               Parallel.For(0, response.Length, i =>
               {
                   _return[i].cityId = response[i].cityId;
                   _return[i].cityName = response[i].cityName;
                   _return[i].countryCode = response[i].countryName;
                   _return[i].regionCode = response[i].regionCode;
                   _return[i].regionName = response[i].regionName;
               });
            }
            return _return;
        }

        public serviceCost[] getServiceCost2(serviceCostRequest request)
        {
            calculator2Proxy.getServiceCost2Response somthing;
            try
            {
                somthing = proxyc.getServiceCost2(CreateServiceCost2Request(request));
            }
            catch (FaultException)
            {
                return new serviceCost[0];
            }
            var response = somthing.@return;
            serviceCost[] _return = new serviceCost[0];
            if (response != null && response.Length > 0)
            {
                _return = new serviceCost[response.Length];
                Parallel.For(0, response.Length, i =>
                {
                    _return[i].cost = response[i].cost;
                    _return[i].serviceName = response[i].serviceName;
                    _return[i].serviceCode = response[i].serviceCode;
                    _return[i].days = response[i].days;
                });
            }
            return _return;
        }

        private getServiceCost2Request CreateServiceCost2Request(serviceCostRequest request)
        {
            var _request = new calculator2Proxy.serviceCostRequest();
            _request.auth = new calculator2Proxy.auth();
            _request.auth.clientKey = request.auth.clientKey;
            _request.auth.clientNumber = request.auth.clientNumber;
            _request.pickup = ConvertProxy(request.pickup);
            _request.delivery = ConvertProxy(request.delivery);
            _request.weight = request.weight;
            _request.volume = request.volume;
            _request.volumeSpecified = request.volumeSpecified;
            _request.maxCost = request.maxCost;
            _request.maxCostSpecified = (request.maxCost > 0); 
            _request.maxDays = request.maxDays;
            _request.selfDelivery = request.selfDelivery;
            _request.selfPickup = request.selfPickup;
            _request.serviceCode = request.serviceCode;
            var request2 = new getServiceCost2Request(_request);
            return request2;
        }

        private calculator2Proxy.cityRequest ConvertProxy(cityRequest request)
        {
            var result = new calculator2Proxy.cityRequest();
            result.cityId = request.cityId;
            result.cityName = request.cityName;
            result.cityIdSpecified = (request.cityId == 0) ? false : true;
            result.countryCode = request.countryCode;
            result.index = request.index;
            result.indexSpecified = (request.index == 0) ? false : true;
            result.regionCode = request.regionCode;
            result.regionCodeSpecified = (request.regionCode == 0) ? false : true;
            return result;
        }
        //to do
        public getServiceCostByParcels2Response getServiceCostByParcels2(getServiceCostByParcels2Request request)
        {
            return proxyc.getServiceCostByParcels2(request);
        }
        //to do
        public getServiceCostInternationalResponse getServiceCostInternational(getServiceCostInternationalRequest request)
        {
            return proxyc.getServiceCostInternational(request);
        }

        
    }
}
