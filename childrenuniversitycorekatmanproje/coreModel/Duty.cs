using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel
{
    public class Duty
    {
        [Key]
        public int DutyID { get; set; }

        public string DutyDefinition { get; set; }
        public string DutyName { get; set; }
        public int DutyPoint { get; set; }

        public ICollection<Units> Units { get; set; }
    }
}
