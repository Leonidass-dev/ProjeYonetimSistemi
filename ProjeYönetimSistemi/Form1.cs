using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeYönetimSistemi
{
    public partial class Form1 : Form
    {
        private ProjeEklemeFormu projeEkleForm = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Eğer form daha önce açılmadıysa, aç
            if (projeEkleForm == null || projeEkleForm.IsDisposed)
            {
                projeEkleForm = new ProjeEklemeFormu();
                projeEkleForm.Show();
            }
            else
            {
                // Form daha önce açıldıysa, sadece göster
                projeEkleForm.Activate();  // Var olan formu ön planda aktif hale getir
            }

        }

        private CalisanFormu calisanform = null;
        private void btncalisan_Click(object sender, EventArgs e)
        {
            // Eğer form daha önce açılmadıysa, aç
            if (calisanform == null || calisanform.IsDisposed)
            {
                calisanform = new CalisanFormu();
                calisanform.Show();
            }
            else
            {
                // Form daha önce açıldıysa, sadece göster
                calisanform.Activate();  // Var olan formu ön planda aktif hale getir
            }
        }

        
    }
}
