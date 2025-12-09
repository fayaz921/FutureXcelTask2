using FutureXcelTask2.Models;

namespace FutureXcelTask2.Services
{
    public interface IAuthServices
    {
        Task<User?> Signup(SignupRequest request);
        Task<string?> Login(LoginRequest request);
        Task<User?> GetUserByEmail(string email);
    }
}
