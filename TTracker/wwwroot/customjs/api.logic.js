var api = "http://localhost:5000/api/";

function getCountriesData() {
    $.getJSON(api + "countries", function (data) { 
        viewModel.countries.removeAll();       
        data.forEach(function(country) {
            viewModel.countries.push(country);
        });
    })
}

function getTouristsData() {
    $.getJSON(api + "tourists", function (data) {
        viewModel.tourists.removeAll();
        data.forEach(function(tourist) {
            viewModel.tourists.push(tourist);
        });
    })
}

getCountriesData();
getTouristsData();