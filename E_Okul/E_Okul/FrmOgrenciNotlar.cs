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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-91ULT0FF;Initial Catalog=E_Okul;Integrated Security=True");
        public string ogrenci_id;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select ders_ad,sınav1,sınav2,sınav3,ortalama,durum from tbl_not inner join tbl_dersler on tbl_not.ders_id=tbl_dersler.ders_id where ogrenci_id=@p1", baglan);
            komut.Parameters.AddWithValue("@p1", ogrenci_id);                        
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();

            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select ogrenci_ad,ogrenci_soyad from tbl_ogrenci where ogrenci_id=@p1", baglan);
            komut1.Parameters.AddWithValue("@p1", ogrenci_id);
            SqlDataReader dr_komut1 = komut1.ExecuteReader();
            while (dr_komut1.Read())
            {
                this.Text = dr_komut1[0] + " " + dr_komut1[1];
            }

            
        }
    }
}
