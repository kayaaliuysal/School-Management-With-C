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
    public partial class FrmDersIşlem : Form
    {
        public FrmDersIşlem()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.tbl_derslerTableAdapter da = new DataSet1TableAdapters.tbl_derslerTableAdapter();

        

        private void FrmDersIşlem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = da.DersListesi();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            da.DersEkle(txtAd.Text,true);
            dataGridView1.DataSource = da.DersListesi();
            MessageBox.Show("Ders Kaydınız Başarıyla Eklenmiştir");
            

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = da.DersListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            da.DersGuncelle(txtAd.Text, byte.Parse(txtİd.Text));
            dataGridView1.DataSource = da.DersListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            da.Ders_Guncelle2(byte.Parse(txtİd.Text));
            dataGridView1.DataSource = da.DersListesi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        
    }
}
