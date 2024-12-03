
# .NET JWT Authentication Demo

This project demonstrates implementing JWT (JSON Web Token) authentication in a .NET application. It provides a secure way to authenticate users and protect API endpoints.

## Features

- **User Authentication**: Users can log in using credentials, receiving a JWT upon successful authentication.
- **Protected Endpoints**: Secured routes require a valid JWT for access.
- **Token Validation**: Middleware ensures tokens are verified before granting access.
- **Role-Based Access Control (Optional)**: Implement authorization based on user roles.

## Technologies Used

- **Framework**: .NET Core or .NET 6
- **Authentication**: JWT
- **Middleware**: ASP.NET Core for request handling and token verification

## Setup and Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/dotnet-jwt-demo.git
   cd dotnet-jwt-demo
   ```

2. **Install Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure AppSettings**:
   Update the `appsettings.json` file with your secret key and token expiration settings:
   ```json
   "JwtSettings": {
     "Secret": "YourSecretKeyHere",
     "Issuer": "YourIssuer",
     "Audience": "YourAudience",
     "ExpirationMinutes": 60
   }
   ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

5. **Test the Endpoints**:
   Use tools like Postman or cURL to test authentication and secured routes.

## How It Works

1. **User Login**:
   - Endpoint: `/api/auth/login`
   - Accepts user credentials (username and password).
   - Returns a JWT on successful authentication.

2. **Secured Endpoints**:
   - Example: `/api/protected/resource`
   - Requires a valid JWT in the `Authorization` header as a Bearer token.
   - Unauthorized requests return a 401 error.

3. **Token Verification**:
   - Middleware validates the JWT for integrity and expiry.
   - Decoded tokens provide user claims for role-based access.

## Example Endpoints

- **Login**:
  ```http
  POST /api/auth/login
  Body: { "username": "user", "password": "password" }
  Response: { "token": "jwt-token-here" }
  ```

- **Protected Resource**:
  ```http
  GET /api/protected/resource
  Headers: { "Authorization": "Bearer jwt-token-here" }
  ```

## Enhancements (Optional)

- **Refresh Tokens**: Implement refresh tokens for extended session management.
- **Role-Based Authorization**: Define roles in claims and restrict access based on roles.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
