angular.module("cupertino")
    .controller("productAddEditController", ["$scope", "productService", "$uibModalInstance", "productId",
        function ($scope, productService, $uibModalInstance, productId) {

            $scope.product = {};

            $scope.save = () => {
                productService.save($scope.product)
                    .then(() => {
                        $uibModalInstance.close();
                    });
            }

            $scope.cancel = () => {
                $uibModalInstance.close();
            }

            if (productId) {
                productService.get(productId)
                    .then((product) => {
                        $scope.product = product;
                    });
            }
        }]);