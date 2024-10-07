using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkProject
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DBEntityUrunEntities db = new DBEntityUrunEntities();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.Kategoriler.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Kategoriler kt = new Kategoriler();
            kt.Ad = TxtKategoriAd.Text;
            db.Kategoriler.Add(kt);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtKategoriID.Text);
            var ktgr= db.Kategoriler.Find(x);
            db.Kategoriler.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtKategoriID.Text);
            var ktgr = db.Kategoriler.Find(x);
            ktgr.Ad = TxtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
