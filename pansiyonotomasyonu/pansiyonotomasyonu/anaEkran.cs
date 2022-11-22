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
    public partial class anaEkran : Form
    {
        public anaEkran()
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmMusteriKayit kayitEkrani = new frmMusteriKayit();
            kayitEkrani.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musteriEkrani musteri = new musteriEkrani();
            musteri.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 giris = new Form1();
            giris.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmOdalar oda = new frmOdalar();
            oda.Show();
        }
        
        private void anaEkran_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "http://fenomen.listenfenomen.com/fenomen/128/icecast.audio";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume += 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume -= 5;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = 0;
        }
    }
}
