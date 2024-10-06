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

namespace OkulProjesi
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        DataSet1TableAdapters.OgrencilerKulupTableAdapter ds = new DataSet1TableAdapters.OgrencilerKulupTableAdapter();

        string cinsiyet = "";

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();

            //Kulüp combobox itemleri çekme
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kulupler", bgl.Baglanti());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "Ad";
            CmbKulup.ValueMember = "ID";
            CmbKulup.DataSource = dt;
            bgl.Baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.OgrenciEkle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), cinsiyet);
            MessageBox.Show("Öğrenci eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        void Listele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(byte.Parse(TxtID.Text));
            MessageBox.Show("Öğrenci silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtAd.Text, TxtSoyad.Text, byte.Parse(CmbKulup.SelectedValue.ToString()), cinsiyet, int.Parse(TxtID.Text));
            MessageBox.Show("Öğrenci güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Kız")
            {
                RdKiz.Checked = true; RdErkek.Checked = false;
            }
            else { RdKiz.Checked = false; RdErkek.Checked = true; }

            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void RdKiz_CheckedChanged(object sender, EventArgs e)
        {
            if (RdKiz.Checked == true) { cinsiyet = "Kız"; } else { cinsiyet = "Erkek"; }
        }

        private void RdErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (RdKiz.Checked == true) { cinsiyet = "Kız"; } else { cinsiyet = "Erkek"; }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.GetOgrenciByAd(TxtAra.Text);
        }
    }
}
