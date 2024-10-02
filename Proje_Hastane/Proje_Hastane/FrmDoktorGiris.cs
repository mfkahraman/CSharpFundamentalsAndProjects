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

namespace Proje_Hastane
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Doktorlar WHERE KimlikNo=@p1 AND Sifre=@p2",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",MskTc.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frm = new FrmDoktorDetay();
                frm.tc = MskTc.Text;
                frm.Show();
                this.Hide();
            }
            else MessageBox.Show("Giriş Bilgileri Hatalıdır","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            bgl.Baglanti().Close();
        }
    }
}
