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
    public partial class FormHasta : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=HospitalManagement;uid=sa;pwd=Ibb2022#!");
        public FormHasta()
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
            cmd.CommandText = "HastaListele";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void Temizle()
        {
            txtHastaNo.Clear();
            txtAdSoyad.Clear();
            txtHastaTC.Clear();
            txtYas.Clear();
            txtBoy.Clear();
            txtRecete.Clear();
            txtRaporDurumu.Clear();
            txtDoktorno.Clear();
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
            cmd.CommandText = "HastaEkle";
            cmd.Parameters.AddWithValue("HastaTC", txtHastaTC.Text);
            cmd.Parameters.AddWithValue("AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", dateDogumTarihi.Text);
            cmd.Parameters.AddWithValue("Boy", txtBoy.Text);
            cmd.Parameters.AddWithValue("Yas", txtYas.Text);
            cmd.Parameters.AddWithValue("Recete", txtRecete.Text);
            cmd.Parameters.AddWithValue("RaporDurumu", txtRaporDurumu.Text);
            cmd.Parameters.AddWithValue("RandevuTarihi", dateRandevutarihi.Text);
            cmd.Parameters.AddWithValue("DoktorNo", txtDoktorno.Text);
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
            cmd.CommandText = "HastaSil";
            cmd.Parameters.AddWithValue("HastaNo", txtHastaNo.Text);
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
            cmd.CommandText = "HastaGuncelle";
            cmd.Parameters.AddWithValue("HastaNo", txtHastaNo.Text);
            cmd.Parameters.AddWithValue("HastaTC", txtHastaTC.Text);
            cmd.Parameters.AddWithValue("AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", dateDogumTarihi.Text);
            cmd.Parameters.AddWithValue("Boy", txtBoy.Text);
            cmd.Parameters.AddWithValue("Yas", txtYas.Text);
            cmd.Parameters.AddWithValue("Recete", txtRecete.Text);
            cmd.Parameters.AddWithValue("RaporDurumu", txtRaporDurumu.Text);
            cmd.Parameters.AddWithValue("RandevuTarihi", dateRandevutarihi.Text);
            cmd.Parameters.AddWithValue("DoktorNo", txtDoktorno.Text);
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
            txtHastaNo.Text = satir.Cells["HastaNo"].Value.ToString();
            txtHastaTC.Text = satir.Cells["HastaTC"].Value.ToString();
            txtAdSoyad.Text = satir.Cells["AdSoyad"].Value.ToString();
            dateDogumTarihi.Text = satir.Cells["DogumTarihi"].Value.ToString();
            txtBoy.Text = satir.Cells["Boy"].Value.ToString();
            txtYas.Text = satir.Cells["Yas"].Value.ToString();
            txtRecete.Text = satir.Cells["Recete"].Value.ToString();
            txtRaporDurumu.Text = satir.Cells["RaporDurumu"].Value.ToString();
            dateRandevutarihi.Text = satir.Cells["RandevuTarihi"].Value.ToString();
            txtDoktorno.Text = satir.Cells["DoktorNo"].Value.ToString();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "HastaTCileAra";
            komut.Parameters.AddWithValue("HastaTC", txtAra.Text);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;
            con.Close();
        }
    }
}
