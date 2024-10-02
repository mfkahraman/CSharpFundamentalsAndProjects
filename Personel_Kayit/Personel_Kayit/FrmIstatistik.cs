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

namespace Personel_Kayit
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            con.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel", con);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            con.Close();

            //Evli Personel Sayısı
            con.Open ();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum = 1", con);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }
            con.Close ();

            //Bekar Personel Sayısı
            con.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum = 0", con);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString();
            }
            con.Close();

            //Farklı Şehir Sayısı
            con.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(DISTINCT(PerSehir))  FROM Tbl_Personel", con);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblFarklıSehir.Text = dr4[0].ToString();
            }
            con.Close();

            //Toplam Maaş
            con.Open();
            SqlCommand komut5 = new SqlCommand("SELECT SUM(PerMaas) FROM Tbl_Personel", con);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString();
            }
            con.Close();

            //Ortalama Maaş
            con.Open();
            SqlCommand komut6 = new SqlCommand("SELECT AVG(PerMaas) FROM Tbl_Personel", con);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            con.Close();
        }
    }
}
