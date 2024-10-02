﻿using System;
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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        private void BtnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Hastalar (Ad,Soyad,KimlikNo,Telefon,Sifre,Cinsiyet) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.Baglanti());
            cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmd.Parameters.AddWithValue("@p3", MskTc.Text);
            cmd.Parameters.AddWithValue("@p4", MskTelefon.Text);
            cmd.Parameters.AddWithValue("@p5", TxtSifre.Text);
            cmd.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
            cmd.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir. Şifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
