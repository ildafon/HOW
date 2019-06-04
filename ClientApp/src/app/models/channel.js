"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Channel = /** @class */ (function () {
    function Channel(channelId, name, isActive, channelCustomers) {
        if (channelCustomers === void 0) { channelCustomers = []; }
        this.channelId = channelId;
        this.name = name;
        this.isActive = isActive;
        this.channelCustomers = channelCustomers;
    }
    return Channel;
}());
exports.Channel = Channel;
//# sourceMappingURL=channel.js.map