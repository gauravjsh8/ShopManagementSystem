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