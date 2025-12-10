# FutureXcel Task 2 - Authentication System

A secure authentication system built with ASP.NET 9 Web API and vanilla JavaScript frontend.

## Features

- ✅ User Registration (Signup)
- ✅ User Login
- ✅ JWT Token-based Authentication
- ✅ HttpOnly Cookie Storage
- ✅ Password Hashing with BCrypt
- ✅ Protected API Endpoints
- ✅ Form Validation
- ✅ Responsive UI with Bootstrap

## Tech Stack

### Backend
- ASP.NET 9 Web API
- Entity Framework Core
- SQL Server
- BCrypt.Net (Password Hashing)
- JWT Bearer Authentication

### Frontend
- HTML5
- CSS3
- Bootstrap 5
- JavaScript (ES6)
- jQuery

## Prerequisites

- .NET 9 SDK
- SQL Server
- Visual Studio 2022 or VS Code

## Installation & Setup

### 1. Clone the repository
```bash
git clone <your-repo-url>
cd FutureXcelTask2
```

### 2. Update Database Connection
Edit `appsettings.json` and update the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=FutureXcelTask2;Trusted_Connection=true;TrustServerCertificate=true"
}
```

### 3. Run Migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application
```bash
dotnet run
```

The API will be available at: `https://localhost:7289`

## API Endpoints

### Authentication

#### Signup
```http
POST /api/auth/signup
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "password123",
  "name": "John Doe"
}
```

#### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "password123"
}
```

#### Logout
```http
POST /api/auth/logout
```

#### Get Current User (Protected)
```http
GET /api/auth/me
Cookie: token=<jwt_token>
```

## Security Features

### Password Security
- Passwords are hashed using BCrypt
- Minimum password length: 6 characters
- Never stored in plaintext

### Token Security
- JWT tokens with 7-day expiration
- Stored in HttpOnly cookies (XSS protection)
- Secure flag enabled (HTTPS only)
- SameSite=Strict (CSRF protection)

### API Security
- CORS configured for specific origins
- Protected endpoints require authentication
- Token validation on every request

## Project Structure
```
FutureXcelTask2/
├── Controllers/
│   └── AuthController.cs
├── Models/
│   ├── User.cs
│   ├── SignupRequest.cs
│   ├── LoginRequest.cs
│   └── AuthResponse.cs
├── Services/
│   ├── IAuthServices.cs
│   └── AuthService.cs
├── Data/
│   └── ApplicationDbContext.cs
├── wwwroot/
│   ├── index.html
│   ├── signup.html
│   ├── login.html
│   ├
│   ├── css/
│   │   └── style.css
│   └── js/
│       └── app.js
├── appsettings.json
└── Program.cs
```

## Database Schema

### Users Table
| Column | Type | Constraints |
|--------|------|-------------|
| Id | int | Primary Key, Identity |
| Email | nvarchar(450) | Unique, Not Null |
| PasswordHash | nvarchar(max) | Not Null |
| Name | nvarchar(max) | Not Null |
| CreatedAt | datetime2 | Not Null, Default: UTC Now |

## Frontend Pages

1. **index.html** - Landing page
2. **signup.html** - User registration form
3. **login.html** - User login form


## Testing

### Manual Testing Steps

1. **Test Signup:**
   - Navigate to `/signup.html`
   - Fill in email, password, and name
   - Submit form
   - Should redirect to dashboard on success

2. **Test Login:**
   - Navigate to `/login.html`
   - Enter credentials
   - Submit form
   - Should redirect to dashboard on success

3. **Test Protected Route:**
   - Try accessing `/index.html` without login
   - Should redirect to login page
   - After login, should access dashboard successfully

4. **Test Logout:**
   - Click logout button
   - Should clear cookie and redirect to login

## Common Issues & Solutions

### Issue: CORS Error
**Solution:** Ensure your frontend URL is added in `Program.cs`:
```csharp
policy.WithOrigins("http://localhost:5112", "http://127.0.0.1:5112")
```

### Issue: Cookie not being set
**Solution:** Check that:
- API is running on HTTPS
- `credentials: 'include'` is set in fetch requests
- CORS `AllowCredentials()` is enabled

### Issue: Database connection failed
**Solution:** Verify SQL Server is running and connection string is correct

## Future Enhancements

- [ ] Email verification
- [ ] Password reset functionality
- [ ] Remember me option
- [ ] User profile updates
- [ ] Role-based authorization
- [ ] Refresh token implementation

## Author

**Built by Muhammad Fayaz**

## License

This project is part of FutureXcel Full Stack Development Program - Week 2

## Acknowledgments

- FutureXcel Training Program
- ASP.NET Core Documentation
- Bootstrap Documentation