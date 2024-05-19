# GlobalProcess

## Overview
GlobalProcess is a dynamic business process management application designed to allow admin users to define workflows, steps, and dynamic forms. This application is built using ASP.NET Core 8 and Entity Framework Core.

## Project Structure

### GlobalProcess.Application
- **Purpose**: Contains business logic and application services.
- **Key Components**:
  - `Services/WorkflowService.cs`: Manages workflow-related business logic.

### GlobalProcess.Core
- **Purpose**: Contains core domain models and interfaces, representing the business logic without dependencies on other layers.
- **Key Components**:
  - `Interfaces/IRepository.cs`: Defines the repository interface.
  - `Models/`: Contains entity and data models such as:
    - `ActionItem.cs`
    - `ApplicationUser.cs`
    - `BaseEntity.cs`
    - `BusinessProcess.cs`
    - `BusinessProcessInstance.cs`
    - `Comment.cs`
    - `DynamicField.cs`
    - `DynamicForm.cs`
    - `EmailTemplate.cs`
    - `FieldPermissions.cs`
    - `FieldValue.cs`
    - `Step.cs`
    - `UserGroupPermission.cs`
    - `Workflow.cs`

### GlobalProcess.Infrastructure
- **Purpose**: Manages data access, repositories, and external services.
- **Key Components**:
  - `Data/AppDbContext.cs`: Defines the application's data context.
  - `Repositories/Repository.cs`: Implements the repository pattern for data access.

### GlobalProcess.Web
- **Purpose**: Contains the web UI and API controllers, handling user interactions and HTTP requests.
- **Key Components**:
  - `Controllers/`: Handles HTTP requests for various parts of the application.
    - `AccountController.cs`: Manages user accounts and authentication.
    - `AdminController.cs`: Provides endpoints for admin operations.
    - `HomeController.cs`: Handles basic navigation and home page requests.
    - `WorkflowController.cs`: Manages workflows and related actions.
  - `Models/`: Contains view models for the web application.
  - `Program.cs`: The entry point of the application.
  - `Properties/`: Contains project properties such as assembly info.
  - `Views/`: Contains Razor views for rendering UI components.
  - `appsettings.json` and `appsettings.Development.json`: Configuration settings for the application.
  - `wwwroot/`: Static files for the web application.

## Dependencies
- ASP.NET Core 8
- Entity Framework Core
- Other necessary packages (specify if there are additional packages)

## Setup Instructions

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- A SQL Server instance for the database (or another supported database).

### Steps

1. **Clone the repository**:
   ```sh
   git clone https://github.com/betsenbaby/GlobalProcess.git

2. **Navigate to the project directory**:
   ```
   cd GlobalProcess/GlobalProcess-master

3. **Install dependencies**:
   ```
   dotnet restore

4. **Configure the database connection**:
   ```
   Update the connection string in appsettings.json to point to your database

5. **Apply migrations to set up the database**:
   ```
   dotnet ef database update

6. **Run the application**:
   ```
   dotnet run

### Areas of Focus

- **Workflow and Dynamic Form Implementation**: Review the implementation of workflows and dynamic forms.
- **Permissions Management**: Check how user/group permissions are managed for each step in the workflow.
- **Specific Concerns**: Address any specific concerns or questions mentioned.

### Contribution Guidelines
- Fork the repository.
- Create a new branch for your feature or bugfix.
- Commit your changes and pu to your branch.
- Create a pull request with a description of your changes.

### License
Specify the license under which the project is distributed.

### Contact
For any questions or suggestions, please contact Betsen.