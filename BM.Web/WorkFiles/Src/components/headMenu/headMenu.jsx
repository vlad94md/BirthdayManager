var React = require('react');
var ReactRouter = require('react-router');
var Link = ReactRouter.Link;

var HeadMenu = React.createClass({
    render: function () {
        return (
            <nav id="myNavbar" className="navbar navbar-default">
            <div className="container-fluid">
                <div className="navbar-header">
                    <button type="button" className="navbar-toggle" data-toggle="collapse" data-target="#navbarCollapse">
                        <span className="sr-only">Toggle navigation</span>
                        <span className="icon-bar"></span>
                        <span className="icon-bar"></span>
                        <span className="icon-bar"></span>
                    </button>
                    <Link to="/" className="navbar-brand">Stores</Link>
                </div>
                <div className="collapse navbar-collapse" id="navbarCollapse">
                    <ul className="nav navbar-nav">
                        <li className="active">
                            <Link to="tablets">Tablets</Link>
                        </li>
                        <li>
                            <Link to="laptops">Laptops</Link>
                        </li>
                        <li>
                            <Link to="mobiles">Mobiles</Link>
                        </li>
                        <li>
                            <Link to="users">Users</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
            )
    }
});

module.exports = HeadMenu;