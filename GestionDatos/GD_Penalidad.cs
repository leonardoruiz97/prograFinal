﻿using Dominio;
using System;
using System.Data;
using System.Data.SqlClient;


namespace GestionDatos
{
   public class GD_Penalidad
    {

        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Penalidad()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }




        public DataTable listar_Penalidad()
        {
            try
            {
                dat = new SqlDataAdapter("SP_Listar_Penalidad_ddl", sqlc);
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




        public DataTable listarMontoPenalidad(Penalidad objpe)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("SP_Listar_Monto_Penalidad", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PK_IPe_Cod ", objpe.PK_IPe_Cod);



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
