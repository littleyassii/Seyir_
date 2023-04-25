using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seyir
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            if(TxtKullaniciAdi.Text=="admin"&& TxtSifre.Text=="12345")
            {
                FrmAnaForm fr=new FrmAnaForm();
                fr.Show();
                this.Hide();
                MessageBox.Show("Seyir Hotele Hoşgeldiniz");
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve Şifreniz Hatalı Tekrar Deneyiniz");
            }
        }
    }
}
