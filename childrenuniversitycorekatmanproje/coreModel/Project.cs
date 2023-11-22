using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectsName { get; set; }

        public DateTime DateofStart { get; set; }
        public DateTime DateofEnd { get; set; }
        [ForeignKey("DutyID")]
        public int DutyID { get; set; }
        public Duty Duty { get; set; }
    }
}
