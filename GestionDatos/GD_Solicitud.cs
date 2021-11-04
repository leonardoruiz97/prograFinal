﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace GestionDatos
{
    public class GD_Solicitud
    {
        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Solicitud()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }



        public int registrarSolicitud(Solicitud objsol)
        {
            cmd = new SqlCommand("SP_REGISTRARSOLICITUD", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@dni", objsol.ISol_Dni);
            cmd.Parameters.AddWithValue("@nombrecompleto", objsol.VSol_Nombre_Completo);
            cmd.Parameters.AddWithValue("@apellidopaterno", objsol.VSol_Apellido_Paterno);
            cmd.Parameters.AddWithValue("@apellidomaterno", objsol.VSol_Apellido_Materno);
            cmd.Parameters.AddWithValue("@fechanacimiento", objsol.DSol_Fecha_Nacimiento);
            cmd.Parameters.AddWithValue("@fecharegistro", objsol.DSol_Fecha_Registro);
            cmd.Parameters.AddWithValue("@direccion", objsol.VSol_Direccion);
            cmd.Parameters.AddWithValue("@correo", objsol.VSol_Correo);
            cmd.Parameters.AddWithValue("@celular", objsol.ISol_Celular);
            cmd.Parameters.AddWithValue("@telefonofijo", objsol.ISol_Telefono_Fijo);
            cmd.Parameters.AddWithValue("@luz", objsol.IMSol_Recibo_Luz);
            cmd.Parameters.AddWithValue("@agua", objsol.IMSol_Recibo_agua);
            cmd.Parameters.AddWithValue("@vivienda", objsol.IMSol_Imagen_Vivienda);
            cmd.Parameters.AddWithValue("@constancia", objsol.IMSol_Constancia);
            cmd.Parameters.AddWithValue("@fk_id", objsol.FK_ID_Cod);
            cmd.Parameters.AddWithValue("@fk_iPro", objsol.FK_IPro_Cod);
            cmd.Parameters.AddWithValue("@fk_IEc", objsol.FK_IEc_Cod);
            cmd.Parameters.AddWithValue("@fk_IOcu", objsol.FK_IOcu_Cod);
            cmd.Parameters.AddWithValue("@fk_IESol", objsol.FK_IESol_Cod);
            cmd.Parameters.AddWithValue("@fk_IA_Cod", objsol.FK_IA_Cod);
            cmd.Parameters.AddWithValue("@residencia", objsol.DepartamentoResidencia);
            cmd.Parameters.AddWithValue("@FK_ISe_Cod", objsol.FK_ISe_Cod);
            cmd.Parameters.AddWithValue("@FK_IDi_Cod", objsol.FK_IDi_Cod);



            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }

        public DataTable listaSolicitudPendiente(Solicitud objsol)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_mostrarSolicitudPendiente", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IESol_Cod", objsol.FK_IESol_Cod);



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

        public DataTable listaSolicitudDenegada(Solicitud objsol)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_mostrarSolicitudDenegada", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IESol_Cod", objsol.FK_IESol_Cod);



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

        public DataTable listaSolicitudAceptada(Solicitud objsol)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_mostrarSolicitudAceptada", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IESol_Cod", objsol.FK_IESol_Cod);



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

      



        public void buscarSolicitud(Solicitud soli)
        {

            cmd = new SqlCommand("sp_BuscarSolicitudPK", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_ISol_Cod ", soli.PK_ISol_Cod);
            sqlc.Close();
            sqlc.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0] != DBNull.Value)
                { soli.PK_ISol_Cod = (int)reader[0]; }
                else
                { soli.PK_ISol_Cod = 0; }

                if (reader[1] != DBNull.Value)
                { soli.ISol_Dni = (int)reader[1]; }
                else
                { soli.ISol_Dni = 0; }

                if (reader[2] != DBNull.Value)
                { soli.VSol_Nombre_Completo = (string)reader[2]; }
                else
                { soli.VSol_Nombre_Completo = ""; }

                if (reader[3] != DBNull.Value)
                { soli.VSol_Apellido_Paterno = (string)reader[3]; }
                else
                { soli.VSol_Apellido_Paterno = ""; }

                if (reader[4] != DBNull.Value)
                { soli.VSol_Apellido_Materno = (string)reader[4]; }
                else
                { soli.VSol_Apellido_Materno = ""; }

                if (reader[5] != DBNull.Value)
                { soli.DSol_Fecha_Nacimiento = (DateTime)reader[5]; }
                else
                { soli.DSol_Fecha_Nacimiento = DateTime.Parse("01/01/2000 00:00:00"); }

                if (reader[6] != DBNull.Value)
                { soli.DSol_Fecha_Registro = (DateTime)reader[6]; }
                else
                { soli.DSol_Fecha_Registro = DateTime.Parse("01/01/2000 00:00:00"); }

                if (reader[7] != DBNull.Value)
                { soli.VSol_Direccion = (string)reader[7]; }
                else
                { soli.VSol_Direccion = ""; }

                if (reader[8] != DBNull.Value)
                { soli.VSol_Correo = (string)reader[8]; }
                else
                { soli.VSol_Correo = ""; }

                if (reader[9] != DBNull.Value)
                { soli.ISol_Celular = (int)reader[9]; }
                else
                { soli.ISol_Celular = 0; }


                if (reader[10] != DBNull.Value)
                { soli.ISol_Telefono_Fijo = (int)reader[10]; }
                else
                { soli.ISol_Telefono_Fijo = 0; }

                if (reader[11] != DBNull.Value)
                { soli.IMSol_Recibo_Luz = (byte[])reader[11]; }

                if (reader[12] != DBNull.Value)
                { soli.IMSol_Recibo_agua = (byte[])reader[12]; }

                if (reader[13] != DBNull.Value)
                { soli.IMSol_Imagen_Vivienda = (byte[])reader[13]; }

                if (reader[14] != DBNull.Value)
                { soli.IMSol_Constancia = (byte[])reader[14]; }


                if (reader[15] != DBNull.Value)
                { soli.FK_ID_Cod = (int)reader[15]; }
                else
                { soli.FK_ID_Cod = 0; }
                if (reader[16] != DBNull.Value)
                { soli.FK_IPro_Cod = (int)reader[16]; }
                else
                { soli.FK_IPro_Cod = 0; }
                if (reader[17] != DBNull.Value)
                { soli.FK_IEc_Cod = (int)reader[17]; }
                else
                { soli.FK_IEc_Cod = 0; }
                if (reader[18] != DBNull.Value)
                { soli.FK_IOcu_Cod = (int)reader[18]; }
                else
                { soli.FK_IOcu_Cod = 0; }
                if (reader[19] != DBNull.Value)
                { soli.FK_IESol_Cod = (int)reader[19]; }
                else
                { soli.FK_IESol_Cod = 0; }
                if (reader[20] != DBNull.Value)
                { soli.FK_IA_Cod = (int)reader[20]; }
                else
                { soli.FK_IA_Cod = 0; }



                soli.estado = 99;
            }
            else
            {
                soli.estado = 1;
            }
            sqlc.Close();
           
        }




        public void ConsultarSolicitudpk(Solicitud soli,Departamento dp, Provincia pro, Estado_Civil ec, Ocupacion ocu, Estado_Solicitud es,Afiliacion afi)
        {

            cmd = new SqlCommand("Sp_ConsultarSolicitud2", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_ISol_Cod ", soli.PK_ISol_Cod);
            sqlc.Close();
            sqlc.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0] != DBNull.Value)
                { soli.PK_ISol_Cod = (int)reader[0]; }
                else
                { soli.PK_ISol_Cod = 0; }

                if (reader[1] != DBNull.Value)
                { soli.ISol_Dni = (int)reader[1]; }
                else
                { soli.ISol_Dni = 0; }

                if (reader[2] != DBNull.Value)
                { soli.VSol_Nombre_Completo = (string)reader[2]; }
                else
                { soli.VSol_Nombre_Completo = ""; }

                if (reader[3] != DBNull.Value)
                { soli.VSol_Apellido_Paterno = (string)reader[3]; }
                else
                { soli.VSol_Apellido_Paterno = ""; }

                if (reader[4] != DBNull.Value)
                { soli.VSol_Apellido_Materno = (string)reader[4]; }
                else
                { soli.VSol_Apellido_Materno = ""; }

                if (reader[5] != DBNull.Value)
                { soli.DSol_Fecha_Nacimiento = (DateTime)reader[5]; }
                else
                { soli.DSol_Fecha_Nacimiento = DateTime.Parse("01/01/2000 00:00:00"); }

                if (reader[6] != DBNull.Value)
                { soli.DSol_Fecha_Registro = (DateTime)reader[6]; }
                else
                { soli.DSol_Fecha_Registro = DateTime.Parse("01/01/2000 00:00:00"); }

                if (reader[7] != DBNull.Value)
                { soli.VSol_Direccion = (string)reader[7]; }
                else
                { soli.VSol_Direccion = ""; }

                if (reader[8] != DBNull.Value)
                { soli.VSol_Correo = (string)reader[8]; }
                else
                { soli.VSol_Correo = ""; }

                if (reader[9] != DBNull.Value)
                { soli.ISol_Celular = (int)reader[9]; }
                else
                { soli.ISol_Celular = 0; }


                if (reader[10] != DBNull.Value)
                { soli.ISol_Telefono_Fijo = (int)reader[10]; }
                else
                { soli.ISol_Telefono_Fijo = 0; }

                if (reader[11] != DBNull.Value)
                { soli.IMSol_Recibo_Luz = (byte[])reader[11]; }

                if (reader[12] != DBNull.Value)
                { soli.IMSol_Recibo_agua = (byte[])reader[12]; }

                if (reader[13] != DBNull.Value)
                { soli.IMSol_Imagen_Vivienda = (byte[])reader[13]; }

                if (reader[14] != DBNull.Value)
                { soli.IMSol_Constancia = (byte[])reader[14]; }


                if (reader[15] != DBNull.Value)
                { dp.VD_Nombre = (string)reader[15]; }
                else
                { soli.FK_ID_Cod = 0; }

                if (reader[16] != DBNull.Value)
                { pro.VPro_Nombre = (string)reader[16]; }
                else
                { soli.FK_IPro_Cod = 0; }

                if (reader[17] != DBNull.Value)
                { ec.VEc_Nombre= (string)reader[17]; }
                else
                { soli.FK_IEc_Cod = 0; }

                if (reader[18] != DBNull.Value)
                { ocu.VOcu_Nombre = (string)reader[18]; }
                else
                { soli.FK_IOcu_Cod = 0; }

                if (reader[19] != DBNull.Value)
                { es.VEsol_Estado_Solicitud = (string)reader[19]; }
                else
                { soli.FK_IESol_Cod = 0; }

                if (reader[20] != DBNull.Value)
                { afi.IA_Cod_Patrocinador = (int)reader[20]; }
                else
                { afi.IA_Cod_Patrocinador = 0; }

                if (reader[21] != DBNull.Value)
                { soli.FK_IA_Cod = (int)reader[20]; }
                else
                { soli.FK_IA_Cod = 0; }



                soli.estado = 99;
            }
            else
            {
                soli.estado = 1;
            }
            sqlc.Close();

        }

        public void actualizarEstadoSolicitud(Solicitud sol)
        {
            cmd = new SqlCommand("sp_actualizarEstadoSolicitud", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_ISol_Cod", sol.PK_ISol_Cod);
            cmd.Parameters.AddWithValue("@FK_IESol_Cod", sol.FK_IESol_Cod);

            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
        }

      

    }
}
