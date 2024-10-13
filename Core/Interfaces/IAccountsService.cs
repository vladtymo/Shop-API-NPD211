using Core.Models;

namespace Core.Interfaces
{
    public interface IAccountsService
    {
        Task Register(RegisterModel model);

        // Login
        // Logout
    }
}
