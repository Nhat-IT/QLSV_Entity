using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_2008._4DTO
{
    class CreateData
        : CreateDatabaseIfNotExists<QLSV2008>
    {
        protected override void Seed(QLSV2008 context)
        {
            context.LSHes.AddRange(new LSH[]
            {
                new LSH{ID_Lop = 1,NameLop = "19TCLC-DT1"},
                new LSH{ID_Lop = 2, NameLop = "19TCLC-DT2"},
                new LSH{ID_Lop = 3, NameLop = "19TCLC-DT3"},
                new LSH{ID_Lop = 4, NameLop = "19TCLC-DT4"},
            });
            context.SVs.AddRange(new SV[]
            {
                new SV{MSSV = "102",NameSV = "Nhat",Gender = true,NS = DateTime.Now,ID_Lop = 1},
                new SV{MSSV = "109",NameSV = "aNhat",Gender = false,NS = DateTime.Now,ID_Lop = 2},
                new SV{MSSV = "122",NameSV = "bNhat",Gender = true,NS = DateTime.Now,ID_Lop = 3},
                new SV{MSSV = "182",NameSV = "dNhat",Gender = false,NS = DateTime.Now,ID_Lop = 2},
                new SV{MSSV = "132",NameSV = "qNhat",Gender = false,NS = DateTime.Now,ID_Lop = 4},
                new SV{MSSV = "152",NameSV = "zNhat",Gender = true,NS = DateTime.Now,ID_Lop = 2},
                new SV{MSSV = "107",NameSV = "wNhat",Gender = false,NS = DateTime.Now,ID_Lop = 4},
                new SV{MSSV = "121",NameSV = "eNhat",Gender = true,NS = DateTime.Now,ID_Lop = 2},
                new SV{MSSV = "162",NameSV = "yNhat",Gender = false,NS = DateTime.Now,ID_Lop = 4},
                new SV{MSSV = "163",NameSV = "cNhat",Gender = true,NS = DateTime.Now,ID_Lop = 1},
            });
        }
    }
}
