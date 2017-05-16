var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SignalRModule, SignalRConfiguration } from 'ng2-signalr';
import { ORIGIN_URL } from './shared/constants/baseurl.constants';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { REQUEST } from './shared/constants/request';
import { BrowserTransferStateModule } from '../modules/transfer-state/browser-transfer-state.module';
export function createConfig() {
    var signalRConfig = new SignalRConfiguration();
    signalRConfig.hubName = 'Ng2SignalRHub';
    signalRConfig.qs = { user: 'donald' };
    signalRConfig.url = 'http://ng2-signalr-backend.azurewebsites.net/';
    signalRConfig.logging = true;
    return signalRConfig;
}
export function getOriginUrl() {
    return window.location.origin;
}
export function getRequest() {
    // the Request object only lives on the server
    return { cookie: document.cookie };
}
var BrowserAppModule = (function () {
    function BrowserAppModule() {
    }
    return BrowserAppModule;
}());
BrowserAppModule = __decorate([
    NgModule({
        bootstrap: [AppComponent],
        imports: [
            BrowserModule.withServerTransition({
                appId: 'my-app-id' // make sure this matches with your Server NgModule
            }),
            BrowserAnimationsModule,
            BrowserTransferStateModule,
            // Our Common AppModule
            AppModule,
            SignalRModule.forRoot(createConfig)
        ],
        providers: [
            {
                // We need this for our Http calls since they'll be using an ORIGIN_URL provided in main.server
                // (Also remember the Server requires Absolute URLs)
                provide: ORIGIN_URL,
                useFactory: (getOriginUrl)
            }, {
                // The server provides these in main.server
                provide: REQUEST,
                useFactory: (getRequest)
            }
        ]
    })
], BrowserAppModule);
export { BrowserAppModule };
