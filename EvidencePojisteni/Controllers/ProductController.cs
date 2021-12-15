using EvidencePojisteni.Data;
using EvidencePojisteni.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvidencePojisteni.Models.Products;

namespace EvidencePojisteni.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;

        public ProductController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> ListProducts()
        {
            var userId = await userManager.GetUserAsync(HttpContext.User);

            var user = context.Users.Include(x => x.Products)
                .Where(x => x.Id == userId.Id)
                .FirstOrDefault<AppUser>();

            var products = user.Products;

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            List<string> userDetails = new List<string>();
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                var currentUser = await userManager.IsInRoleAsync(user, "admin");
                if (!currentUser)
                {
                    userDetails.Add($"RČ: {user.IdNumber} - {user.FirstName} {user.LastName}");
                    // bylo by možné přidávat rovnou do SelectList??????
                }
                
            }
            SelectList list = new SelectList(userDetails);
            ViewBag.AllUsers = list;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Title,ShortDesc,Description,UserId")] Product product)
        {
            if (ModelState.IsValid)
            {
                string idNumber = product.UserId.Substring(4, 9);
                product.UserId = context.Users.Where(user => user.IdNumber == idNumber).First().Id;

                context.Add(product);
                await context.SaveChangesAsync(); 
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            List<string> userDetails = new List<string>();
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                var currentUser = await userManager.IsInRoleAsync(user, "admin");
                if (!currentUser)
                {
                    userDetails.Add($"RČ: {user.IdNumber} - {user.FirstName} {user.LastName}");
                    // bylo by možné přidávat rovnou do SelectList??????
                }

            }
            SelectList list = new SelectList(userDetails);
            ViewBag.AllUsers = list;

            ViewBag.returnUrl = Request.Headers["Referer"].ToString();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string returnUrl, [Bind("ProductId,Title,ShortDesc,Description,UserId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string idNumber = product.UserId.Substring(4, 9);
                    product.UserId = context.Users.Where(user => user.IdNumber == idNumber).First().Id;

                    context.Update(product);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect(returnUrl);
            }
            return Redirect(returnUrl);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Products.FindAsync(id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductDetailViewModel
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                UserId = product.UserId
            };

            return View(model);
        }

        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.ProductId == id);
        }


    }
}
