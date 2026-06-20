using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDmahasiswaADO
{
    internal class DAL
    {
        static string connectionString = "Data Source=DESKTOP-MNFM95A\\HAFIDH;Initial Catalog=DBAkademikADO;Integrated Security=True";

        public string GetConnectionString()
        {
            return connectionString;
        }

        SqlConnection conn = new SqlConnection(connectionString);

        SqlDataAdapter da;
        DataTable dtMahasiswa;

            public int CountMhs()
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = new SqlCommand("sp_CountMahasiswa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Menggunakan parameter @Total sesuai error database
                    SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    return Convert.ToInt32(outputParam.Value);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            public DataTable GetMhs()
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = new SqlCommand("sp_GetMahasiswa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    da = new SqlDataAdapter(cmd);
                    dtMahasiswa = new DataTable();
                    da.Fill(dtMahasiswa);

                    return dtMahasiswa;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            public DataTable getAllDataChart()
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = new SqlCommand("sp_DashBoard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    da = new SqlDataAdapter(cmd);
                    dtMahasiswa = new DataTable();
                    da.Fill(dtMahasiswa);

                    return dtMahasiswa;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

        // Method untuk Grafik Berdasarkan Tahun
        public DataTable getDataChartByTahun(DateTime thMasuk)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_DashBoardByTahun", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inTglMsuk", thMasuk.Year);

                da = new SqlDataAdapter(cmd);
                dtMahasiswa = new DataTable();
                da.Fill(dtMahasiswa);

                return dtMahasiswa;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public void InsertMhs(string nim, string nama, string alamat, string jenisKelamin, DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand("sp_InsertMahasiswa", conn);
                command.Transaction = trans;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("pNIM", nim);
                command.Parameters.AddWithValue("pNama", nama);
                command.Parameters.AddWithValue("pAlamat", alamat);
                command.Parameters.AddWithValue("pTanggalLahir", tanggalLahir);
                command.Parameters.AddWithValue("pJenisKelamin", jenisKelamin);


                // PERBAIKAN DI SINI: Diubah dari pNmProdi menjadi pKodeProdi sesuai Stored Procedure SQL Server
                command.Parameters.AddWithValue("pKodeProdi", kodeProdi);

                // Menangani parameter foto jika bernilai null (saat import file excel)
                if (foto == null)
                    command.Parameters.Add("pFoto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                else
                    command.Parameters.AddWithValue("pFoto", foto);

                command.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        public void UpdateMhs(string nim, string nama, string alamat, string jenisKelamin, DateTime tanggalLahir, string kodeProdi, byte[] foto)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand command = new SqlCommand("sp_UpdateMahasiswa", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("pNIM", nim);
                command.Parameters.AddWithValue("pNama", nama);
                command.Parameters.AddWithValue("pAlamat", alamat);
                command.Parameters.AddWithValue("pJenisKelamin", jenisKelamin);
                command.Parameters.AddWithValue("pTanggalLahir", tanggalLahir);


                command.Parameters.AddWithValue("pKodeProdi", kodeProdi);

                if (foto == null)
                    command.Parameters.Add("pFoto", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                else
                    command.Parameters.AddWithValue("pFoto", foto);

                command.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }


        public void DeleteMhs(string nim)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_DeleteMahasiswa", conn);
                cmd.Parameters.AddWithValue("pNIM", nim);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public void resetData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string deleteQuery = "DELETE FROM mahasiswa;";
                SqlCommand cmdDelete = new SqlCommand(deleteQuery, conn);
                cmdDelete.ExecuteNonQuery();

                string insertQuery = @"
                    INSERT INTO mahasiswa
                    SELECT * FROM mahasiswa_backup;";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, conn);
                cmdInsert.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public void testInject(string nim)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "Update mahasiswa set nama = 'HACKED' where NIM = '" + nim + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public DataTable GetMhsByNIM(string nim)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_GetMahasiswaByNIM", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pNIM", nim);

                da = new SqlDataAdapter(cmd);
                dtMahasiswa = new DataTable();
                da.Fill(dtMahasiswa);

                return dtMahasiswa;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }


        public void InsertLog(string message)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                using (var cmd = new SqlCommand("dbo.sp_LogMessage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@psn", message ?? string.Empty);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Fallback local file logging if database logging fails
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }
}