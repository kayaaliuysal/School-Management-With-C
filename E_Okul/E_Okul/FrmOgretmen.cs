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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void btnDersIslem_Click(object sender, EventArgs e)
        {
            FrmDersIşlem fr = new FrmDersIşlem();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenciislem fr = new FrmOgrenciislem();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSinavNotlar fr = new frmSinavNotlar();
            fr.Show();
        }
    }
}
