var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BroadcastEventListener } from 'ng2-signalr';
var ChatMessage = (function () {
    function ChatMessage(user, content) {
        this.user = user;
        this.content = content;
    }
    return ChatMessage;
}());
export { ChatMessage };
var ChatComponent = (function () {
    function ChatComponent(route) {
        this.chatMessages = [];
        this._connection = route.snapshot.data['connection'];
    }
    ChatComponent.prototype.ngOnInit = function () {
        var _this = this;
        var onMessageSent$ = new BroadcastEventListener('OnMessageSent');
        this._connection.listen(onMessageSent$);
        this._subscription = onMessageSent$.subscribe(function (chatMessage) {
            _this.chatMessages.push(chatMessage);
            console.log('chat messages', _this.chatMessages);
        });
    };
    // send chat message to server
    ChatComponent.prototype.sendMessage = function (user, message) {
        console.log('send message', user, message);
        this._connection.invoke('Chat', new ChatMessage(user, message))
            .catch(function (err) { return console.log('Failed to invoke', err); });
    };
    return ChatComponent;
}());
ChatComponent = __decorate([
    Component({
        selector: 'chat',
        templateUrl: './chat.component.html',
        styleUrls: ['./chat.component.css']
    }),
    __metadata("design:paramtypes", [ActivatedRoute])
], ChatComponent);
export { ChatComponent };
