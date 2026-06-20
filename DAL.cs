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

