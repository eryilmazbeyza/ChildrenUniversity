using coreData.Data;
using coreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class KidsController : Controller
    {
        public readonly ApplicationDbContext Context;
        public KidsController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public IActionResult Index()
        {
            var result = Context.kids.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Kids Kids)
        {
            Context.Add(Kids);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.kids.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Kids Kids)
        {
            Context.Update(Kids);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.kids.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Context.kids.FindAsync(id);
            Context.kids.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
