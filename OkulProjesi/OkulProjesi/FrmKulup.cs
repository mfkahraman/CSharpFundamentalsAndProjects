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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Liste();
        }

        void Liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kulupler", bgl.Baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.Baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand("INSERT INTO Kulupler (Ad) VALUES(@p1)",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Kulüp eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand("DELETE Kulupler WHERE ID=@p1", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtKulupID.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Kulüp silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            Liste();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Kulupler SET Ad=@p1 WHERE ID=@p2", bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtKulupID.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Kulüp Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
        }
    }
}
