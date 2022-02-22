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
namespace OgrenciKayit
{
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }
        public void Ogrenciler()
        {
            baglanti.Open();
            SqlCommand veriler = new SqlCommand("select OgrenciNo from Ogrenciler", baglanti);
            SqlDataReader veri = veriler.ExecuteReader();
            while (veri.Read())
            {
                comboBox1.Items.Add(veri[0]);
            }
            baglanti.Close();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Okul;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand OgrenciKayitEkle = new SqlCommand("insert into Ogrenciler (OgrenciNo,OgrenciAd,OgrenciSoyad,KayitTarihi) values (@no,@ad,@soyad,@tarih)", baglanti);
            OgrenciKayitEkle.Parameters.AddWithValue("@no", TxtOgrencino.Text);
            OgrenciKayitEkle.Parameters.AddWithValue("@ad", TxtOgrenciAd.Text);
            OgrenciKayitEkle.Parameters.AddWithValue("@soyad", TxtOgrenciSoyad.Text);
            OgrenciKayitEkle.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            OgrenciKayitEkle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Kaydı Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TxtOgrenciAd.Clear();
            TxtOgrenciSoyad.Clear();
            TxtOgrencino.Clear();
            dateTimePicker1.ResetText();



        }

       public string kayit;
        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            Ogrenciler();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count (*) from Ogrenciler where OgrenciNo='"+ GlobalDeger.ogrencino.ToString()+"'", baglanti);
           

SqlDataReader data = komut.ExecuteReader();



            while (data.Read())
            {
                kayit = data[0].ToString();

            }
            baglanti.Close();


            if (kayit == "1")
            {



                comboBox1.Text = GlobalDeger.ogrencino.ToString();
                TxtOgrencino.Text = GlobalDeger.ogrencino.ToString();

                comboBox1_SelectedIndexChanged(comboBox1, e);

            }
            else
            {

                TxtOgrencino.Text = GlobalDeger.ogrencino.ToString();

             




            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from Ogrenciler where OgrenciNo like'" + comboBox1.Text + "'", baglanti);
            SqlDataReader veri = komut.ExecuteReader();
            while (veri.Read())

            {
                TxtOgrencino.Text = veri[1].ToString();
                TxtOgrenciAd.Text = veri[2].ToString();
                TxtOgrenciSoyad.Text = veri[3].ToString();
                dateTimePicker1.Text = veri[4].ToString();
            }
            baglanti.Close();
        }
            



        }
}
