var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { TransferState } from '../transfer-state/transfer-state';
import { isPlatformServer } from '@angular/common';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/observable/fromPromise';
var TransferHttp = (function () {
    function TransferHttp(platformId, http, transferState) {
        this.platformId = platformId;
        this.http = http;
        this.transferState = transferState;
        this.isServer = isPlatformServer(this.platformId);
    }
    TransferHttp.prototype.request = function (uri, options) {
        var _this = this;
        return this.getData(uri, options, function (url, options) {
            return _this.http.request(url, options);
        });
    };
    /**
     * Performs a request with `get` http method.
     */
    TransferHttp.prototype.get = function (url, options) {
        var _this = this;
        return this.getData(url, options, function (url, options) {
            return _this.http.get(url, options);
        });
    };
    /**
     * Performs a request with `post` http method.
     */
    TransferHttp.prototype.post = function (url, body, options) {
        var _this = this;
        return this.getPostData(url, body, options, function (url, options) {
            return _this.http.post(url, body, options);
        });
    };
    /**
     * Performs a request with `put` http method.
     */
    TransferHttp.prototype.put = function (url, body, options) {
        var _this = this;
        return this.getPostData(url, body, options, function (url, options) {
            return _this.http.put(url, body, options);
        });
    };
    /**
     * Performs a request with `delete` http method.
     */
    TransferHttp.prototype.delete = function (url, options) {
        var _this = this;
        return this.getData(url, options, function (url, options) {
            return _this.http.delete(url, options);
        });
    };
    /**
     * Performs a request with `patch` http method.
     */
    TransferHttp.prototype.patch = function (url, body, options) {
        var _this = this;
        return this.getPostData(url, body, options, function (url, options) {
            return _this.http.patch(url, body.options);
        });
    };
    /**
     * Performs a request with `head` http method.
     */
    TransferHttp.prototype.head = function (url, options) {
        var _this = this;
        return this.getData(url, options, function (url, options) {
            return _this.http.head(url, options);
        });
    };
    /**
     * Performs a request with `options` http method.
     */
    TransferHttp.prototype.options = function (url, options) {
        var _this = this;
        return this.getData(url, options, function (url, options) {
            return _this.http.options(url, options);
        });
    };
    TransferHttp.prototype.getData = function (uri, options, callback) {
        var _this = this;
        var url = uri;
        if (typeof uri !== 'string') {
            url = uri.url;
        }
        var key = url + JSON.stringify(options);
        try {
            return this.resolveData(key);
        }
        catch (e) {
            return callback(url, options)
                .map(function (res) { return res.json(); })
                .do(function (data) {
                if (_this.isServer) {
                    _this.setCache(key, data);
                }
            });
        }
    };
    TransferHttp.prototype.getPostData = function (uri, body, options, callback) {
        var _this = this;
        var url = uri;
        if (typeof uri !== 'string') {
            url = uri.url;
        }
        var key = url + JSON.stringify(body);
        try {
            return this.resolveData(key);
        }
        catch (e) {
            return callback(uri, body, options)
                .map(function (res) { return res.json(); })
                .do(function (data) {
                if (_this.isServer) {
                    _this.setCache(key, data);
                }
            });
        }
    };
    TransferHttp.prototype.resolveData = function (key) {
        var data = this.getFromCache(key);
        if (!data) {
            throw new Error();
        }
        return Observable.fromPromise(Promise.resolve(data));
    };
    TransferHttp.prototype.setCache = function (key, data) {
        return this.transferState.set(key, data);
    };
    TransferHttp.prototype.getFromCache = function (key) {
        return this.transferState.get(key);
    };
    return TransferHttp;
}());
TransferHttp = __decorate([
    Injectable(),
    __param(0, Inject(PLATFORM_ID)),
    __metadata("design:paramtypes", [Object, Http,
        TransferState])
], TransferHttp);
export { TransferHttp };
