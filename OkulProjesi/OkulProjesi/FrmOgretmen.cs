using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OkulProjesi
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        public string numara;
        SqlBaglantisi bgl=new SqlBaglantisi();
        private void FrmOgretmen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKulup frm=new FrmKulup();
            frm.Show();
        }

        private void BtnDersIslemleri_Click(object sender, EventArgs e)
        {
            FrmDersler frm =new FrmDersler();
            frm.Show();
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm =new FrmOgrenci();
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frm =new FrmSinavNotlar();
            frm.Show();
        }
    }
}
