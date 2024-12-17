namespace ProjeYönetimSistemi
{
    partial class CalisanFormu
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
            this.dataGridViewcalisan = new System.Windows.Forms.DataGridView();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtPozisyon = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcalisan)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewcalisan
            // 
            this.dataGridViewcalisan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewcalisan.Location = new System.Drawing.Point(32, 27);
            this.dataGridViewcalisan.Name = "dataGridViewcalisan";
            this.dataGridViewcalisan.RowHeadersWidth = 51;
            this.dataGridViewcalisan.RowTemplate.Height = 24;
            this.dataGridViewcalisan.Size = new System.Drawing.Size(544, 274);
            this.dataGridViewcalisan.TabIndex = 0;
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(618, 27);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(374, 22);
            this.txtAdSoyad.TabIndex = 1;
            // 
            // txtPozisyon
            // 
            this.txtPozisyon.Location = new System.Drawing.Point(618, 68);
            this.txtPozisyon.Name = "txtPozisyon";
            this.txtPozisyon.Size = new System.Drawing.Size(374, 22);
            this.txtPozisyon.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(618, 145);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(138, 44);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Çalışan Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Çalışan Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(618, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "Çalışan Güncelle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // CalisanFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1190, 548);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtPozisyon);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.dataGridViewcalisan);
            this.Name = "CalisanFormu";
            this.Text = "ÇalışanFormu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewcalisan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewcalisan;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtPozisyon;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}