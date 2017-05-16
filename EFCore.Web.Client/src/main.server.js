import 'zone.js/dist/zone-node';
import './polyfills/server.polyfills';
import { enableProdMode } from '@angular/core';
import { createServerRenderer } from 'aspnet-prerendering';
// Grab the (Node) server-specific NgModule
import { ServerAppModule } from './app/server-app.module';
// Temporary * the engine will be on npm soon (`@universal/ng-aspnetcore-engine`)
import { ngAspnetCoreEngine, createTransferScript } from './polyfills/temporary-aspnetcore-engine';
enableProdMode();
export default createServerRenderer(function (params) {
    // Platform-server provider configuration
    var setupOptions = {
        appSelector: '<app></app>',
        ngModule: ServerAppModule,
        request: params,
        providers: []
    };
    return ngAspnetCoreEngine(setupOptions).then(function (response) {
        // Apply your transferData to response.globals
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object',
            fromDotnet: params.data.thisCameFromDotNET // example of data coming from dotnet, in HomeController
        });
        return ({
            html: response.html,
            globals: response.globals
        });
    });
});
