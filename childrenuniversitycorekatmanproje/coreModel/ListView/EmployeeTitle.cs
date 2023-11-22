using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.ListView
{
    public class EmployeeTitle
    {
        public int EmployeeID { get; set; }
        [Required]
        public string NameSurname { get; set; }

        public string Gender { get; set; }

        public DateTime DateofStart { get; set; }
        public bool Shift { get; set; }

        public decimal Salary { get; set; }
        public decimal Bounty { get; set; }
        public int TitleID { get; set; }

        public string TitleName { get; set; }

    }
}
