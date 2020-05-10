using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodStore_mvc.Models.FoodStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class ProductController : Controller
    {
        // Create context.
        private FoodStoreContext db;
        public ProductController(FoodStoreContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            //send a collection of all Products as the view model.
            return View(db.Product);
        }

        public async Task<IActionResult> Details(int? id)
        {
            //send a collection of all Products as the view model.
         //   return View(db.Product);

            if (id == null)
            {
                return NotFound();
            }

            var product = await db.Product
                .Include(p => p.MfgNavigation)
                .Include(p => p.VendorNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
