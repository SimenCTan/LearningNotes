import React from "react";
import ReactDOM from "react-dom/client";
import asabenehImage from "./images/asabeneh.jpg";

// button component
const Button = ({text,onclick,style})=>(
  <button style={style} onClick={onclick}>{text}</button>
  );

// CSS styles in JavaScript Object
const buttonStyles = {
  backgroundColor: '#61dbfb',
  padding: 10,
  border: 'none',
  borderRadius: 5,
  margin: '3px auto',
  cursor: 'pointer',
  fontSize: 22,
  color: 'white',
}

// class base component
class Header extends React.Component {
  render(){
    console.log(this.props.data);
    const {
      welcome,
      title,
      subtitle,
      author:{firstName,lastName},
      date
    }=this.props.data;

     return (
    <header>
       <div className='header-wrapper'>
          <h1>{welcome}</h1>
          <h2>{title}</h2>
          <h3>{subtitle}</h3>
          <p>
            {firstName} {lastName}
          </p>
          <small>{date}</small>
          <p>Select a country for your next holiday</p>
        </div>
    </header>
    )
  }
}

class App extends React.Component {
  state = {
    count: 0,
    loggedIn:false,
    styles: {
      backgroundColor: "",
      color: "",
    },
  };
  showDate = (time) => {
    const months = [
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
      "August",
      "September",
      "October",
      "November",
      "December",
    ];

    const month = months[time.getMonth()].slice(0, 3);
    const year = time.getFullYear();
    const date = time.getDate();
    return ` ${month} ${date}, ${year}`;
  };
  addOne = () => {
    this.setState({ count: this.state.count + 1 });
  };

  // method which subtract one to the state
  minusOne = () => {
    this.setState({ count: this.state.count - 1 });
  };
  handleTime = () => {
    alert(this.showDate(new Date()));
  };
  greetPeople = () => {
    alert("Welcome to 30 Days Of React Challenge, 2020");
  };
handleLogged=()=>{
this.setState({loggedIn:!this.state.loggedIn,count:this.state.count+1})
}

  changeBackground = () => {};
  render() {
    const data = {
      welcome: "Welcome to 30 Days Of React",
      title: "Getting Started React",
      subtitle: "JavaScript Library",
      author: {
        firstName: "Asabeneh",
        lastName: "Yetayeh",
      },
      date: "Oct 7, 2020",
    };
    const techs = ["HTML", "CSS", "JavaScript"];
    const date = new Date();
    // copying the author from data object to user variable using spread operator
    const user = { ...data.author, image: asabenehImage };
    let status;
    let text;
    if(this.state.loggedIn){
      status = <h3>Welcome to 30 Days Of React</h3>
      text = "Logout"
    }else{
      status = <h3>Please Login</h3>
      text = "Login"
    }
    return (
      <div className="app">
       <Header data={data}/>
       {status}
       <Button text={text} style={buttonStyles} onclick={this.handleLogged}/>
      </div>
    );
  }
}

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    {/* <User firstName = 'Asabeneh' lastName='Yetayeh' country = 'Finland' /> */}
    {<App />}
  </React.StrictMode>
);
