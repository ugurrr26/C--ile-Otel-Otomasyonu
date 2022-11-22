using System;
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
    public partial class musteriEkrani : Form
    {
        public musteriEkrani()
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


        private void cmbCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUcret_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOda_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoyadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdi_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime girisTarihi = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime cikisTarihi = Convert.ToDateTime(dateTimePicker2.Value);
            int id = Convert.ToInt16(lblID.Text);
            csMusteriEkrani me = new csMusteriEkrani();
            me.musteriGuncelle(id, txtAdi.Text, txtSoyadi.Text, cmbCinsiyet.Text, txtTelefon.Text, txtMail.Text, txtTc.Text, txtOda.Text, txtUcret.Text, girisTarihi, cikisTarihi);
            dataGridView1.DataSource = me.tablola();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void musteriEkrani_Load(object sender, EventArgs e)
        {
            csMusteriEkrani me = new csMusteriEkrani();
            dataGridView1.DataSource = me.tablola();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             lblID.Text= Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
             txtAdi.Text = dataGridView1.Rows[e.RowIndex].Cells["adi"].Value.ToString();
             txtSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells["soyadi"].Value.ToString();
             cmbCinsiyet.Text = dataGridView1.Rows[e.RowIndex].Cells["cinsiyet"].Value.ToString();
             txtTelefon.Text = dataGridView1.Rows[e.RowIndex].Cells["telefon"].Value.ToString();
             txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells["mail"].Value.ToString();
             txtTc.Text = dataGridView1.Rows[e.RowIndex].Cells["tcNo"].Value.ToString();
             txtOda.Text = dataGridView1.Rows[e.RowIndex].Cells["odaNo"].Value.ToString();
             txtUcret.Text = dataGridView1.Rows[e.RowIndex].Cells["ucret"].Value.ToString();
             dateTimePicker1.Value=Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["girisTarihi"].Value);
             dateTimePicker2.Value=Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["cikisTarihi"].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            csMusteriEkrani me = new csMusteriEkrani();
            dataGridView1.DataSource = me.tablola();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            cmbCinsiyet.Text = "";
            txtTelefon.Text = "";
            txtMail.Text = "";
            txtTc.Text = "";
            txtOda.Text = "";
            txtUcret.Text = "";
            dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblID.Text);
            csMusteriEkrani me = new csMusteriEkrani();
            me.musteriSil(id);
            dataGridView1.DataSource = me.tablola();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            csMusteriEkrani me = new csMusteriEkrani();
           dataGridView1.DataSource= me.aramaYap(txtAra.Text);

        }
    }
}
