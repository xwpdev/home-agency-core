(function () {
    'use strict'
    var productApp = angular.module('productApp', ['ui.bootstrap']);

    productApp.controller('productController', ["$scope", "$uibModal", "$q", "productService", function ($scope, $uibModal, $q, productService) {
        $scope.productList = [];
        $scope.loadData = function () {
            //$scope.productList.push({ id: 1, brand: "Delmage", category: "Supiri Soya", name: "Chicken-Buddy-50g", reference: "21113217102", packs: false, items_per_pack: "25", quantity: "25", unit_price: "100.00", active: false });
            //$scope.productList.push({ id: 2, brand: "Motha", category: "Desert", name: "Watalappan-110g", reference: "21113288110", packs: false, items_per_pack: "50", quantity: "100", unit_price: "40.00", active: false });
            productService.getProduct().then(function (res) {
                $scope.productList = res.data;
            });
        }
        $scope.openAddPanel = function () {
            $uibModal.open({
                templateUrl: 'productAddPanel',
                backdrop: "static",
                controller: ['$scope', '$uibModalInstance', function ($scopeChild, $uibModalInstance) {
                    $scopeChild.error = { show: false, message: "" };
                    $scopeChild.product = { packs: false, active: true, brandId: 0, categoryId: 0 };
                    productService.getBrand().then(function (res) { $scopeChild.brandList = res.data });
                    productService.getCategory().then(function (res) { $scopeChild.categoryList = res.data });

                    $scopeChild.saveProduct = function () {
                        productService.saveProduct($scopeChild.product).then(function (res) {
                            $scopeChild.error.show = !res.status;
                            if (res.status) {
                                $scopeChild.cancelModal();
                                $scope.loadData();
                            }
                            else {
                                $scopeChild.error.message = ($scopeChild.res.id < 0) ? "Duplicate Name" : "Error Saving Data";
                            }
                        });
                    }
                    $scopeChild.cancelModal = function () {
                        $uibModalInstance.close();
                    }
                }]
            });
        }
    }]);
    productApp.factory('productService', ['$http', function ($http) {
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

        var getBrand = function () {
            url = "/Api/GetBrandData";
            return getResponse(url);
        };

        var getCategory = function () {
            url = "/Api/GetCategoryData";
            return getResponse(url);
        };

        var getProduct = function () {
            url = "/Api/GetProductData";
            return getResponse(url);
        };

        var saveProduct = function (product) {
            url = "/Api/SaveProduct";
            return postResponse(url, product);
        };
        return {
            getBrand: getBrand,
            getCategory: getCategory,
            getProduct: getProduct,
            saveProduct: saveProduct
        };
    }]);
})();