"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var models_1 = require("../models");
var PagingService = /** @class */ (function () {
    function PagingService(localStorageService, prefix) {
        this.localStorageService = localStorageService;
        this.prefix = prefix;
        this.requestObject$ = new rxjs_1.BehaviorSubject(this.getRequestObjectInitial());
    }
    Object.defineProperty(PagingService.prototype, "currentRequestObject", {
        get: function () {
            return this.requestObject$.getValue();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(PagingService.prototype, "requestObject", {
        get: function () {
            return this.requestObject$.asObservable();
        },
        enumerable: true,
        configurable: true
    });
    PagingService.prototype.changeRequestObject = function (reqObj) {
        this.requestObject$.next(Object.assign(this.requestObject$.value, reqObj));
        this.localStorageService.setItem(this.prefix + "_REQUEST_OBJECT", this.currentRequestObject);
    };
    PagingService.prototype.refresh = function () {
        this.requestObject$.next(Object.assign(this.requestObject$.value, {}));
    };
    PagingService.prototype.getRequestObjectInitial = function () {
        return this.localStorageService
            .getItem(this.prefix + "_REQUEST_OBJECT") || new models_1.RequestObject;
    };
    PagingService = __decorate([
        core_1.Injectable()
    ], PagingService);
    return PagingService;
}());
exports.PagingService = PagingService;
//# sourceMappingURL=paging.service.js.map