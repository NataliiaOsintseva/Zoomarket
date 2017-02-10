var OwnerApp = angular.module('OwnerApp', ['ngRoute', 'OwnerControllers']);
OwnerApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: 'Owner/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'Owner/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'Owner/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'Owner/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);