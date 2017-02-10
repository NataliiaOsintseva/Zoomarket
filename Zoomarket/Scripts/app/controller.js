var OwnerControllers = angular.module("OwnerControllers", []);
// this controller call the api method and display the list of owners  
// in list.html  
OwnerControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/owner').success(function (data) {
            $scope.owner = data;
        });
    }
]);

// this controller call the api method and display the record of selected owner  
// in delete.html and provide an option for delete  
OwnerControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/owner/' + $routeParams.id).success(function (data) {
            $scope.name = data.Name;
            $scope.petsQuantity = data.PetsQuantity;
        });
        $scope.delete = function () {
            $http.delete('/api/Owner/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "An error has occured while deleting pet owner! " + data;
            });
        };
    }
]);

// this controller call the api method and display the record of selected owner  
// in edit.html and provide an option for create and modify the owner and save the owner record  
OwnerControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/pet').success(function (data) {
            $scope.pets = data;
        });
        $scope.id = 0;
        $scope.getPets = function () {
            var pet = $scope.pet;
            if (pet) {
                $http.get('/api/pet/' + pet).success(function (data) {
                    $scope.pets = data;
                });
            }
            else {
                $scope.pets = null;
            }
        }
        $scope.save = function () {
            var obj = {
                OwnerId: $scope.id,
                Name: $scope.name,
                PetsQuantity: $scope.pets
            };
            if ($scope.id == 0) {
                $http.post('/api/Owner/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "An error has occured while adding pet owner! " + data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/Owner/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while saving pet owner! " + data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Owner";
            $http.get('/api/owner/' + $routeParams.id).success(function (data) {
                $scope.name = data.Name;
                $scope.petsQuantity = data.PetsQuantity;
                $scope.getPets();
            });
        }
        else {
            $scope.title = "Create New Pet Owner";
        }
    }
]);