/// <reference path="../knockout.js" />

function itemController() {
    var self = this;

    var baseUrl = "/api/Item"
    self.newItem = ko.observable(new ItemModel());
    self.allItems = ko.observableArray();


    ajax.get(baseUrl).then((result) => {
        var data = ko.utils.arrayMap(result, function (item) {
            return new ItemModel(item);
        });
        self.allItems(data);
    })
    self.test = function () {
        self.allItems.push(ko.toJS(self.newItem()));
    }
}

var ajax = {
    get: function (url, data) {
        return $.ajax({
            method: "GET",
            url: url,

        });
    }
}