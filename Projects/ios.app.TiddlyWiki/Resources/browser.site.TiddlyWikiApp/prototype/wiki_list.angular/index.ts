/**
 * Created by local-rlong on 10/07/2016.
 */



/// <reference path="../../typings/index.d.ts" />
/// <reference path="../../typescript.lib.json_broker/lib.json_broker.ts" />
/// <reference path="../../typescript.lib.json_broker/angular1.ts" />
/// <reference path="../../ts/service.ts" />


import BrokerMessage = lib.json_broker.BrokerMessage;


class ViewController {


    proxy: service.TiddlyWikiRepository;

    constructor( $http: angular.IHttpService,$q: angular.IQService ) {

        let requestHandler = lib.json_broker.angular1.buildRequestHandler( $http, $q );
        this.proxy = new service.TiddlyWikiRepository(requestHandler);

    }

    ping() {

        console.log( arguments );
        this.proxy.ping().then(
            (response ) => { // successCallback
                console.log( response );
            }
            , (response ) => { // errorCallback
                console.error( response );
            }
        )
    }

}


var mcRemote= angular.module('TiddlyWikiServer', []);

mcRemote.controller('index', ["$http", "$q", "$scope", function ($http: angular.IHttpService,$q: angular.IQService,$scope) {


    $scope.variable = "hey hey (from angular)";

    $scope.viewController = new ViewController( $http, $q );
    $scope.viewController.ping();


}]);

