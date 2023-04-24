//using Amazon.EC2.Model;
using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystemApp.Controllers
{
    public class PurchaseController : Controller
    {

        public readonly ApplicationDbContext _context;

        public PurchaseController(ApplicationDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            List<Purchase> purchases;

            purchases= _context.Purchases.ToList(); 

            return View(purchases);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Purchase purchase= new Purchase();
            purchase.PurchaseDetails.Add(new PurchaseDetails() { Id = 1 });
            return View(purchase);  
        }

        [HttpPost]
        public IActionResult Create(Purchase purchase)
        {
            _context.Add(purchase);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
    }

}
