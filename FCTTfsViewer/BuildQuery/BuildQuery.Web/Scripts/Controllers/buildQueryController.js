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
