using FoodMart.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FoodMart.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public IActionResult AddUser()//User
        {
            return View();
        }
        
        //------------------------------------- Creat User ---------------- C --------------------------
        public async Task<IActionResult> Privacy(string username, string password, string phone, string Email, int Age)//User
        {
            await _userService.CreateUserAsync(username, password, phone, Email, Age);
            return View("AddUser");
        }

        //------------------------------------ Read User ------------------- R -------------------------- 
        public async Task<IActionResult> UsersList()//User
        {
            var users = await _userService.GetAllUsersAsync();

            return View(users);
        }


       //--------------------- Updat User Get Id --------------------------- U1 --------------------

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)//User
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return View(user);
            }

        }


        //-------------------------- Updat User Post ---------------------- U2 ----------------
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string username, string email, string phone)//User
        {
            var isSuccess = await _userService.UpdateUser(id, username, email, phone);
            if (isSuccess)
            {
                return RedirectToAction("UsersList");

            }
            return RedirectToAction("UsersList");
        }


        //---------------------- Delete User ------------------------------ D -----------------
        public async Task<IActionResult> DeleteUser(string id) 
        {
            var isSuccess= await _userService.DeleteUser(id);
            return RedirectToAction("UsersList");
        
        }

        //--------------------------------- Login ---------- Login -----------------

        [HttpGet]
        public IActionResult Login() 
        {
            return View("Login");

        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, bool remember)
        {
            var isSuccess = await _userService.LoginAsync(username, password, remember);
            if (isSuccess)
            {

                return RedirectToAction("UsersList");
            }
            return View();

            }



            // Role ---------------------- Role ----------------------- Role ------------------------- Role ---------------------- Role ------------------Role
            public IActionResult AddRole()//Role
        {
            return View();


        }
        //------------------------------------- Creat Role ---------------- C --------------------------
        public async Task<IActionResult> Index(string roleName) //Role
        {
            await _roleService.CreateRoleAsync(roleName);
            return View("AddRole");

        }

        //------------------------------------ Read Role ------------------- R -------------------------- 

        public async Task<IActionResult> RolesList()//Role
        {
            var roles = await _roleService.GetAllRolesAsync();
            return View(roles);
        }


        //--------------------- Updat Role Get Id --------------------------- U1 --------------------

        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _userService.GetUserById(id);
            if (role == null)
            {
                return NotFound();
            }
            else
            {
                return View(role);
            }

        }


        //-------------------------- Updat Role Post ---------------------- U2 ----------------

        public async Task<IActionResult> EditRole(string id, string roleName)
        {
            var isSuccess = await _roleService.UpdateRole(id, roleName);
            if (isSuccess)
            {
                return RedirectToAction("RolesList");

            }
            return RedirectToAction("RolesList");
        }
        //---------------------- Delete Role ------------------------------ D -----------------

        public async Task<IActionResult> DeleteRole(string id) 
        {
            var isSuccess = await _roleService.DeleteRole(id);
            return RedirectToAction("RolesList");
        }



    }
}
