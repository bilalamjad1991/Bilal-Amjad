angular.module('myApp').factory('UserPersistenceService', ['$cookies', function($cookies) {
        return {
            setCookieData: function(cookie_name, cookie_data, expire_date) {
                $cookies.put(cookie_name, cookie_data, {'expires': expire_date});
            },
            getCookieData: function(cookie_name) {
                return $cookies.get(cookie_name);
            },
            clearCookieData: function(cookie_name) {
                $cookies.remove(cookie_name);
            }
        }
}]);
