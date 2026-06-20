using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDmahasiswaADO
{
    public partial class Form3 : Form
    {
        static string connectionString = "Data Source=DESKTOP-MNFM95A\\HAFIDH;Initial Catalog=DBAkademikADO;User ID=sa;Password=123";

        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter da;
        DataTable dtMahasiswa;

        // Variabel penampung data dari Form2
        string prodi { get; set; }
        DateTime tglMasuk { get; set; }

        DataMahasiswa DataMahasiswa = new DataMahasiswa();

        // PERBAIKAN 1: Ubah constructor agar menerima parameter dari Form2
        public Form3(string Prodi, DateTime TglMasuk)
        {
            InitializeComponent();

            // Simpan nilai parameter ke variabel global form ini
            this.prodi = Prodi;
            this.tglMasuk = TglMasuk;

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_Report", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Gunakan variabel yang sudah terisi tadi
                cmd.Parameters.AddWithValue("@inProdi", this.prodi);
                cmd.Parameters.AddWithValue("@inTglMsuk", this.tglMasuk.Year);

                da = new SqlDataAdapter(cmd);

                dtMahasiswa = new DataTable();
                da.Fill(dtMahasiswa);

                conn.Close();

                // Pastikan nama class Crystal Report sesuai (DataMahasiswa atau ListMahasiswa)
                DataMahasiswa.SetDataSource(dtMahasiswa);
                crystalReportViewer1.ReportSource = DataMahasiswa;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Kosongkan saja, logika sudah dipindah ke Constructor
        }
    }
}