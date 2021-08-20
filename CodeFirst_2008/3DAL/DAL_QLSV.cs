using CodeFirst_2008._4DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_2008._3DAL
{
    public class DAL_QLSV
    {
        private static DAL_QLSV instance;

        public static DAL_QLSV Instance
        {
            get
            {
                if (instance == null) instance = new DAL_QLSV();
                return instance;
            }
            private set
            {

            }
        }

        public List<SV> DAL_getListSV()
        {
            return QLSV2008.Instance.SVs.ToList();
        }
        public SV DAL_getSVbyMSSV(string s)
        {
            return QLSV2008.Instance.SVs.Find(s);
        }
        public List<LSH> DAL_getListLSH()
        {
            return QLSV2008.Instance.LSHes.ToList();
        }
        public void DAL_updateSV(SV a)
        {
            SV s = QLSV2008.Instance.SVs.Find(a.MSSV);
            s.NameSV = a.NameSV;
            s.ID_Lop = a.ID_Lop;
            s.NS = a.NS;
            s.Gender = a.Gender;
            QLSV2008.Instance.SaveChanges();
        }
        public void DAL_addSV(SV s)
        {
            QLSV2008.Instance.SVs.Add(s);
            QLSV2008.Instance.SaveChanges();
        }
        public bool DAL_checkMSSV(string s)
        {
            SV a = QLSV2008.Instance.SVs.Find(s);
            return a == null;
        }
        public void DAL_deleteSV(string s)
        {
            SV a = QLSV2008.Instance.SVs.Find(s);
            QLSV2008.Instance.SVs.Remove(a);
            QLSV2008.Instance.SaveChanges();
        }
    }
}
