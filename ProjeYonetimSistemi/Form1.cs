using System;
using System.Windows.Forms;

namespace ProjeYönetimSistemi
{
    public partial class Form1 : Form
    {
        private ProjeEklemeFormu projeEkleForm = null;
        private CalisanFormu calisanform = null;
        private YeniKullaniciEkle yeniKullaniciForm = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (projeEkleForm == null || projeEkleForm.IsDisposed)
            {
                projeEkleForm = new ProjeEklemeFormu();
                projeEkleForm.Show();
            }
            else
            {
                projeEkleForm.Activate();
            }
        }

        private void btncalisan_Click(object sender, EventArgs e)
        {
            if (calisanform == null || calisanform.IsDisposed)
            {
                calisanform = new CalisanFormu();
                calisanform.Show();
            }
            else
            {
                calisanform.Activate();
            }
        }

        private void btnYeniKullanici_Click(object sender, EventArgs e)
        {
            if (yeniKullaniciForm == null || yeniKullaniciForm.IsDisposed)
            {
                yeniKullaniciForm = new YeniKullaniciEkle();
                yeniKullaniciForm.Show();
            }
            else
            {
                yeniKullaniciForm.Activate();
            }
        }
    }
}
