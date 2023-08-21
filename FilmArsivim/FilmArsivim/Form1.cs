using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FilmArsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-S866UD2;Initial Catalog=FilmArsivim;Integrated Security=True");

        void filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBLFILMLER",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filmler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLFILMLER (AD,KATEGORI,LINK) VALUES (@P1,@P2,@P3)",baglanti);
            komut.Parameters.AddWithValue("@P1",TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2",TxtKategori.Text);
            komut.Parameters.AddWithValue("@P3",TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Eklendi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Şafak ŞAhin tarafından 4 Temmuz 2018'de kodlandı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
