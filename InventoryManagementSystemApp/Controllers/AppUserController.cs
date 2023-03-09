using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.DataContext;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace InventoryManagementSystemApp.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IUserService _user;
        private readonly ILoginService _loginService;
        private readonly ApplicationDbContext _context;

        public AppUserController(ApplicationDbContext context,IUserService user, ILoginService loginService)
        {
            _context = context;
            _user = user;
            _loginService = loginService;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var userList = await _user.GetAll();
                return View(userList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
                public async Task<IActionResult> ShowSearchForm()
                {
                    return View();

                }

                public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
                {
                    return View("Index", await _context.AppUsers.Where(x => x.UserName.Contains(SearchPhrase)));
                }
        */

           
    [HttpGet]
     public async Task<IActionResult> SearchResults(string UserSearch) //for search 
       {
       ViewData["GetDetails"] = UserSearch;
       // var UserSearchInt = Convert.ToInt64(UserSearch);

        if (!String.IsNullOrEmpty(UserSearch))
       {
         var searchQuerry = _context.AppUsers.Where(x => x.UserName.Equals(UserSearch)); //|| x.Id.Equals(UserSearchInt));
         return View(await searchQuerry.AsNoTracking().ToListAsync());   

        }
            else return View("Index");

 }


        [HttpGet]
        public async Task<IActionResult> SearchResultsId(int UserSearchId) //for search 
        {
            ViewData["GetDetailsId"] = UserSearchId;

            var searchQuerry = _context.AppUsers.Where(x => x.Id.Equals(UserSearchId));

            return View(await searchQuerry.AsNoTracking().ToListAsync());

        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new AppUser());
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppUser user)
        {
            try
            {
                if (!ModelState.IsValid) return View(user);
                AppUser existingUser = await _user.CheckIfExist(user.UserName);
                if (existingUser != null)
                {
                    TempData["Message"] = "User name is already exist";
                    return View(user);
                }
                await _user.Save(user);
                TempData["Message"] = "Successfully Saved";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _user.Get(id);
                return View(user);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUser user)
        {
            try
            {
                if (!ModelState.IsValid) return View(user);

                AppUser existingUser = await _user.Get(user.Id);

                existingUser.FirstName = user.FirstName;
                existingUser.MiddleName = user.MiddleName;
                existingUser.LastName = user.LastName;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Gender = user.Gender;
                existingUser.UpdatedDate = DateTime.Now;

                await _user.Update(user);
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _user.Get(id);
                _user.Remove(user);
                TempData["Message"] = "Successfully Deleted";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }






                /* 
            [HttpGet]
            public async Task<IActionResult> GetById(int id)
            {
                    var user = await _user.Get(id); 
                    return user == null ? NotFound() : Ok(user);
             }


            [HttpGet]
            public async Task<IActionResult> GetByName(string name)
                {
                    var user = await _user.Find(name);
                    return user == null ? NotFound() : Ok(user);
                }

                [HttpDelete]
                public async Task<IActionResult> DeleteAll()
                {
                    var all = await _context.user.ToListAsync();
                    _context.user.RemoveRange(all);
                    await _context.SaveChangesAsync();
                    return NoContent();

                    //var Task = _context.user.FirstOrDefault(x => x.Id == id);



                    /*
                    _context.Entry(user).State = EntityState.Deleted;

                    _context.SaveChanges();

                    _context.EntityState.Deleted();

                    */



                /*var delUsers = _context.user.FromSql("DROP TABLE user");
                _context.Database.ExecuteSql(`DROP TABLE user`);
                return NoContent(); 
                */


            

        }
    }
}
