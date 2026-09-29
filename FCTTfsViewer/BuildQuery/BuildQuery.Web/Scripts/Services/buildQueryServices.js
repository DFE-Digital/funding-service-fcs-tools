(function () {
    'use strict';

    var buildQueryServices = angular.module('buildQueryServices', []);
    buildQueryServices.factory('BuildQuery', buildQuery);

    buildQuery.$inject = ['$http'];

    function buildQuery($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData(callback) {
            return $http.get('/api/TfsApi').then(function (result) {
                callback(result.data);
            });
            
        }
    }
})();