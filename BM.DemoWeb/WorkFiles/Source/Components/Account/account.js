"use strict";
const React = require("react");
class Account extends React.Component {
    render() {
        return React.createElement("div", { classNameName: "row", style: { marginTop: '10%' } },
            React.createElement("div", { className: "col-md-4 col-md-offset-4" },
                React.createElement("div", null,
                    React.createElement("form", { id: "log-form" },
                        React.createElement("div", { className: "form-group" },
                            React.createElement("label", { for: "Credentials", style: { color: 'white' } }, "Credentials"),
                            React.createElement("input", { type: "text", className: "form-control creds" })),
                        React.createElement("div", { className: "form-group" },
                            React.createElement("label", { for: "exampleInputEmail2", style: { color: 'white' } }, "Password"),
                            React.createElement("input", { type: "email", className: "form-control", id: "exampleInputEmail2" })),
                        React.createElement("div", { className: "pull-right" },
                            React.createElement("input", { type: "button", className: "btn btn-primary", id: "log-in", value: "Log in" })),
                        React.createElement("div", null,
                            React.createElement("input", { type: "button", className: "btn btn-primary", id: "first-enter", value: "First Enter?" })))),
                React.createElement("div", { id: "reg-form", style: { display: 'none' } },
                    React.createElement("form", null,
                        React.createElement("div", { className: "form-group" },
                            React.createElement("label", { for: "Credentials", style: { color: 'white' } }, "Credentials"),
                            React.createElement("input", { type: "text", className: "form-control creds" })),
                        React.createElement("div", { className: "form-group" },
                            React.createElement("label", { for: "exampleInputEmail2", style: { color: 'white' } }, "Password"),
                            React.createElement("input", { type: "email", className: "form-control", id: "exampleInputEmail2" })),
                        React.createElement("div", { className: "form-group", id: "pswrd-confirm" },
                            React.createElement("label", { for: "exampleInputEmail2", style: { color: 'white' } }, "Confirm Password"),
                            React.createElement("input", { type: "email", className: "form-control", id: "exampleInputEmail2" })),
                        React.createElement("div", { className: "pull-right" },
                            React.createElement("input", { type: "button", className: "btn btn-primary", id: "reg-me", value: "Register me" })),
                        React.createElement("div", null,
                            React.createElement("input", { type: "button", className: "btn btn-primary", id: "back", value: "Back" }))))));
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = Account;
//# sourceMappingURL=account.js.map