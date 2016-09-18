/**
 * Created by local-rlong on 10/07/2016.
 */
/// <reference path="../../typings/index.d.ts" />
/// <reference path="../../typescript.lib.json_broker/lib.json_broker.ts" />
/// <reference path="../../typescript.lib.json_broker/angular1.ts" />
/// <reference path="../../ts/service.ts" />
var BrokerMessage = lib.json_broker.BrokerMessage;
var ViewController = (function () {
    function ViewController($http, $q) {
        var requestHandler = lib.json_broker.angular1.buildRequestHandler($http, $q);
        this.proxy = new service.TiddlyWikiRepository(requestHandler);
    }
    ViewController.prototype.ping = function () {
        console.log(arguments);
        this.proxy.ping().then(function (response) {
            console.log(response);
        }, function (response) {
            console.error(response);
        });
    };
    return ViewController;
}());
var mcRemote = angular.module('TiddlyWikiServer', []);
mcRemote.controller('index', ["$http", "$q", "$scope", function ($http, $q, $scope) {
        $scope.variable = "hey hey (from angular)";
        $scope.viewController = new ViewController($http, $q);
        $scope.viewController.ping();
    }]);
//# sourceMappingURL=index.js.map