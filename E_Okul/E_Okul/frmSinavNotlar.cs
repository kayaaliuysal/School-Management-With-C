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
    public partial class frmSinavNotlar : Form
    {
        public frmSinavNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-91ULT0FF;Initial Catalog=E_Okul;Integrated Security=True");

        DataSet1TableAdapters.tbl_notTableAdapter ds = new DataSet1TableAdapters.tbl_notTableAdapter();

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtİd.Text));
        }

        private void frmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_dersler", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);            
            cmbDers.DisplayMember = "ders_ad";
            cmbDers.ValueMember = "ders_id";
            cmbDers.DataSource = dt;
            baglan.Close();
        }
        int notid;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtİd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sınav1, sınav2, sınav3, proje;

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtİd.Text = "";
            
        }

        double ort;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            
            //string durum;
            sınav1 = Convert.ToInt32(txtSınav1.Text);
            sınav2 = Convert.ToInt32(txtSınav2.Text);
            sınav3 = Convert.ToInt32(txtSınav3.Text);
            proje = Convert.ToInt32(txtProje.Text);
            ort = (sınav1 + sınav2 + sınav3 + proje) / 4;
            txtOrt.Text = ort.ToString();
            if (ort < 50)
            {
                txtDurum.Text = "False";
            }
            else
            {
                txtDurum.Text = "True";
            }
            
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()), int.Parse(txtİd.Text),byte.Parse( sınav1.ToString()),byte.Parse(sınav2.ToString()),byte.Parse(sınav3.ToString()),byte.Parse(proje.ToString()),decimal.Parse(ort.ToString()),bool.Parse(txtDurum.Text),notid);
        }
    }
}
