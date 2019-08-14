var myApp = angular.module('dvdApp', ['ngRoute']);

myApp.factory('dvdFactory',
    function ($http) {
        var webApi = {};
        var url = '/api/DVDs/';
        webApi.getDVDs = function () {
            return $http.get(url);
        };
        webApi.saveDvd = function (dvd) {
            return $http.post(url, dvd);
        };
        webApi.delete = function (id) {
            return $http.delete(url + id);
        };
        webApi.update = function (dvd) {
            return $http.put(url + '/' +dvd.DvdId,dvd);
        };
        return webApi;
    });

myApp.config(function ($routeProvider) {
    $routeProvider.when('/Routes',
        {
            controller: 'DVDController',
            templateUrl: '/DVDViews/DVDList.html'
        })
        .when('/AddDVD',
        {
            controller: 'AddDVDController',
            templateUrl: '/DVDViews/AddDVD.cshtml'
        })
        .otherwise({ redirectTo: '/Routes' });
});

myApp.controller('DVDController',
    function ($scope, $location, $route, dvdFactory) {
        
        function loadDvds() {
            dvdFactory.getDVDs()
            .success(function (data) {
                $scope.dvds = data;
            })
            .error(function (data, status) {
                alert('Oh no! Something went wrong!' + status);
            });
        }

        loadDvds();
        $scope.Rating = {
            RatingId: ""
        }
        $scope.dvd = {
            Rating,
            Website: "",
            DvdId: "",
            Loan: ""
        };

        $scope.update = function (data) {
            $scope.dvd.Loan = !data.Loan;
            $scope.dvd.DvdId = data.DvdId;
            $scope.dvd.Title = data.Title;
            $scope.dvd.MovieDirector = data.MovieDirector;
            $scope.dvd.Rating.RatingId = data.Rating.RatingId;
            $scope.dvd.ReleaseDate = data.ReleaseDate;
            $scope.dvd.Studio = data.Studio;
            $scope.dvd.Website = data.Website;
            dvdFactory.update($scope.dvd)
                .success(function() {
                    $route.reload();
                })
                .error(function() {
                    alert('you messed up somewhere');
                });
        };

        $scope.save = function () {
            $scope.dvd.Title = $('#Title').val();
            $scope.dvd.ReleaseDate = $('#ReleaseDate').val();
            $scope.dvd.Rating.RatingId = $('#Rating').val();
            $scope.dvd.MovieDirector = $('#MovieDirector').val();
            $scope.dvd.Studio = $('#Studio').val();
            $scope.dvd.DvdId = $('#DvdId').val();
            $scope.dvd.Website = $('#Website').val();
            dvdFactory.saveDvd($scope.dvd)
                .success(function () {
                    $('#addDvdModal').modal('hide');
                    $route.reload();
                })
                .error(function (data, status) {
                    alert('Oh no! Something went wrong!');
                });
        }
        
        $scope.delete = function () {
            var id = $(this.dvd.DvdId)[0];
            dvdFactory.delete(id)
                .success(function () {
                    $route.reload();
                })
                .error(function () {
                    alert('Something bad has happened.');
                });
        }
    });

myApp.controller('AddDVDController',
function ($scope, $location, dvdFactory) {
    $scope.dvd = {};
    $scope.editting = {};
    $scope.save = function () {
        dvdFactory.saveDvd($scope.dvd)
            .success(function () {
                $('#addDvdModal').modal('hide');
                $location.path('/Routes');
            })
            .error(function (data, status) {
                alert('Oh no! Something went wrong!');
            });
    }
});