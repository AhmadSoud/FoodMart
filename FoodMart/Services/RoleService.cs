using FoodMart.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoodMart.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly FoodMartContext _context;
        public RoleService(RoleManager<IdentityRole> roleManager, FoodMartContext context)
        {
            _roleManager = roleManager;
            _context = context;


        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {

            if (!await _roleManager.RoleExistsAsync(roleName)) // اذا ال roleName الي بدي ابعثه من الصفحة غير موجود قم باضافته 
            {
             var result=   await _roleManager.CreateAsync(new IdentityRole(roleName));//هذه الاضافة  اذا تحقق الشرط 
                return result.Succeeded;

            }
            return false;
        
        }
        public async Task<List<IdentityRole>> GetAllRolesAsync() 
        {
            return await _context.Roles.ToListAsync();
        }


        public async Task<IdentityRole> GetRoleById(string id) 
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<bool> UpdateRole(string id, string roleName)

        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) 
                return false;
                role.Name= roleName;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return (true);

            }
            else
            {
                return false;
            }




        }
        public async Task<bool> DeleteRole(string id)
        {
            var role= await _roleManager.FindByIdAsync(id);
            if(role == null)
                return false;
            var result= await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return (true);
            }
            else 
            {
                return false;
            }
        }


    }

}
