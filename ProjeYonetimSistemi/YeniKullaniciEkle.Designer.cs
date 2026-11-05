namespace ProjeYönetimSistemi
{
    partial class YeniKullaniciEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnKaydol = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParolaTekrar = new System.Windows.Forms.TextBox();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.btnVazgeç = new System.Windows.Forms.Button();
            this.txteposta = new System.Windows.Forms.TextBox();
            this.labeleposta = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(194, 12);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(194, 22);
            this.txtKullaniciAdi.TabIndex = 1;
            // 
            // btnKaydol
            // 
            this.btnKaydol.Location = new System.Drawing.Point(194, 180);
            this.btnKaydol.Name = "btnKaydol";
            this.btnKaydol.Size = new System.Drawing.Size(93, 32);
            this.btnKaydol.TabIndex = 2;
            this.btnKaydol.Text = "Kayıt Ol";
            this.btnKaydol.UseVisualStyleBackColor = true;
            this.btnKaydol.Click += new System.EventHandler(this.btnKaydol_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Parola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parola Tekrar";
            // 
            // txtParolaTekrar
            // 
            this.txtParolaTekrar.Location = new System.Drawing.Point(194, 129);
            this.txtParolaTekrar.Name = "txtParolaTekrar";
            this.txtParolaTekrar.Size = new System.Drawing.Size(194, 22);
            this.txtParolaTekrar.TabIndex = 1;
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(194, 85);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(194, 22);
            this.txtParola.TabIndex = 1;
            // 
            // btnVazgeç
            // 
            this.btnVazgeç.Location = new System.Drawing.Point(295, 180);
            this.btnVazgeç.Name = "btnVazgeç";
            this.btnVazgeç.Size = new System.Drawing.Size(93, 32);
            this.btnVazgeç.TabIndex = 2;
            this.btnVazgeç.Text = "Vazgeç";
            this.btnVazgeç.UseVisualStyleBackColor = true;
            this.btnVazgeç.Click += new System.EventHandler(this.btnVazgeç_Click);
            // 
            // txteposta
            // 
            this.txteposta.Location = new System.Drawing.Point(194, 50);
            this.txteposta.Name = "txteposta";
            this.txteposta.Size = new System.Drawing.Size(194, 22);
            this.txteposta.TabIndex = 1;
            // 
            // labeleposta
            // 
            this.labeleposta.AutoSize = true;
            this.labeleposta.Location = new System.Drawing.Point(114, 53);
            this.labeleposta.Name = "labeleposta";
            this.labeleposta.Size = new System.Drawing.Size(54, 16);
            this.labeleposta.TabIndex = 3;
            this.labeleposta.Text = "E-posta";
            // 
            // YeniKullaniciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labeleposta);
            this.Controls.Add(this.btnVazgeç);
            this.Controls.Add(this.btnKaydol);
            this.Controls.Add(this.txtParola);
            this.Controls.Add(this.txteposta);
            this.Controls.Add(this.txtParolaTekrar);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "YeniKullaniciEkle";
            this.Text = "YeniKullanıcıEkle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnKaydol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParolaTekrar;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Button btnVazgeç;
        private System.Windows.Forms.TextBox txteposta;
        private System.Windows.Forms.Label labeleposta;
    }
}