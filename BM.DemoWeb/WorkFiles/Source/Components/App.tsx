import * as React from 'react';
import Head from './headMenu';
import SideMenu from './sideMenu';
import Calendar from './calendarComponent';

class App extends React.Component<any, any>{
    render(){
        return (
            <div>
                <Head />
                <div className="container-fluid">
                    <div className="col-md-2" style={{height: '1000px', backgroundColor: '#1f262d', padding: '0'}}>
                        <SideMenu />
                    </div>
                    <div className="col-md-10">
                        <Calendar />
                    </div>
                </div>

                {this.props.children}
            </div>
        )
    }
}

export default App;
