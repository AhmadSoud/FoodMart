using FoodMart.Models;

namespace FoodMart.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string username, string password,string phone, string Email, int Age );
        Task<List<ApplicationUser>> GetAllUsersAsync();


        Task<ApplicationUser> GetUserById(string id );

        Task<bool> UpdateUser( string id , string username , string email , string phone );
        Task<bool> DeleteUser( string id );
        Task <bool> LoginAsync( string username , string password , bool remember);

    }

}
