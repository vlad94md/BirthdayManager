import * as React from 'react';

class SideMenu extends React.Component<any, any>{
    render(){
        return (
            <div id="sidebar">
                <ul>
                    <li className="active"><a href="index.html"><i className="icon icon-home"></i> <span>Dashboard</span></a> </li>
                    <li className="submenu">
                        <a href="#"><span>Users</span></a>
                        <ul>
                            <li><a href="#">All Users</a></li>
                            <li><a href="#">Add User</a></li>
                        </ul>
                    </li>
                    <li className="submenu">
                        <a href="#"><span>Payments</span></a>
                        <ul>
                            <li><a href="#">All Payments</a></li>
                            <li><a href="#">Add New Payment</a></li>
                        </ul>
                    </li>
                    <li className="submenu">
                        <a href="#"><span>Birthdays</span></a>
                        <ul>
                            <li><a href="#">Calendar</a></li>
                        </ul>
                    </li>
                </ul>
                </div>
        )
    }
}

export default SideMenu;