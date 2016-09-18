/**
 * Created by local-rlong on 10/07/2016.
 */

/// <reference path="../../typings/index.d.ts" />
/// <reference path="../../typescript.lib.json_broker/lib.json_broker.ts" />
/// <reference path="../../typescript.lib.json_broker/mithril.ts" />
/// <reference path="../../ts/service.ts" />


var requestHandler = lib.json_broker.mithril.buildRequestHandler();
var proxy = new service.TiddlyWikiRepository(requestHandler);


//this application only has one component: todo
var todo: any = {};

//for simplicity, we use this component to namespace the model classes


//the view-model tracks a running list of todos,
//stores a description for new todos before they are created
//and takes care of the logic surrounding when adding is permitted
//and clearing the input after adding a todo to the list
todo.vm = (function() {
    var vm: any = {}
    vm.init = function() {

        //a slot to store the name of a new todo before it is created
        vm.description = m.prop("hey hey (from mithril)");

        vm.ping = function() {

            proxy.ping().then(
                () => {
                    console.log( "success");
                },
                (reason) => {
                    console.error( reason );
                }
            )
        }
    }
    return vm
}())

//the controller defines what part of the model is relevant for the current page
//in our case, there's only one view-model that handles everything
todo.controller = function() {
    todo.vm.init()
}

//here's the view
todo.view = function() {
    return [

        m( "div", todo.vm.description() ),
        m("button", {onclick: todo.vm.ping},
            m( "h3", "Ping!") )
    ]
};

//initialize the application
m.mount(document.body, {controller: todo.controller, view: todo.view});
