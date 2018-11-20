const contentCountries = { template: '<div>countries</div>' }
const contentTourists = { template: '<div>tourists</div>' }
const contentVisits = { template: '<div>visits</div>' }

const routes = [
    { path: '/', component: contentCountries },
    { path: '/countries', component: contentCountries },
    { path: '/tourists', component: contentTourists },
    { path: '/visits', component: contentVisits }
]

const router = new VueRouter({
    routes
})

var vueApp = new Vue({
    router,
    el: '#vueApp',
    data: {
        countries: [],
        tourists: [],
        visits: [],
        visitYearsRange: { min: 1, max: 1 },
        selectedTourist: -1,
        selectedCountry: -1,
        selectedYear: -1
    },
    computed: {
        visitYears: function () {
            var years = [];
            for (var i = this.visitYearsRange.min; i <= this.visitYearsRange.max; i++) {
                years.push(i);
            }
            return years;
        }
    }
})