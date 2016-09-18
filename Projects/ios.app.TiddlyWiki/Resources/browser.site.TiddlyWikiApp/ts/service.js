/**
 * Created by local-rlong on 10/07/2016.
 */
/// <reference path="../typings/Promise.d.ts" />
/// <reference path="../typescript.lib.json_broker/lib.json_broker.ts" />
var service;
(function (service) {
    var SERVICE_NAME = "TiddlyWikiRepository";
    var TiddlyWikiRepository = (function () {
        function TiddlyWikiRepository(requestHandler) {
            this.requestHandler = requestHandler;
        }
        TiddlyWikiRepository.prototype.ping = function () {
            var request = new lib.json_broker.BrokerMessage();
            request.serviceName = SERVICE_NAME;
            request.methodName = "ping";
            return this.requestHandler.dispatch(request).then(function (promiseValue) {
                console.log(promiseValue);
            });
        };
        return TiddlyWikiRepository;
    }());
    service.TiddlyWikiRepository = TiddlyWikiRepository;
})(service || (service = {}));
//# sourceMappingURL=service.js.map