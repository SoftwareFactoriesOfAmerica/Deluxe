import React, { Component } from 'react';
import './App.css';
import ResultComponent from './components/ResultComponent';
import KeyPadComponent from "./components/KeyPadComponent";

class App extends Component {
    constructor(){
        super();

        this.state = {
            result: "",
            statusMessage: "Status: waiting...",
            grandTotal: 0,
            memoryStore: 0
        }
    }

    onClick = button => {
        switch (button)
        {
            case "=":
                this.calculate()
                break;
            case "GT":
                this.setState({
                    result: this.state.grandTotal
                })                               
                break;               
            case "MC":
                this.reset();
                break;
            case "MR":
                this.setState({
                    result: this.state.memoryStore
                })   
                break;     
            case "M-":
                this.setState({
                    memoryStore: 0
                })
                break;    
            case "M+":
                this.setState({
                    statusMessage: 'Memory set...',
                    memoryStore: this.state.result
                })
                break;                                       
            case "CE":
                this.backspace();   
                break;
            case "C":
                this.setState({
                    result: ''
                })  
                break;              
            case "+/-":
                try {
                    let sign = this.state.result
                    if (sign.startsWith('-')) {
                        this.state.result = sign.replace('-', '')
                    } else {
                        this.state.result = '-' + this.state.result
                    }
                } catch {}
                this.setState({
                    result: this.state.result
                })                            
                break;
            case "%":
                this.setState({
                    result: this.state.result *.01
                })                               
                break;
            default:
                this.setState({
                    result: this.state.result + button
                })                
            }
    };

    calculate = () => {
        var checkResult = ''
        if(this.state.result.includes('--')){
            checkResult = this.state.result.replace('--','+')
        }
        else {
            checkResult = this.state.result
        }
        try {
            this.setState({
                result: (eval(checkResult) || "" ) + "",
                grandTotal: eval(checkResult)
                //grandTotal: this.state.grandTotal + eval(checkResult)
            })
        } catch (e) {
            this.setState({
                result: "error",
                className: "resultError",
                statusMessage: e
            })
            //alert(e);
        }
    };
 
    reset = () => {
        this.setState({
            result: "",
            grandTotal: 0,
            memoryStore: 0
        })
    };

    backspace = () => {
        try {
        this.setState({
            result: this.state.result.slice(0, -1)
            })
        }
        catch { }
    };

    render() {
        return (
            <div>
            <br />
                <div className="calculator-body">
                    <img src="https://www.deluxe.com/etc.clientlibs/deluxe/clientlibs/main/resources/img/deluxe_logo_2020.svg"
                    alt="Deluxe">
                        </img>
                    &nbsp;&nbsp;<label width="100%" style={{fontSize: "30px"}}>Accountant Calculator</label>
                    <ResultComponent result={this.state.result}/>
                    <KeyPadComponent onClick={this.onClick}/>
                </div>
            </div>
        );
    }
}

export default App;
