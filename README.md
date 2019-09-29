# boilerplate-netcore-api-mysql

.Net Core Api with MySql boilerplate using The Repository Pattern

Repository Pattern allows us to create an abstraction layer between the data access layer and the business logic layer of an application. So, this Data Access Pattern offers a more loosely coupled approach to data access. So, we are able to create the data access logic in a separate class, called a Repository, which has the responsibility of persisting the application’s business model.

### Folder structure options and naming conventions for software projects

    .
    ├── Apps                    # Source files (alternatively `lib` or `app`)
        └── Controllers             # For controller path
        └── DataSeeders             # Additional data seeders
        └── Dtos                    # In or out Dtos
        └── Extensions              # Code extension (ex: CreateMapper)
        └── Interfaces              # Abstraction code for repository
        └── Models                  # Initial object in database (code first)
        └── Repository              # Code for data access layer
        └── Utils                   # General code for reusable
    ├── AppsTest                # Automated tests source files unit test
    ├── bin                     # Compiled files
    ├── Extensions              # Source for middleware code
    ├── Libs                    # Additional Library
    ├── Logs                    # Logging run program
    └── README.md

> Use uppercase names at files and folders except

### Package List

1. Microsoft.AspNetCore.Mvc.Versioning v3.1.6
2. Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer v3.2.1
3. Microsoft.EntityFrameworkCore v2.2.6
4. MySql.Data.EntityFrameworkCore v8.0.17
5. Serilog v2.8.0
6. Swashbuckle.AspNetCore v4.0.1
7. xunit v2.4.1
8. Automapper v9.0.0
9. AspNetCore.HealthChecks v2.2.2

## Prerequirements

- [Visual Studio 2017 / Visual Studio code](https://code.visualstudio.com/download)
- [The .NET Core 2.2 SDK](https://www.microsoft.com/net/core)
- [MySQL](https://www.mysql.com/)

## How To Run

1. Clone this project

```Console
 git clone https://github.com/dhanisulistiyo/boilerplate-netcore-api.git

```

2. Move to

```Console
cd boilerplate-netcore-api

```

3. Restore dependencies:

```Console
dotnet restore

```

4. Create Migration:

```Console
dotnet ef migrations add InitialCreate

```

5. Apply Migration:

```Console
dotnet ef database update

```

6. For Run server:

```Console
dotnet run
# or with custom port
dotnet run --urls="http://*:{port}"
```

7. For Unit test: (Optional)

```Console
# Copy .appsetting.json to <ProjectName>\bin\Debug\netcoreapp2.2
dotnet test

```
