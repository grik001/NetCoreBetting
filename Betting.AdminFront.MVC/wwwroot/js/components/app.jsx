import React, { Component } from 'react'
import { Router, Route, Link, IndexRoute, hashHistory, browserHistory } from 'react-router'

class App extends React.Component {

    render() {
        return (
            <Router history={hashHistory}>
                <Route path='/' component={Home} />
                <Route path='/address' component={Address} />
            </Router>
        );
    }
};

export default App