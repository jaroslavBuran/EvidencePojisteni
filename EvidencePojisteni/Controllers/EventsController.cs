using EvidencePojisteni.Data;
using EvidencePojisteni.Models.InsuranceEvents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencePojisteni.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Events
        public IActionResult Index()
        {
            var users = context.Users.ToList();

            SelectList list = new SelectList(users, "Id", "IdNumber");
            ViewBag.Users = list;

            List<InsuranceEvent> events = context.InsuranceEvents.Include(x => x.Product).ToList();

            return View(events);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceEvent = await context.InsuranceEvents.Include(x => x.Product.User)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (insuranceEvent == null)
            {
                return NotFound();
            }

            return View(insuranceEvent);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,EventDescription")] InsuranceEvent insuranceEvent)
        {
            if (ModelState.IsValid)
            {
                context.Add(insuranceEvent);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceEvent);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await context.InsuranceEvents.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,EventDescription")] InsuranceEvent insuranceEvent)
        {
            if (id != insuranceEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(insuranceEvent);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(insuranceEvent.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceEvent);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await context.InsuranceEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceEvent = await context.InsuranceEvents.FindAsync(id);
            context.InsuranceEvents.Remove(insuranceEvent);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return context.InsuranceEvents.Any(e => e.EventId == id);
        }
    }
}
