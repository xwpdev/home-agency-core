(function () {
    'use strict'
    var invoiceApp = angular.module('invoiceApp', []);

    invoiceApp.controller('invoiceController', ["$scope", "invoiceService", function ($scope, invoiceService) {


    }]);

    invoiceApp.factory('invoiceService', ['$http', function ($http) {
        var url = "";

        var getResponse = function (url) {
            return $http.get(url).then(function (result) {
                return result.data;
            });
        }
        var postResponse = function (url, data) {
            return $http.post(url, data).then(function (result) {
                return result.data;
            });
        }

        //var getProduct = function () {
        //    url = "/Api/GetProductData";
        //    return getResponse(url);
        //};

        //var saveProduct = function (product) {
        //    url = "/Api/SaveProduct";
        //    return postResponse(url, product);
        //};

        return {
            //getProduct: getProduct,
            //saveProduct: saveProduct
        };
    }]);
})();