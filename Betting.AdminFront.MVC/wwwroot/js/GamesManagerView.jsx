class GameCard extends React.Component {
    handleEnableGame = (event) => {
        event.preventDefault();

        var id = this.props.Id;
        axios.put("http://brandxgatewayapirest.azurewebsites.net/api/games/" + id + "/" + "true").then(res => {
        });
    }

    handleDisableGame = (event) => {
        event.preventDefault();
        var id = this.props.Id;

        axios.put("http://brandxgatewayapirest.azurewebsites.net/api/games/" + id + "/" + "false").then(res => {
        });
    }

    handleDeleteGame = (event) => {
        event.preventDefault();
        var id = this.props.Id;

        axios.delete("http://brandxgatewayapirest.azurewebsites.net/api/games/" + id).then(res => {
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
                <div><h4>{this.props.Code}</h4></div>
                <div className="col-md-12">
                    {this.props.IsActive ?
                        <button onChange={this.props.onChange} onClick={this.handleDisableGame} className="col-md-6" width="100%" type="submit">Deactivate</button>
                        :
                        <div>
                            <button onClick={this.handleEnableGame} className="col-md-4" width="100%" type="submit">Activate</button>
                            <button onClick={this.handleDeleteGame} className="col-md-4" width="100%" type="submit">Delete</button>
                            <button onClick={this.handleEdit} className="col-md-4" width="100%" type="submit">Edit</button>
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
                    {this.props.data.map(game =>
                        <GameCard onChange={this.props.onChange} onEdit={this.props.onEdit} key={game.Id} Id={game.Id} Code={game.Code} Description={game.Description} IsActive={game.IsActive} ImageUrl={game.ImageUrl} EntryTime={game.EntryTime} />
                    )}
                </div>
            </form>
        );
    };
};


class GameModify extends React.Component {


    render() {
        return (
            <div className="col-md-12">
                <label className="col-md-12">Title</label>
                <div className="col-md-12">
                    <input onChange={this.props.handleTitleChange} value={this.props.currentGame.code} type="text" />
                </div>
                <label className="col-md-12">Description</label>
                <div className="col-md-12">
                    <input onChange={this.props.handleDescriptionChange} className="form-control" value={this.props.currentGame.description} style={{ minWidth: "100%" }} />
                </div>
                <label className="col-md-12">ImageUrl</label>
                <div className="col-md-12">
                    <input onChange={this.props.handleImageUrlChange} className="form-control" value={this.props.currentGame.imageUrl} style={{ minWidth: "100%" }} />
                </div>
                <div className="col-md-12">
                    <button onClick={this.props.handlePushGame} className="col-md-6">Update</button>
                    <button onClick={this.props.handleClearGame} className="col-md-6">Clear</button>
                </div >
            </div>
        );
    };
};


class App extends React.Component {
    state = { dataActive: [], currentGame: { id: '', code: '', description: '', imageUrl: '' } };

    fetchData = () => {
        axios.get('http://brandxgatewayapirest.azurewebsites.net/api/games')
            .then(res => {

                const games = res.data.entity.map(obj => ({
                    Id: obj.id, Code: obj.code, Description: obj.description, ImageUrl: obj.imageUrl, IsActive: obj.isActive, EntryTime: obj.entryTime
                }));

                this.setState({ dataActive: games });
            });
    }

    loadGame = (id) => {

        axios.get('http://brandxgatewayapirest.azurewebsites.net/api/games/' + id)
            .then(res => {
                this.setState({ currentGame: res.data.entity });
            });
    }

    componentWillMount() {
        this.fetchData();
    }

    componentDidMount() {
        var uri = "ws://" + "brandxgatewayapirest.azurewebsites.net" + "/notifications?test=t";
        this.connection = new WebSocket(uri)
        this.connection.onmessage = e => {
            var resultObj = JSON.parse(e.data);
            //var result = $.grep(this.state.dataActive, function (e) { return e.Id == resultObj.data.Id; });

            var elementPos = this.state.dataActive.map(function (x) { return x.Id; }).indexOf(resultObj.data.Id);

            
            if (elementPos == -1) {
                console.log('inserting');
                this.state.dataActive.push(resultObj.data);
            }
            else {
                this.state.dataActive[elementPos] = resultObj.data
            }

            this.setState({ dataActive: this.state.dataActive });
            this.forceUpdate();
        }

        this.connection.onerror = e => this.setState({ error: 'WebSocket error' })
        this.connection.onclose = e => !e.wasClean && this.setState({ error: `WebSocket error: ${e.code} ${e.reason}` })
    }

    handleTitleChange = (event) => {
        this.state.currentGame.code = event.target.value;
        this.setState({ currentGame: this.state.currentGame });
    }

    handleDescriptionChange = (event) => {
        this.state.currentGame.description = event.target.value;
        this.setState({ currentGame: this.state.currentGame });
    }

    handleImageUrlChange = (event) => {
        this.state.currentGame.imageUrl = event.target.value;
        this.setState({ currentGame: this.state.currentGame });
    }

    clearGame = () => {
        this.state.currentGame.id = '';
        this.state.currentGame.code = '';
        this.state.currentGame.description = '';
        this.state.currentGame.imageurl = '';
        this.state.currentGame.isactive = '';

        this.setState({ currentGame: this.state.currentGame });
    }

    handleClearGame = (event) => {
        this.clearGame();
    }

    handlePushGame = (event) => {
        var id = this.state.currentGame.id;


        if (id == '' || id == null) {
            var data = { Code: this.state.currentGame.code, Description: this.state.currentGame.description, ImageUrl: this.state.currentGame.imageUrl, IsActive: false };
            axios.post("http://brandxgatewayapirest.azurewebsites.net/api/games", data).then(res => {
            });
        }
        else {
            var data = { Id: this.state.currentGame.id, Code: this.state.currentGame.code, Description: this.state.currentGame.description, ImageUrl: this.state.currentGame.imageUrl, IsActive: this.state.currentGame.isactive };
            axios.put("http://brandxgatewayapirest.azurewebsites.net/api/games/" + data.Id, data).then(res => {
            });
        }
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
                    <GameModify handlePushGame={this.handlePushGame} handleTitleChange={this.handleTitleChange} handleDescriptionChange={this.handleDescriptionChange} handleImageUrlChange={this.handleImageUrlChange} handleClearGame={this.handleClearGame} currentGame={this.state.currentGame} />
                </div>
            </div>
        );
    }
};

ReactDOM.render(
    <App />,
    document.getElementById('content')
);
