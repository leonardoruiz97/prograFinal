using Dominio;
using System;
using System.Data;
using System.Data.SqlClient;


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

        public int registrarMovimiento(Movimiento objmo)
        {
            cmd = new SqlCommand("Sp_Registra_Aporte", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaRegistro", objmo.DMove_Fecha_Registro);
            cmd.Parameters.AddWithValue("@importe", objmo.FMove_Importe);
            cmd.Parameters.AddWithValue("@detalle", objmo.VMove_Detalle);
            cmd.Parameters.AddWithValue("@codigoSocio", objmo.FK_IS_Cod);

            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }

        public int registrarAhorro(Movimiento objmo)
        {
            cmd = new SqlCommand("Sp_Registra_Ahorro", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaRegistro", objmo.DMove_Fecha_Registro);
            cmd.Parameters.AddWithValue("@importe", objmo.FMove_Importe);
            cmd.Parameters.AddWithValue("@detalle", objmo.VMove_Detalle);
            cmd.Parameters.AddWithValue("@codigoSocio", objmo.FK_IS_Cod);

            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }

        public DataTable listarMovimientoxSocio(Socio soci)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("Sp_MovimientoxSocio", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IS_Cod ", soci.PK_IS_Cod);



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

        public DataTable listarMovimiento()
        {
            try
            {
                dat = new SqlDataAdapter("Sp_listarMovimientos", sqlc);
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
