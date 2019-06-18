"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Chat = /** @class */ (function () {
    function Chat(chatId, isActive, customerFirstResponse, score, customer, visitor, messages, lastMessageId) {
        this.chatId = chatId;
        this.isActive = isActive;
        this.customerFirstResponse = customerFirstResponse;
        this.score = score;
        this.customer = customer;
        this.visitor = visitor;
        this.messages = messages;
        this.lastMessageId = lastMessageId;
    }
    return Chat;
}());
exports.Chat = Chat;
//# sourceMappingURL=chat.js.map