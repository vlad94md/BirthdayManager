import * as React from 'react';

export default class Calendar extends React.Component<any, any>{
  render(){
    return (
      <div className="widget-box widget-calendar">
      <div style={{height: '35px'}}>
        <div className="pull-right">
          <button className="btn btn-primary" id="add-event-but">Add event</button>
        </div>
      </div>
          <hr />
          <div id="calendar"></div>
      </div>
      
    )
  }
}
