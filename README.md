Basic Explanation:

The solution has been split up into 3 seperate projects. An API to be used as a gateway for both Fronts. A client MVC application which will connect to the API to retreive all the data and an Admin MVC application to manage the inventory.

All application have been implemented using the C# and .net core 1.1.

The API is using JWT to authenticate requests. It will also be pushing updates to both website towards any websockets subscribers, the Microsoft library was used for the websocket implementation. The API will be exposing the Games & Messages controllers.

The Games controller will be utilizing redis cache to maintain fast restreival of games both for Moderators and Clients. The API will then update the database and will push an update to the clients subscribed thus receiving instant updates.

The Client website so far will allow the clients to interfact by: Loging in, viewing instant messages from Moderators and receive rewards. Since this just a concept only the bare minimum has been developed for each function.

Database:

The database script has been included in the soluation. A sample database has been left running on Azure to be able to test prototype without creating the database.

RedisCache:

Redish cahce needs to be setup locally and update connectionstring to be able to run the API. As an alternative a test RedisCache service has been left running on Azure to be able to run the application with installing Redis.

Hosting:

The applications have also been hosted on Azure for presentation. Feel free to build and run code on your local machine.

API Url:
ClientFront Url:
AdminFront Url:

Libraries:

The following libraries have been added to abstract code. Data, Common, Entities.

Data: Data contains all the code that connects with the database to retreive any data. The code has been abstracted out of the controllers to allow change of Database if required.

Common: Any repeated functions have also been abstracted out of the controllers. Also, any clients that connect to APIs have been abstracted here to allow IoC.

Entities: This layer contains any View models shared between Fronts and all the Objects generated for the Database which are currently using the EntityFramework library.

Running Application:

The application was developed using Visual Studio 2017. Open the application ensure that all 3 applications: ClientFront, AdminFront and API are set as startup projects. After these have been set as startup hit Run.

The following credentials can be used to login to test: Username: 

Admin: test@test.com Password: Test1234$

UnitTests:

VisualStudio Testing Framework has been used to generate a test project. Ideally you should use VS2017 to execute these tests.

Step 1: Open Project using VS2017
Step 2: Build
Step 3: If build is sucessfully open Text Explorer found under the Test section.
Step 4: Process to run all or specific tests using the menu.




