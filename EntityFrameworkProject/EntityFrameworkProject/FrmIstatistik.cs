using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkProject
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DBEntityUrunEntities db = new DBEntityUrunEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Kategoriler.Count().ToString();
            label3.Text = db.Urunler.Count().ToString();
            label5.Text = db.Musteriler.Count(x=> x.AktifMi == true).ToString();
            label7.Text = db.Musteriler.Count(x => x.AktifMi == false).ToString();
            label9.Text = db.Urunler.Count(x => x.Kategori == 1).ToString();
            label11.Text = db.Urunler.Sum(x=> x.Stok).ToString();
            label13.Text = (from x in db.Urunler orderby x.Fiyat descending select x.Ad).FirstOrDefault();
            label15.Text = (from x in db.Urunler orderby x.Fiyat ascending select x.Ad).FirstOrDefault();
            label17.Text = (from x in db.Musteriler select x.Sehir).Distinct().Count().ToString();
            label19.Text = db.Satislar.Sum(x=> x.Fiyat).ToString() + " TL";
            label21.Text = db.EnCokUrunuOlanMarka().FirstOrDefault();
            label23.Text = db.Urunler.Count(X=> X.Ad == "Buzdolabı").ToString();
        }
    }
}
