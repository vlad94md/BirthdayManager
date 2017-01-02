"use strict";
const React = require("react");
class Calendar extends React.Component {
    render() {
        return (React.createElement("div", { className: "widget-box widget-calendar" },
            React.createElement("div", { style: { height: '35px' } },
                React.createElement("div", { className: "pull-right" },
                    React.createElement("button", { className: "btn btn-primary", id: "add-event-but" }, "Add event"))),
            React.createElement("hr", null),
            React.createElement("div", { id: "calendar" })));
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = Calendar;
//# sourceMappingURL=calendarComponent.js.map