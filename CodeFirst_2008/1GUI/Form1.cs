using CodeFirst_2008._1GUI;
using CodeFirst_2008._2BLL;
using CodeFirst_2008._4DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_2008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setCBB_Lop();
            setCBB_TenCotSV();
        }
        public void loadData()
        {
            List<SV> list = BLL_QLSV.Instance.BLL_getListSV();
            dtgvShow.DataSource = list.Select(p => new { p.MSSV, p.NameSV, p.Gender, p.NS, p.ID_Lop, p.LSH.NameLop }).ToList();
        }
        public void setCBB_Lop()
        {
            List<LSH> list = BLL_QLSV.Instance.BLL_getListLSH();
            cbLSH.Items.Add(new LSH
            {
                ID_Lop = 0,
                NameLop = "ALL"
            });
            foreach (LSH i in list)
            {
                cbLSH.Items.Add(i);
            }
            cbLSH.SelectedIndex = 0;
            cbLSH.DisplayMember = "NameLop";
        }
        public void setCBB_TenCotSV()
        {
            var s = typeof(SV).GetProperties().Select(p => p.Name);
            foreach(object a in s)
            {
                cbSort.Items.Add(a);
            }
            cbSort.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Sender("");
            f.refresh = loadData;
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            string s = dtgvShow.CurrentRow.Cells["MSSV"].Value.ToString();
            f.refresh = loadData;
            f.Sender(s);
            f.Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dtgvShow.SelectedRows.OfType<DataGridViewRow>().Where(row => !row.IsNewRow).ToArray();
            string s;
            foreach (var row in selectedRows)
            {
                s = row.Cells["MSSV"].Value.ToString();
                BLL_QLSV.Instance.BLL_deleteSV(s);
            }
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = txtSearch.Text;
            List<SV> list = BLL_QLSV.Instance.BLL_getListSV();
            if (s == "" && ((LSH)cbLSH.SelectedItem).NameLop == "ALL") loadData();
            else if (((LSH)cbLSH.SelectedItem).NameLop == "ALL")
            {
                dtgvShow.DataSource = list.Where(p => p.NameSV.Contains(s)).Select(p => new { p.MSSV, p.NameSV, p.Gender, p.NS, p.LSH.NameLop }).ToList();
            }
            else
            {
                dtgvShow.DataSource = list.Where(p => p.NameSV.Contains(s) && p.ID_Lop == ((LSH)cbLSH.SelectedItem).ID_Lop).Select(p => new { p.MSSV, p.NameSV, p.Gender, p.NS, p.LSH.NameLop }).ToList();
            }
        }

        private void btnIncre_Click(object sender, EventArgs e)
        {
            string sortElement = cbSort.SelectedItem.ToString();
            var but = (Button)sender;
            string typeSort = but.Name;
            List<SV> list = BLL_QLSV.Instance.BLL_sortIncreByKeyWord(sortElement,typeSort == "btnIncre"?true:false);
            dtgvShow.DataSource = list.Select(p => new { p.MSSV, p.NameSV, p.Gender, p.NS, p.ID_Lop, p.LSH.NameLop }).ToList();
        }

        private void cbLSH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = ((LSH)cbLSH.SelectedItem).NameLop;
            if (s.Equals("ALL")) loadData();
            else
            {
                List<SV> list = BLL_QLSV.Instance.BLL_getListSV();
                int id = ((LSH)cbLSH.SelectedItem).ID_Lop;
                dtgvShow.DataSource = list.Where(m => m.ID_Lop == id).Select(p => new { p.MSSV, p.NameSV, p.Gender, p.NS, p.LSH.NameLop }).ToList();
            }
        }
    }
}
