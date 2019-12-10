'use strict';

angular.module('myApp.personal', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/personal', {
            templateUrl: 'personal/personal.html',
            controller: 'PersonalCtrl'
        });
    }])

    .controller('PersonalCtrl', ['WebSocketService','UserPersistenceService','$scope', '$rootScope', '$window',
        function (WebSocketService, UserPersistenceService, $scope, $rootScope, $window) {

            function InitController() {
                $scope.show_success_alert = false;
                $scope.show_error_alert = false;

                var account_cookie = UserPersistenceService.getCookieData('login_account');
                if (account_cookie === undefined){
                    $window.location.href = "#!/signup"
                }
                $scope.account = JSON.parse(account_cookie);
                console.log("account ", $scope.account);

                var history_cookie = UserPersistenceService.getCookieData('transaction_history');

                if (history_cookie== undefined){
                    $scope.transaction_history = {};
                }else{
                    $scope.transaction_history = JSON.parse(history_cookie);
                }

                var is_login = UserPersistenceService.getCookieData('is_login');
                if(is_login === undefined) {
                    $window.location.href = "#!/signup";
                }

                $rootScope.is_login = is_login;

                $rootScope.login_user_name = UserPersistenceService.getCookieData('login_user_name');


                $scope.deposit = {};
            }

            function Formatter(data, type) {
                var fd = {
                        account_num: $scope.account.account_num
                };
                if(type == "balance"){
                    fd.txn = {
                        op: 0
                    }
                }else if(type == "deposit"){
                    fd.txn = {
                        op: 1,
                        amount: data.amount
                    }
                } else if (type == "withdraw") {
                        fd.txn = {
                            op: 2,
                            amount: data.amount
                        }
                } else if (type == "transfer") {
                    fd.txn = {
                        op: 3,
                        amount: data.amount,
                        to_account_num: data.to_account_num
                    }
                }
                return fd;
            }

            $scope.DepositSubmit = function (data) {
                console.log("Deposit Submitted", data);
                var formatted_data = Formatter(data, "deposit");
                var promise = WebSocketService.Transaction(formatted_data);

                promise.then(function (response) {
                    console.log("data at controller", response);
                    if (response.type != "Error") {
                        $scope.account.balance = response.data.balance;
                        // update cookies
                        var expireDate = new Date();
                        expireDate.setDate(expireDate.getDate() + 1);

                        var cookie_data = JSON.stringify($scope.account);
                        UserPersistenceService.setCookieData('login_account', cookie_data, expireDate);

                        $scope.transaction_history.push(response);
                        var history_data = JSON.stringify($scope.transaction_history);
                        UserPersistenceService.setCookieData('transaction_history', history_data, expireDate);

                        $scope.deposit = {};
                        $scope.show_success_alert = true;
                        $scope.show_error_alert = false;
                        $scope.success_message = "Deposit Successful.";
                        var elm = angular.element('#balance_tab');
                        //elm.tab('show');
                        elm.click();
                    }else {
                        $scope.show_success_alert = false;
                        $scope.show_error_alert = true;
                        $scope.error_message = response.data.error_string;
                    }

                }, function (err) {
                    console.log("error occurs: ", err);
                    $scope.show_success_alert = false;
                    $scope.show_error_alert = true;
                    $scope.error_message = err;
                });
            };

            $scope.WithdrawSubmit = function (data) {
                var formatted_data = Formatter(data, "withdraw");
                var promise = WebSocketService.Transaction(formatted_data);

                promise.then(function (response) {
                    console.log("data at controller", response);
                    if(response.type != "Error"){
                        $scope.account.balance = response.data.balance;
                        // update cookies
                        var expireDate = new Date();
                        expireDate.setDate(expireDate.getDate() + 1);

                        var cookie_data = JSON.stringify($scope.account);
                        UserPersistenceService.setCookieData('login_account', cookie_data, expireDate);

                        $scope.transaction_history.push(response);
                        var history_data = JSON.stringify($scope.transaction_history);
                        UserPersistenceService.setCookieData('transaction_history', history_data, expireDate)

                        $scope.withdraw = {};
                        $scope.show_success_alert = true;
                        $scope.show_error_alert = false;
                        $scope.success_message = "Withdrawal Successful.";
                        var elm = angular.element('#balance_tab');
                        //elm.tab('show');
                        elm.click();
                    }else{
                        $scope.show_success_alert = false;
                        $scope.show_error_alert = true;
                        $scope.error_message = response.data.error_string;
                    }
                }, function (err) {
                    console.log("error occurs: ", err);
                    $scope.show_success_alert = false;
                    $scope.show_error_alert = true;
                    $scope.error_message = err;
                });
            };

            $scope.TransferSubmit = function (data) {
                console.log("transfer, ",data);
                var formatted_data = Formatter(data, "transfer");
                var promise = WebSocketService.Transaction(formatted_data);

                promise.then(function (response) {
                    console.log("data at controller", response);
                    if(response.type != "Error"){
                        $scope.account.balance = response.data.balance;
                        // update cookies
                        var expireDate = new Date();
                        expireDate.setDate(expireDate.getDate() + 1);
                        var cookie_data = JSON.stringify($scope.account);
                        UserPersistenceService.setCookieData('login_account', cookie_data, expireDate);

                        $scope.transaction_history.push(response);
                        var history_data = JSON.stringify($scope.transaction_history);
                        UserPersistenceService.setCookieData('transaction_history', history_data, expireDate)

                        $scope.transfer = {};
                        $scope.show_success_alert = true;
                        $scope.shpw_error_alert = false;
                        $scope.success_message = "Transfer successful.";
                        var elm = angular.element('#balance_tab');
                        //elm.tab('show');
                        elm.click();
                    }else{
                        $scope.show_success_alert = false;
                        $scope.show_error_alert = true;
                        $scope.error_message = response.data.error_string;
                    }

                }, function (err) {
                    console.log("error occurs: ", err);
                    $scope.show_success_alert = false;
                    $scope.show_error_alert = true;
                    $scope.error_message = err;
                });
            };
            $scope.Balance = function () {
                var formatted_data = Formatter($scope.account.account_num, "balance");
                var promise = WebSocketService.Transaction(formatted_data);

                promise.then(function (response) {
                    console.log("data at controller", response);
                    $scope.account.balance = response.data.balance;
                    // update cookies
                    var expireDate = new Date();
                    expireDate.setDate(expireDate.getDate() + 1);
                    var cookie_data = JSON.stringify($scope.account);
                    UserPersistenceService.setCookieData('login_account', cookie_data, expireDate);
                }, function (err) {
                    console.log("error occurs: ", err);
                });
            };

            // init controller
            InitController();
        }]);