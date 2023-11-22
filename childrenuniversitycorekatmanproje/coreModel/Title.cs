using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel
{
    public class Title
    {
        [Key]
        public int TitleID { get; set; }

        public string TitleName { get; set; }
    }
}
