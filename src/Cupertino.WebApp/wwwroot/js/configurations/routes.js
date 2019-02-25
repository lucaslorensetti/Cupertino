angular.module('cupertino', ['ngRoute']).config(function ($routeProvider, $locationProvider) {

    //$locationProvider.html5Mode(true);
    //$locationProvider.hashPrefix('');

    $routeProvider
        .when('/', {
            templateUrl: 'views/dashboard/dashboard.html',
            controller: 'dashboardController'
        })
        .when('/notfound', {
            templateUrl: 'views/errors/notfound/notfound.html',
            controller: 'notfoundController'
        })
        .when('/login', {
            templateUrl: 'views/login/login.html',
            controller: 'loginController'
        })
        .otherwise('/notfound');
});