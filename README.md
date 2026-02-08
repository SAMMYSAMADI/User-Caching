Repository Structure
--------------------------

Backend - User-Caching-Api

UserCachingApi/

├── Controllers/

│   └── UsersController.cs

├── Data/

│   └── SqlConnectionFactory.cs

├── Models/

│   └── User.cs

├── Repositories/

│   ├── IUserRepository.cs

│   └── UserRepository.cs

├── Services/

│   ├── IExternalUserService.cs

│   └── ExternalUserService.cs

├── Program.cs

├── appsettings.json

└── Api.csproj



Public API used: https://jsonplaceholder.typicode.com/users



Steps to Setup the Backend

---------------------------

1\. Initially create the Database and the Table Refer schema.sql

2\. Clone the project and restore it

3\. Configure the Database Connection in appsettings.json

4\. Restore Dependencies 

\- Navigate to the backend folder

cd UserCachingApi

-Restore

dotnet restore

5\. Build the Backend

dotnet build

6\. Run the Backend

dotnet run

7\. Open Swagger and do the testing
http://localhost:5100/swagger




