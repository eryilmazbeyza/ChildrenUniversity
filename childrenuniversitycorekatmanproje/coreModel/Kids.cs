using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel
{
    public class Kids
    {
        [Key]
        public int KidID { get; set; }
        public string NameSurname { get; set; }
        public string Gender { get; set; }
        public DateTime DateofBirth { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }
    }
}
