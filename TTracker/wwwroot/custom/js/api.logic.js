var api = "http://localhost:5000/api/";

function getCountriesData() {
    $.getJSON(api + "countries", function (data) {
        var parsed = JSON.parse(JSON.stringify(data));

        viewModel.countries.removeAll();
        parsed.forEach(function (country) {
            viewModel.countries.push(country);
        });
    })
}

function getTouristsData() {
    $.getJSON(api + "tourists", function (data) {
        var parsed = JSON.parse(JSON.stringify(data));

        viewModel.tourists.removeAll();
        parsed.forEach(function (tourist) {
            viewModel.tourists.push(tourist);
        });
    })
}

getCountriesData();
getTouristsData();