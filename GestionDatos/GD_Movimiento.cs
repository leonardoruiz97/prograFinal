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
    public class GD_Movimiento
    {
        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Movimiento()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }
        public int registrarMovimientoxCuotaPagada(Movimiento objMov)
        {
            cmd = new SqlCommand("Sp_RegistrarMovimientoxCuotaPagada", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FMove_Importe", objMov.FMove_Importe);
            cmd.Parameters.AddWithValue("@FK_IS_Cod", objMov.FK_IS_Cod);

            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }
    }
}
