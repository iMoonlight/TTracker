ko.observableArray.fn.pushAll = function (valuesToPush) {
    this.valueWillMutate();
    ko.utils.arrayPushAll(this, valuesToPush);
    this.valueHasMutated();
    return this;
};

ko.observableArray.fn.Set = function (valuesToSet) {
    this.valueWillMutate();
    this.removeAll();
    ko.utils.arrayPushAll(this, valuesToSet);
    this.valueHasMutated();
    return this;
};

var viewModel = {
    countries: ko.observableArray([]),
    tourists: ko.observableArray([]),
    visits: ko.observableArray([]),
    visitYearsRange: ko.observable({ min: 1, max: 1 }),
    visitYears: ko.pureComputed(function () {
        var years = [];
        for (var i = viewModel.visitYearsRange().min; i <= viewModel.visitYearsRange().max; i++) {
            years.push(i);
        }
        return years;
    }, this),
    selectedTourist: -1,
    selectedCountry: -1,
    selectedYear: -1
};

ko.applyBindings(viewModel);