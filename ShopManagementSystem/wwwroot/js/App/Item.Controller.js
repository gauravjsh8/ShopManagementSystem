/// <reference path="../knockout.js" />

function itemController() {
    var self = this;

    var baseUrl = "/api/Item"
    self.mode = ko.observable(mode.create);
    self.newItem = ko.observable(new ItemModel());
    self.allItems = ko.observableArray();
    self.SelectedItem = ko.observable(new ItemModel());

    //Get Method called
   
    ajax.get(baseUrl).then((result) => {
        featcheddata = result.data;
        var result = ko.utils.arrayMap(featcheddata, function (item) {
            return new ItemModel(item);
        });
        self.allItems(result);
        console.log(ko.toJS(result));
    });

    self.AddItem = function () {

        switch (self.mode()) {
            case 1:
                ajax.post(baseUrl, ko.toJSON(self.newItem()))
                    .done((result) => {
                        alert();
                        self.allItems.push(new ItemModel(result));
                    });
                break;
            case 2:
                alert();
                ajax.put(baseUrl + "/" + self.newItem().id(), ko.toJSON(self.newItem())).done((result) => {
                    self.allItems.replace(self.SelectedItem(), self.newItem());
                })
                break;
    }
        console.log(ko.toJSON(self.newItem()));
    }
    //self.UpdateItem = function () {
    //    alert();
    //    ajax.put(baseUrl + "/" + self.newItem().id(), ko.toJSON(self.newStudent())).done((result) => {
    //        self.allItems.replace(self.SelectedItem(), self.newItem());
    //    })
    //}
    self.DeleteItem = function (model) {
        ajax.delete(baseUrl + "/" + ko.toJS(model).id)
            .done((result) => {
                self.allItems.remove(model);
            });
    }
    self.selectItem = (model) => {
        self.SelectedItem(model);
        self.newItem(new ItemModel(ko.toJS(model)));
        console.log(self.SelectedItem());
        self.mode(mode.update);
    };
   
}

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
            data:data
        });
    },
    delete: function (url) {
        //api/apiController/id
        return $.ajax({
            method: "DELETE",
            url: url

        });

    }
}

const mode = {
    create: 1,
    update: 2
};