var React = require('react');
$ = jQuery = require('jquery');

var Users = React.createClass({
    getInitialState: function(){
        return {
            users: []
        }
    },
    componentWillMount: function () {
        var self = this;
        $.ajax('api/User').done(function (result) {

            self.setState({
                users: result
            })

        })

        
    },
    render: function () {
        return <div className="jumbotron">
                     <ul>
                         {
                            this.state.users.map(function (user) {
                                return <li>{user.FirstName} {user.LastName}</li>
                            })
                         }
                     </ul>
                </div>
    }
});

module.exports = Users;