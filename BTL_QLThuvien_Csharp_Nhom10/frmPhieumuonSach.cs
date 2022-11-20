using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLThuvien_Csharp_Nhom10
{
    public partial class frmPhieumuonSach : Form
    {
        string A;
        DataTable dtpm;
        int vt;
        SqlConnection con;
        public frmPhieumuonSach()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=.;Initial Catalog=QLThuVien;Integrated Security=True");
        }

        private void frmPhieumuonSach_Load(object sender, EventArgs e)
        {

        }
        #region hien ma phieu muon
        private string taomapm()
        {
            string Mapm;
            Random ran = new Random();
            Mapm = "MP" + ran.Next(50, 999).ToString();
            return Mapm;
        }
        #endregion
        #region binding
        private void data_binding()
        {
            txtmapm.DataBindings.Add("Text", dgvttpm.DataSource, "MaPM");
            cbmasach.DataBindings.Add("SelectedValue", dgvttpm.DataSource, "MaSach");
            cbmathe.DataBindings.Add("SelectedValue", dgvttpm.DataSource, "MaThe");
        }
        private void huy_binding()
        {
            if (txtmapm.DataBindings != null)
            {
                txtmapm.DataBindings.Clear();
            }
            if (cbmathe.DataBindings != null)
            {
                cbmathe.DataBindings.Clear();
            }
            if (cbmasach.DataBindings != null)
            {
                cbmasach.DataBindings.Clear();
            }
            if (dtpNgaymuon.DataBindings != null)
            {
                dtpNgaymuon.DataBindings.Clear();
            }
        }
        #endregion
        private void hienthi_tieudecot()
        {
            dgvttpm.Columns[0].HeaderText = "Ma PM";
            dgvttpm.Columns[1].HeaderText = "Ma sach";
            dgvttpm.Columns[0].HeaderText = "Ma the";
            dgvttpm.Columns[0].HeaderText = "Ngay muon";
        }
        private DataTable loadsach()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LOADSACH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataTable sach = new DataTable();
            con.Open();
            sach.Load(cmd.ExecuteReader());
            con.Close();
            return sach;
        }
        private void loaddlsach()
        {
            cbmasach.DataSource = loadsach();
            cbmasach.ValueMember = "MaSach";
            cbmasach.DisplayMember = "TenSach";
        }
        private DataTable loadtheThuvien()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_LOADTHETHUVIEN";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            DataTable theThuvien = new DataTable();
            con.Open();
            theThuvien.Load(cmd.ExecuteReader());
            con.Close();
            return theThuvien;
        }
        private void loaddlthe()
        {
            cbmathe.DataSource= loadtheThuvien();
            cbmathe.ValueMember = "MaThe";
            cbmathe.DisplayMember = "TenSV";
        }
        #region doc ten file
        private DataTable docphieumuon()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "sp_LOADPHIEUMUON";
            sqlCommand.Connection = con;
            DataTable phieumuon = new DataTable();
            con.Open();
            phieumuon.Load(sqlCommand.ExecuteReader());
            con.Close();
            return phieumuon;
        }
        private void loaddlphieumuon()
        {
            dgvttpm.DataSource = docphieumuon();
        }
        private void luuphieumuon()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_LUUPHIEUMUON";
            sqlcmd.Connection = con;
            string mapm, mathe, masach;
            DateTime ngaymuon;
            mapm = txtmapm.Text;

        }
    }
}
