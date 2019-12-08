'use strict';

angular.module('myApp.signup', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/signup', {
            templateUrl: 'signup/signup.html',
            controller: 'SignupCtrl'
        });
    }])

    .controller('SignupCtrl', ['WebSocketService', 'UserPersistenceService', '$scope', '$rootScope', '$window',
        function (WebSocketService, UserPersistenceService, $scope, $rootScope, $window) {

            function InitController() {
                $scope.new_account = {first_name: '', last_name: '', password: '', balance: 0};
            }

            $scope.SignupSubmit = function () {
		    console.log("Request coming here...");
                var promise = WebSocketService.createAccount($scope.new_account);
                promise.then(function (response) {
                    console.log("data at controller", response);
                    if(response.type != "Error") {
                        $scope.account = response.data;

                        var expireDate = new Date();
                        expireDate.setDate(expireDate.getDate() + 1);

                        var cookie_data = JSON.stringify(response.data);

                        UserPersistenceService.setCookieData('login_account', cookie_data, expireDate);
                        UserPersistenceService.setCookieData('is_login', true, expireDate);

                        $rootScope.transaction_history = [response];
                        var txn_data = JSON.stringify($rootScope.transaction_history);
                        UserPersistenceService.setCookieData('transaction_history', txn_data, expireDate);
                        $rootScope.is_login = true;

                        $rootScope.login_user_name = $scope.account.first_name +' '+ $scope.account.last_name;
                        UserPersistenceService.setCookieData('login_user_name', $rootScope.login_user_name);

                        $window.location.href = '#!/personal';
                    }else{
                        $scope.new_account = {};
                        $scope.show_error_alert = true;
                        $scope.error_message = response.data.error_string;
                    }
                }, function (err) {
                    console.log("error occurs: ", err);
                });

            };

            // Init Controller
            InitController();

        }]);