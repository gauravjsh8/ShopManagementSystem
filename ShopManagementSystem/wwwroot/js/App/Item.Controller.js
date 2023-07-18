/// <reference path="../knockout.js" />

function itemController() {
    var self = this;

    var baseUrl = "/api/ItemApi"
    self.mode = ko.observable(mode.create);
    self.newItem = ko.observable(new ItemModel());
    self.allItems = ko.observableArray();
    self.SelectedItem = ko.observable(new ItemModel());
    
 
    self.newItemVm = ko.observable(new ItemViewModel());
    // for Checkout page
    self.SearchDropDown = ko.observableArray([]);
    self.SearchedString = ko.observable('');
    self.jsModel = ko.observable(new ItemViewModel());


    //Array for item added  for checkout
    self.CheckoutItemArray = ko.observableArray();

    //Get Method called
   
    ajax.get(baseUrl).then((result) => {
        fetcheddata = result.data;
        var result = ko.utils.arrayMap(fetcheddata, function (item) {
            return new ItemModel(item);
        });
        self.allItems(result);
    });

   //Add and Update
    self.AddItem = function () {

        switch (self.mode()) {
            case 1:
                ajax.post(baseUrl, ko.toJSON(self.newItem()))
                    .done((result) => {
                        self.allItems.push(ko.toJS(new ItemModel(result.data)));
                    });
                break;
            case 2:
                alert();
                ajax.put(baseUrl, ko.toJSON(self.newItem())).done((result) => {
                    self.allItems.replace(self.SelectedItem(), self.newItem());
                })
                break;
        }
    }
    self.Testing = function (model) {
      
        self.jsModel =ko.toJS(model)
        self.newItemVm().id(self.jsModel.id);
        self.newItemVm().name(self.jsModel.name);
        self.newItemVm().price(self.jsModel.price);
        self.newItemVm().discount(self.jsModel.discount);
        self.SearchedString('');
        self.SearchDropDown([]);
    }

    //Delete function

self.DeleteItem = function (model) {
        alert();
        ajax.delete(baseUrl + "/" + ko.toJS(model).id)
            .done((result) => {
                self.allItems.remove(model);
            });
    }

    //Select  For Update
    self.selectItem = (model) => {
        self.SelectedItem(model);
        self.newItem(new ItemModel(ko.toJS(model)));
        self.mode(mode.update);
    };

    //For search
    self.searchQuery = ko.observable('');

    self.performSearch = function () {
        if (self.SearchedString() === "") {
            self.SearchDropDown([]);
        } else {
        ajax.get(baseUrl + '/Search?search=' + self.SearchedString()).then((res) => {
            fetcheddata = res.data;
            var result = ko.utils.arrayMap(fetcheddata, function (item) {
                return new ItemModel(item);
            });
            self.SearchDropDown(result)
        })
    }
    }

    self.ItemAddToCheckOut = function () {
     
        self.CheckoutItemArray.push(ko.toJS(self.newItemVm()))
        console.log(self.CheckoutItemArray());
        self.calculateGrandTotal();
    }
    self.grandTotal = ko.observable(0);
    self.calculateGrandTotal = function () {
        var grandTotal = 0;
        ko.utils.arrayForEach(self.CheckoutItemArray(), function (item) {
            grandTotal += Number(item.total);
        });
        self.grandTotal(grandTotal);
    };
}
    


//Ajax variable
var ajax = {
    get: function (url) {
        return $.ajax({
            method: "GET",
            url: url,

        });
    },

    post: function (url, data) {
        return $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            url: url,
            data: data
        });
    },

    put: function (url, data) {
        return $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "PUT",
            url: url,
            data: data
        });
    },
    delete: function (url) {
        //api/apiController/id
        return $.ajax({
            method: "DELETE",
            url: url
        });

    },


    //getByName: function (url) {
    //    return $.ajax({
    //        method: "GET",
    //        url: url

    //    });
    //}
}
const mode = {
    create: 1,
    update: 2
};