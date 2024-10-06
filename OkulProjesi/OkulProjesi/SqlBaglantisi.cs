using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulProjesi
{
    internal class SqlBaglantisi
    {
        public SqlConnection Baglanti()
        {
            SqlConnection con=new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OkulProje;Integrated Security=True");
            con.Open();
            return con;
        }
    }
}
