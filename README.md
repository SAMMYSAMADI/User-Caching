**Repository Structure
--------------------------**


Public API used: https://jsonplaceholder.typicode.com/users

**Installation**

------------
-Clone the Repository
git clone https://github.com/SAMMYSAMADI/User-Caching.git

-Create the Database and the table using schema.sql


**Backend - UserCachingApi
------------------------**

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



**Steps to Setup the Backend**

---------------------------

1\. Navigate to the backend folder

cd UserCachingApi

2\. Configure the Database Connection in appsettings.json

* Open appsettings.json
* Update the connection string with your database details

3\. Restore Dependencies 

* dotnet restore

4\. Build the Backend

* dotnet build

5\. Run the Backend

* dotnet run

6\. Open Swagger and do the testing
http://localhost:5100/swagger


--------------------------------------------------------



**Steps to Setup the Frontend
---------------------------**



1\. Navigate to the backend folder

* cd UserCachingUi

2\. Install dependencies

* npm install

3\. Configure API base URL

* Check src/app/services/user.service.ts
  http://localhost:5100/api/users

4.Run the frontend

* ng serve

5\. Open it in browser

* http://localhost:4200








