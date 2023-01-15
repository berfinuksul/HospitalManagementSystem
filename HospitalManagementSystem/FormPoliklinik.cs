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
    public partial class FormPoliklinik : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=HospitalManagement;uid=sa;pwd=Ibb2022#!");
        public FormPoliklinik()
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
            cmd.CommandText = "PoliklinikListele";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void Temizle()
        {
            txtPolikNo.Clear();
            txtPolikAd.Clear();
            txtUzmanSayısı.Clear();
            txtPolikBaskani.Clear();
            txtBashemsire.Clear();
            txtYatakSayisi.Clear();
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
            cmd.CommandText = "PoliklinikEkle";
            cmd.Parameters.AddWithValue("PoliklinikAdi", txtPolikAd.Text);
            cmd.Parameters.AddWithValue("UzmanSayisi", txtUzmanSayısı.Text);
            cmd.Parameters.AddWithValue("BaskanAdi", txtPolikBaskani.Text);
            cmd.Parameters.AddWithValue("BasHemsireAdi", txtBashemsire.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", txtYatakSayisi.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtPolikNo.Text = satir.Cells["PoliklinikNo"].Value.ToString();
            txtPolikAd.Text = satir.Cells["PoliklinikAdi"].Value.ToString();
            txtUzmanSayısı.Text = satir.Cells["UzmanSayisi"].Value.ToString();
            txtPolikBaskani.Text = satir.Cells["BaskanAdi"].Value.ToString();
            txtBashemsire.Text = satir.Cells["BasHemsireAdi"].Value.ToString();
            txtYatakSayisi.Text = satir.Cells["YatakSayisi"].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PoliklinikSil";
            cmd.Parameters.AddWithValue("PoliklinikNo", txtPolikNo.Text);
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
            cmd.CommandText = "PoliklinikGuncelle";
            cmd.Parameters.AddWithValue("PoliklinikNo", txtPolikNo.Text);
            cmd.Parameters.AddWithValue("PoliklinikAdi", txtPolikAd.Text);
            cmd.Parameters.AddWithValue("UzmanSayisi", txtUzmanSayısı.Text);
            cmd.Parameters.AddWithValue("BaskanAdi", txtPolikBaskani.Text);
            cmd.Parameters.AddWithValue("BasHemsireAdi", txtBashemsire.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", txtYatakSayisi.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Listele();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
