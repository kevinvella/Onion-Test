import 'zone.js/dist/zone-node';
import './polyfills/server.polyfills';
import { enableProdMode } from '@angular/core';
import { createServerRenderer } from 'aspnet-prerendering';
// Grab the (Node) server-specific NgModule
import { ServerAppModuleNgFactory } from './ngfactory/app/server-app.module.ngfactory';
// Temporary * the engine will be on npm soon (`@universal/ng-aspnetcore-engine`)
import { ngAspnetCoreEngine, createTransferScript } from './polyfills/temporary-aspnetcore-engine';
enableProdMode();
export default createServerRenderer(function (params) {
    // Platform-server provider configuration
    var setupOptions = {
        appSelector: '<app></app>',
        ngModule: ServerAppModuleNgFactory,
        request: params,
        providers: []
    };
    return ngAspnetCoreEngine(setupOptions).then(function (response) {
        // Apply your transferData to response.globals
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object'
        });
        return ({
            html: response.html,
            globals: response.globals
        });
    });
});
/* -------- THIS FILE IS TEMPORARY and will be gone when @ngtools/webpack can handle dual files (w server) ---------- */
