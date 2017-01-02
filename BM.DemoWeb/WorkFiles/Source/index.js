"use strict";
const React = require("react");
const ReactDOM = require("react-dom");
const react_router_1 = require("react-router");
const App_1 = require("./Components/App");
ReactDOM.render((React.createElement(react_router_1.Router, { history: react_router_1.browserHistory },
    React.createElement(react_router_1.Route, { path: "/", component: App_1.default }))), document.getElementById("app"));
//# sourceMappingURL=index.js.map