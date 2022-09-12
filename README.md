# RJP

.Net Core Project built with clean design and architecture using CQRS and MediatR pattern

<strong>Key Features</strong><br />
-Onion Architecture<br />
-CQRS<br />
-MediatR pattern<br />
-Serilog<br />
-Custom Exception Handling<br />
-Custom Exception Middleware<br />
-Swagger<br />
-Validation using Fluent Validation<br />

# Description
The Project consists of 3 main microservices (APIs) that contain endpoints for all CRUD operations<br />
-CustomerService.API<br />
-AccountService.API<br />
-TransactionService.API<br />


# Packages Installed
MediatR<br />
Automapper<br />
Fluent Validation<br />
Entity Framework Core<br />
Serilog<br />
Moq<br />
Shouldly<br />
Swagger<br />

# Running the Project
To run the project please do the following: <br />
  Chnge the connection string in each appsettings.json file as required<br />
  Open the Package Manager Console<br />
  Make Sure that the RJP.Persistence project is set as Default Project.<br />
  Write the following commands in the package manager console"<br />
&nbsp;&nbsp;-add-migration "migration-name"<br />
&nbsp;&nbsp;-update database<br />
  Make Sure all required packages are installed with the correct versions.<br />
