using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader; // Menggunakan library ExcelDataReader sesuai Modul 14

namespace CRUDmahasiswaADO
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtMahasiswa = new DataTable();

        // Memanggil objek logis data akses terpusat (DAL)
        DAL dbLogic = new DAL();

        public Form1()
        {
            InitializeComponent();
        }

        // =========================================================================
        // METHOD UTAMA (LoadData, HitungTotal, ClearForm, simpanLog, BindControls)
        // =========================================================================

        private void LoadData()
        {
            try
            {
                // Mengambil data terpusat menggunakan arsitektur objek dbLogic
                dtMahasiswa = dbLogic.GetMhs();
                bindingSource.DataSource = dtMahasiswa;
                dataGridView1.DataSource = bindingSource;

                // Konfigurasi otomatis kolom Foto di DataGridView agar tidak pecah/terpotong
                if (dataGridView1.Columns["Foto"] != null)
                {
                    DataGridViewImageColumn fotoColumn = (DataGridViewImageColumn)dataGridView1.Columns["Foto"];
                    fotoColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                }

                HitungTotal();
                BindControls();

                // Pengaturan status aktif tombol form sesuai petunjuk praktikum
                dataGridView1.Enabled = true;

                if (this.Controls.Find("ImpDb_Click", true).FirstOrDefault() is Button btnImp)
                    btnImp.Enabled = false;

                MenampilkanData.Enabled = true;
                MenambahData.Enabled = true;
            }
            catch (Exception ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void HitungTotal()
        {
            try
            {
                int total = dbLogic.CountMhs();
                lblTotal1.Text = "Total : " + total.ToString();
            }
            catch (Exception ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
            }
        }

        void ClearForm()
        {
            txtNIM.Enabled = true;
            txtNIM.Clear();
            txtNama.Clear();
            cmbJK.SelectedIndex = -1;
            txtAlamat.Clear();
            txtKodeProdi.Clear();
            dtpTanggalLahir.Value = DateTime.Now;
            fotoMhs.Image = null;
            txtNIM.Focus();
        }

        public void simpanLog(string message)
        {
            dbLogic.InsertLog(message);
        }

        private void BindControls()
        {
            // Membersihkan sisa ikatan lama desainer agar tidak crash
            txtNIM.DataBindings.Clear();
            txtNama.DataBindings.Clear();
            cmbJK.DataBindings.Clear();
            dtpTanggalLahir.DataBindings.Clear();
            txtAlamat.DataBindings.Clear();
            txtKodeProdi.DataBindings.Clear();

            // Menghubungkan ulang komponen kontrol secara murni lewat kode program
            txtNIM.DataBindings.Add("Text", bindingSource, "NIM");
            txtNama.DataBindings.Add("Text", bindingSource, "Nama");
            cmbJK.DataBindings.Add("Text", bindingSource, "JenisKelamin");
            dtpTanggalLahir.DataBindings.Add("Value", bindingSource, "TanggalLahir");
            txtAlamat.DataBindings.Add("Text", bindingSource, "Alamat");

            // Sesuai dengan aliases kolom "Nama Prodi" pada sp_GetMahasiswa di modul halaman 2!
            txtKodeProdi.DataBindings.Add("Text", bindingSource, "Nama Prodi");
        }

        // =========================================================================
        // EVENT CLICK UTAMA (Menampilkan, Menambah, Mengubah, Menghapus, Reset)
        // =========================================================================

        private void MenampilkanData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void MenambahData_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] ConvertImageToBytes(PictureBox pb)
                {
                    if (pb.Image == null) return null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }

                byte[] imgBytes = ConvertImageToBytes(fotoMhs);
                dbLogic.InsertMhs(txtNIM.Text, txtNama.Text, txtAlamat.Text, cmbJK.Text, dtpTanggalLahir.Value.Date, txtKodeProdi.Text, imgBytes);

                MessageBox.Show("Data mahasiswa berhasil ditambahkan");
                ClearForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                simpanLog("Rollback Insert : " + ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                simpanLog("General Error : " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void MengubahData_Click_1(object sender, EventArgs e)
        {
            try
            {
                byte[] ConvertImageToBytes(PictureBox pb)
                {
                    if (pb.Image == null) return null;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }

                byte[] imgBytes = ConvertImageToBytes(fotoMhs);
                dbLogic.UpdateMhs(txtNIM.Text, txtNama.Text, txtAlamat.Text, cmbJK.Text, dtpTanggalLahir.Value.Date, txtKodeProdi.Text, imgBytes);

                MessageBox.Show("Data mahasiswa berhasil diubah");
                ClearForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void MenghapusData_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult konfirmasi = MessageBox.Show(
                    "Yakin ingin menghapus data ini?",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    dbLogic.DeleteMhs(txtNIM.Text);
                    MessageBox.Show("Data berhasil dihapus");
                    ClearForm();
                    LoadData();
                }
            }
            catch (SqlException ex)
            {
                simpanLog("SQL Error saat hapus: " + ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                simpanLog("General Error saat hapus: " + ex.Message);
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        // Tombol Reset Data (button1_Click_1)
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                dbLogic.resetData();
                MessageBox.Show("Data berhasil direset");
                LoadData();
            }
            catch (SqlException ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }

        // Tombol Test SQL Injection (button1_Click_2)
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                dbLogic.testInject(txtNIM.Text);
                LoadData();
            }
            catch (SqlException ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("SQL Error : " + ex.Message);
            }
            catch (Exception ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        // Tombol Membuka Koneksi (button1_Click)
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbLogic.GetConnectionString()))
                {
                    connection.Open();
                    MessageBox.Show("Koneksi berhasil!");
                }
            }
            catch (Exception ex)
            {
                simpanLog(ex.Message);
                MessageBox.Show("Koneksi gagal: " + ex.Message);
            }
        }

        // =========================================================================
        // DATA GRID CELL CLICK & INTERFACES PENDUKUNG
        // =========================================================================

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = ((DataRowView)bindingSource[e.RowIndex]).Row;

                txtNIM.Text = row["NIM"].ToString();
                txtNama.Text = row["Nama"].ToString();
                cmbJK.Text = row["JenisKelamin"].ToString();
                dtpTanggalLahir.Value = Convert.ToDateTime(row["TanggalLahir"]);
                txtAlamat.Text = row["Alamat"].ToString();
                txtKodeProdi.Text = row["NamaProdi"].ToString();

                if (row["Foto"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row["Foto"];
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        fotoMhs.Image = Image.FromStream(ms);
                        fotoMhs.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    fotoMhs.Image = null;
                }

                txtNIM.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var src = Image.FromFile(ofd.FileName))
                    {
                        fotoMhs.Image?.Dispose();
                        fotoMhs.Image = new Bitmap(src);
                        fotoMhs.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void btnImpExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });
                        DataTable dt = result.Tables[0];

                        // Set langsung ke BindingSource agar tidak crash data binding
                        bindingSource.DataSource = dt;
                        dataGridView1.DataSource = bindingSource;
                        dataGridView1.Enabled = false;

                        if (this.Controls.Find("ImpDb_Click", true).FirstOrDefault() is Button btnImp)
                            btnImp.Enabled = true;

                        MenambahData.Enabled = false;
                        MenampilkanData.Enabled = false;
                    }
                }
            }
        }

        private void btnImpDb_Click(object sender, EventArgs e)
        {
            try
            {
                // Mengambil data dari internal BindingSource agar terhindar dari Error Casting 
                DataTable dt = (DataTable)bindingSource.DataSource;
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diimport.");
                    return;
                }
                int sukses = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string nim = row["NIM"].ToString().Trim();
                    string nama = row["Nama"].ToString().Trim();
                    string jk = row["JenisKelamin"].ToString().Trim();
                    string alamat = row["Alamat"].ToString().Trim();
                    string kodeProdi = row["NamaProdi"].ToString().Trim();

                    if (string.IsNullOrEmpty(nim) || string.IsNullOrEmpty(nama))
                        continue;

                    DateTime tglLahir;
                    if (!DateTime.TryParse(row["TanggalLahir"].ToString(), out tglLahir))
                        continue;

                    dbLogic.InsertMhs(nim, nama, alamat, jk, tglLahir, kodeProdi, null);
                    sukses++;
                }
                MessageBox.Show($"{sukses} Data mahasiswa berhasil ditambahkan dari Excel!");
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                simpanLog("General Error Excel: " + ex.Message);
                MessageBox.Show("General Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rkp_data_Click(object sender, EventArgs e)
        {
            Dashboard fmDashboard = new Dashboard();
            fmDashboard.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void bindingNavigator1_RefreshItems(object sender, EventArgs e) { }
        private void label7_Click_1(object sender, EventArgs e) { }
    }
}