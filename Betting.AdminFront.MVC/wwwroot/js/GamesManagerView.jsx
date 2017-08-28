class GameCard extends React.Component {
    handleEnableGame = (event) => {
        event.preventDefault();

        var id = this.props.Id;
        axios.put("http://localhost:50048/api/games/" + id + "/" + "true").then(res => {
            this.props.onChange();
        });
    }

    handleDisableGame = (event) => {
        event.preventDefault();
        var id = this.props.Id;

        axios.put("http://localhost:50048/api/games/" + id + "/" + "false").then(res => {
            this.props.onChange();
        });
    }

    handleDeleteGame = (event) => {
        event.preventDefault();
        var id = this.props.Id;
        
        axios.delete("http://localhost:50048/api/games/" + id).then(res => {
            this.props.onChange();
        });
    }

    handleEdit = (event) => {
        event.preventDefault();

        var id = this.props.Id;
        this.props.onEdit(this.props.Id)
    }


    render() {
        return (
            <div className="col-md-4">
                {this.props.IsActive ?
                    <img width="100%" height="100%" src={this.props.ImageUrl} />
                    :
                    <img width="100%" style={{ filter: 'grayscale(100%)' }} height="100%" src={this.props.ImageUrl} />
                }
                <div><h4>{this.props.Description}</h4></div>
                <div className="col-md-12">
                    {this.props.IsActive ?
                        <button onChange={this.props.onChange} onClick={this.handleDisableGame} className="col-md-6" width="100%" type="submit">Deactivate</button>
                        :
                        <div>
                            <button onClick={this.handleEnableGame} className="col-md-6" width="100%" type="submit">Activate</button>
                            <button onClick={this.handleDeleteGame} className="col-md-6" width="100%" type="submit">Delete</button>
                            <button onClick={this.handleEdit} className="col-md-6" width="100%" type="submit">Edit</button>
                        </div>
                    }
                </div>
            </div>
        );
    };
};

class GameList extends React.Component {
    handleSubmit = (event) => {
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div className="col-md-12">
                    {this.props.data.map(movie =>
                        <GameCard onChange={this.props.onChange} onEdit={this.props.onEdit} key={movie.Id} Id={movie.Id} Title={movie.Title} Description={movie.Description} IsActive={movie.IsActive} ImageUrl={movie.ImageUrl} />
                    )}
                </div>
            </form>
        );
    };
};


class GameModify extends React.Component {
    state = { currentGame: {} };

    handleTitleChange = (event) => {
        this.props.currentGame.Code = event.target.value;
        this.setState({ currentGame: this.props.currentGame });
        this.forceUpdate();

    }

    handleDescriptionChange = (event) => {
        this.props.currentGame.Description = event.target.value;
        this.setState({ currentGame: this.props.currentGame });
        this.forceUpdate();

    }

    handleImageUrlChange = (event) => {
        this.props.currentGame.ImageUrl = event.target.value;
        this.setState({ currentGame: this.props.currentGame });
        this.forceUpdate();
    }

    handlePushGame = (event) => {
        event.preventDefault();

        var data = { Id: this.props.currentGame.Id, Code: this.props.currentGame.Code, description: this.props.currentGame.Description, ImageUrl: this.props.currentGame.ImageUrl }

        if (data.Id == '') {
            axios.post("http://localhost:50048/api/games", data).then(res => {
                this.setState({ gameTitle: "" });
                this.setState({ gameDescription: "" });
                this.setState({ gameImageUrl: "" });
            });
        }
        else {
            axios.post("http://localhost:50048/api/games/" + data.Id, data).then(res => {
                this.setState({ gameTitle: "" });
                this.setState({ gameDescription: "" });
                this.setState({ gameImageUrl: "" });
            });
        }
    }

    handleClearGame = (event) => {
        event.preventDefault();

        this.setState({ gameTitle: "" });
        this.setState({ gameDescription: "" });
        this.setState({ gameImageUrl: "" });
    }


    render() {
        return (
            <div className="col-md-12">
                <label className="col-md-12">Title</label>
                <div className="col-md-12">
                    <input onChange={this.handleTitleChange} value={this.props.currentGame.Title} type="text" />
                </div>
                <label className="col-md-12">Description</label>
                <div className="col-md-12">
                    <textarea onChange={this.handleDescriptionChange} className="form-control" value={this.props.currentGame.Description} style={{ minWidth: "100%" }}></textarea>
                </div>
                <label className="col-md-12">ImageUrl</label>
                <div className="col-md-12">
                    <textarea onChange={this.handleImageUrlChange} className="form-control" value={this.props.currentGame.ImageUrl} style={{ minWidth: "100%" }}></textarea>
                </div>
                <div className="col-md-12">
                    <button onClick={this.handlePushGame} className="col-md-6">Update</button>
                    <button onClick={this.handleClearGame} className="col-md-6">Clear</button>
                </div >
            </div>
        );
    };
};


class App extends React.Component {
    state = { dataActive: [], currentGame: {Id: '', Code : '', Description:'', ImageUrl:''} };

    fetchData = () => {
        axios.get('http://localhost:50048/api/games')
            .then(res => {
                console.log(res);
                const games = res.data.entity.map(obj => ({
                    Id: obj.id, Title: obj.code, Description: obj.description, ImageUrl: obj.imageUrl, IsActive: obj.isActive
                }));

                this.setState({ dataActive: games });
            });
    }

    loadGame = (id) => {
        
        axios.get('http://localhost:50048/api/games/' + id)
            .then(res => {
                this.setState({ currentGame: res.data.entity });
                console.log(this.state.currentGame);
            });
    }

    componentWillMount() {
        this.fetchData();
    }

    componentDidMount() {
        var uri = "ws://" + "localhost:50048" + "/notifications";
        this.connection = new WebSocket(uri)
        this.connection.onmessage = e => {
            var resultObj = JSON.parse(e.data);
            this.state.dataActive.push(resultObj.data);
            this.forceUpdate();
        }
        this.connection.onerror = e => this.setState({ error: 'WebSocket error' })
        this.connection.onclose = e => !e.wasClean && this.setState({ error: `WebSocket error: ${e.code} ${e.reason}` })
    }

    render() {
        return (
            <div>
                <div className="col-md-12">
                    <h3>Games</h3>
                    <GameList onChange={this.fetchData} onEdit={this.loadGame} data={this.state.dataActive} />
                </div>
                <div className="col-md-12">
                    <h3 >Manage Games</h3>
                    <GameModify currentGame={this.state.currentGame} />
                </div>
            </div>
        );
    }
};

ReactDOM.render(
    <App />,
    document.getElementById('content')
);
