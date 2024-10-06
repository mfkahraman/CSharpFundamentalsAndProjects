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
    public partial class OgrenciNotlar : Form
    {
        public OgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();
        public string numara;

        private void OgrenciNotlar_Load(object sender, EventArgs e)
        {
            //Öğrenci adını çek
            SqlCommand cmd = new SqlCommand("SELECT Ad,Soyad FROM Ogrenciler WHERE ID="+numara, bgl.Baglanti());
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[0] + " " + dr[1] + " Ders Notları";
            }
            bgl.Baglanti().Close();

            //Data Grid Doldur
            SqlCommand cmd2 = new SqlCommand("SELECT D.Ad AS DersAdi,Sınav1,Sınav2,Sınav3,ProjeNotu,Ortalama,GectiMi FROM Notlar N INNER JOIN Dersler D ON N.DersID = D.ID WHERE OgrenciID=@p1", bgl.Baglanti());
            cmd2.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara;
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Baglanti().Close();
        }
    }
}
