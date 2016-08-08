(function (app) {
    app.controller("errorController", errorController);
    
        errorController.$inject = ['$scope', 'serviceHelper'];

    function errorController($scope, serviceHelper) {
        $scope.errors = [];
        $scope.getErrors = getErrors;
        $scope.name = "Anil";
        $scope.person = {
            firstName: 'Anil',
            lastName: 'malakar'
        };

        function getErrors() {
            serviceHelper.get('/api/Errors/', null, getSuccess, getFailure);
        }

        function getSuccess(result) {
            $scope.errors = result.data;
        }

        function getFailure(result) {
            alert("Error" +  result.data);
        }

        $scope.getErrors();
    }
    
    }
)(angular.module('errorApp'));