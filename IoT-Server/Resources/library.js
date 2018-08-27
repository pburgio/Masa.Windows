var urlBase = "https://backend-dev5.iotty.com";

function HttpCall(url, verb, dataObj, success) {
	//debugger;
	
    $.support.cors = true;
    $.ajax({
        url: url,
        type: verb,
        contentType: "application/json",
		//data: JSON.stringify({ jsonRequest: dataObj }),
		success: function (response) {
			success(response);
		},
		error: function (xhr, ajaxOptions, thrownError) {
            //debugger;
			alert("ERRORE DI COMUNICAZIONE COL SERVER");
        }
        
    });
}
