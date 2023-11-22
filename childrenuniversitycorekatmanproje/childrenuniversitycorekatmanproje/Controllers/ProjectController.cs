using coreData.Data;
using coreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class ProjectController : Controller
    {
        public readonly ApplicationDbContext Context;
        public ProjectController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public IActionResult Index()
        {
            var result = Context.projects.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project Project)
        {
            Context.Add(Project);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.projects.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project Project)
        {
            Context.Update(Project);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.projects.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Context.projects.FindAsync(id);
            Context.projects.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
