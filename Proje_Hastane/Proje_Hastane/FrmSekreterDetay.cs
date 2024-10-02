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
using System.Data.Common;

namespace Proje_Hastane
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string TcNo;
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TcNo;

            //Ad Soyad
            SqlCommand cmd = new SqlCommand("SELECT AdSoyad FROM Tbl_Sekreterler WHERE KimlikNo=" + TcNo,bgl.Baglanti());
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            { 
                LblAdSoyad.Text = dr[0].ToString(); 
            }

            bgl.Baglanti().Close();

            //Branşları datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Tanim FROM Tbl_Branslar",bgl.Baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doktorları datagride aktarma
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT Ad,Soyad,Brans,KimlikNo FROM Tbl_Doktorlar",bgl.Baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşları aktar
            SqlCommand cmd2 = new SqlCommand("SELECT Tanim FROM Tbl_Branslar", bgl.Baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0].ToString());
            }
            bgl.Baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Randevular (Tarih,Saat,Brans,Doktor,HastaTC) VALUES(@p1,@p2,@p3,@p4,@p5)",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",MskTarih.Text);
            cmd.Parameters.AddWithValue("@p2", MskSaat.Text);
            cmd.Parameters.AddWithValue("@p3", CmbBrans.Text);
            cmd.Parameters.AddWithValue("@p4", CmbDoktor.Text);
            cmd.Parameters.AddWithValue("@p5", MskTc.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu","Randevu Oluşturuldu",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT Ad,Soyad FROM Tbl_Doktorlar WHERE Brans=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",CmbBrans.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            bgl.Baglanti().Close();
        }

        private void BtnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Duyurular (Duyuru) VALUES(@p1)", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",RichDuyuru.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu","Duyuru Oluşturuldu",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli frm = new FrmDoktorPaneli();
            frm.Show();
        }

        private void BtnBrans_Click(object sender, EventArgs e)
        {
            FrmBrans frm = new FrmBrans();
            frm.Show();
        }

        private void BtnRandevuListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frm=new FrmRandevuListesi();
            frm.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();
        }
    }
}
