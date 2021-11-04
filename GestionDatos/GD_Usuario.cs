using System;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace GestionDatos
{
    public class GD_Usuario
    {
        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;

        public GD_Usuario()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }
     
        public void IniciarSesion(Usuario objusu)
        {

            cmd = new SqlCommand("sp_IniciarSesion", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.AddWithValue("@IU_Dni", objusu.IU_Dni);
             cmd.Parameters.AddWithValue("@VU_Contraseña", objusu.VU_Contraseña);
             sqlc.Close();
            sqlc.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
           

                if (reader[0] != DBNull.Value)
                { objusu.IU_Dni = (int)reader[0]; }
                else
                { objusu.IU_Dni = 0; }

                if (reader[1] != DBNull.Value)
                { objusu.VU_Contraseña = (string)reader[1]; }
                else
                { objusu.VU_Contraseña = ""; }



                objusu.estado = 99;
            }
            else
            {
                objusu.estado = 1;
            }
            sqlc.Close();

        }




        public int registrarUsuario(Usuario objusu)
        {
            cmd = new SqlCommand("sp_Registrar_Usuario", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VU_Correo ", objusu.VU_Correo);
            cmd.Parameters.AddWithValue("@IU_Dni ", objusu.IU_Dni);
            cmd.Parameters.AddWithValue("@FK_IS_Cod",objusu.FK_IS_Cod);
            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }





        public void buscarUsuarioDni(Usuario objusu)
        {

            cmd = new SqlCommand("sp_BuscarUsuariodni", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IPN_Dni", objusu.IU_Dni);
            sqlc.Close();
            sqlc.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0] != DBNull.Value)
                { objusu.PK_IU_Cod = (int)reader[0]; }
                else
                { objusu.PK_IU_Cod = 0; }

                if (reader[1] != DBNull.Value)
                { objusu.VU_Correo = (string)reader[2]; }
                else
                { objusu.VU_Correo = ""; }

                if (reader[2] != DBNull.Value)
                { objusu.VU_Contraseña = (string)reader[2]; }
                else
                { objusu.VU_Contraseña = ""; }

                if (reader[3] != DBNull.Value)
                { objusu.IU_Dni = (int)reader[3]; }
                else
                { objusu.IU_Dni = 0; }

                if (reader[4] != DBNull.Value)
                { objusu.FK_IRo_Cod = (int)reader[4]; }
                else
                { objusu.FK_IRo_Cod = 0; }

                if (reader[5] != DBNull.Value)
                { objusu.FK_IS_Cod = (int)reader[5]; }
                else
                { objusu.FK_IS_Cod = 0; }

                if (reader[6] != DBNull.Value)
                { objusu.FK_IPa_Cod = (int)reader[6]; }
                else
                { objusu.FK_IPa_Cod = 0; }
                objusu.estado = 99;
            }
            else
            {
                objusu.estado = 1;
            }
            sqlc.Close();
        }








    }
}
