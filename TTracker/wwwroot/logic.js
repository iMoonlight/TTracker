var apiLink = 'http://localhost:5000/api';

function loadContentCountries() {
	$(".nav-item").removeClass("active");
	$("#nav-countries").addClass("active");
	
	$('#content').load(contentDir + 'countries.html');
	getCountries();
}

function getCountries(){
	$.getJSON( apiLink+'/countries', function( data ) {
		var items = [];
		$.each( data, function( key, val ) {
			items.push( '<li onclick="countryClicked(' + val.id + ')" id="countryButton' + val.id + '">' + val.name + '</li>');
		});
 
		$("#countries-list").html(items.join( "" ))
	});
}

function countryClicked( id ){
	var button = $("#countryButton"+id);

	if (!button.hasClass("active")){
			$.getJSON( apiLink+'/countries/'+id, function( data ) {
 
		$(".country-button").removeClass("active");
		button.addClass("active");
		$("#country-description").html('<p>' + data.description + '</p>')
	});
	}
}