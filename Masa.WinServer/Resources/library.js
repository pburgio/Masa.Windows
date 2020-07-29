//var urlBase = "https://masa.hipert.unimore.it";
var urlBase = "http://localhost:8080";
var imgBase = "./Resources/Lights/";

/* Vehicle Paths */
var VEHICLE_GO_TO_PARK = 4;
var VEHICLE_NORMAL_ROUTE = 5;
var VEHICLE_ON_TRAFFIC = 6;


function GetHttpError(xhr){
	switch(xhr.statusCode().status) {
		case 0: return "Disconnected from server. Check your internet connection";
		case 401: return "Unauthorized";
		case 403: return "Forbidden";
		case 404: return "Not found";
		case 500: return "Internal server error";
	}
}

function HttpCall(url, verb, dataObj, success, error) {
	//debugger;
	
    $.support.cors = true;
    $.ajax({
        url: url,
        type: verb,
        contentType: "application/json",
		data: JSON.stringify(dataObj),
		success: function (response) {
			success(response);
		},
		error: function (xhr, ajaxOptions, thrownError) {
			if(xhr.statusCode().status != 0)
				alert("Il server ha risposto: errore " + xhr.statusCode().status + " - " + GetHttpError(xhr));
        }
        
    });
}

function VehicleCtrl(key, name, path) {
	var obj = new Object();
	obj.key = key;
	obj.name = name;
	obj.path = path;
	HttpCall(urlBase + "/api/vehicle/" + name + "/ctrl", 'POST', obj, function (res) {

	});
}
