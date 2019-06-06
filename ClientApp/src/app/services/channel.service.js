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
var ChannelService = /** @class */ (function () {
    function ChannelService(api, localStorageService) {
        this.api = api;
        this.localStorageService = localStorageService;
        this.requestObject$ = new rxjs_1.BehaviorSubject(this.getRequestObjectInitial());
    }
    Object.defineProperty(ChannelService.prototype, "currentRequestObject", {
        get: function () {
            return this.requestObject$.getValue();
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ChannelService.prototype, "requestObject", {
        get: function () {
            return this.requestObject$.asObservable();
        },
        enumerable: true,
        configurable: true
    });
    ChannelService.prototype.changeRequestObject = function (reqObj) {
        //console.log("changeRequestObject call!");
        this.requestObject$.next(Object.assign(this.requestObject$.value, reqObj));
        this.localStorageService.setItem("CHANNEL_REQUEST_OBJECT", this.currentRequestObject);
    };
    ChannelService.prototype.getChannelsPaged = function (channelRequestObj) {
        return this.api.sendRequest("GET", '/api/channels'
            + '?Related=' + channelRequestObj.related
            + '&PageNumber=' + channelRequestObj.pageNumber
            + '&PageSize=' + channelRequestObj.pageSize
            + '&Term=' + channelRequestObj.term);
    };
    ChannelService.prototype.getChannel = function (id) {
        return this.api.sendRequest("GET", "/api/channels/" + id);
    };
    ChannelService.prototype.createChannel = function (channel) {
        var data = {
            name: channel.name,
            channelCustomers: channel.channelCustomers
        };
        return this.api.sendRequest("POST", '/api/channels', data);
    };
    ChannelService.prototype.editChannel = function (channel) {
        var data = {
            channelId: channel.channelId,
            name: channel.name,
            channelCustomers: channel.channelCustomers
        };
        return this.api.sendRequest("PUT", "/api/channels/" + channel.channelId, data);
    };
    ChannelService.prototype.deleteChannel = function (id) {
        return this.api.sendRequest("DELETE", "/api/channels/" + id);
    };
    ChannelService.prototype.refresh = function () {
        this.requestObject$.next(Object.assign(this.requestObject$.value, {}));
    };
    ChannelService.prototype.getRequestObjectInitial = function () {
        return this.localStorageService
            .getItem("CHANNEL_REQUEST_OBJECT") || new models_1.RequestObject;
    };
    ChannelService = __decorate([
        core_1.Injectable()
    ], ChannelService);
    return ChannelService;
}());
exports.ChannelService = ChannelService;
//# sourceMappingURL=channel.service.js.map