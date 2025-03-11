# Todo API

This project is a .NET Core Todo API built using Clean Architecture principles. It utilizes Mini APIs, MediatR for CQRS, and JWT for authentication.

## Features

- **CRUD Operations**: Create, Read, Update, and Delete todo items.
- **JWT Authentication**: Secure endpoints with JWT tokens.
- **MediatR**: Implements the CQRS pattern for better separation of concerns.
- **Clean Architecture**: Organized into distinct layers for better maintainability.

## Project Structure

- **src/TodoApi**: Contains the main API project.
  - **Controllers**: Handles HTTP requests.
  - **Extensions**: Contains service registration extensions.
  - **Middleware**: Custom middleware for JWT validation.
  - **Program.cs**: Entry point of the application.
  - **appsettings.json**: Configuration settings.
  
- **src/Application**: Contains application logic.
  - **Behaviors**: Pipeline behaviors for MediatR.
  - **Interfaces**: Service interfaces.
  - **Services**: Implementation of application services.
  - **Features**: Commands and queries for todo items.

- **src/Domain**: Contains domain entities and exceptions.
  - **Entities**: Defines the TodoItem entity.
  - **Exceptions**: Custom exceptions for the application.
  - **ValueObjects**: Defines value objects like TodoStatus.

- **src/Infrastructure**: Contains infrastructure-related code.
  - **Persistence**: Database context and factory.
  - **Repositories**: Repository implementations.
  - **Services**: Services like JWT handling.

- **tests**: Contains unit tests for the application.

## Setup Instructions

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd TodoApi
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

4. Run the application:
   ```
   dotnet run --project src/TodoApi/TodoApi.csproj
   ```

5. Use tools like Postman or curl to interact with the API endpoints.

## Usage

- **Authentication**: Obtain a JWT token by authenticating a user.
- **Todo Endpoints**:
  - `GET /todos`: Retrieve all todos.
  - `POST /todos`: Create a new todo.
  - `PUT /todos/{id}`: Update an existing todo.
  - `DELETE /todos/{id}`: Delete a todo.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.