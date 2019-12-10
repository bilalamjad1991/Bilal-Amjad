'use strict';

angular.module('myApp.login', ['ngRoute'])

    .config(['$routeProvider', function($routeProvider) {
        $routeProvider.when('/login', {
            templateUrl: 'login/login.html',
            controller: 'LoginCtrl'
        });
    }])

    .controller('LoginCtrl', ['WebSocketService','UserPersistenceService','$scope', '$rootScope','$window',
        function(WebSocketService, UserPersistenceService, $scope, $rootScope, $window) {

        function InitController() {

        }
        $scope.LoginSubmit = function (data) {
            console.log("Login Submited", data);

            var promise = WebSocketService.Login(data);
            promise.then(function (response) {
                console.log("data at controller", response);
                if(response.type != "Error") {
                    var account = {
                        first_name:response.data.first_name,
                        last_name: response.data.last_name,
                        account_num: response.data.account_num,
                        balance: response.data.balance
                    };
                    $scope.account = account;
                    $scope.transaction_history = response.data.transaction_history;

                    var expireDate = new Date();
                    expireDate.setDate(expireDate.getDate() + 1);

                    var account_cookie = JSON.stringify($scope.account);
                    var history_cookie = JSON.stringify($scope.transaction_history);

                    UserPersistenceService.setCookieData('login_account', account_cookie, expireDate);
                    UserPersistenceService.setCookieData('transaction_history', history_cookie, expireDate);
                    UserPersistenceService.setCookieData('is_login', true, expireDate);

                    $rootScope.is_login = true;

                    $rootScope.login_user_name = $scope.account.first_name +' '+ $scope.account.last_name;
                    UserPersistenceService.setCookieData('login_user_name', $rootScope.login_user_name);

                    $window.location.href = '#!/personal';
                }else{
                    $scope.login = {}
                    $scope.show_error_alert = true;
                    $scope.error_message = response.data.error_string;
                }
            }, function (err) {
                console.log("error occurs: ", err);
            });

        }

        // Initialize controller
        InitController();
    }]);