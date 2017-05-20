(function () {
    'use strict'
    var brandApp = angular.module('brandApp', ['ui.bootstrap']);
    brandApp.controller('brandController', ['$scope', '$uibModal', 'brandService', function ($scope, $uibModal, brandService) {
        $scope.filterdData = [];
        $scope.brandList = [];
        $scope.loadData = function () {
            brandService.getBrand().then(
                function (res) {
                    $scope.brandList = res.data;
                });
        };
        $scope.openAddPanel = function () {
            $uibModal.open({
                templateUrl: 'brandAddPanel',
                backdrop: 'static',
                controller: ['$scope', '$uibModalInstance', function ($scopeChild, $uibModalInstance) {
                    $scopeChild.error = { show: false, message: "" };
                    $scopeChild.brand = { active: true };
                    $scopeChild.saveBrand = function () {
                        brandService.saveBrand($scopeChild.brand.name, $scopeChild.brand.active).then(function (res) {
                            $scopeChild.error.show = !res.status;
                            if (res.status) {
                                $scopeChild.cancelModal();
                                $scope.loadData();
                            }
                            else {
                                $scopeChild.error.message = ($scopeChild.res.id < 0) ? "Duplicate Name" : "Error Saving Data";
                            }
                        });
                    };
                    $scopeChild.cancelModal = function () {
                        $uibModalInstance.close();
                    };
                }]
            });
        };
    }]);
    brandApp.factory('brandService', ['$http', function ($http) {
        var url = "";
        var saveBrand = function (name, active) {
            url = "/Api/SaveBrand";
            var data = { name: name, active: active };
            return $http.post(url, data).then(function (result) {
                return result.data;
            });
        };
        var getBrand = function () {
            url = "/Api/GetBrandData";
            return $http.get(url).then(function (result) {
                return result.data;
            });
        };
        return {
            saveBrand: saveBrand,
            getBrand: getBrand
        };
    }]);
})();