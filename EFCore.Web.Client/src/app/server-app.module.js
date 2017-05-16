var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { ServerTransferStateModule } from '../modules/transfer-state/server-transfer-state.module';
import { TransferState } from '../modules/transfer-state/transfer-state';
var ServerAppModule = (function () {
    function ServerAppModule(transferState) {
        var _this = this;
        this.transferState = transferState;
        // Gotcha (needs to be an arrow function)
        this.ngOnBootstrap = function () {
            _this.transferState.inject();
        };
    }
    return ServerAppModule;
}());
ServerAppModule = __decorate([
    NgModule({
        bootstrap: [AppComponent],
        imports: [
            BrowserModule.withServerTransition({
                appId: 'my-app-id' // make sure this matches with your Browser NgModule
            }),
            ServerModule,
            NoopAnimationsModule,
            ServerTransferStateModule,
            // Our Common AppModule
            AppModule
        ]
    }),
    __metadata("design:paramtypes", [TransferState])
], ServerAppModule);
export { ServerAppModule };
