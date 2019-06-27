"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Chat = /** @class */ (function () {
    function Chat(chatId, isActive, customerFirstResponse, score, lastMessageId, lastMessage, customer, visitor, messages) {
        this.chatId = chatId;
        this.isActive = isActive;
        this.customerFirstResponse = customerFirstResponse;
        this.score = score;
        this.lastMessageId = lastMessageId;
        this.lastMessage = lastMessage;
        this.customer = customer;
        this.visitor = visitor;
        this.messages = messages;
    }
    return Chat;
}());
exports.Chat = Chat;
//# sourceMappingURL=chat.js.map