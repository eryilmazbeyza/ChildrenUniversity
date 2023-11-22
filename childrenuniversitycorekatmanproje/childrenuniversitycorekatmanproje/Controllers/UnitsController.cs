using coreData.Data;
using coreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class UnitsController : Controller
    {
        public readonly ApplicationDbContext Context;

        public UnitsController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }
        public IActionResult Index()
        {
            var result = Context.units.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Units Units)
        {
            Context.Add(Units);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.units.FindAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Units Units)
        {

            Context.Update(Units);
            await Context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {

                return RedirectToAction("Index");


            }
            var result = await Context.units.FindAsync(id);
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {


            var result = await Context.units.FindAsync(id);
            Context.units.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
