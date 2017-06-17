//var serviceUrl = 'http://localhost:63658/dpdService.svc/REST/';
var serviceUrl = 'http://192.168.104.2:1718/dpdService.svc/REST/';
//var serviceUrl = 'https://traking.cpost.ru/dpdService.svc/REST/';
var recUrl = 'getServiceCost2/';
var geoUrl = 'getCitiesDPD/';
var whUrl = 'getTerminalsSelfDelivery2/';
var updUrl = 'needUpdate';
//Скорее всего не понадобится не стоит открывать ключ клиентам.
var auth =
{
    clientNumber: 0000000000,
    clientKey: "0000000000000000000000000000000000000000"
};
var cities = [];
var request = {};
//маска чисел
var dMask = "999990X99";
var maskOptions= {
    translation: {
        'X': {
            pattern: /./, optional: true
        }
    }
};

//Список городов JSONP
function GetGeography() {
    var url = serviceUrl + geoUrl;// + auth.clientKey + '/' + auth.clientNumber;
    $.ajax({
        url: url,
        dataType: "jsonp",
        type: "GET",
        jsonpCallback: "cb_Geo",
        success: function (data, textStatus, jqXHR) {

        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Список городов не получен. Расчет цены не возможен. Причина: " + textStatus);
        },
        complete: function (jqXHR, textStatus) {

        }
    });
};


//Действия при получени списка городов
function cb_Geo(data) {
    if (data != undefined) {
        if (Array.isArray(data))
        {
            if (cities.length != data.length) {//Список городов изменился
                cities = data;
                //Обновляем локальное хранилище
                localStorage.clear();
                localStorage.setItem("cities", JSON.stringify(cities));
                //Обновляем списки автозаполнения
                $('#from-input').autocomplete('option', 'source', cities);
                $('#to-input').autocomplete('option', 'source', cities);
                
            }
            $('#calc').show();
            $('#result').empty();
            checkUpdate();
        }
    } else {
        if (confirm("Не удалось получить список городов.\nПопробовать снова?"))
            GetGeography();
    }
};

//Проверка обновлений городов JSONP
function checkUpdate() {
    var url = serviceUrl + updUrl;
    $.ajax({
        url: url,
        dataType: "jsonp",
        type: "GET",
        jsonpCallback: "cb_Update",
        success: function (data, textStatus, jqXHR) { },
        error: function (jqXHR, textStatus, errorThrown) {  },
        complete: function (jqXHR, textStatus) {  }
    });
};
//Помещаем в кууки результат наличия обновлений (м.б. к сайту подключен jqery cookies)
function setCityCookie() {
    var date = new Date();
    date.setTime(date.getTime() + 356 * 30 * 24 * 60 * 60 * 1000);//1 год.
    document.cookie = "citiesUpdated=1;path=/; expires=" + date.toUTCString();
};
function getCityCookie() {
    var reg = /citiesUpdated=/i;
    return (reg.exec(document.cookie)) ? 'true' : 'false';
};
function delCityCookie() {

    var date = new Date();
    date.setTime(date.getTime() - 1);
    document.cookie = "citiesUpdated='';path=/; expires=" + date.toUTCString();;
};
function cb_Update(data)
{
    if (data) {
        setCityCookie()
    } else {
        delCityCookie();
    };
}

//Расчет цены
function PostCalc() {
    var url = serviceUrl + recUrl;
    request.auth = auth;
    request.weight = $('#weight-input').val();
    request.volume = $('#volume-input').val();
    request.volumeSpecified = (request.volume) ? true : false;
    request.pickup = { cityName: $('#from-input').val() };
    request.delivery = { cityName: $('#to-input').val() };
    request.selfPickup = $('#self-pickap-input').prop('checked');
    request.selfDelivery = $('#self-delivery-input').prop('checked');
    var requestJson = JSON.stringify(request);
    $.ajax({
        url: url,
        type: "POST",
        data: requestJson,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: cb_Calc
    });
};

//Действия при получении цен
function cb_Calc(data) {
    if (data != undefined) {
        if (Array.isArray(data)) {
            $('#result').empty();
            if (data.length > 0) {
                //Создаем таблицу с результатом ответа сервиса
                var table = $('<table class="table table-striped"></table>')
                $('<thead style="color:white; background-color:red">').append('<tr><th>Сервис</th><th>Стоимость</th><th>Дней</th></tr>').appendTo(table);
                var tbody = $('<tbody>');
                data.forEach(function (item) {
                    var serviceName = $("<td></td>").text(item.serviceName);
                    var cost = $("<td></td>").text(item.cost);
                    var days = $("<td></td>").text(item.days);
                    $("<tr>").append(serviceName, cost, days).appendTo(tbody);
                });
                table.append(tbody).appendTo('#result');
            } else {
                $('<p>').text('Нет тарифа по данному направлению').appendTo('#result');
            }
            
            
        }
    }
};
//Уведомление клиента о отсутствии списка городов.
function noCities() {
    $('#calc').hide();
    $('#result').append('<p>Загрузка списка городов...</p><img src="img/loading30.gif" />');
}
//On load
$(function () {
    $('#calc').on('click', function () {
        PostCalc();
    });
    //Получаем список городов
    if (typeof (Storage) !== "undefined") {
        var jsonCities = localStorage.getItem("cities");
        if (jsonCities) {
            if (Array.isArray(JSON.parse(jsonCities))) {
                cities = JSON.parse(jsonCities);
            } else {
                //Локальное хранилище повреждено
                noCities();
                localStorage.clear();
            }

        } else {
            //Локальное хранилище пустое
            noCities();
        }
    } else {
        //Локальное хранилище недоступно
        noCities();
    }
    //Картинки подгрузки городов в autocomplete
    $("#loading").hide();
    $("#loading2").hide();
    //Проверяем куки надо ли получать новый список городов если надо подгружаем
    if(getCityCookie())
        GetGeography();

    $('#from-input').autocomplete({
        source: cities.map(function (item) {
            return item.cityName;
        }),
        search: function () {
            $("#loading").show();
        },
        response: function () {
            $("#loading").hide();
        },
        minLength: 3,
    });
    $('#to-input').autocomplete({
        source: cities.map(function (item) {
            return item.cityName;
        }),
        search: function () {
            $("#loading2").show();
        },
        response: function () {
            $("#loading2").hide();
        },
        minLength: 3,
    });
    //Маска не работает непонятно почему
    //$('#weight-input').mask(dMask, maskOptions);
    //$('#volume-input').mask(dMask, maskOptions);
});
