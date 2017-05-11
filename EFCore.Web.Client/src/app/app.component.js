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
import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute } from '@angular/router';
import { Meta, Title } from '@angular/platform-browser';
import { LinkService } from './shared/link.service';
// i18n support
import { TranslateService } from '@ngx-translate/core';
import { REQUEST } from './shared/constants/request';
var AppComponent = (function () {
    function AppComponent(router, activatedRoute, title, meta, linkService, translate, request) {
        this.router = router;
        this.activatedRoute = activatedRoute;
        this.title = title;
        this.meta = meta;
        this.linkService = linkService;
        this.translate = translate;
        this.request = request;
        // This will go at the END of your title for example "Home - Angular Universal..." <-- after the dash (-)
        this.endPageTitle = 'Angular Universal and ASP.NET Core Starter';
        // If no Title is provided, we'll use a default one before the dash(-)
        this.defaultPageTitle = 'My App';
        // this language will be used as a fallback when a translation isn't found in the current language
        translate.setDefaultLang('en');
        // the lang to use, if the lang isn't available, it will use the current loader to get them
        translate.use('en');
        console.log("What's our REQUEST Object look like?");
        console.log("The Request object only really exists on the Server, but on the Browser we can at least see Cookies");
        console.log(this.request);
    }
    AppComponent.prototype.ngOnInit = function () {
        // Change "Title" on every navigationEnd event
        // Titles come from the data.title property on all Routes (see app.routes.ts)
        this._changeTitleOnNavigation();
    };
    AppComponent.prototype.ngOnDestroy = function () {
        // Subscription clean-up
        this.routerSub$.unsubscribe();
    };
    AppComponent.prototype._changeTitleOnNavigation = function () {
        var _this = this;
        this.routerSub$ = this.router.events
            .filter(function (event) { return event instanceof NavigationEnd; })
            .map(function () { return _this.activatedRoute; })
            .map(function (route) {
            while (route.firstChild)
                route = route.firstChild;
            return route;
        })
            .filter(function (route) { return route.outlet === 'primary'; })
            .mergeMap(function (route) { return route.data; })
            .subscribe(function (event) {
            _this._setMetaAndLinks(event);
        });
    };
    AppComponent.prototype._setMetaAndLinks = function (event) {
        // Set Title if available, otherwise leave the default Title
        var title = event['title']
            ? event['title'] + " - " + this.endPageTitle
            : this.defaultPageTitle + " - " + this.endPageTitle;
        this.title.setTitle(title);
        var metaData = event['meta'] || [];
        var linksData = event['links'] || [];
        for (var i = 0; i < metaData.length; i++) {
            this.meta.updateTag(metaData[i]);
        }
        for (var i = 0; i < linksData.length; i++) {
            this.linkService.addTag(linksData[i]);
        }
    };
    return AppComponent;
}());
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.scss'],
        encapsulation: ViewEncapsulation.None
    }),
    __param(6, Inject(REQUEST)),
    __metadata("design:paramtypes", [Router,
        ActivatedRoute,
        Title,
        Meta,
        LinkService,
        TranslateService, Object])
], AppComponent);
export { AppComponent };
