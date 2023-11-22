using coreData.Data;
using coreModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly ApplicationDbContext Context;

        public EmployeeController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }
        public IActionResult Index()
        {
            var result = Context.employees.ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee Employee)
        {
            Context.Add(Employee);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var result = await Context.employees.FindAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {

            Context.Update(employee);
            await Context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {

                return RedirectToAction("Index");


            }
            var result = await Context.employees.FindAsync(id);
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {


            var result = await Context.employees.FindAsync(id);
            Context.employees.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");

        }


    }
}
