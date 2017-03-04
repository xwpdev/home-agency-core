var categoryApp = angular.module('categoryApp', ['ui.bootstrap']);

categoryApp.controller('categoryController', function ($scope, $uibModal) {
    $scope.categoryList = [];
    $scope.loadData = function () {
        $scope.categoryList.push({ id: 1, name: "Noodles", active: false });
        $scope.categoryList.push({ id: 2, name: "Supiri Soya", active: false });
    }
    $scope.openAddPanel = function () {
        $uibModal.open({
            templateUrl: 'categoryAddPanel',
            backdrop: "static",
            controller: ['$scope', '$uibModalInstance', function ($scopeChild, $uibModalInstance) {
                $scopeChild.category = { active: true };
                $scopeChild.saveCategory = function () {
                    console.log($scopeChild.category);
                }
                $scopeChild.cancelModal = function () {
                    $uibModalInstance.close()
                }
            }]
        });
    }
});