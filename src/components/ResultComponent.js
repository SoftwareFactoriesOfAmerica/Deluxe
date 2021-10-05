import React, {Component} from 'react';

class ResultComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {email: 'art.scott@hotmail.com'};

         this.handleSubmit = this.handleSubmit.bind(this);
      }
    
      handleSubmit(event) {
        alert('hi: ' + this.state.email);
        event.preventDefault();
      }

    render() {
        let {result} = this.props;
        //let {email} = this.props;
        let { statusMessage} = this.props;

        return (
            <div>
                <div className="statusCaption">
                <form onSubmit={this.handleSubmit}>
                    <label width="100%">
                        <br />
                        &nbsp;&nbsp;email:
                        <input type="text" name="email" value={this.state.email} style={{width: "80%"}}/>
                        <input type="submit" value="Save" />
                    </label>   
                </form>             
                </div>            
                <div className="result">
                    <p>{result}</p>
                </div>
            </div>
    )
        ;
    }
}


export default ResultComponent;

