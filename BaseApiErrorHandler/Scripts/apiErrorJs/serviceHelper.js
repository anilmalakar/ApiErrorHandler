(function(app) {
    'use strict';
    app.factory('serviceHelper', serviceHelper);
    serviceHelper.$inject = ["$http"];

    function serviceHelper($http) {
        var service = {
            get: httpGet,
            post: httpPost
        };

        function httpGet(url, data, success, failure) {
            return $http.get(url, data)
                .then(function(result) {
                        success(result);
                    },
                    function(error) {
                        if (error.status != 200) {
                            failure(error);
                        }
                    }
                );
        }

        function httpPost(url, data, success, failure) {
                $http.post(url, data)
                    .then(function(result) {
                        success(result);
                    }, function error() {
                        if (error.status != 200) {
                            failure(error);
                        }
                    });
            };
        
        
        return service;
    }
})(angular.module('errorApp'));
