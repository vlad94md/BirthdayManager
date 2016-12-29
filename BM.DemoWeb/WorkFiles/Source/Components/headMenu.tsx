import * as React from 'react';

class Head extends React.Component<any, any>{
    render(){
        return (
            <div className="container-fluid">
            <nav className="navbar navbar-default">
                <div>
                    <a href="#" className="navbar-brand">Happy Birthday, Motherfucker</a>
                </div>
                
                <div className="navbar-form navbar-left pull-right">
                    <button className="btn btn-default">Log out</button>
                </div>
            </nav>
            </div>
        )
    }
}

export default Head;