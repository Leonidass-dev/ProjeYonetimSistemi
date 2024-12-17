namespace ProjeYönetimSistemi
{
    partial class ProjeEklemeFormu
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtProjeAdi = new System.Windows.Forms.TextBox();
            this.dtpBaslangicTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpBitisTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnProjeEkle = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(41, 23);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(570, 323);
            this.dataGridView2.TabIndex = 0;
            // 
            // txtProjeAdi
            // 
            this.txtProjeAdi.Location = new System.Drawing.Point(631, 37);
            this.txtProjeAdi.Name = "txtProjeAdi";
            this.txtProjeAdi.Size = new System.Drawing.Size(406, 22);
            this.txtProjeAdi.TabIndex = 1;
            // 
            // dtpBaslangicTarihi
            // 
            this.dtpBaslangicTarihi.CustomFormat = "";
            this.dtpBaslangicTarihi.Location = new System.Drawing.Point(631, 65);
            this.dtpBaslangicTarihi.Name = "dtpBaslangicTarihi";
            this.dtpBaslangicTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpBaslangicTarihi.TabIndex = 2;
            this.dtpBaslangicTarihi.Value = new System.DateTime(2024, 12, 15, 18, 19, 6, 0);
            // 
            // dtpBitisTarihi
            // 
            this.dtpBitisTarihi.CustomFormat = "";
            this.dtpBitisTarihi.Location = new System.Drawing.Point(837, 65);
            this.dtpBitisTarihi.Name = "dtpBitisTarihi";
            this.dtpBitisTarihi.Size = new System.Drawing.Size(200, 22);
            this.dtpBitisTarihi.TabIndex = 2;
            this.dtpBitisTarihi.Value = new System.DateTime(2024, 12, 15, 18, 19, 13, 0);
            // 
            // btnProjeEkle
            // 
            this.btnProjeEkle.Location = new System.Drawing.Point(742, 93);
            this.btnProjeEkle.Name = "btnProjeEkle";
            this.btnProjeEkle.Size = new System.Drawing.Size(172, 49);
            this.btnProjeEkle.TabIndex = 3;
            this.btnProjeEkle.Text = "Proje EKLE";
            this.btnProjeEkle.UseVisualStyleBackColor = true;
            this.btnProjeEkle.Click += new System.EventHandler(this.btnProjeEkle_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ProjeEklemeFormu
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 673);
            this.Controls.Add(this.btnProjeEkle);
            this.Controls.Add(this.dtpBitisTarihi);
            this.Controls.Add(this.dtpBaslangicTarihi);
            this.Controls.Add(this.txtProjeAdi);
            this.Controls.Add(this.dataGridView2);
            this.Name = "ProjeEklemeFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtProjeAdi;
        private System.Windows.Forms.DateTimePicker dtpBaslangicTarihi;
        private System.Windows.Forms.DateTimePicker dtpBitisTarihi;
        private System.Windows.Forms.Button btnProjeEkle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}