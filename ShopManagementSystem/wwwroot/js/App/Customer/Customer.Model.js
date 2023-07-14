/// <reference path="../../knockout3.5.1.js" />

function CustomerModel(item) {
    var self = this;
    item = item || {};
    self.id = ko.observable(item.id || 0);
    self.name = ko.observable(item.name || '');
    self.contactNo = ko.observable(item.contactNo || '');
    self.address = ko.observable(item.address || '');

}