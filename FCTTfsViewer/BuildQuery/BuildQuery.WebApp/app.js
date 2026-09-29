(function () {
    'use strict';

    angular.module('buildQueryapp', [
        // Angular modules 
        'angularChart',

        // Custom modules 
        'buildQueryServices'

        // 3rd Party Modules
        
    ]);
})();
(function () {
    'use strict';

    angular
        .module('buildQueryapp')
         .controller('buildQueryController', buildQueryController);

    buildQueryController.$inject = ['$scope', '$interval', 'BuildQuery' ];

    function buildQueryController($scope, $interval, BuildQuery) {
        $scope.title = 'buildQueryController';
        var getLatestData = function ($scope, BuildQuery) {
            BuildQuery.getData(function (data) {
                $scope.Model = data;

                angular.forEach(data.InProgressTasks, function (task, taskKey) {

                    var dayToday = new Date().getDay();
                    switch (dayToday) {
                        case 6: //Saturday so compare midnight Friday/Saturday with task
                            task.IsLingering = new Date(now.getFullYear(),now.getMonth(),now.getDate(),0, 0, 0) - new Date(task.FirstInProgressDate).getTime() > (24 * 60 * 60 * 1000);
                            break;
                        case 0: //Sunday so compare midnight Friday/Saturday with task
                            task.IsLingering = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0) - (1 * 24 * 60 * 60 * 1000) - new Date(task.FirstInProgressDate).getTime() > (24 * 60 * 60 * 1000);
                            break;
                        case 1: //Monday so take 2 days off to compare with friday
                            task.IsLingering = Date.now() - (2 * 24 * 60 * 60 * 1000) - new Date(task.FirstInProgressDate).getTime() > (24 * 60 * 60 * 1000);
                            break;
                        default:  //weekday so compare with yesterday
                            task.IsLingering = Date.now() - new Date(task.FirstInProgressDate).getTime() > (24 * 60 * 60 * 1000);
                            break;
                    };
                    task.StoryNameTruncated = task.StoryName.substring(0, 25) + "...";
                    task.NameTruncated = task.Name.substring(0, 50) + "...";
                });
                //set up data for test charts
                angular.forEach(data.KeyBuildList, function (keyBuild, keyBuildkey) {
                    angular.forEach(keyBuild.TestRunList, function (testRun, testRunKeykey) {

                        testRun.DonutChartOption =
                            {
                                chart: {
                                    size: {
                                        height: 120,
                                        width: 120
                                    },
                                    data: {
                                        columns: [
                                                    ['Inconclusive', testRun.TotalTestsInconclusive],
                                                    ['InProgress', testRun.TotalTestsInProgress],
                                                    ['Passed', testRun.TotalTestsPassed],
                                                    ['Failed', testRun.TotalTestsFailed],
                                                    ['Pending', testRun.TotalTestsPending],
                                        ],
                                        type: 'donut'
                                    },
                                    donut: {
                                        label: {
                                            format: function (value, ratio, id) {
                                                return value;
                                            }
                                        }
                                    },
                                    legend: {
                                        hide: true
                                        //or hide: 'data1'
                                        //or hide: ['data1', 'data2']
                                    }
                                }
                            };
                    });
                });

                //set up data for In progress test charts
                angular.forEach(data.RunningKeyBuildList, function (keyBuild, keyBuildkey) {
                    angular.forEach(keyBuild.TestRunList, function (testRun, testRunKeykey) {

                        testRun.DonutChartOption =
                            {
                                chart: {
                                    size: {
                                        height: 120,
                                        width: 120
                                    },
                                    data: {
                                        columns: [
                                                    ['Inconclusive', testRun.TotalTestsInconclusive],
                                                    ['InProgress', testRun.TotalTestsInProgress],
                                                    ['Passed', testRun.TotalTestsPassed],
                                                    ['Failed', testRun.TotalTestsFailed],
                                                    ['Pending', testRun.TotalTestsPending],
                                        ],
                                        type: 'donut'
                                    },
                                    donut: {
                                        label: {
                                            format: function (value, ratio, id) {
                                                return value;
                                            }
                                        }
                                    },
                                    legend: {
                                        hide: true
                                        //or hide: 'data1'
                                        //or hide: ['data1', 'data2']
                                    }
                                }
                            };
                    });
                });

                //set up data for burndowns charts
                $scope.OptionsList = [data.TeamBurnDowns.length];
                angular.forEach(data.TeamBurnDowns, function (value, key) {
                    $scope.OptionsList[key] =
                        {
                            name: data.TeamBurnDowns[key].Team + ': ' + data.TeamBurnDowns[key].Iteration,
                            data: data.TeamBurnDowns[key].DataPoints,
                            chart: {
                                size: {
                                    height: 320,
                                    width: 523
                                },
                                axis:
                                        {
                                            y: { min: 0 },
                                            y2: { min: 0 }
                                        },
                                line: {
                                    connectNull: true
                                }

                            },
                            dimensions: {
                                Index: {
                                    type: 'line',
                                    axis: 'x'
                                },
                                RemainingWorkHours: {
                                    axis: 'y'
                                },
                                RemainingWorkPoints: {
                                    axis: 'y2'
                                },
                                IdealTrendHours: {
                                    axis: 'y'
                                },
                                IdealTrendPoints: {
                                    axis: 'y2'
                                }
                            }
                        };
                });
            });
        }
        getLatestData($scope, BuildQuery);
        $interval(getLatestData, 60000, 0, true, $scope, BuildQuery);

        //this.endLongPolling = function () { $interval.cancel(this.interval); };


        //activate();

        //function activate() { }
    }

    
})();

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