using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjeYönetimSistemi
{
    public partial class YeniKullaniciEkle : Form
    {
        public YeniKullaniciEkle()
        {
            InitializeComponent();
            txtParola.UseSystemPasswordChar = true;
            txtParolaTekrar.UseSystemPasswordChar = true;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Kaydol butonuna tıklandığında
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string eposta = txteposta.Text.Trim();
            string parola = txtParola.Text;
            string parolaTekrar = txtParolaTekrar.Text;

            // Boş alan kontrolü
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(parola) || string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parolaların eşleşip eşleşmediğini kontrol et
            if (parola != parolaTekrar)
            {
                MessageBox.Show("Parolalar birbiriyle eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // E-posta format kontrolü
            if (!IsValidEmail(eposta))
            {
                MessageBox.Show("Lütfen geçerli bir e-posta adresi giriniz!", "Geçersiz E-Posta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kullanıcı adı veya e-posta zaten var mı kontrolü
                if (IsUserExist(kullaniciAdi, eposta))
                {
                    MessageBox.Show("Bu kullanıcı adı veya e-posta adresi zaten kullanımda!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parolayı SHA-256 ile özetle ve veritabanına ekle
                string hashedPassword = DbConnectorManager.HashPassword(parola);
                AddUserToDatabase(kullaniciAdi, hashedPassword, eposta);

                MessageBox.Show("Kullanıcı başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Alanları temizle ve formu kapat
                txtKullaniciAdi.Clear();
                txteposta.Clear();
                txtParola.Clear();
                txtParolaTekrar.Clear();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında bir hata oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // E-posta geçerliliğini kontrol et
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Vazgeç butonuna tıklandığında
        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Veritabanında kullanıcı adının veya e-postanın var olup olmadığını kontrol et
        private bool IsUserExist(string kullaniciAdi, string eposta)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_KullaniciAdi", MySqlDbType.VarChar) { Value = kullaniciAdi },
                new MySqlParameter("@p_Eposta", MySqlDbType.VarChar) { Value = eposta }
            };

            DataTable dt = DbConnectorManager.ExecuteStoredProcedure("KullaniciVarMi", parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0]["KayitSayisi"]);
                return count > 0;
            }

            return false;
        }

        // Yeni kullanıcıyı veritabanına saklı yordam ile ekle
        private void AddUserToDatabase(string kullaniciAdi, string parola, string eposta)
        {
            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@p_KullaniciAdi", MySqlDbType.VarChar) { Value = kullaniciAdi },
                new MySqlParameter("@p_Eposta", MySqlDbType.VarChar) { Value = eposta },
                new MySqlParameter("@p_Parola", MySqlDbType.VarChar) { Value = parola }
            };

            DbConnectorManager.ExecuteStoredProcedureNonQuery("KullaniciEkle", parameters);
        }
    }
}
