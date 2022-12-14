using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace MinhaEscola
{
    class BancoSql
    {
        public static SqlConnection con = null;

        public void ConexaoBanco()
        {
            con = new SqlConnection(@"Data Source=SIN002;Initial Catalog=MeuCurso;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            con.Open();
        }
    }
}
