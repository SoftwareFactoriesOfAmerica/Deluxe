import React, {Component} from 'react';
import backSpace from '../images/backspace.png'

class KeyPadComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {statusMessage: 'Welcome to your Deluxe Accountant Calculator...'};
  }
    render() {
        return (
          <div className="button">
            <button name="MC" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)} title="Reset everything">MC</button>
            <button name="MR" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)} title="Memory Recall">MR</button>
            <button name="M-" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)} title="Memory Remove">M-</button>
            <button name="M+" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)} title="Memory Add">M+</button>
            <button name="C" className="buttonHalfNormal" onClick={e => this.props.onClick("C")} title="clear result">C</button>            
            <button name="CE" className="buttonHalfNormal" onClick={e => this.props.onClick("CE")} title="clear entry">
                <img src={backSpace} width="25px" height="25px" alt="<-" title="Clear last entry"></img>
            </button><br />

            <button name="7" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>7</button>
            <button name="8" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>8</button>
            <button name="9" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>9</button>
            <button name="+/-" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>+/-</button>
            <button name="GT" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)} title="Grand Total">GT</button><br/>

            <button name="4" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>4</button>
            <button name="5" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>5</button>
            <button name="6" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>6</button>
            <button name="/" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>/</button>
            <button name="%" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>%</button><br/>

            <button name="1" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>1</button>
            <button name="2" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>2</button>
            <button name="3" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>3</button>
            <button name="-" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>-</button>
            <button name="*" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>*</button><br/>

            <button name="0" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>0</button>
            <button name="00" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>00</button>
            <button name="." className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>.</button>
            <button name="+" className="buttonNormal" onClick={e => this.props.onClick(e.target.name)}>+</button>
            <button name="=" className="buttonEqual" onClick={e => this.props.onClick(e.target.name)}>=</button><br/>

            <br />
            <div className="statusMessage">
                  <br />
                    Status: {this.state.statusMessage}
                </div>             
          </div>
          
        );
    }
}


export default KeyPadComponent;
