using FoodMart.Models;
using Microsoft.AspNetCore.Identity;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using FoodMart.Data;
using Microsoft.EntityFrameworkCore;

 
namespace FoodMart.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FoodMartContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager; 
        public UserService (UserManager<ApplicationUser> userManager, FoodMartContext context, SignInManager<ApplicationUser> signInManager)
            
        
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        
        
        }
        public async Task<bool> CreateUserAsync(string username, string password, string phone, string Email, int Age)
        {

            var user = new ApplicationUser
            {
                UserName = username,
                Email = Email,
                PhoneNumber= phone,
                Age=Age,


            }; 
          var result =  await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {

                return (true);
            
            
            }
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"[ERROR] {error.Code}: {error.Description}");
            }

            return false;

        }
        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<ApplicationUser> GetUserById(string id) 
        {
            return await _userManager.FindByIdAsync(id);

        }

        public async Task<bool> UpdateUser(string id, string username, string email, string phone) 
        {
         var user= await _userManager.FindByIdAsync(id);
            if (user == null)
                return false;
            user.Email = email;
            user.UserName = username;
            user.PhoneNumber = phone;

            var result =await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return (true);

            }
            else 
            {
                return false;
            }

        }
        public async Task<bool> DeleteUser(string id) 
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
                return false;
            var result=await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return (true);
            }
            else 
            {
                return false;
            }

        
        }
       public async Task<bool> LoginAsync(string username, string password, bool remember) 
        {
            var result =  await   _signInManager.PasswordSignInAsync(username, password, remember,lockoutOnFailure:false);
            if (result.Succeeded) 
            { 
                return true;

            }
            return false;


        }


    }




}
