using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.IService;
using InventoryManagementSystemInfrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _user;
        private readonly ILoginService _loginService;

        public LoginController(IUserService user,ILoginService loginService) //why do we write these inside constructor ? 
        {
            _loginService = loginService;
            _user = user;   
        }


       public IActionResult Index()
        {
            return View();
        }



        [HttpGet]

        [HttpPost]
        public async Task<IActionResult> Login(Login logingData)
        {
            try
            {

                AppUser user = await _user.CheckIfExist(logingData.Name);


                if (user != null)
                {
                    if (user.Password == logingData.Password)
                    {
                        TempData["Message"] = "User name and password Matches ! ";
                        return RedirectToAction("Index", "AppUser");
                    }
                    else
                    {
                        TempData["Message"] = "Wrong password ! ! ";
                        return RedirectToAction("Index","Login");
                    }
                }

                else
                {
                    TempData["Message"] = "User name does not exist ";
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
