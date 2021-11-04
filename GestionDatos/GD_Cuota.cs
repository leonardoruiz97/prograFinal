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
    public class GD_Cuota
    {
        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Cuota()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }

        public int registrarCuota(Cuota cu)
        {

            cmd = new SqlCommand("sp_Registrar_Cuota", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IC_NumeroCuota ", cu.IC_NumeroCuota);
            cmd.Parameters.AddWithValue("@DC_FechaPago", cu.DC_FechaPago);
            cmd.Parameters.AddWithValue("@FC_MontoCuota", cu.FC_MontoCuota);
            cmd.Parameters.AddWithValue("@DC_FechaInicio", cu.DC_FechaInicio);
            cmd.Parameters.AddWithValue("@DC_FechaFin", cu.DC_FechaFin);
            cmd.Parameters.AddWithValue("@FK_IPre_Cod", cu.FK_IPre_Cod);
       

            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }


        public DataTable listarCuotaMoroso(Cuota objcuota)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_CuotasMorosa", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IECU_Cod", objcuota.FK_IECU_Cod);



                dat = new SqlDataAdapter(cmd);
                ds = new DataSet();
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
