/**
 * Created by local-rlong on 28/08/2016.
 */



namespace app.context {

    export function setupPassword() {

        var password = localStorage.getItem( "tw5-password-upload" );
        if( !password ) {
            localStorage.setItem( "tw5-password-upload", "password" );
        }
    }

}