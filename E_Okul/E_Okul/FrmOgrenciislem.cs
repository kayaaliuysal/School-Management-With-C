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
    public partial class FrmOgrenciislem : Form
    {
        public FrmOgrenciislem()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-91ULT0FF;Initial Catalog=E_Okul;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter dt = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenciislem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt.OgrenciGetir();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_kulup", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable df = new DataTable();
            da.Fill(df);
            cmbKulup.DisplayMember = "kulup_ad";
            cmbKulup.ValueMember = "kulup_id";
            cmbKulup.DataSource = df;
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            
            dt.OgrenciEkle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c);
            dataGridView1.DataSource = dt.OgrenciGetir();
            MessageBox.Show("Öğrenci Başarıyla Kaydedilmiştir");
        }

        private void cmbKulup_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            dt.OgrenciGuncelle2(Convert.ToInt32(txtİd.Text));
            dataGridView1.DataSource = dt.OgrenciGetir();
            MessageBox.Show("Öğrenci Başarıyla Silinmiştir");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()=="kız")
            {
                radioButton1.Checked = true;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()=="erkek")
            {
                radioButton2.Checked = true;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "kız";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                c = "erkek";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            dt.OgrenciGuncelle(txtAd.Text, txtSoyad.Text, byte.Parse(cmbKulup.SelectedValue.ToString()), c, int.Parse(txtİd.Text));
            dataGridView1.DataSource = dt.OgrenciGetir();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= dt.OgrenciGetirr(txtAra.Text);
        }
    }
}
