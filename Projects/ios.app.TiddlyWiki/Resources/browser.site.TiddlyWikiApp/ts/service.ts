/**
 * Created by local-rlong on 10/07/2016.
 */


/// <reference path="../typings/Promise.d.ts" />
/// <reference path="../typescript.lib.json_broker/lib.json_broker.ts" />


module service {


    const SERVICE_NAME = "TiddlyWikiRepository";

    import IRequestHandler = lib.json_broker.IRequestHandler;
    import BrokerMessage = lib.json_broker.BrokerMessage;

    export class TiddlyWikiRepository {

        requestHandler: IRequestHandler;

        constructor( requestHandler: IRequestHandler ) {

            this.requestHandler = requestHandler;
        }

        ping(): Promise<void> {

            let request = new lib.json_broker.BrokerMessage();
            request.serviceName = SERVICE_NAME;
            request.methodName = "ping";

            return this.requestHandler.dispatch( request ).then(
                (promiseValue:BrokerMessage) => {
                    console.log(promiseValue);
                }
            );

        }

    }

}