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
    public partial class YeniKullaniciEkle : Form
    {        
        public YeniKullaniciEkle()
        {
            InitializeComponent();
        }

        // Kaydol butonuna tıklandığında
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string eposta = txteposta.Text;
            string parola = txtParola.Text;
            string parolaTekrar = txtParolaTekrar.Text;

            // Parolaların eşleşip eşleşmediğini kontrol et
            if (parola != parolaTekrar)
            {
                MessageBox.Show("Parolalar eşleşmiyor!");
                return;
            }

            // Kullanıcı adı boş mu diye kontrol et
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(parola) || string.IsNullOrEmpty(eposta))
            {
                MessageBox.Show("Kullanıcı adı,e-posta veya parola boş olamaz!");
                return;
            }
            
            if (!IsValidEmail(eposta))
            {
                MessageBox.Show("Geçersiz e-posta adresi!");
                return;
            }
           
            if (IsUserExist(kullaniciAdi))
            {
                MessageBox.Show("Bu kullanıcı adı zaten alınmış!");
                return;
            }

            // Kullanıcıyı veritabanına ekle
            AddUserToDatabase(kullaniciAdi, parola, eposta);



            MessageBox.Show("Kayıt başarılı!");
            this.Hide();  // YeniKullaniciEkle formunu kapat
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
            this.Hide();  // Formu kapat
        }

        // Veritabanında kullanıcı adının var olup olmadığını kontrol et
        private bool IsUserExist(string kullaniciAdi)
        {
            string query = "SELECT COUNT(*) FROM kullanicilar WHERE KullaniciAdi = @AdıSoyadı";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@AdıSoyadı", MySqlDbType.VarChar) { Value = kullaniciAdi }
            };

            DataTable dt = DbConnectorManager.ExecuteStoredProcedure(query, parameters);
            return dt.Rows.Count > 0;

        }

        // Yeni kullanıcıyı veritabanına ekle
        private void AddUserToDatabase(string kullaniciAdi, string parola,string eposta)
        {
            string query = "INSERT INTO kullanicilar (AdıSoyadı, Sifre, Eposta) VALUES (@AdıSoyadı, @Sifre, @Eposta)";

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                new MySqlParameter("@AdıSoyadı", MySqlDbType.VarChar) { Value = kullaniciAdi },
                new MySqlParameter("@Sifre", MySqlDbType.VarChar) { Value = parola },
                new MySqlParameter("@Eposta", MySqlDbType.VarChar) { Value = eposta } // Eposta parametresi
            };

            DbConnectorManager.ExecuteStoredProcedureNonQuery(query, parameters);
        }

        
    }
}
