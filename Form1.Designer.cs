namespace CRUDmahasiswaADO
{
    partial class Form1
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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtNIM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbJK = new System.Windows.Forms.ComboBox();
            this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKodeProdi = new System.Windows.Forms.TextBox();
            this.MembukaKoneksi = new System.Windows.Forms.Button();
            this.MenampilkanData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MenambahData = new System.Windows.Forms.Button();
            this.MengubahData = new System.Windows.Forms.Button();
            this.MenghapusData = new System.Windows.Forms.Button();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(38, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(38, 20);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "NIM";
            this.Label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNIM
            // 
            this.txtNIM.Location = new System.Drawing.Point(142, 28);
            this.txtNIM.Name = "txtNIM";
            this.txtNIM.Size = new System.Drawing.Size(167, 26);
            this.txtNIM.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(150, 77);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(159, 26);
            this.txtNama.TabIndex = 3;
            this.txtNama.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Jenis Kelamin";
            // 
            // cmbJK
            // 
            this.cmbJK.FormattingEnabled = true;
            this.cmbJK.Items.AddRange(new object[] {
            "P",
            "L"});
            this.cmbJK.Location = new System.Drawing.Point(150, 124);
            this.cmbJK.Name = "cmbJK";
            this.cmbJK.Size = new System.Drawing.Size(121, 28);
            this.cmbJK.TabIndex = 5;
            this.cmbJK.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpTanggalLahir
            // 
            this.dtpTanggalLahir.Location = new System.Drawing.Point(150, 172);
            this.dtpTanggalLahir.Name = "dtpTanggalLahir";
            this.dtpTanggalLahir.Size = new System.Drawing.Size(159, 26);
            this.dtpTanggalLahir.TabIndex = 6;
            this.dtpTanggalLahir.Value = new System.DateTime(2026, 4, 9, 0, 0, 0, 0);
            this.dtpTanggalLahir.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tanggal Lahir";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Alamat";
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(150, 232);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(159, 26);
            this.txtAlamat.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kode Prodi";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtKodeProdi
            // 
            this.txtKodeProdi.Location = new System.Drawing.Point(150, 279);
            this.txtKodeProdi.Name = "txtKodeProdi";
            this.txtKodeProdi.Size = new System.Drawing.Size(100, 26);
            this.txtKodeProdi.TabIndex = 11;
            this.txtKodeProdi.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // MembukaKoneksi
            // 
            this.MembukaKoneksi.Location = new System.Drawing.Point(494, 23);
            this.MembukaKoneksi.Name = "MembukaKoneksi";
            this.MembukaKoneksi.Size = new System.Drawing.Size(159, 37);
            this.MembukaKoneksi.TabIndex = 12;
            this.MembukaKoneksi.Text = "Membuka Koneksi";
            this.MembukaKoneksi.UseVisualStyleBackColor = true;
            this.MembukaKoneksi.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenampilkanData
            // 
            this.MenampilkanData.Location = new System.Drawing.Point(494, 77);
            this.MenampilkanData.Name = "MenampilkanData";
            this.MenampilkanData.Size = new System.Drawing.Size(159, 35);
            this.MenampilkanData.TabIndex = 13;
            this.MenampilkanData.Text = "Menampilkan Data";
            this.MenampilkanData.UseVisualStyleBackColor = true;
            this.MenampilkanData.Click += new System.EventHandler(this.MenampilkanData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(142, 311);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(479, 157);
            this.dataGridView1.TabIndex = 14;
            // 
            // MenambahData
            // 
            this.MenambahData.Location = new System.Drawing.Point(494, 127);
            this.MenambahData.Name = "MenambahData";
            this.MenambahData.Size = new System.Drawing.Size(159, 35);
            this.MenambahData.TabIndex = 15;
            this.MenambahData.Text = "Menambah Data";
            this.MenambahData.UseVisualStyleBackColor = true;
            this.MenambahData.Click += new System.EventHandler(this.MenambahData_Click);
            // 
            // MengubahData
            // 
            this.MengubahData.Location = new System.Drawing.Point(494, 172);
            this.MengubahData.Name = "MengubahData";
            this.MengubahData.Size = new System.Drawing.Size(159, 35);
            this.MengubahData.TabIndex = 16;
            this.MengubahData.Text = "Mengubah Data";
            this.MengubahData.UseVisualStyleBackColor = true;
            // 
            // MenghapusData
            // 
            this.MenghapusData.Location = new System.Drawing.Point(494, 217);
            this.MenghapusData.Name = "MenghapusData";
            this.MenghapusData.Size = new System.Drawing.Size(159, 35);
            this.MenghapusData.TabIndex = 17;
            this.MenghapusData.Text = "Menghapus Data";
            this.MenghapusData.UseVisualStyleBackColor = true;
            this.MenghapusData.Click += new System.EventHandler(this.MenghapusData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.MenghapusData);
            this.Controls.Add(this.MengubahData);
            this.Controls.Add(this.MenambahData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MenampilkanData);
            this.Controls.Add(this.MembukaKoneksi);
            this.Controls.Add(this.txtKodeProdi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpTanggalLahir);
            this.Controls.Add(this.cmbJK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNIM);
            this.Controls.Add(this.Label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtNIM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbJK;
        private System.Windows.Forms.DateTimePicker dtpTanggalLahir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKodeProdi;
        private System.Windows.Forms.Button MembukaKoneksi;
        private System.Windows.Forms.Button MenampilkanData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button MenambahData;
        private System.Windows.Forms.Button MengubahData;
        private System.Windows.Forms.Button MenghapusData;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
    }
}

