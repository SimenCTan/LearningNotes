// index.js
import React, { Component } from "react";
import ReactDOM from "react-dom";

const options = [
  {
    value: "",
    label: "-- Select Country--",
  },
  {
    value: "Finland",
    label: "Finland",
  },
  {
    value: "Sweden",
    label: "Sweden",
  },
  {
    value: "Norway",
    label: "Norway",
  },
  {
    value: "Denmark",
    label: "Denmark",
  },
];

// mapping the options to list(array) of JSX options
const selectOptions = options.map(({ value, label }) => {
  <option value={value}>{label}</option>;
});
class App extends Component {
  constructor() {
    super();
  }
  state = {
    fristName: "",
    lastName: "",
    email: "",
    country: "",
    tel: "",
    dateOfBirth: "",
    favoriteColor: "",
    weight: "",
    gender: "",
    file: "",
    bio: "",
    skills: {
      html: false,
      css: false,
      javascript: false,
    },
    touched: {
      firstName: false,
      lastName: false,
    },
  };
  handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    if (type === "checkbox") {
      this.setState({ skills: { ...this.state.skills, [name]: checked } });
    } else if (type === "file") {
      console.log(type, "check here");
      this.setState({ [name]: e.target.files[0] });
    } else {
      this.setState({ [name]: value });
    }
  };
  handleBlur = (e) => {
    const { name, value } = e.target;
    this.setState({ touched: { ...this.state.touched, [name]: true } });
  };

  validate = () => {
    const errors = {
      firstName: "",
    };
    if (
      (this.state.touched.firstName && this.state.firstName.length < 3) ||
      (this.state.touched.firstName && this.state.firstName.length > 12)
    ) {
      errors.firstName = "First name must be between 2 and 12";
    }
    return errors;
  };

  handleSubmit = (e) => {
    e.preventDefault();
    const {
      firstName,
      lastName,
      email,
      tel,
      dateOfBirth,
      favoriteColor,
      weight,
      country,
      gender,
      bio,
      file,
      skills,
    } = this.state;

    const formattedSkills = [];
    for (const key in skills) {
      console.log(key);
      if (skills[key]) {
        formattedSkills.push(key.toUpperCase());
      }
    }
    const data = {
      firstName,
      lastName,
      email,
      tel,
      dateOfBirth,
      favoriteColor,
      weight,
      country,
      gender,
      bio,
      file,
      skills: formattedSkills,
    };
    /*
     the is the place where we connect backend api
     to send the data to the database
     */
    console.log(data);
  };
  render() {
    const { firstNameerr } = this.validate();

    return (
      <div className="App">
        <h3>Add Student</h3>
        <form onSubmit={this.handleSubmit} noValidate>
          <div className="row">
            <div className="form-group">
              <label htmlFor="firstName">First Name </label>
              <input
                type="text"
                name="firstName"
                value={this.state.firstName}
                onChange={this.handleChange}
                onBlur={this.handleBlur}
                placeholder="First Name"
              />{" "}
              <br />
              <small>{firstNameerr}</small>
            </div>
            <div className="form-group">
              <label htmlFor="lastName">Last Name </label>
              <input
                type="text"
                name="lastName"
                value={this.state.lastName}
                onChange={this.handleChange}
                placeholder="Last Name"
              />
            </div>
            <div className="form-group">
              <label htmlFor="email">Email </label>
              <input
                type="email"
                name="email"
                value={this.state.email}
                onChange={this.handleChange}
                placeholder="Email"
              />
            </div>
          </div>

          <div className="form-group">
            <label htmlFor="tel">Telephone </label>
            <input
              type="tel"
              name="tel"
              value={this.state.tel}
              onChange={this.handleChange}
              placeholder="Tel"
            />
          </div>

          <div className="form-group">
            <label htmlFor="dateOfBirth">Date of birth </label>
            <input
              type="date"
              name="dateOfBirth"
              value={this.state.dateOfBirth}
              onChange={this.handleChange}
              placeholder="Date of Birth"
            />
          </div>
          <div className="form-group">
            <label htmlFor="favoriteColor">Favorite Color</label>
            <input
              type="color"
              id="favoriteColor"
              name="favoriteColor"
              value={this.state.favoriteColor}
              onChange={this.handleChange}
              placeholder="Favorite Color"
            />
          </div>
          <div className="form-group">
            <label htmlFor="weight">Weight </label>
            <input
              type="number"
              id="weight"
              name="weight"
              value={this.state.weight}
              onChange={this.handleChange}
              placeholder="Weight in Kg"
            />
          </div>
          <div>
            <label htmlFor="country">Country</label> <br />
            <select name="country" onChange={this.handleChange} id="country">
              {selectOptions}
            </select>
          </div>

          <div>
            <p>Gender</p>
            <div>
              <input
                type="radio"
                id="female"
                name="gender"
                value="Female"
                onChange={this.handleChange}
                checked={this.state.gender === "Female"}
              />
              <label htmlFor="female">Female</label>
            </div>
            <div>
              <input
                id="male"
                type="radio"
                name="gender"
                value="Male"
                onChange={this.handleChange}
                checked={this.state.gender === "Male"}
              />
              <label htmlFor="male">Male</label>
            </div>
            <div>
              <input
                id="other"
                type="radio"
                name="gender"
                value="Other"
                onChange={this.handleChange}
                checked={this.state.gender === "Other"}
              />
              <label htmlFor="other">Other</label>
            </div>
          </div>

          <div>
            <p>Select your skills</p>
            <div>
              <input
                type="checkbox"
                id="html"
                name="html"
                onChange={this.handleChange}
              />
              <label htmlFor="html">HTML</label>
            </div>
            <div>
              <input
                type="checkbox"
                id="css"
                name="css"
                onChange={this.handleChange}
              />
              <label htmlFor="css">CSS</label>
            </div>
            <div>
              <input
                type="checkbox"
                id="javascript"
                name="javascript"
                onChange={this.handleChange}
              />
              <label htmlFor="javascript">JavaScript</label>
            </div>
          </div>
          <div>
            <label htmlFor="bio">Bio</label> <br />
            <textarea
              id="bio"
              name="bio"
              value={this.state.bio}
              onChange={this.handleChange}
              cols="120"
              rows="10"
              placeholder="Write about yourself ..."
            />
          </div>

          <div>
            <input type="file" name="file" onChange={this.handleChange} />
          </div>
          <div>
            <button>Submit</button>
          </div>
        </form>
      </div>
    );
  }
}

const rootElement = document.getElementById("root");
ReactDOM.render(<App />, rootElement);
