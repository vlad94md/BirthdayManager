import * as React from 'react';


export default class Account extends React.Component<any, any>{
    render() {
        return <div classNameName="row" style={{ marginTop: '10%'}}>
            <div className="col-md-4 col-md-offset-4">
                <div>
                    <form id="log-form">
                        <div className="form-group">
                            <label for="Credentials" style={{ color: 'white' }}>Credentials</label>
                            <input type="text" className="form-control creds" />
                                </div>
                            <div className="form-group">
                            <label for="exampleInputEmail2" style={{ color: 'white' }}>Password</label>
                                <input type="email" className="form-control" id="exampleInputEmail2" />
                                </div>
                                <div className="pull-right">
                                    <input type="button" className="btn btn-primary" id="log-in" value="Log in" />
                                </div>
                                    <div>
                                        <input type="button" className="btn btn-primary" id="first-enter" value="First Enter?" />
                                </div>
                                
                                </form>
                                </div>

                                <div id="reg-form" style={{display: 'none'}}>
                              <form>
                                        <div className="form-group">
                            <label for="Credentials" style={{ color: 'white' }}>Credentials</label>
                                            <input type="text" className="form-control creds" />
                                </div>
                                            <div className="form-group">
                            <label for="exampleInputEmail2" style={{ color: 'white' }}>Password</label>
                                                <input type="email" className="form-control" id="exampleInputEmail2" />
                                </div>
                                                <div className="form-group" id="pswrd-confirm">
                            <label for="exampleInputEmail2" style={{ color: 'white' }}>Confirm Password</label>
                                                    <input type="email" className="form-control" id="exampleInputEmail2" />
                                </div>
                                                    <div className="pull-right">
                                                        <input type="button" className="btn btn-primary" id="reg-me" value="Register me" />
                                </div>
                                                        <div>
                                                            <input type="button" className="btn btn-primary" id="back" value="Back" />
                                </div>
                            </form>
                           </div>
                    </div>
               </div>
    }
}