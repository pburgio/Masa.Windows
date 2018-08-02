function GetLogs(success) {
	//debugger;
	var dataObj = "{ }";
    console.log("Hello");
	var url = "https://backend-dev5.iotty.com/api/pages/getlogs";
    $.support.cors = true;
    $.ajax({
        url: url,
        type: 'POST',
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


function myFunction() {
	//alert('Hello');
	GetLogs(function (res)
	{
		//debugger;
		$("#logpanel").empty();
		for (var i = 0; i < res.Rows.length; i++) {
   
			$("#logpanel").append(res.Rows[i] + "<br />");
		}
		
	});
}
		
$( document ).ready(function() {
	// alert("init");
	setInterval(myFunction, 3000);
	//myFunction();
})