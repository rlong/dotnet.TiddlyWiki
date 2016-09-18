/**
 * Created by local-rlong on 28/08/2016.
 */
var app;
(function (app) {
    var context;
    (function (context) {
        function setupPassword() {
            var password = localStorage.getItem("tw5-password-upload");
            if (!password) {
                localStorage.setItem("tw5-password-upload", "password");
            }
        }
        context.setupPassword = setupPassword;
    })(context = app.context || (app.context = {}));
})(app || (app = {}));
//# sourceMappingURL=app.context.js.map