using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjeYönetimSistemi
{
    public partial class ProjeEklemeFormu : Form
    {
        public ProjeEklemeFormu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dtpBaslangicTarihi.Value = DateTime.Today;
            dtpBitisTarihi.Value = DateTime.Today.AddMonths(1);
            LoadProjects();
        }

        private void LoadProjects()
        {
            try
            {
                DataTable projectTable = DbConnectorManager.ExecuteStoredProcedure("ProjeleriListele");
                dataGridView2.DataSource = projectTable;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Projeler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProjeEkle_Click_1(object sender, EventArgs e)
        {
            string projeAdi = txtProjeAdi.Text.Trim();
            DateTime baslangicTarihi = dtpBaslangicTarihi.Value.Date;
            DateTime bitisTarihi = dtpBitisTarihi.Value.Date;
            int kullaniciID = 1; // Varsayılan yönetici kullanıcı

            if (string.IsNullOrEmpty(projeAdi))
            {
                MessageBox.Show("Lütfen proje adını giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (baslangicTarihi > bitisTarihi)
            {
                MessageBox.Show("Başlangıç tarihi bitiş tarihinden sonra olamaz!", "Geçersiz Tarih", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                DbConnectorManager.ExecuteStoredProcedureNonQuery("ProjeEkle", parameters);

                MessageBox.Show("Proje başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtProjeAdi.Clear();
                dtpBaslangicTarihi.Value = DateTime.Today;
                dtpBitisTarihi.Value = DateTime.Today.AddMonths(1);
                LoadProjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proje ekleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
