"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Customer = /** @class */ (function () {
    function Customer(customerId, name, email, avatar, channelCustomers, chats) {
        if (channelCustomers === void 0) { channelCustomers = []; }
        if (chats === void 0) { chats = []; }
        this.customerId = customerId;
        this.name = name;
        this.email = email;
        this.avatar = avatar;
        this.channelCustomers = channelCustomers;
        this.chats = chats;
    }
    return Customer;
}());
exports.Customer = Customer;
//# sourceMappingURL=customer.js.map