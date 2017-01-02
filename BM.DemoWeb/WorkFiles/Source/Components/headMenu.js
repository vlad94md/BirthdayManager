"use strict";
const React = require("react");
class Head extends React.Component {
    render() {
        return (React.createElement("div", { className: "container-fluid" },
            React.createElement("nav", { className: "navbar navbar-default" },
                React.createElement("div", null,
                    React.createElement("a", { href: "#", className: "navbar-brand" }, "Happy Birthday, Motherfucker")),
                React.createElement("div", { className: "navbar-form navbar-left pull-right" },
                    React.createElement("button", { className: "btn btn-default" }, "Log out")))));
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = Head;
//# sourceMappingURL=headMenu.js.map