using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            dataGridView1.DataSource = LogicPersonel.LLPersonelListesi();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click_1(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Gorev = TxtGorev.Text;
            ent.Maas = short.Parse(TxtMaas.Text);
            var result = LogicPersonel.LLPersonelEkle(ent);
            if (result == -1)
                MessageBox.Show("Hatalı giriş","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            var result = LogicPersonel.LLPersonelSil(Convert.ToInt32(TxtID.Text));
            if(result) { MessageBox.Show("Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else MessageBox.Show("Hatalı giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(TxtID.Text);   
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Gorev = TxtGorev.Text;
            ent.Maas = short.Parse(TxtMaas.Text);
            var result = LogicPersonel.LLPersonelGuncelle(ent);
            if (result == false)
                MessageBox.Show("Hatalı giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
