using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_2008._4DTO
{
    [Table("SinhVien")]
    public class SV
    {
        [Key]   
        public string MSSV { get; set; }
        public string NameSV { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        public int ID_Lop { get; set; }
        [ForeignKey("ID_Lop")]
        public virtual LSH LSH { get; set; }

        public static bool cmpMSSV(SV a, SV b)
        {
            return (String.Compare(a.MSSV,b.MSSV) < 0);
        }
        public static bool cmpNameSV(SV a, SV b)
        {
            return (String.Compare(a.NameSV, b.NameSV) < 0);
        }
        public static bool cmpGender(SV a, SV b)
        {
            return (String.Compare(a.Gender.ToString(), b.Gender.ToString()) < 0);
        }
        public static bool cmpNS(SV a,SV b)
        {
            return (a.NS < b.NS);
        }
        public static bool cmpIDLop(SV a, SV b)
        {
            return (a.ID_Lop < b.ID_Lop);
        }
        public static bool cmpLSH(SV a, SV b)
        {
            return (String.Compare(a.LSH.NameLop, b.LSH.NameLop) < 0);
        }
    }
}
