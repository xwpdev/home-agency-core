(function () {
    'use strict'
    var categoryApp = angular.module('categoryApp', ['ui.bootstrap']);

    categoryApp.controller('categoryController', ["$scope", "$uibModal", "categoryService", function ($scope, $uibModal, categoryService) {
        $scope.filterdData = [];
        $scope.categoryList = [];
        $scope.loadData = function () {
            categoryService.getCategory().then(
               function (res) {
                   $scope.categoryList = res.data;
               });
        };
        $scope.openAddPanel = function () {
            $uibModal.open({
                templateUrl: 'categoryAddPanel',
                backdrop: 'static',
                controller: ['$scope', '$uibModalInstance', function ($scopeChild, $uibModalInstance) {
                    $scopeChild.error = { show: false, message: "" };
                    $scopeChild.category = { active: true };
                    $scopeChild.saveCategory = function () {
                        categoryService.saveCategory($scopeChild.category.name, $scopeChild.category.active).then(function (res) {
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
    categoryApp.factory('categoryService', ['$http', function ($http) {
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