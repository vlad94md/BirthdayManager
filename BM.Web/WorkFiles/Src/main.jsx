var React = require('react');
var ReactDOM = require('react-dom');
var ReactRouter = require('react-router');

var Router = ReactRouter.Router;
var Route = ReactRouter.Route;
var IndexRoute = ReactRouter.IndexRoute;
var browserHistory = ReactRouter.browserHistory;


var Head = require('./components/headMenu/headMenu.jsx');
var Laptops = require('./components/laptopsPage/laptopPage.jsx');
var Mobiles = require('./components/mobilesPage/mobilePage.jsx');
var Tablets = require('./components/tabletsPage/tabletPage.jsx');
var Users = require('./components/usersPage/userPage.jsx');
var Login = require('./components/loginPage/loginPage.jsx');

var Main = React.createClass({
    render: function () {
        return (
            <div>
                <Head />
                {this.props.children}
            </div>
        )
    }
});

ReactDOM.render((
        <Router history={browserHistory}>
            <Route path="/" component={Main}>
                <IndexRoute name="tablets" component={Tablets}/>
                <Route name="mobiles" path="/mobiles" component={Mobiles} />
                <Route name="laptops" path="/laptops" component={Laptops} />
                <Route name="users" path="/users" component={Users} />
                <Route name="login" path="/login" component={Login} />
            </Route>
        </Router>
    ), document.getElementById("BDapp"));