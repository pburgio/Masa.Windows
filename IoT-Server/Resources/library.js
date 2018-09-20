var urlBase = "http://backend-dev5.iotty.com";
//var urlBase = "http://192.168.10.236";
var imgBase = "./Resources/Lights/";


function GetHttpError(xhr){
	switch(xhr.statusCode().status) {
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
            //alert("Il server ha risposto: errore " + xhr.statusCode().status + " - " + GetHttpError(xhr));
        }
        
    });
}
