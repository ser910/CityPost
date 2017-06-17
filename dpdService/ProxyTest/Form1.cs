using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProxyTest.Proxy;

namespace ProxyTest
{
    public partial class Form1 : Form
    {
        const int maxItemsToDisplay = 300;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auth auth = new auth()
            {
                clientNumber = 0000000000,
                clientKey = "0000000000000000000000000000000000000000"
            };
            IdpdProxyClient proxy = new IdpdProxyClient();
            try
            {
                textBox1.Text = "Requesting...";
                var cities = proxy.getCitiesDPD();
                textBox1.Clear();
                textBox1.AppendText("Requested " + cities.Count().ToString() + " elements" + System.Environment.NewLine);
                int recordsDisplayed = 0;
                foreach (city oneCity in cities)
                {
                    var tmpS = "";
                    tmpS += "Страна=" + oneCity.countryCode + " город=" + oneCity.cityName + " регион=" + oneCity.regionName + System.Environment.NewLine;
                    textBox1.AppendText(tmpS);
                    recordsDisplayed++;
                    if (recordsDisplayed > maxItemsToDisplay)
                        break;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            auth auth = new auth()
            {
                clientNumber = 0000000000,
                clientKey = "0000000000000000000000000000000000000000"
            };

            //DPDGeographyClient DPD_geography_proxy = new DPDGeographyClient();
            //try
            //{
            //    textBox1.Text = "Requesting...";
            //    DpdService.geographyProxy.city[] cities = DPD_geography_proxy.getCitiesCashPay(auth);
            //    textBox1.Clear();
            //    textBox1.AppendText("Requested " + cities.Count().ToString() + " elements" + System.Environment.NewLine);
            //    var filteredCities =
            //        from item in cities
            //        where
            //            item.cityName.ToLower().Contains(textBox2.Text.ToLower())
            //        select new { item };

            //    int recordsDisplayed = 0;
            //    textBox1.AppendText("FIltered " + filteredCities.Count().ToString() + " elements" + System.Environment.NewLine);
            //    foreach (var oneCity in filteredCities)
            //    {
            //        var tmpS = "";
            //        tmpS += "Страна=" + oneCity.item.countryName + " город=" + oneCity.item.cityName + " регион=" + oneCity.item.regionName + System.Environment.NewLine;
            //        textBox1.AppendText(tmpS);
            //        recordsDisplayed++;
            //        if (recordsDisplayed > maxItemsToDisplay)
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    textBox1.Text = ex.Message;
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            auth auth = new auth()
            {
                clientNumber = 0000000000,
                clientKey = "0000000000000000000000000000000000000000"
            };

            //DpdService.geographyProxy.dpdParcelShopRequest PSreq = new DpdService.geographyProxy.dpdParcelShopRequest()
            //{
            //    auth = auth,
            //    //cityCode = "61000001000", // Ростов на дону
            //    //cityName = "Ростов-на-Дону"
            //};

            //DpdService.geographyProxy.DPDGeographyClient DPD_geography_proxy = new DpdService.geographyProxy.DPDGeographyClient();
            //try
            //{
            //    textBox1.Text = "Requesting...";
            //    DpdService.geographyProxy.dpdParcelShops parcelShops = DPD_geography_proxy.getParcelShops(PSreq);
            //    textBox1.Clear();
            //    textBox1.AppendText("Requested " + parcelShops.parcelShop.Count().ToString() + " elements" + System.Environment.NewLine);
            //    int recordsDisplayed = 0;

            //    foreach (var oneParcelShop in parcelShops.parcelShop)
            //    {
            //        var tmpS = "";
            //        tmpS += "Регион=" + oneParcelShop.address.regionName + " Город=" + oneParcelShop.address.cityName + " Адрес=" + oneParcelShop.address.addressString + System.Environment.NewLine;
            //        textBox1.AppendText(tmpS);
            //        recordsDisplayed++;
            //        if (recordsDisplayed > maxItemsToDisplay)
            //            break;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    textBox1.Text = ex.Message;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            auth auth = new auth()
            {
                clientNumber = 0000000000,
                clientKey = "0000000000000000000000000000000000000000"
            };

            IdpdProxyClient proxy = new IdpdProxyClient();
            try
            {

                cityRequest pickup = new cityRequest()
                {
                    cityName = textBox4.Text//"Москва"
                };

                cityRequest delivery = new cityRequest()
                {
                    cityName = textBox5.Text//"Москва"
                };

                double weight = 0;
                if (!Double.TryParse(textBox6.Text, out weight))
                {
                    throw new Exception("Невозможно распарсить вес");
                }

                bool isVolumeSpecified = false;
                double volume = 0;
                if (!Double.TryParse(textBox7.Text, out volume))
                {
                    textBox7.Text = "undefined";
                }
                else
                {
                    isVolumeSpecified = true;
                }

                serviceCostRequest req = new serviceCostRequest()
                {
                    auth = auth,
                    weight = weight,
                    volume = volume,
                    volumeSpecified = isVolumeSpecified,
                    pickup = pickup,
                    delivery = delivery,
                    selfPickup = checkBox1.Checked,
                    selfDelivery = checkBox2.Checked
                };


                textBox1.Text = "Requesting...";
                serviceCost[] serviceCost = proxy.getServiceCost2(req);
                textBox3.Clear();
                textBox3.AppendText("Requested " + serviceCost.Count().ToString() + " elements" + System.Environment.NewLine);
                int recordsDisplayed = 0;

                foreach (var oneserviceCost in serviceCost)
                {
                    var tmpS = "";
                    tmpS += "Сервис=" + oneserviceCost.serviceCode.ToString() + "[" + oneserviceCost.serviceName.ToString() + "]" + " Стоимость=" + oneserviceCost.cost.ToString() + " Дней=" + oneserviceCost.days.ToString() + System.Environment.NewLine;
                    textBox3.AppendText(tmpS);
                    recordsDisplayed++;
                    if (recordsDisplayed > maxItemsToDisplay)
                        break;
                }

            }
            catch (Exception ex)
            {
                textBox3.Text = ex.Message;
            }

        }
    }
}
