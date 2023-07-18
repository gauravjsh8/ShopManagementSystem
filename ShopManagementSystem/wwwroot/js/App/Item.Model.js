/// <reference path="../knockout.js" />

function ItemModel(itemModel) {
    var self = this;
    itemModel = itemModel || {};
    self.id = ko.observable(itemModel.id || 0);
    self.name = ko.observable(itemModel.name || "");
    self.price = ko.observable(itemModel.price || 0.00);
    self.discount = ko.observable(itemModel.discount || 0);
    self.stock = ko.observable(itemModel.stock || 0);

}

function ItemViewModel(itemModel) {
    var self = this;
    itemModel = itemModel || {};
    self.id = ko.observable(itemModel.id || 0);
    self.name = ko.observable(itemModel.name || "");
    self.price = ko.observable(itemModel.price || 0.00);
    self.discount = ko.observable(itemModel.discount || 0);
    self.quantity = ko.observable(itemModel.quantity || 0);

    self.total = ko.computed(function () {
        var totalPrice = (self.price() - self.discount()) * self.quantity();

        return totalPrice.toFixed(2); // Round to 2 decimal places if needed
    });
}

