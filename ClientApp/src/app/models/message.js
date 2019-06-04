"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Message = /** @class */ (function () {
    function Message(messageId, content, fromVisitor, received, chat) {
        this.messageId = messageId;
        this.content = content;
        this.fromVisitor = fromVisitor;
        this.received = received;
        this.chat = chat;
    }
    return Message;
}());
exports.Message = Message;
//# sourceMappingURL=message.js.map