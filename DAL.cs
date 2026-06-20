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
