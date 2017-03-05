var productApp = angular.module('productApp', ['ui.bootstrap']);

productApp.controller('productController', function ($scope, $uibModal) {
    $scope.productList = [];
    $scope.loadData = function () {
        $scope.productList.push({ id: 1, brand: "Delmage", category: "Supiri Soya", name: "Chicken-Buddy-50g", reference: "21113217102", packs: false, items_per_pack: "25", quantity: "25", unit_price: "100.00", active: false });
        $scope.productList.push({ id: 1, brand: "Motha", category: "Desert", name: "Watalappan-110g", reference: "21113288110", packs: false, items_per_pack: "50", quantity: "100", unit_price: "40.00", active: false });
    }
    $scope.openAddPanel = function () {
        $uibModal.open({
            templateUrl: 'productAddPanel',
            backdrop: "static",
            controller: ['$scope', '$uibModalInstance', function ($scopeChild, $uibModalInstance) {
                $scopeChild.brandList = [{ id: 1, name: "Delmage", active: false }, { id: 2, name: "Motha", active: false }];
                $scopeChild.categoryList = [{ id: 1, name: "Desert", active: false }, { id: 2, name: "Supiri Soya", active: false }];

                $scopeChild.product = { packs: true, active: true };
                $scopeChild.saveProduct = function () {
                    console.log($scopeChild.product);
                }
                $scopeChild.cancelModal = function () {
                    $uibModalInstance.close()
                }
            }]
        });
    }
});