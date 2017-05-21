(function () {
    'use strict'

    var agentApp = angular.module('agentApp', ['ui.bootstrap']);

    agentApp.controller('agentController', ["$scope", "$uibModal", "agentService", function ($scope, $uibModal, categoryService) {

    }]);

    categoryApp.factory('agentService', ['$http', function ($http) {
        var url = "";
        var saveCategory = function (name, active) {
            url = "/Api/SaveCategory";
            var data = { name: name, active: active };
            return $http.post(url, data).then(function (result) {
                return result.data;
            });
        };
        var getCategory = function () {
            url = "/Api/GetCategoryData";
            return $http.get(url).then(function (result) {
                return result.data;
            });
        };
        return {
            saveCategory: saveCategory,
            getCategory: getCategory
        };
    }]);
})();