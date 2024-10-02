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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad Çekme
            LblTC.Text = tc;
            SqlCommand cmd = new SqlCommand("SELECT Ad,Soyad FROM Tbl_Hastalar WHERE KimlikNo=@p1",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",tc);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.Baglanti().Close();

            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tbl_Randevular WHERE HastaTC=" + tc, bgl.Baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Baglanti().Close();

            //Branşları Çek
            SqlCommand cmd2 = new SqlCommand("SELECT Tanim FROM Tbl_Branslar", bgl.Baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.Baglanti().Close();
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

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tbl_Randevular WHERE Brans = '" + CmbBrans.Text  + "' AND Doktor='" +CmbDoktor.Text+"' AND Durum=0" ,bgl.Baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle frm = new FrmBilgiDuzenle();
            frm.TcNo = tc;
            frm.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Tbl_Randevular SET Durum=1,HastaTC=@p1,Sikayet=@p2 WHERE Id=@p3", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1",tc);
            cmd.Parameters.AddWithValue("@p2",RichSikayet.Text);
            cmd.Parameters.AddWithValue("@p3", TxtID.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Randevu alınmıştır","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
