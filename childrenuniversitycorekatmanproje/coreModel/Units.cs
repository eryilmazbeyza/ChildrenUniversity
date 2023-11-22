using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel
{
    public class Units
    {
        [Key]
        public int UnitsID { get; set; }
        [Required]
        public string UnitsName { get; set; }
        [Required]
        [Range(10, 1000, ErrorMessage = "10 ile 1000 arasında değer giriniz.")]
        public int NumberofEmployee { get; set; }
        public ICollection<Duty> Duty { get; set; }
    }
}
