'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
    'ngRoute',
    'ngCookies',
    'myApp.view1',
    'myApp.view2',
    'myApp.version',
    'myApp.home',
    'myApp.signup',
    'myApp.login',
    'myApp.personal',
    'myApp.logout'
]).config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix('!');

    $routeProvider.otherwise({redirectTo: '/home'});
}]);