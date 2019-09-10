angular.module("cupertino")
    .controller("productListController", ["$scope", "productService", "$uibModal",
        function ($scope, productService, $uibModal) {

            $scope.search = (productName) => {
                productService.search(productName)
                    .then(products => {
                        $scope.products = products;
                    });
            }

            $scope.add = () => {
                openModal();
            }

            $scope.edit = (productId) => {
                openModal(productId);
            }

            $scope.delete = (productId) => {
                productService.delete(productId)
                    .then(() => {
                        $scope.search();
                    });
            }

            function openModal(productId) {
                let templateUrl = productService.endpoint('AddEdit');
                let modal = $uibModal.open({
                    templateUrl: templateUrl,
                    size: 'lg',
                    controller: 'productAddEditController',
                    resolve: {
                        productId: () => productId
                    }
                });
                modal.result.then(() => $scope.search());
            }

            $scope.search();

        }]);