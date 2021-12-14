using EvidencePojisteni.Data;
using EvidencePojisteni.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencePojisteni.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public ClientsController(ApplicationDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListClients()
        {
            //vybere pouze ty users, jejichž id není v tabulce UserRoles
            var clients = context.Users.Where(c => !context.UserRoles.Select(b => b.UserId).Distinct().Contains(c.Id)).ToList();

            return View(clients);
        }
        


        


    }
}
