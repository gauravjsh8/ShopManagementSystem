/// <reference path="../../knockout3.5.1.js" />

function CustomerController(prop) {
    var self = this;
   // const baseurl = "/api/CustomersApi"

 //   self.mode = ko.observable(mode.create);
    self.newCustomer = ko.observable(new CustomerModel());
    self.allCustomers = ko.observableArray();
    self.selectedCustomer = ko.observable(new CustomerModel());
    self.addCustomer = function () {
      //  alert();
        self.allCustomers.push(ko.toJS(self.newCustomer()));
    }
    //self.addCustomer = function () {
    //    switch (self.mode()) 
    //    case mode.create:
    //        self.customers.push(new Customer(ko.toJS(self.newCustomer())));
    //        self.newCustomer(new Customer());
    //    break;
    //        case mode.update:
    //            self.customers.replace(self.selectedCustomer(), new Customer(ko.toJS(self.newCustomer())));
    //            self.newCustomer(new Customer());
    //            self.mode(mode.update);
    //            break;
    //    }
    //};








    }

 















