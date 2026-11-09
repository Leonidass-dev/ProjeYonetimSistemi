namespace ProjeYönetimSistemi
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btncalisan = new System.Windows.Forms.Button();
            this.btnYeniKullanici = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(40, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 140);
            this.button1.TabIndex = 0;
            this.button1.Text = "📋 Proje İşlemleri";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncalisan
            // 
            this.btncalisan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btncalisan.Location = new System.Drawing.Point(360, 60);
            this.btncalisan.Name = "btncalisan";
            this.btncalisan.Size = new System.Drawing.Size(280, 140);
            this.btncalisan.TabIndex = 1;
            this.btncalisan.Text = "👥 Çalışan Yönetimi";
            this.btncalisan.UseVisualStyleBackColor = true;
            this.btncalisan.Click += new System.EventHandler(this.btncalisan_Click);
            // 
            // btnYeniKullanici
            // 
            this.btnYeniKullanici.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniKullanici.Location = new System.Drawing.Point(680, 60);
            this.btnYeniKullanici.Name = "btnYeniKullanici";
            this.btnYeniKullanici.Size = new System.Drawing.Size(280, 140);
            this.btnYeniKullanici.TabIndex = 2;
            this.btnYeniKullanici.Text = "🔐 Kullanıcı Kaydı";
            this.btnYeniKullanici.UseVisualStyleBackColor = true;
            this.btnYeniKullanici.Click += new System.EventHandler(this.btnYeniKullanici_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 280);
            this.Controls.Add(this.btnYeniKullanici);
            this.Controls.Add(this.btncalisan);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proje ve Çalışan Yönetim Sistemi - Ana Menü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btncalisan;
        private System.Windows.Forms.Button btnYeniKullanici;
    }
}
