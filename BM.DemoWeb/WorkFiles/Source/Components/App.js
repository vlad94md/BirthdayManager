"use strict";
const React = require('react');
const headMenu_1 = require('./headMenu');
const sideMenu_1 = require('./sideMenu');
const calendarComponent_1 = require('./calendarComponent');
class App extends React.Component {
    render() {
        return (React.createElement("div", null, React.createElement(headMenu_1.default, null), React.createElement("div", {className: "container-fluid"}, React.createElement("div", {className: "col-md-2", style: { height: '1000px', backgroundColor: '#1f262d', padding: '0' }}, React.createElement(sideMenu_1.default, null)), React.createElement("div", {className: "col-md-10"}, React.createElement(calendarComponent_1.default, null))), this.props.children));
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = App;
//# sourceMappingURL=App.js.map