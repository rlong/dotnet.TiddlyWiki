/**
 * Created by local-rlong on 17/09/2016.
 */



let password:string = localStorage.getItem( "tw5-password-upload" );

console.log( password );

if( !password ) {

    localStorage.setItem( "tw5-password-upload", "password" );

}

