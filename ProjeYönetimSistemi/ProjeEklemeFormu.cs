using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using ProjeYönetimSistemi;

namespace ProjeYönetimSistemi
{
    public partial class ProjeEklemeFormu : Form
    {
        public ProjeEklemeFormu()
        {
            InitializeComponent();
            LoadProjects();
            LoadDurumOptions();
        }
        private void LoadProjects()
        {

            try
            {

                DataTable projectTable = DbConnectorManager.ExecuteStoredProcedure("ProjeleriListele");


                dataGridView2.DataSource = projectTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void LoadDurumOptions()
        {
            
        }

        private void btnProjeEkle_Click_1(object sender, EventArgs e)
        {          
            string projeAdi = txtProjeAdi.Text;
            DateTime baslangicTarihi = dtpBaslangicTarihi.Value;
            DateTime bitisTarihi = dtpBitisTarihi.Value;
            int kullaniciID = 1;
            
            if (string.IsNullOrEmpty(projeAdi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.");
                return;
            }
            if (baslangicTarihi > bitisTarihi)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz!");
                return;
            }


            try
            {                
                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@ProjeAdi", MySqlDbType.VarChar) { Value = projeAdi },
                    new MySqlParameter("@BaslangicTarihi", MySqlDbType.Date) { Value = baslangicTarihi }, 
                    new MySqlParameter("@BitisTarihi", MySqlDbType.Date) { Value = bitisTarihi },  
                    new MySqlParameter("@KullaniciID", MySqlDbType.Int32) { Value = kullaniciID } 
                };




                // Saklı yordamı çağırıyoruz
                DbConnectorManager.ExecuteStoredProcedure("ProjeEkle", parameters);

                MessageBox.Show("Proje başarıyla eklendi!");

               
                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
    

        
        
        
        
        
        
        
        








    

