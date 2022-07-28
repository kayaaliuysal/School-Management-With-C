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

namespace E_Okul
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-91ULT0FF;Initial Catalog=E_Okul;Integrated Security=True");
        public string durum = "1";
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulup where kulup_durum=1", baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();
            
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_kulup (kulup_ad,kulup_durum) values(@p2,@p1)", baglan);
            komut.Parameters.AddWithValue("@p1", durum);
            komut.Parameters.AddWithValue("@p2", txtAd.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kulüp İşleminiz Başarıyla Kaydedilmiştir", "E-Okul", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.DarkOrange;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update tbl_kulup set kulup_durum=0 where kulup_id=@p1", baglan);
            komut.Parameters.AddWithValue("@p1", txtİd.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            listele();
            MessageBox.Show("Kaydınız Başarıyla Silinmiştir");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand(" update tbl_kulup set kulup_ad=@p1 where kulup_id=@p2", baglan);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtİd.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            listele();
            MessageBox.Show("Kaydınız başarıyla güncellenmiştir");
        }
    }
}
