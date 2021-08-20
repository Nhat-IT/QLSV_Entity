using CodeFirst_2008._3DAL;
using CodeFirst_2008._4DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_2008._2BLL
{
    public class BLL_QLSV
    {
        private static BLL_QLSV instance;

        public static BLL_QLSV Instance
        {
            get
            {
                if (instance == null) instance = new BLL_QLSV();
                return instance;
            }
            private set
            {

            }
        }
        public List<SV> BLL_getListSV()
        {
            return DAL_QLSV.Instance.DAL_getListSV();
        }
        public SV BLL_getSVbyMSSV(string s)
        {
            return DAL_QLSV.Instance.DAL_getSVbyMSSV(s);
        }
        public List<LSH> BLL_getListLSH()
        {
            return DAL_QLSV.Instance.DAL_getListLSH();
        }
        public void BLL_updateSV(SV a)
        {
            DAL_QLSV.Instance.DAL_updateSV(a);
        }
        public void BLL_addSV(SV s)
        {
            DAL_QLSV.Instance.DAL_addSV(s);
        }
        public bool BLL_checkMSSV(string s)
        {
            return DAL_QLSV.Instance.DAL_checkMSSV(s);
        }
        public void BLL_deleteSV(string s)
        {
            DAL_QLSV.Instance.DAL_deleteSV(s);
        }
        public delegate bool CompareTwoSV(SV a, SV b);
        public List<SV> BLL_sortIncreByKeyWord(string s, bool type)
        {
            List<SV> list = DAL_QLSV.Instance.DAL_getListSV();
            CompareTwoSV compare;
            switch (s)
            {
                case "MSSV":
                    compare = SV.cmpMSSV;
                    break;
                case "ID_Lop":
                    compare = SV.cmpIDLop;
                    break;
                case "Gender":
                    compare = SV.cmpGender;
                    break;
                case "NS":
                    compare = SV.cmpNS;
                    break;
                case "LSH":
                    compare = SV.cmpLSH;
                    break;
                default:
                    compare = SV.cmpNameSV;
                    break;
            }
            SV tmp = new SV();
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = 0; j < list.Count; j++)
                {
                    if (compare(list[i], list[j]) == type)
                    {
                        tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                }
            }
            return list;
        }
    }
}
