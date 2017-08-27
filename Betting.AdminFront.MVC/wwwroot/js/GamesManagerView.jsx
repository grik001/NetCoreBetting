class GameCard extends React.Component {
    handleEnableGame = (event) => {
        event.preventDefault();

        var id = this.props.id;
        axios.put("http://localhost:50048/api/games/" + id + "/" + "true").then(res => {
            this.props.onChange();
        });
    }

    handleDisableGame = (event) => {
        event.preventDefault();
        var id = this.props.id;

        axios.put("http://localhost:50048/api/games/" + id + "/" + "false").then(res => {
            this.props.onChange();
        });
    }

    render() {
        return (
            <div className="col-md-4">
                <img width="100%" height="100%" src={this.props.imageUrl} />
                <div><h4>{this.props.description}</h4></div>
                <div className="col-md-12">
                    {this.props.isActive ?
                        <button onChange={this.props.onChange} onClick={this.handleDisableGame} className="col-md-6" width="100%" type="submit">Deactivate</button>
                        :
                        <button onChange={this.props.onChange} onClick={this.handleEnableGame} className="col-md-6" width="100%" type="submit">Activate</button>
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
                        <GameCard onChange={this.props.onChange} key={movie.id} id={movie.id} title={movie.title} description={movie.description} isActive={movie.isActive} imageUrl={movie.imageUrl} />
                    )}
                </div>
            </form>
        );
    };
};

class App extends React.Component {
    state = { dataActive: [], dataInActive: [] };

    fetchData = () => {
        axios.get('http://localhost:50048/api/games?status=true')
            .then(res => {
                console.log(res);
                const games = res.data.entity.map(obj => ({
                    id: obj.id, title: obj.code, description: obj.description, imageUrl: obj.imageUrl, isActive: obj.isActive
                }));

                this.setState({ dataActive: games });
            });

        axios.get('http://localhost:50048/api/games?status=false')
            .then(res => {
                console.log(res);
                const games = res.data.entity.map(obj => ({
                    id: obj.id, title: obj.code, description: obj.description, imageUrl: obj.imageUrl
                }));

                this.setState({ dataInActive: games });
            });
    }

    componentWillMount() {
        this.fetchData();
    }

    render() {
        return (
            <div>
                <h1>Active Games</h1>
                <div className="col-md-12">
                    <GameList onChange={this.fetchData} data={this.state.dataActive} />
                </div>
                <h1>InActive Games</h1>
                <div className="col-md-12">
                    <GameList onChange={this.fetchData} data={this.state.dataInActive} />
                </div>
            </div>
        );
    }
};

ReactDOM.render(
    <App />,
    document.getElementById('content')
);
