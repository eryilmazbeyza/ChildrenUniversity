using coreData.Data;
using coreModel.ListView;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace childrenuniversitycorekatmanproje.Controllers
{
    public class EmployeeTitleController : Controller
    {

        public readonly ApplicationDbContext Context;

        public EmployeeTitleController(ApplicationDbContext Context)
        {

            this.Context = Context;
        }
        public IActionResult Index()
        {

            var result = (from e in Context.employees
                          join t in Context.titles
                         on e.TitleID equals t.TitleID
                          select new EmployeeTitle
                          {
                              NameSurname = e.NameSurname,
                              Gender = e.Gender,
                              DateofStart = e.DateofStart,
                              Shift = e.Shift,
                              TitleID = t.TitleID,
                              TitleName = t.TitleName

                          }).ToList();

            return View(result);
        }
    }
}
