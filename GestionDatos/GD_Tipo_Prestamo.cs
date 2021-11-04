using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace GestionDatos
{
   public class GD_Tipo_Prestamo
    {

        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        public GD_Tipo_Prestamo()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);

        }
        public DataTable listar_Tipo_Prestamo()
        {
            try
            {
                dat = new SqlDataAdapter("SP_Listar_Prestamo_ddl", sqlc);
                dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                dat.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
