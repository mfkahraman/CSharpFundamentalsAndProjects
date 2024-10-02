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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl= new SqlBaglantisi();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Sekreterler WHERE KimlikNo=@p1 AND Sifre=@p2",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",MskTc.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);
            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frm = new FrmSekreterDetay();
                frm.TcNo = MskTc.Text;
                frm.Show();
                this.Hide();
            }
            else MessageBox.Show("Giriş bilgileri hatalıdır","Giriş Hatası",MessageBoxButtons.OK,MessageBoxIcon.Error);

            bgl.Baglanti().Close();
        }
    }
}
