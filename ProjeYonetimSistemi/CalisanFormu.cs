using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjeYönetimSistemi
{
    public partial class CalisanFormu : Form
    {
        public CalisanFormu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridViewcalisan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewcalisan.MultiSelect = false;
            dataGridViewcalisan.SelectionChanged += DataGridViewcalisan_SelectionChanged;
            LoadEmployees();
        }

        private void DataGridViewcalisan_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewcalisan.SelectedRows.Count > 0)
            {
                var row = dataGridViewcalisan.SelectedRows[0];
                if (row.Cells["AdSoyad"]?.Value != null)
                {
                    txtAdSoyad.Text = row.Cells["AdSoyad"].Value.ToString();
                }
                if (row.Cells["Pozisyon"]?.Value != null)
                {
                    txtPozisyon.Text = row.Cells["Pozisyon"].Value.ToString();
                }
            }
        }

        private void LoadEmployees()
        {
            try
            {
                DataTable employeeTable = DbConnectorManager.ExecuteStoredProcedure("CalisanlariListele");
                dataGridViewcalisan.DataSource = employeeTable;
                dataGridViewcalisan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çalışanlar yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text.Trim();
            string pozisyon = txtPozisyon.Text.Trim();

            if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(pozisyon))
            {
                MessageBox.Show("Lütfen Ad Soyad ve Pozisyon alanlarını doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@AdSoyad", MySqlDbType.VarChar) { Value = adSoyad },
                    new MySqlParameter("@Pozisyon", MySqlDbType.VarChar) { Value = pozisyon }
                };

                DbConnectorManager.ExecuteStoredProcedureNonQuery("CalisanEkle", parameters);

                MessageBox.Show("Çalışan başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAdSoyad.Clear();
                txtPozisyon.Clear();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewcalisan.SelectedRows.Count > 0)
            {
                int selectedCalisanID = Convert.ToInt32(dataGridViewcalisan.SelectedRows[0].Cells["CalisanID"].Value);
                string calisanAdi = dataGridViewcalisan.SelectedRows[0].Cells["AdSoyad"].Value?.ToString();

                DialogResult result = MessageBox.Show($"'{calisanAdi}' adlı çalışanı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        MySqlParameter[] parameters = new MySqlParameter[]
                        {
                            new MySqlParameter("@p_CalisanID", MySqlDbType.Int32) { Value = selectedCalisanID }
                        };

                        DbConnectorManager.ExecuteStoredProcedureNonQuery("CalisanSil", parameters);

                        MessageBox.Show("Çalışan başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtAdSoyad.Clear();
                        txtPozisyon.Clear();
                        LoadEmployees();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz çalışanı tablodan seçin.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewcalisan.SelectedRows.Count > 0)
            {
                int calisanID = Convert.ToInt32(dataGridViewcalisan.SelectedRows[0].Cells["CalisanID"].Value);
                string adSoyad = txtAdSoyad.Text.Trim();
                string pozisyon = txtPozisyon.Text.Trim();

                if (string.IsNullOrEmpty(adSoyad) || string.IsNullOrEmpty(pozisyon))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    DbConnectorManager.ExecuteStoredProcedureNonQuery("CalisanGuncelle", parameters);

                    MessageBox.Show("Çalışan başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtAdSoyad.Clear();
                    txtPozisyon.Clear();
                    LoadEmployees();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir çalışan seçin.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
