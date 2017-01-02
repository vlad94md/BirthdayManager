"use strict";
const React = require("react");
class SideMenu extends React.Component {
    render() {
        return (React.createElement("div", { id: "sidebar" },
            React.createElement("ul", null,
                React.createElement("li", { className: "active" },
                    React.createElement("a", { href: "index.html" },
                        React.createElement("i", { className: "icon icon-home" }),
                        " ",
                        React.createElement("span", null, "Dashboard")),
                    " "),
                React.createElement("li", { className: "submenu" },
                    React.createElement("a", { href: "#" },
                        React.createElement("span", null, "Users")),
                    React.createElement("ul", null,
                        React.createElement("li", null,
                            React.createElement("a", { href: "#" }, "All Users")),
                        React.createElement("li", null,
                            React.createElement("a", { href: "#" }, "Add User")))),
                React.createElement("li", { className: "submenu" },
                    React.createElement("a", { href: "#" },
                        React.createElement("span", null, "Payments")),
                    React.createElement("ul", null,
                        React.createElement("li", null,
                            React.createElement("a", { href: "#" }, "All Payments")),
                        React.createElement("li", null,
                            React.createElement("a", { href: "#" }, "Add New Payment")))),
                React.createElement("li", { className: "submenu" },
                    React.createElement("a", { href: "#" },
                        React.createElement("span", null, "Birthdays")),
                    React.createElement("ul", null,
                        React.createElement("li", null,
                            React.createElement("a", { href: "#" }, "Calendar")))))));
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = SideMenu;
//# sourceMappingURL=sideMenu.js.map