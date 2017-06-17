/**
 * Created by User on 30.01.2017.
 */
var dpdUrl = 'http://localhost:63658/dpdService.svc/SOAP';
var auth =
{
    clientNumber : 0000000000,
    clientKey : "0000000000000000000000000000000000000000"
};
function GetCitiesCashPay()
{
    var pl = new SOAPClientParameters();
    pl.add("auth", auth);
    SOAPClient.invoke(dpdUrl, "getCitiesCashPay", pl, true, GetCitiesCashPay_cB);
}
function GetCitiesCashPay_cB(u)
{
    if(u == null)
        alert("No user found.\r\n\r\nEnter a username and repeat search.");
    else
    if (data.Items != undefined) {
        if (Array.isArray(data.Items)) {
            $('#out').text = data;
        }
    }
}
$(function () {
    
    $('#btn-click').on('click',function () {
        GetCitiesCashPay();
    })
});
