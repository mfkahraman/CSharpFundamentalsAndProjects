using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection bgl =
            new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBPersonel;Integrated Security=True");
    }
}
