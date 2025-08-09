using FoodMart.Models;
using Microsoft.AspNetCore.Identity;

namespace FoodMart.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(string roleName);
        Task<List<IdentityRole>> GetAllRolesAsync();



        Task<IdentityRole> GetRoleById(string id);

        Task<bool> UpdateRole(string id,string roleName);
        Task<bool> DeleteRole(string id);



    }
}
