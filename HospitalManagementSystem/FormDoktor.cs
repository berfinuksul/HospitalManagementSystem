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
    public partial class FormDoktor : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=HospitalManagement;uid=sa;pwd=Ibb2022#!");

        public FormDoktor()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormAnasayfa formAnasayfa = new FormAnasayfa();
            formAnasayfa.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        public void Listele()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DoktorListele";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void Temizle()
        {
            txtDoktorNo.Clear();
            txtAdSoyad.Clear();
            txtTcNo.Clear();
            txtTelefon.Clear();
            txtUnvan.Clear();
            txtUzmanlık.Clear();
            txtpoliklinikno.Clear();
            txtAdres.Clear();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DoktorEkle";
            cmd.Parameters.AddWithValue("AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("DoktorTC", txtTcNo.Text);
            cmd.Parameters.AddWithValue("Uzmanlik", txtUzmanlık.Text);
            cmd.Parameters.AddWithValue("Unvan", txtUnvan.Text);
            cmd.Parameters.AddWithValue("Telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("Adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", dateDogumtarihi.Text);
            cmd.Parameters.AddWithValue("PoliklinikNo", txtpoliklinikno.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DoktorSil";
            cmd.Parameters.AddWithValue("DoktorNo", txtDoktorNo.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DoktorGuncelle";
            cmd.Parameters.AddWithValue("DoktorNo", txtDoktorNo.Text);
            cmd.Parameters.AddWithValue("AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("DoktorTC", txtTcNo.Text);
            cmd.Parameters.AddWithValue("Uzmanlik", txtUzmanlık.Text);
            cmd.Parameters.AddWithValue("Unvan", txtUnvan.Text);
            cmd.Parameters.AddWithValue("Telefon", txtTelefon.Text);
            cmd.Parameters.AddWithValue("Adres", txtAdres.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", dateDogumtarihi.Text);
            cmd.Parameters.AddWithValue("PoliklinikNo", txtpoliklinikno.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtDoktorNo.Text = satir.Cells["DoktorNo"].Value.ToString();
            txtAdSoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
            txtTcNo.Text = satir.Cells["DoktorTC"].Value.ToString();
            txtUzmanlık.Text = satir.Cells["Uzmanlik"].Value.ToString();
            txtUnvan.Text = satir.Cells["Unvan"].Value.ToString();
            txtTelefon.Text = satir.Cells["Telefon"].Value.ToString();
            txtAdres.Text = satir.Cells["Adres"].Value.ToString();
            dateDogumtarihi.Text = satir.Cells["DogumTarihi"].Value.ToString();
            txtpoliklinikno.Text = satir.Cells["PoliklinikNo"].Value.ToString();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            if (comboxAra.Text == "Doktor No")
            {
                komut.CommandText = "DoktorNoileAra";
                komut.Parameters.AddWithValue("DoktorNo", txtAra.Text);
            }
            else if (comboxAra.Text == "Ad Soyad")
            {
                komut.CommandText = "DoktorAdSoyadileAra";
                komut.Parameters.AddWithValue("AdSoyad", txtAra.Text);
            }
            else
            {
                komut.CommandText = "DoktorTCileAra";
                komut.Parameters.AddWithValue("DoktorTC", txtAra.Text);
            }
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }
    }
}
