using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Seyir
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection("Server=215-14\\SQLEXPRESS;Database=SeyirHotel;uid=sa;pwd=Ibb2022#!");
        //private void verilergoster()
        //{
        //    //baglanti.Open();
        //    //SqlCommand komut= new SqlCommand("select*from MusteriEkle",baglanti);
        //    //SqlDataReader oku=komut.ExecuteReader();
        //    //while(oku.Read())
        //    //{
        //    //   ListViewItem ekle=new ListViewItem();
        //    //    ekle.Text = oku["Musteriid"].ToString();
        //    //    ekle.SubItems.Add(oku["Adi"].ToString());
        //    //    ekle.SubItems.Add(oku["Soyadi"].ToString());
        //    //    ekle.SubItems.Add(oku["Cinsiyet"].ToString());
        //    //    ekle.SubItems.Add(oku["Telefon"].ToString());
        //    //    ekle.SubItems.Add(oku["Mail"].ToString());
        //    //    ekle.SubItems.Add(oku["TC"].ToString());
        //    //    ekle.SubItems.Add(oku["OdaNo"].ToString());
        //    //    ekle.SubItems.Add(oku["Ucret"].ToString());
        //    //    ekle.SubItems.Add(oku["GirisTarihi"].ToString());
        //    //    ekle.SubItems.Add(oku["CikisTarihi"].ToString());
        //    //    listView1.Items.Add(ekle);  
        //    //}
        //    //baglanti.Close();   
        //}
        //Listeleme//
        public void Listele(string baglan)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(baglan, baglanti);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select * from MusteriEkle");
        
        }
        //Listele Procedure:

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            TxtAdi.Tag = satir.Cells["Musteriid"].Value.ToString(); //gizli bölme tag de id
            TxtAdi.Text = satir.Cells["Adi"].Value.ToString(); 
            TxtSoyadi.Text = satir.Cells["Soyadi"].Value.ToString();
            comboBox1.Text = satir.Cells["Cinsiyet"].Value.ToString();
            MskTxtTelefon.Text = satir.Cells["Telefon"].Value.ToString();
            TxtMail.Text = satir.Cells["Mail"].Value.ToString();
            TxtKimlikNo.Text = satir.Cells["TC"].Value.ToString();
            TxtOdaNo.Text = satir.Cells["OdaNo"].Value.ToString();
            TxtUcret.Text = satir.Cells["Ucret"].Value.ToString();
            DtpGirisTarihi.Text = satir.Cells["GirisTarihi"].Value.ToString();
            DtpCikisTarihi.Text = satir.Cells["CikisTarihi"].Value.ToString();


         
     

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Güncelle Procedure:
          

            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PGuncelle";
            komut.Parameters.AddWithValue("Musteriid", TxtAdi.Tag);
            komut.Parameters.AddWithValue("Adi", TxtAdi.Text);
            komut.Parameters.AddWithValue("Soyadi",TxtSoyadi.Text);
            komut.Parameters.AddWithValue("Cinsiyet",comboBox1.Text);
            komut.Parameters.AddWithValue("Telefon", MskTxtTelefon.Text);
            komut.Parameters.AddWithValue("Mail", TxtMail.Text);
            komut.Parameters.AddWithValue("TC", TxtKimlikNo.Text);
            komut.Parameters.AddWithValue("OdaNo", TxtOdaNo.Text);
            komut.Parameters.AddWithValue("Ucret", TxtUcret.Text);
            komut.Parameters.AddWithValue("GirisTarihi",DtpGirisTarihi.Text);
            komut.Parameters.AddWithValue("CikisTarihil", DtpCikisTarihi.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from MusteriEkle");
        }

        private void BtnSıl_Click(object sender, EventArgs e)
        {
            //Silme Procedure:
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PSil";
            komut.Parameters.AddWithValue("PoliklinikNo", TxtAdi.Tag);

            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele("select * from MusteriEkle");
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            //A'da Göre Arama:
            SqlCommand komut = new SqlCommand();  //sql komutunu yazmamızı sağlayan komut.
            komut.Connection = baglanti;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "HAra";
            komut.Parameters.AddWithValue("Adi", TxtAdi.Text);

            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
//Data Source=215-14\SQLEXPRESS;Initial Catalog=SeyirHotel;User ID=sa;Password=Ibb2022#!
//buradan devam et 