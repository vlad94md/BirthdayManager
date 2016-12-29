import * as React from "react";
import * as ReactDOM from "react-dom";
import { Router, Route, IndexRoute, browserHistory } from 'react-router';
import App from './Components/App';

ReactDOM.render((
    <Router history={browserHistory}>
        <Route path="/" component={App} />
    </Router>
    ), document.getElementById("app"));
