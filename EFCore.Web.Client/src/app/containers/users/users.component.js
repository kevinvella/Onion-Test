var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, 
// animation imports
trigger, state, style, transition, animate } from '@angular/core';
import { UserService } from '../../shared/user.service';
var UsersComponent = (function () {
    // Use "constructor"s only for dependency injection
    function UsersComponent(userService) {
        this.userService = userService;
    }
    // Here you want to handle anything with @Input()'s @Output()'s
    // Data retrieval / etc - this is when the Component is "ready" and wired up
    UsersComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.userService.getUsers().subscribe(function (result) {
            console.log('Get user result: ', result);
            console.log('TransferHttp [GET] /api/users/allresult', result);
            _this.users = result;
        });
    };
    UsersComponent.prototype.onSelect = function (user) {
        this.selectedUser = user;
    };
    UsersComponent.prototype.deleteUser = function (user) {
        var _this = this;
        this.userService.deleteUser(user).subscribe(function (result) {
            console.log('Delete user result: ', result);
            if (result.ok) {
                var position = _this.users.indexOf(user);
                _this.users.splice(position, 1);
            }
            else {
                alert('There was an issue, Could not delete user');
            }
        });
    };
    UsersComponent.prototype.addUser = function (newUserName) {
        var _this = this;
        this.userService.addUser(newUserName).subscribe(function (result) {
            console.log('Post user result: ', result);
            if (result.ok) {
                _this.users.push(result.json());
            }
            else {
                alert('There was an issue, Could not edit user');
            }
        });
    };
    return UsersComponent;
}());
UsersComponent = __decorate([
    Component({
        selector: 'users',
        templateUrl: './users.component.html',
        styleUrls: ['./users.component.css'],
        animations: [
            // Animation example
            // Triggered in the ngFor with [@flyInOut]
            trigger('flyInOut', [
                state('in', style({ transform: 'translateY(0)' })),
                transition('void => *', [
                    style({ transform: 'translateY(-100%)' }),
                    animate(1000)
                ]),
                transition('* => void', [
                    animate(1000, style({ transform: 'translateY(100%)' }))
                ])
            ])
        ]
    }),
    __metadata("design:paramtypes", [UserService])
], UsersComponent);
export { UsersComponent };
