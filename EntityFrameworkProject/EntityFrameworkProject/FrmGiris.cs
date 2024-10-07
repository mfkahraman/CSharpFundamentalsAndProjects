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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            DBEntityUrunEntities db = new DBEntityUrunEntities();
            var sorgu = (from x in db.Adminler where x.Kullanici == TxtKullanici.Text && x.Sifre == TxtSifre.Text select x);
            if (sorgu.Any())
            {
                FrmAna frm = new FrmAna();
                frm.Show();
                this.Hide();
            }
            else MessageBox.Show("Giriş bilgileri hatalıdır.","Hatalı giriş",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
