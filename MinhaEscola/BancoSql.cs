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
        private static SqlConnection con;

        private static SqlConnection ConexaoBanco()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-K8FS7AT;Initial Catalog=Escola;User ID=sa;Password=Sql@ge1971;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return con;
        }


        
    }
}
