var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable, RendererFactory2, ViewEncapsulation } from '@angular/core';
import { TransferState } from './transfer-state';
import { PlatformState } from '@angular/platform-server';
var ServerTransferState = (function (_super) {
    __extends(ServerTransferState, _super);
    function ServerTransferState(state, rendererFactory) {
        var _this = _super.call(this) || this;
        _this.state = state;
        _this.rendererFactory = rendererFactory;
        return _this;
    }
    /**
     * Inject the State into the bottom of the <head>
     */
    ServerTransferState.prototype.inject = function () {
        try {
            var document_1 = this.state.getDocument();
            var transferStateString = JSON.stringify(this.toJson());
            var renderer = this.rendererFactory.createRenderer(document_1, {
                id: '-1',
                encapsulation: ViewEncapsulation.None,
                styles: [],
                data: {}
            });
            var body = document_1.body;
            var script = renderer.createElement('script');
            renderer.setValue(script, "window['TRANSFER_STATE'] = " + transferStateString);
            renderer.appendChild(body, script);
        }
        catch (e) {
            console.log('Failed to append TRANSFER_STATE to body');
            console.error(e);
        }
    };
    return ServerTransferState;
}(TransferState));
ServerTransferState = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [PlatformState, RendererFactory2])
], ServerTransferState);
export { ServerTransferState };
