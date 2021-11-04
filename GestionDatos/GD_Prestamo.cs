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
    public class GD_Prestamo
    {
        SqlConnection sqlc;
        private SqlDataAdapter dat;
        private SqlCommand cmd;
        private DataSet ds;
        public GD_Prestamo()
        {
            sqlc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        }



        public int registrarPrestamo(Prestamo objpre)
        {
            cmd = new SqlCommand("SP_Registrar_Prestamo", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@DPre_Fecha_Registro", objpre.DPre_Fecha_Registro);
            cmd.Parameters.AddWithValue("@FPre_Importe", objpre.FPre_Importe);
            cmd.Parameters.AddWithValue("@IPre_Cuotas", objpre.IPre_Cuotas);
            cmd.Parameters.AddWithValue("@VPre_Residencia", objpre.VPre_Residencia);
            cmd.Parameters.AddWithValue("@IPre_Miembros", objpre.IPre_Miembros);
            cmd.Parameters.AddWithValue("@IPre_Antiguedad", objpre.IPre_Antiguedad);
            cmd.Parameters.AddWithValue("@FPre_Ingresosfijos", objpre.FPre_Ingresosfijos);
            cmd.Parameters.AddWithValue("@FPre_Ingresosvariables", objpre.FPre_Ingresosvariables);
            cmd.Parameters.AddWithValue("@FPre_Egresosfijos", objpre.FPre_Egresosfijos);
            cmd.Parameters.AddWithValue("@FPre_Egresosvariables", objpre.FPre_Egresosvariables);
            cmd.Parameters.AddWithValue("@VPre_PrestamoVigente", objpre.VPre_PrestamoVigente);
            cmd.Parameters.AddWithValue("@FPre_MontoPreVigente", objpre.FPre_MontoDeVigente);
            cmd.Parameters.AddWithValue("@IPre_CuotasPreVigente", objpre.IPre_CuotasPreVigente);
            cmd.Parameters.AddWithValue("@FPre_MoMensualPreVigente", objpre.FPre_MoMensualPreVigente);
            cmd.Parameters.AddWithValue("@VPre_DeudaVigente", objpre.VPre_DeudaVigente);
            cmd.Parameters.AddWithValue("@VPre_TipoDeVigente", objpre.VPre_TipoDeVigente);
            cmd.Parameters.AddWithValue("@VPre_BancoDeVigente", objpre.VPre_BancoDeVigente);
            cmd.Parameters.AddWithValue("@VPre_GastoAlquiler", objpre.VPre_GastoAlquiler);
            cmd.Parameters.AddWithValue("@FPre_MontoDeVigente", objpre.FPre_MontoDeVigente);
            cmd.Parameters.AddWithValue("@IPre_CuotasDeVigente", objpre.IPre_CuotasDeVigente);
            cmd.Parameters.AddWithValue("@FPre_MoMensualDeVigente", objpre.FPre_MoMensualDeVigente);
            cmd.Parameters.AddWithValue("@TipoPreVigente", objpre.VPre_TipoPreVigente);
            cmd.Parameters.AddWithValue("@tcea", objpre.FPre_Tcea);
            cmd.Parameters.AddWithValue("@tasa_mensual", objpre.FPre_Tasa_Mensual);
            cmd.Parameters.AddWithValue("@IMPre_Copia_DNI", objpre.IMPre_Copia_DNI);
            cmd.Parameters.AddWithValue("@IMPre_Libreta_Socio", objpre.IMPre_Libreta_Socio);
            cmd.Parameters.AddWithValue("@IMPre_Declaracion_Salud", objpre.IMPre_Declaracion_Salud);
            cmd.Parameters.AddWithValue("@IMPre_FPP", objpre.IMPre_FPP);
            cmd.Parameters.AddWithValue("@IMPre_Aportes_Sociales", objpre.IMPre_Aportes_Sociales);
            cmd.Parameters.AddWithValue("@IMPre_Declaracion_Jurada", objpre.IMPre_Declaracion_Jurada);
            cmd.Parameters.AddWithValue("@IMPre_Boleta_Pago", objpre.IMPre_Boleta_Pago);
            cmd.Parameters.AddWithValue("@IMPre_Declaracion_Ingresos", objpre.IMPre_Declaracion_Ingresos);
            cmd.Parameters.AddWithValue("@IMPre_Ingresos_Notariales", objpre.IMPre_Ingresos_Notariales);
            cmd.Parameters.AddWithValue("@FK_ITPre_Cod", objpre.FK_ITPre_Cod);
            cmd.Parameters.AddWithValue("@FK_ITVi_Cod", objpre.FK_ITVi_Cod);
            cmd.Parameters.AddWithValue("@FK_IPro_Cod", objpre.FK_IPro_Cod);
            cmd.Parameters.AddWithValue("@FK_IRu_Cod", objpre.FK_IRu_Cod);
            cmd.Parameters.AddWithValue("@FK_ISLa_Cod", objpre.FK_ISLa_Cod);
            cmd.Parameters.AddWithValue("@FK_IFre_Cod", objpre.FK_IFre_Cod);
            cmd.Parameters.AddWithValue("@FK_IS_Cod", objpre.Fk_IS_Cod);


            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
            return 1;
        }


        public DataTable listaPrestamodPendiente(Prestamo objpre)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_mostrarPrestamoPendiente", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IEPre", objpre.FK_IFre_Cod);



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


        public DataTable listaPrestamoRechazado(Prestamo objpre)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_mostrarPrestamoRechazado", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IEPre", objpre.FK_IFre_Cod);



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

        public DataTable listaPrestamoAceptada(Prestamo objpre)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("sp_mostrarPrestamoAceptada", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FK_IEPre", objpre.FK_IFre_Cod);



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




        public void actualizarEstadoPrestamo(Prestamo pre)
        {
            cmd = new SqlCommand("sp_actualizarEstadoPrestamo", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_IPre_Cod", pre.PK_IPre_Cod);
            cmd.Parameters.AddWithValue("@FK_IEPre", pre.FK_IEPre);

            sqlc.Open();
            cmd.ExecuteNonQuery();
            sqlc.Close();
        }

        public void ConsultarPrestamopk(Prestamo pre, Tipo_Prestamo tpre, Socio soc, Tipo_Vivienda tv, Profesion pro, Rubro ru, Situacion_Laboral sl, Frecuencia fre, Solicitud sol, Sexo sex, Estado_Civil ec, Distrito di, Ocupacion ocu, Estado_Prestamo epre)
        {

            cmd = new SqlCommand("Sp_ConsultarPrestamo", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_IPre_Cod ", pre.PK_IPre_Cod);
            sqlc.Close();
            sqlc.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0] != DBNull.Value)
                { pre.PK_IPre_Cod = (int)reader[0]; }
                else
                { pre.PK_IPre_Cod = 0; }

                if (reader[1] != DBNull.Value)
                { pre.DPre_Fecha_Registro = (DateTime)reader[1]; }
                else
                { pre.DPre_Fecha_Registro = DateTime.Parse("01/01/2000"); }

                if (reader[2] != DBNull.Value)
                { tpre.VTP_Nombre = (string)reader[2]; }
                else
                { tpre.VTP_Nombre = ""; }

                if (reader[3] != DBNull.Value)
                { pre.IPre_Cuotas = (int)reader[3]; }
                else
                { pre.IPre_Cuotas = 0; }

                if (reader[4] != DBNull.Value)
                { pre.FPre_Importe = (double)reader[4]; }
                else
                { pre.FPre_Importe = 0; }

                if (reader[5] != DBNull.Value)
                { pre.FPre_Tasa_Mensual = (double)reader[5]; }
                else
                { pre.FPre_Tasa_Mensual = 0; }

                if (reader[6] != DBNull.Value)
                { pre.FPre_Tcea = (double)reader[6]; }
                else
                { pre.FPre_Tcea = 0; }

                if (reader[7] != DBNull.Value)
                { soc.VS_Nombre_Completo = (string)reader[7]; }
                else
                { soc.VS_Nombre_Completo = ""; }

                if (reader[8] != DBNull.Value)
                { soc.VS_Apellido_Paterno = (string)reader[8]; }
                else
                { soc.VS_Apellido_Paterno = ""; }

                if (reader[9] != DBNull.Value)
                { soc.VS_Apellido_Materno = (string)reader[9]; }
                else
                { soc.VS_Apellido_Materno = ""; }

                if (reader[10] != DBNull.Value)
                { pre.IPre_Miembros = (int)reader[10]; }
                else
                { pre.IPre_Miembros = 0; }

                if (reader[11] != DBNull.Value)
                { tv.VTVi_Nombre = (string)reader[11]; }
                else
                { tv.VTVi_Nombre = ""; }

                if (reader[12] != DBNull.Value)
                { pro.VPro_Nombre = (string)reader[12]; }
                else
                { pro.VPro_Nombre = ""; }

                if (reader[13] != DBNull.Value)
                { ru.VRu_Nombre = (string)reader[13]; }
                else
                { ru.VRu_Nombre = ""; }

                if (reader[14] != DBNull.Value)
                { sl.VSit_Nombre = (string)reader[14]; }
                else
                { sl.VSit_Nombre = ""; }

                if (reader[15] != DBNull.Value)
                { pre.IPre_Antiguedad = (int)reader[15]; }
                else
                { pre.IPre_Antiguedad = 0; }

                if (reader[16] != DBNull.Value)
                { fre.VFre_Nombre = (string)reader[16]; }
                else
                { fre.VFre_Nombre = ""; }

                if (reader[17] != DBNull.Value)
                { pre.FPre_Ingresosfijos = (double)reader[17]; }
                else
                { pre.FPre_Ingresosfijos = 0; }

                if (reader[18] != DBNull.Value)
                { pre.FPre_Ingresosvariables = (double)reader[18]; }
                else
                { pre.FPre_Ingresosvariables = 0; }

                if (reader[19] != DBNull.Value)
                { pre.FPre_Egresosfijos = (double)reader[19]; }
                else
                { pre.FPre_Egresosfijos = 0; }

                if (reader[20] != DBNull.Value)
                { pre.FPre_Egresosvariables = (double)reader[20]; }
                else
                { pre.FPre_Egresosvariables = 0; }

                if (reader[21] != DBNull.Value)
                { pre.VPre_PrestamoVigente = (string)reader[21]; }
                else
                { pre.VPre_PrestamoVigente = ""; }

                if (reader[22] != DBNull.Value)
                { pre.VPre_TipoPreVigente = (string)reader[22]; }
                else
                { pre.VPre_TipoPreVigente = ""; }

                if (reader[23] != DBNull.Value)
                { pre.FPre_MontoPreVigente = (double)reader[23]; }
                else
                { pre.FPre_MontoPreVigente = 0; }

                if (reader[24] != DBNull.Value)
                { pre.IPre_CuotasPreVigente = (int)reader[24]; }
                else
                { pre.IPre_CuotasPreVigente = 0; }

                if (reader[25] != DBNull.Value)
                { pre.FPre_MoMensualPreVigente = (double)reader[25]; }
                else
                { pre.FPre_MoMensualPreVigente = 0; }

                if (reader[26] != DBNull.Value)
                { pre.VPre_DeudaVigente = (string)reader[26]; }
                else
                { pre.VPre_DeudaVigente = ""; }

                if (reader[27] != DBNull.Value)
                { pre.VPre_TipoDeVigente = (string)reader[27]; }
                else
                { pre.VPre_TipoDeVigente = ""; }

                if (reader[28] != DBNull.Value)
                { pre.VPre_BancoDeVigente = (string)reader[28]; }
                else
                { pre.VPre_BancoDeVigente = ""; }

                if (reader[29] != DBNull.Value)
                { pre.FPre_MontoDeVigente = (double)reader[29]; }
                else
                { pre.FPre_MontoDeVigente = 0; }

                if (reader[30] != DBNull.Value)
                { pre.IPre_CuotasDeVigente = (int)reader[30]; }
                else
                { pre.IPre_CuotasDeVigente = 0; }

                if (reader[31] != DBNull.Value)
                { pre.FPre_MoMensualDeVigente = (double)reader[31]; }
                else
                { pre.FPre_MoMensualDeVigente = 0; }

                if (reader[32] != DBNull.Value)
                { sex.VSe_Nombre = (string)reader[32]; }
                else
                { sex.VSe_Nombre = ""; }

                if (reader[33] != DBNull.Value)
                { ec.VEc_Nombre = (string)reader[33]; }
                else
                { ec.VEc_Nombre = ""; }

                if (reader[34] != DBNull.Value)
                { pre.VPre_Residencia = (string)reader[34]; }
                else
                { pre.VPre_Residencia = ""; }

                if (reader[35] != DBNull.Value)
                { di.VDi_Nombre = (string)reader[35]; }
                else
                { di.VDi_Nombre = ""; }

                if (reader[36] != DBNull.Value)
                { ocu.VOcu_Nombre = (string)reader[36]; }
                else
                { ocu.VOcu_Nombre = ""; }

                if (reader[37] != DBNull.Value)
                { epre.VEPre_Estado_Prestamo = (string)reader[37]; }
                else
                { epre.VEPre_Estado_Prestamo = ""; }


                pre.estado = 99;
            }
            else
            {
                pre.estado = 1;
            }
            sqlc.Close();

        }




        public void ConsultarPrestamoSocio(Prestamo pre,Socio soc)
        {

            cmd = new SqlCommand("Sp_ConsultarPrestamoSocio", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PK_IPre_Cod", pre.PK_IPre_Cod);
            sqlc.Close();
            sqlc.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader[0] != DBNull.Value)
                { soc.VS_Nombre_Completo = (string)reader[0]; }
                else
                { soc.VS_Nombre_Completo = ""; }

                if (reader[1] != DBNull.Value)
                { soc.VS_Apellido_Paterno = (string)reader[1]; }
                else
                { soc.VS_Apellido_Paterno = ""; }

                if (reader[2] != DBNull.Value)
                { soc.VS_Apellido_Materno = (string)reader[2]; }
                else
                { soc.VS_Apellido_Materno = ""; }

                if (reader[3] != DBNull.Value)
                { pre.PK_IPre_Cod = (int)reader[3]; }
                else
                { pre.PK_IPre_Cod = 0; }

                if (reader[4] != DBNull.Value)
                { pre.FPre_Importe = (double)reader[4]; }
                else
                { pre.FPre_Importe = 0; }

                if (reader[5] != DBNull.Value)
                { pre.IPre_Cuotas = (int)reader[5]; }
                else
                { pre.IPre_Cuotas = 0; }

                if (reader[6] != DBNull.Value)
                { pre.DPre_Fecha_Registro = (DateTime)reader[6]; }
                else
                { pre.DPre_Fecha_Registro = DateTime.Parse("01/01/2000 00:00:00"); }



                pre.estado = 99;
            }
            else
            {
                pre.estado = 1;
            }
            sqlc.Close();

        }

        public DataTable listaPrestamos(Prestamo objpre)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("SP_ListarPrestamos", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public DataTable listaPrestamosDesembolsado(Prestamo objpre)
        {
            try
            {
                sqlc.Open();

                cmd = new SqlCommand("SP_ListarPrestamosDesembolsados", sqlc);
                cmd.CommandType = CommandType.StoredProcedure;

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


