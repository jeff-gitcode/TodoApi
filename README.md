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
   ```sh
   git clone <repository-url>
   ```

### Authenticate and get JWT token

4. Copy the JWT token from the response.
5. Replace the `{{jwt_token}}` placeholder in the [requests.http](http://_vscodecontentref_/5) file with the actual JWT token.
6. Send requests to the API endpoints by clicking on the "Send Request" link above each request in the [requests.http](http://_vscodecontentref_/6) file.

### Example [requests.http](http://_vscodecontentref_/7) File

```http
### Get all todos
GET http://localhost:5000/api/todos
Authorization: Bearer {{jwt_token}}

###

### Create a new todo
POST http://localhost:5000/api/todos
Content-Type: application/json
Authorization: Bearer {{jwt_token}}

{
  "title": "New Todo"
}

###

### Update an existing todo
PUT http://localhost:5000/api/todos/1
Content-Type: application/json
Authorization: Bearer {{jwt_token}}

{
  "title": "Updated Todo"
}

###

### Delete a todo
DELETE http://localhost:5000/api/todos/1
Authorization: Bearer {{jwt_token}}

###

### Authenticate and get JWT token
POST http://localhost:5000/api/authenticate
Content-Type: application/json

{
  "username": "your_username",
  "password": "your_password"
}