using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_2008._4DTO
{
    public class LSH
    {
        public LSH()
        {
            SVs = new HashSet<SV>();
        }
        [Key]
        public int ID_Lop { get; set; }
        public string NameLop { get; set; }
        public virtual ICollection<SV> SVs { get; set; }
    }
}
