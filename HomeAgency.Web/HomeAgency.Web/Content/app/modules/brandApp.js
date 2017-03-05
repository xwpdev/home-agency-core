var brandApp = angular.module('brandApp', ['ui.bootstrap']);

brandApp.controller('brandController', function ($scope, $uibModal) {
    $scope.brandList = [];
    $scope.loadData = function () {
        $scope.brandList.push({ id: 1, name: "Delmage", active: false });
        $scope.brandList.push({ id: 2, name: "Motha", active: false });
    }
    $scope.openAddPanel = function () {
        $uibModal.open({
            templateUrl: 'brandAddPanel',
            backdrop: "static",
            controller: ['$scope', '$uibModalInstance', function ($scopeChild, $uibModalInstance) {
                $scopeChild.brand = { active: true };
                $scopeChild.saveBrand = function () {
                    console.log($scopeChild.brand);
                }
                $scopeChild.cancelModal = function () {
                    $uibModalInstance.close()
                }
            }]
        });
    }
});