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
import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ORIGIN_URL } from './constants/baseurl.constants';
import { TransferHttp } from '../../modules/transfer-http/transfer-http';
var UserService = (function () {
    function UserService(transferHttp, // Use only for GETS that you want re-used between Server render -> Client render
        http, // Use for everything else
        baseUrl) {
        this.transferHttp = transferHttp;
        this.http = http;
        this.baseUrl = baseUrl;
    }
    UserService.prototype.getUsers = function () {
        // ** TransferHttp example / concept **
        //    - Here we make an Http call on the server, save the result on the window object and pass it down with the SSR,
        //      The Client then re-uses this Http result instead of hitting the server again!
        //  NOTE : transferHttp also automatically does .map(res => res.json()) for you, so no need for these calls
        return this.transferHttp.get(this.baseUrl + "/api/users");
    };
    UserService.prototype.getUser = function (user) {
        return this.transferHttp.get(this.baseUrl + "/api/users/" + user.id);
    };
    UserService.prototype.deleteUser = function (user) {
        return this.http.delete(this.baseUrl + "/api/users/" + user.id);
    };
    UserService.prototype.updateUser = function (user) {
        return this.http.put(this.baseUrl + "/api/users/" + user.id, user);
    };
    UserService.prototype.addUser = function (newUserName) {
        return this.http.post(this.baseUrl + "/api/users", { name: newUserName });
    };
    return UserService;
}());
UserService = __decorate([
    Injectable(),
    __param(2, Inject(ORIGIN_URL)),
    __metadata("design:paramtypes", [TransferHttp,
        Http, String])
], UserService);
export { UserService };
