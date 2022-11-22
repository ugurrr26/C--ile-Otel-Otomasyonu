using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pansiyonotomasyonu
{
    public partial class frmOdalar : Form
    {
        public frmOdalar()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                    {
                        m.Result = (IntPtr)0x2;
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        
        private void frmOdalar_Load(object sender, EventArgs e)
        {
            csOdalar oda = new csOdalar();
            dataGridView1.DataSource = oda.tablola();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblID.Text= Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
             txtOda.Text= dataGridView1.Rows[e.RowIndex].Cells["odaAdi"].Value.ToString();
             txtMusteri.Text= dataGridView1.Rows[e.RowIndex].Cells["odayiAlan"].Value.ToString();
             cmbDurum.Text= dataGridView1.Rows[e.RowIndex].Cells["durumu"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblID.Text);
            csOdalar oda = new csOdalar();
            oda.odaGuncelle(id, txtMusteri.Text, cmbDurum.Text);
            dataGridView1.DataSource = oda.tablola();
        }
    }
}
