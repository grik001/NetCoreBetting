#Brand X#

The solution has been split up into 2 separate projects. An API to be used as a gateway for both Fronts. An Admin MVC application which will connect to the API to retrieve all the data and manage the inventory.

All application have been implemented using the C# and .net core 1.1.

The API is using JWT to authenticate requests. It will also be pushing updates towards both website using websockets, the Microsoft library was used for the websocket implementation. 

The Games controller will be utilizing redis cache to maintain fast retrieval of games both for Moderators and Clients. The API will then update the database and will push an update to the clients subscribed thus receiving instant updates.

###Database###

The database script has been included in the solution. A sample database has been left running on Azure to be able to test prototype without creating the database. If creating database locally, create database named "BrandxStore" first and execute attached script. Sample data has also been included with the script.

###RedisCache###

Redish cahce needs to be setup locally and the connectionstring will also need to be updated to be able to run the API. As an alternative a test RedisCache service has been left running on Azure to be able to run the application without installing Redis.

###Azure Hosting###

The API is hosted on azure thus no urls need to be updated upon running solution locally. I tried to also host the website on Azure but got stuck setting up React.

If testing API using postman remember to request token first from api/token.

API Url: http://brandxgatewayapirest.azurewebsites.net/api/

###Libraries###

The following libraries have been added. 

Data, Common, Entities.

Data: Data contains all the code that connects with the database to retrieve any data. The code has been abstracted out of the controllers to allow change of Database if required.

Common: Any repeated functions have also been abstracted out of the controllers.

Entities: This layer contains View models shared between Fronts and all the Objects generated for the Database which are currently using the EntityFramework library.

###Running Application###

The application was developed using Visual Studio 2017. Open the application and ensure that both applications: AdminFront and API are set as startup projects. Once set hit run.

The following credentials can be used to login to test: Username: 

test@test.com Password: Test1234$

###UnitTests###

VisualStudio Testing Framework has been used to generate a test project. Ideally you should use VS2017 to execute these tests.

* Step 1: Open Project using VS2017
* Step 2: Build
* Step 3: If build is sucessfully open Text Explorer found under the Test section.
* Step 4: Select process to run all or specific tests using the menu.


