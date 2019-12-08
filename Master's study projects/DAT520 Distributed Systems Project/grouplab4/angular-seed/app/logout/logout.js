'use strict';

angular.module('myApp.logout', [])

    .controller('LogoutCtrl', ['WebSocketService','UserPersistenceService', '$scope', '$rootScope', '$window',
        function(WebSocketService, UserPersistenceService, $scope, $rootScope, $window) {

        $scope.Logout = function () {
           UserPersistenceService.clearCookieData('login_account');
           UserPersistenceService.clearCookieData('is_login');
           UserPersistenceService.clearCookieData('login_user_name');
           UserPersistenceService.clearCookieData('transaction_history');
           $rootScope.is_login = false;
           //WebSocketService.CloseSocket();
           $window.location.href = '#!/home';
        }
    }]);