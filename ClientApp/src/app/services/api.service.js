"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var rxjs_1 = require("rxjs");
var operators_1 = require("rxjs/operators");
var ApiService = /** @class */ (function () {
    function ApiService(http, baseUrl) {
        this.http = http;
        this.baseUrl = baseUrl;
    }
    ApiService.prototype.sendRequest = function (verb, url, body) {
        var myHeaders = new http_1.HttpHeaders();
        myHeaders = myHeaders.set('Content-Type', 'application/json; charset=utf-8');
        myHeaders = myHeaders.set('Accept', 'application/json');
        return this.http.request(verb, "" + this.baseUrl + url, {
            body: body,
            headers: myHeaders
        }).pipe(operators_1.catchError(this.handleServerError));
    };
    ApiService.prototype.handleServerError = function (error) {
        console.log(error.error || error.json() || error);
        return rxjs_1.Observable.throw(error.error || error.json() || error || "Server error");
    };
    ApiService = __decorate([
        core_1.Injectable(),
        __param(1, core_1.Inject('BASE_URL'))
    ], ApiService);
    return ApiService;
}());
exports.ApiService = ApiService;
//# sourceMappingURL=api.service.js.map