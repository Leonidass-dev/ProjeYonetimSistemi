using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjeYönetimSistemi
{
    public partial class CalisanFormu : Form
    {
        public CalisanFormu()
        {
            InitializeComponent();
            LoadEmployees();
        }
        private void LoadEmployees()
        {

            try
            {

                DataTable employeeTable = DbConnectorManager.ExecuteStoredProcedure("CalisanlariListele");


                dataGridViewcalisan.DataSource = employeeTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text;
            string pozisyon = txtPozisyon.Text;

            if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(pozisyon))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                MySqlParameter[] parameters = new MySqlParameter[]
                {
            new MySqlParameter("@AdSoyad", MySqlDbType.VarChar) { Value = adSoyad },
            new MySqlParameter("@Pozisyon", MySqlDbType.VarChar) { Value = pozisyon }
                };

                DbConnectorManager.ExecuteStoredProcedure("CalisanEkle", parameters);

                MessageBox.Show("Çalışan başarıyla eklendi!");

                // Çalışanları yeniden yükle
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewcalisan.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki CalisanID'yi al
                int selectedCalisanID = Convert.ToInt32(dataGridViewcalisan.SelectedRows[0].Cells["CalisanID"].Value);

                // Seçilen çalışanın silinip silinmeyeceğini onayla
                DialogResult result = MessageBox.Show("Seçilen çalışanı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        MySqlParameter[] parameters = new MySqlParameter[]
                        {
                        new MySqlParameter("@p_CalisanID", MySqlDbType.Int32) { Value = selectedCalisanID }
                        };

                        // Çalışan silme prosedürünü çağır
                        DbConnectorManager.ExecuteStoredProcedure("CalisanSil", parameters);

                        MessageBox.Show("Çalışan başarıyla silindi!");
                        LoadEmployees();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz çalışanı seçin.");
            }
        }
    



        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewcalisan.SelectedRows.Count > 0)
            {
                int calisanID = Convert.ToInt32(dataGridViewcalisan.SelectedRows[0].Cells[0].Value); // CalisanID'yi al
                string adSoyad = txtAdSoyad.Text;
                string pozisyon = txtPozisyon.Text;

                if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(pozisyon))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.");
                    return;
                }

                try
                {
                    MySqlParameter[] parameters = new MySqlParameter[]
                    {
                new MySqlParameter("@p_CalisanID", MySqlDbType.Int32) { Value = calisanID },
                new MySqlParameter("@p_AdSoyad", MySqlDbType.VarChar) { Value = adSoyad },
                new MySqlParameter("@p_Pozisyon", MySqlDbType.VarChar) { Value = pozisyon }
                    };

                    DbConnectorManager.ExecuteStoredProcedure("CalisanGuncelle", parameters);

                    MessageBox.Show("Çalışan başarıyla güncellendi!");

                    // Çalışanları yeniden yükle
                    LoadEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir çalışan seçin.");
            }
        }





    }
}
