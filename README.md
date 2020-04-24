# CoreMusic
A multi layer .NET Core 3.1 API sample which implements multi layer architecture, Swagger documentation for API, model validation rules with FluentValidation, Repository and Unit of Work Patterns etc.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. Clone the repository to get  started.

### Prerequisites
* [NET Core SDK](https://dotnet.microsoft.com/download) - For building and running .Net Core applications 
* [MS SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - The project target database

### Running
Change the connection string properties of the default connection from the appsetings.json located in the API folder - src/CoreMusic.API
```
"Default": "server=<SERVER NAME>; database=<DATABASE NAME>; Trusted_Connection=True;"
                                        OR
"Default": "server=<SERVER NAME>; database=<DATABASE NAME>; user id=<USER ID>; password=<PASSWORD>"
```

From the root folder on the command line, run the following command:
```
dotnet run -p src/CoreMusic.Api/CoreMusic.Api.csproj
```
See [dotnet run command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run) for more details.

The above command will start up the API and migrate sample data into the database.

Open below localhost url on the browser:
```
https://localhost:5000/
```
This opens the Swagger documentation of the API. Try executing GET /Music, which returns all Music and associated Artist from the database.

Happy coding! :)

## Acknowledgments
* [Medium post](https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368) by Andre Lopes
