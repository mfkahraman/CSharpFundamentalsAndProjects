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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DBEntityUrunEntities db = new DBEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            dataGridView1.DataSource = (from x in db.Urunler
                                        select new
                                        { x.ID, x.Ad, x.Marka, x.Stok, x.Fiyat, KategoriAdı = x.Kategoriler.Ad, x.Durum }
                                        ).ToList();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            Urunler t = new Urunler();
            t.Ad = TxtUrunAd.Text;
            t.Marka = TxtMarka.Text;
            t.Stok = short.Parse(TxtStok.Text);
            t.Kategori = int.Parse(CmbKategori.SelectedValue.ToString());
            t.Fiyat = decimal.Parse(TxtFiyat.Text);
            t.Durum = true;
            db.Urunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            Listele();

            //Combobox Kategorileri çekme
            var kategoriler = (from x in db.Kategoriler
                               select new
                               { x.ID, x.Ad }
                               ).ToList();
            CmbKategori.ValueMember = "ID";
            CmbKategori.DisplayMember = "Ad";
            CmbKategori.DataSource = kategoriler;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunID.Text);
            var urun = db.Urunler.Find(x);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunID.Text);
            var urun = db.Urunler.Find(x);
            urun.Ad = TxtUrunAd.Text;
            urun.Marka = TxtMarka.Text;
            urun.Stok = short.Parse(TxtStok.Text);
            urun.Fiyat = decimal.Parse(TxtFiyat.Text);
            urun.Durum = bool.Parse(TxtDurum.Text);
            urun.Kategori = int.Parse(CmbKategori.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
