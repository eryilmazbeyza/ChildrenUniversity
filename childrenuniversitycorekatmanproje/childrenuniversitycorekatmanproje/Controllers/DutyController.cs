using coreData.Data;
using coreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class DutyController : Controller
    {
        public readonly ApplicationDbContext Context;
        public DutyController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public IActionResult Index()
        {
            var result = Context.dutys.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Duty Duty)
        {
            Context.Add(Duty);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.dutys.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Duty Duty)
        {
            Context.Update(Duty);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.dutys.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Context.dutys.FindAsync(id);
            Context.dutys.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
