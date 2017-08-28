class MessageCard extends React.Component {
    handleDeleteMessage = (event) => {
        event.preventDefault();
        console.log("test");
        var id = this.props.id;
        axios.delete("http://localhost:50048/api/messages/" + id).then(res => {
            this.props.onChange();
        });
    }

    handleEditMessage = (event) => {
        event.preventDefault();
        var id = this.props.id;

        axios.delete("http://localhost:50048/api/messages/" + id).then(res => {
            this.props.onChange();
        });
    }

    render() {
        return (
            <div className="col-md-12 messageCard">
                <div className="col-md-12"><h4>SEND TO:{this.props.TargetClient}</h4></div>
                <div className="col-md-12"><h3>{this.props.title}</h3></div>
                <div className="col-md-12"><h4>{this.props.text}</h4></div>
                <div className="col-md-12">
                    <button onChange={this.props.onChange} onClick={this.handleEditMessage} className="col-md-6" width="100%" type="submit">Edit</button>
                    <button onChange={this.props.onChange} onClick={this.handleDeleteMessage} className="col-md-6" width="100%" type="submit">Remove</button>
                </div>
            </div>
        );
    };
};

class MessageList extends React.Component {
    render() {
        return (
            <div className="col-md-12">
                {this.props.data.map(message =>
                    <MessageCard onChange={this.props.onChange} key={message.id} id={message.id} title={message.title} text={message.text} TargetClient={message.TargetClient} />
                )}
            </div>
        );
    };
};

class ClientEmailList extends React.Component {
    state = { selectValue: '' }

    handleChange = (event) => {
        this.setState({ selectValue: e.target.value });
    }

    render() {
        return (
            <select value={this.state.selectValue} onChange={this.handleChange} >
                {this.props.clients.map(client => <option key={client.id} value={client.id}>{client.email}</option>
             )}
            </select>
        );
    };
};

class MessageBox extends React.Component {
    state = { messageText: [], messageTitle: [], messageTargetEmail: '', emails: [] };

    handleTitleChange = (event) => {
        this.setState({ messageTitle: event.target.value });
    }

    handleTextChange = (event) => {
        this.setState({ messageText: event.target.value });
    }

    handleMessageTargetEmailChange = (event) => {
        this.setState({ messageTargetEmail: event.target.value });
    }

    handlePushMessage = (event) => {
        event.preventDefault();

        var data = { Title: this.state.messageTitle, Text: this.state.messageText }

        axios.post("http://localhost:50048/api/messages", data).then(res => {
            this.setState({ messageTitle: "" });
            this.setState({ messageText: "" });

            this.props.onChange();
        });
    }

    handleClearMessage = (event) => {
        event.preventDefault();

        this.setState({ messageTitle: "" });
        this.setState({ messageText: "" });
    }

    componentWillMount() {
        axios.get('http://localhost:50048/api/clients')
            .then(res => {

                console.log(res);

                const clientData = res.data.entity.map(obj => ({
                    id: obj.id, email: obj.email
                }));

                clientData.push({id: '', email: 'N/A'});
                this.setState({ emails: clientData });    
            });
    }

    render() {
        return (
            <div className="col-md-12">
                <label className="col-md-12">Title</label>
                <div className="col-md-12">
                    <input onChange={this.handleTitleChange} value={this.state.messageTitle} type="text" />
                </div>
                <label className="col-md-12">Text</label>
                <div className="col-md-12">
                    <textarea onChange={this.handleTextChange} className="form-control" value={this.state.messageText} style={{ minWidth: "100%" }}></textarea>
                </div>
                <label className="col-md-12">Target Client</label>
                <div className="col-md-12">
                    <ClientEmailList clients={this.state.emails} />
                </div>
                <label className="col-md-12">Text</label>
                <div className="col-md-12">
                    <button onClick={this.handlePushMessage} onChange={this.props.onChange} className="col-md-6">Push</button>
                    <button onClick={this.handleClearMessage} className="col-md-6">Clear</button>
                </div >
            </div>
        );
    };
};

class App extends React.Component {
    state = { messages: [] };

    fetchData = () => {
        axios.get('http://localhost:50048/api/messages')
            .then(res => {
                console.log(res);
                const messages = res.data.entity.map(obj => ({
                    id: obj.id, title: obj.title, text: obj.text, TargetClient: obj.targetClientId
                }));

                this.setState({ messages: messages });
            });
    }

    componentWillMount() {
        this.fetchData();
    }

    render() {
        return (
            <div className="col-md-12">
                <h1>Message Clients</h1>
                <div className="col-md-6">
                    <MessageList onChange={this.fetchData} data={this.state.messages} />
                </div>
                <div className="col-md-6">
                    <MessageBox onChange={this.fetchData} />
                </div>
            </div>
        );
    }
};

ReactDOM.render(
    <App />,
    document.getElementById('content')
);
