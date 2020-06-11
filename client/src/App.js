import React, { Component } from 'react';
import './App.css';

class App extends Component {
  state = {
    streak: null
  }

  componentDidMount() {
    fetch('https://productivity-tracker-api-2.azurewebsites.net/api/CommitStreak')
    .then(res => res.json())
    .then((data) => {
      this.setState({ streak: data })
      console.log(this.state.streak)
    })
    .catch(console.log)
  }

  render() {
    return (
      <div>
      <center><h1>Productivity Streak</h1></center>
          <div>
              <center><h3> Commit Streak: {this.state.streak} </h3></center>
          </div>
      </div>
    )
  }
}

export default App;
