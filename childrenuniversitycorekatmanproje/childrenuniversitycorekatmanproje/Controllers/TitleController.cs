using coreData.Data;
using coreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class TitleController : Controller
    {
        public readonly ApplicationDbContext Context;
        public TitleController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public IActionResult Index()
        {
            var result = Context.titles.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Title Title)
        {
            Context.Add(Title);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.titles.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Title Title)
        {
            Context.Update(Title);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.titles.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Context.titles.FindAsync(id);
            Context.titles.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
