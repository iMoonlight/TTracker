var api = "http://localhost:5000/api/";

function apiGetCountriesData() {
    $.getJSON(api + "countries/all", function (data) {
        var countries = JSON.parse(JSON.stringify(data));

        viewModel.countries.Set(countries);
    })
}

function apiGetTouristsData() {
    $.getJSON(api + "tourists/all", function (data) {
        var tourists = JSON.parse(JSON.stringify(data));

        viewModel.tourists.Set(tourists);
    })
}

function apiGetYearsRange() {
    $.getJSON(api + "visits/yearsrange", function (data) {
        var yearsRange = JSON.parse(JSON.stringify(data));

        viewModel.visitYearsRange(yearsRange);
    })
}

function apiGetVisits(touristid, countryid, year) {
    var request = api + "visits/by/tourist/" + touristid + "/country/" + countryid + "/year/" + year;

    $.getJSON(request, function (data) {
        var visits = JSON.parse(JSON.stringify(data)).sort(dynamicSort("touristName"));

        viewModel.visits.Set(visits);
    })
}