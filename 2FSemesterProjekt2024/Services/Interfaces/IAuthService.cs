using _2FSemesterProjekt2024.Models;
namespace _2FSemesterProjekt2024.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidateCredentials(string email, string password, out string userType, out int userId);
    }

}
