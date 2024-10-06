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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace OkulProjesi
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.NotlarTableAdapter ds = new DataSet1TableAdapters.NotlarTableAdapter();
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void BtnTemizle_Click(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtID.Text));
        }

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            //Comboboxa veri çekme
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dersler", bgl.Baglanti());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "Ad";
            CmbDers.ValueMember = "ID";
            CmbDers.DataSource = dt;
            bgl.Baglanti().Close();
        }

        int notID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            double ortalama;
            string durum;
            sinav1 = Convert.ToInt16(TxtSinav1.Text);
            sinav2 = Convert.ToInt16(TxtSinav2.Text);
            sinav3 = Convert.ToInt16(TxtSinav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50) { TxtDurum.Text = "True"; }
            else TxtDurum.Text = "False";
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(TxtID.Text), byte.Parse(TxtSinav1.Text),
                byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), byte.Parse(TxtOrtalama.Text),
                bool.Parse(TxtDurum.Text), notID);
            MessageBox.Show("Ders notları güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
