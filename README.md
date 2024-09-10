# TT.EMS
It is necessary to develop an application using data, create a table Employees (Id, FirstName, LastName, Age, Sex) SQL database can be used Manager Studio, the data must be filled in by yourself (a few records are enough). The application should consist of several layers (at the developer's discretion). Any technology can be used to query the database, at the discretion of the developer. The application must have an API to get the list of Employees, add, edit and delete them.

The client application should be a single page app on React.
 
Requirements
The application should provide the user with the following features:
1) displaying a list of already existing items;
2) create a new item and add it to the list;
3) edit any entry in the list;
4) deleting one or more entries from the list.
 
Data integrity requirements:
1) first name, last name and gender fields are mandatory;
2) age cannot be negative and must be in the range [18, 100].
 
If data integrity is violated, the user must be notified with the specific non-compliance with the field completion requirements. 
 
Design requirements:
1) records must be displayed as a scrollable list if the visible area is insufficient to display all items;
2) if the number of records in the list exceeds one, it is necessary to use a different color scheme for each even and odd line (maximum 2 colors for any number of records);
3) last name and first name must be displayed as a single line;
4) age must be displayed as a number with the postfix "years"
5) if there are no items in the list, the editing and deleting functionality should be unavailable, and instead of an empty list another template should be displayed informing that there are no items in the list;
6) in case of deleting one or more items from the list, the user should be asked to confirm this action.
 
To perform the task, you can use APIs with .NET Core or MVC Web APIs, not in principle. React application should be written using hooks, applying Redux is optional.

# Backend stack:
- Architecture: Monolith with DDD
- Virtualization: Docker
- Platform: .Net 8
- APIs : Minimal APIs
- ORM: EntityFrameworkCore
- SQRS: MediatR
- Logger: Serilog.AspNetCore
- Mapping: Mapster
- Resilience and transient-fault-handling: polly
- OpenAPI Specification: Swagger

- Db: PostgreSql
- DbManager: pgadmin

# Frontend stack:
- react: 18.3.1
- react-axios: 2.0.6
- react-dom": 18.3.1

# How to start the project
Required Environment: Docker.

Running commands from the root path.

CLR commands for terminal:

- Debug:
        docker compose -f "docker-compose.debug.yml" up -d --build

- Prod:
        docker compose -f "docker-compose.yml" up -d --build

# How to look at the project

- Frontend: http://localhost:3000/

- BackEnd: http://localhost:5054/swagger/index.html

- DbManager: http://localhost:7000/