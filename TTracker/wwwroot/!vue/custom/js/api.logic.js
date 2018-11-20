var api = "http://localhost:5000/api/";

function apiGetCountriesData() {
    jQuery.getJSON(api + "countries/all", function (data) {
        var countries = JSON.parse(JSON.stringify(data));

        vueApp.countries = countries;
    })
}

function apiGetTouristsData() {
    jQuery.getJSON(api + "tourists/all", function (data) {
        var tourists = JSON.parse(JSON.stringify(data));

        vueApp.tourists.Set(tourists);
    })
}

function apiGetYearsRange() {
    jQuery.getJSON(api + "visits/yearsrange", function (data) {
        var yearsRange = JSON.parse(JSON.stringify(data));

        vueApp.visitYearsRange(yearsRange);
    })
}

function apiGetVisits(touristid, countryid, year) {
    var request = api + "visits/by/tourist/" + touristid + "/country/" + countryid + "/year/" + year;

    jQuery.getJSON(request, function (data) {
        var visits = JSON.parse(JSON.stringify(data)).sort(dynamicSort("touristName"));

        vueApp.visits.Set(visits);
    })
}