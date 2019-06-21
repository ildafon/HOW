"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Customer = /** @class */ (function () {
    function Customer(customerId, name, email, avatar, avatarId, channelCustomers, chats) {
        if (channelCustomers === void 0) { channelCustomers = []; }
        this.customerId = customerId;
        this.name = name;
        this.email = email;
        this.avatar = avatar;
        this.avatarId = avatarId;
        this.channelCustomers = channelCustomers;
        this.chats = chats;
    }
    return Customer;
}());
exports.Customer = Customer;
//# sourceMappingURL=customer.js.map