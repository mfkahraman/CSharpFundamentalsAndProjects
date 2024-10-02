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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();
        public string tcNo;

        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = tcNo;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Doktorlar WHERE KimlikNo=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",tcNo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbBrans.Text = dr[3].ToString();
                TxtSifre.Text = dr[5].ToString();
            }
            bgl.Baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("UPDATE Tbl_Doktorlar SET Brans=@p1,Sifre=@p2 WHERE KimlikNo="+tcNo, bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",CmbBrans.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSifre.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Bilgileriniz güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
