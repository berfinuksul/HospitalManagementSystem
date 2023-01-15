using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=HospitalManagement;uid=sa;pwd=Ibb2022#!");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Giris";
            komut.Parameters.AddWithValue("KullaniciAdi", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("Sifre", txtSifre.Text);
            con.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler ! Başarılı Bir Şekilde Giriş Yaptınız.");
                FormAnasayfa formAnasayfa = new FormAnasayfa();
                formAnasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız veya Şifreniz Hatalı. Kontrol Ediniz.");
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox2.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtemail.Text == "" || txtusername.Text == "" || txtpassword.Text == "" || txtTelefon.Text == "")
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz doldurunuz.");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KullaniciEkle";
                cmd.Parameters.AddWithValue("KullaniciAdi", txtusername.Text);
                cmd.Parameters.AddWithValue("Sifre", txtpassword.Text);
                cmd.Parameters.AddWithValue("Mail", txtemail.Text);
                cmd.Parameters.AddWithValue("Telefon", txtTelefon.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kullanıcı başarıyla kaydedildi.");
                txtusername.Clear();
                txtpassword.Clear();
                txtemail.Clear();
                txtTelefon.Clear();
            }
        }
    }
}
