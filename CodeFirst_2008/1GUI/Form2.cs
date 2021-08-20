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

namespace CodeFirst_2008._1GUI
{
    public partial class Form2 : Form
    {
        public delegate void SendMessage(string s);
        public SendMessage Sender;
        public string MssV;
        public delegate void RefreshData();
        public RefreshData refresh;
        public void getMess(string a)
        {
            MssV = a;
        }
        public Form2()
        {
            InitializeComponent();
            Sender = getMess;
            settCBB();
            rdNam.Checked = true;
        }
        public void loadData()
        {
            if(MssV != "")
            {
                SV a = BLL_QLSV.Instance.BLL_getSVbyMSSV(MssV);
                txtMSSV.Enabled = false;
                txtMSSV.Text = MssV;
                txtNameSV.Text = a.NameSV;
                if (a.Gender) rdNam.Checked = true;
                else rdNu.Checked = true;
                dtpNS.Value = a.NS;
                cbLSH.SelectedItem = a.LSH;
            }
        }
        public void settCBB()
        {
            List<LSH> list = BLL_QLSV.Instance.BLL_getListLSH();
            foreach(LSH i in list)
            {
                cbLSH.Items.Add(i);
            }
            cbLSH.SelectedIndex = 0;
            cbLSH.DisplayMember = "NameLop";
        }

        public SV getSVfromForm()
        {
            return new SV
            {
                MSSV = txtMSSV.Text,
                NameSV = txtNameSV.Text,
                NS = dtpNS.Value,
                ID_Lop = ((LSH)cbLSH.SelectedItem).ID_Lop,
                Gender = (rdNam.Checked) ? true : false
            };
        }
        public bool checkValidate()
        {
            if (txtMSSV.Text != "" && txtNameSV.Text != "")
            {
                return true;
            }
            return false;
        }
        public bool checkMSSV()
        {
            if (MssV == "" && BLL_QLSV.Instance.BLL_checkMSSV(txtMSSV.Text))
                return true;
            else return false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkValidate())
            {
                if (MssV != "")
                {
                    DialogResult dg = MessageBox.Show("Bạn muốn cập nhật SV?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dg == DialogResult.Yes)
                    {
                        BLL_QLSV.Instance.BLL_updateSV(getSVfromForm());
                    }
                    else return;
                }
                else if(checkMSSV())
                {
                    DialogResult dg = MessageBox.Show("Bạn muốn thêm SV?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dg == DialogResult.Yes)
                    {
                        BLL_QLSV.Instance.BLL_addSV(getSVfromForm());
                    }
                }
                else MessageBox.Show("Trùng mssv !!!", "Cảnh báo");
                refresh();
                this.Dispose();
            }
            else
                MessageBox.Show("Bạn chưa nhập đầy đủ !!!", "Cảnh báo");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
