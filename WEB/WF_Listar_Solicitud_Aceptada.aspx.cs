﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using GestionDatos;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

public partial class WF_Listar_Solicitud_Aceptada : System.Web.UI.Page
{

    Departamento dep = new Departamento();
    N_Departamento Ndep = new N_Departamento();

    Afiliacion afilia = new Afiliacion();
    N_Afiliacion Nafilia = new N_Afiliacion();

    Estado_Civil ecivil = new Estado_Civil();
    N_EstadoCivil Necivil = new N_EstadoCivil();

    Ocupacion ocu = new Ocupacion();
    N_Ocupacion Nocu = new N_Ocupacion();

    Provincia pro = new Provincia();
    N_Provincia Nprovi = new N_Provincia();

    Solicitud sol = new Solicitud();
    N_Solicitud Nsol = new N_Solicitud();

    Socio so = new Socio();
    N_Socio Nso = new N_Socio();

    Usuario usu = new Usuario();
    N_Usuario Nusu = new N_Usuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

         
                listarsolicitudAceptada();
            
      
           
        }
    }


    void listarsolicitudAceptada()
    {
        //    txtpkusuario.Text = "" + 2;
        sol.FK_IESol_Cod = 2;
        gv_Tabla_Lista_Solicitud_Aceptada.DataSource = Nsol.listarsolicitudAceptada(sol);
        gv_Tabla_Lista_Solicitud_Aceptada.DataBind();

    }
    protected void gv_Tabla_Lista_Solicitud_Aceptada_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Credenciales")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string codSol = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[0].Text;
            string dni = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[1].Text;
            string nombre = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[2].Text;
            string ap = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[3].Text;
            string am = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[4].Text;
            string registro = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[6].Text;
            string correo = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[8].Text;
            txtFKsol.Text = codSol;
            txtCorreo.Text = correo;
            txtnombrecompleto.Text = nombre + " " + ap + " " + am; 
            txtdni.Text = dni;
            txtfechaRegistro.Text = registro;
            txtcodSoliAceptada.Text = codSol;
            buscarSocio();
            registrarUsuario();
            validarCorreo();
        }

        if (e.CommandName == "Ver")//VER 

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodSoliAceptada.Text = gv_Tabla_Lista_Solicitud_Aceptada.Rows[index].Cells[0].Text;
            Session["CodSoliGrid"] = "" + txtcodSoliAceptada.Text;
            Response.Redirect("WF_Detalle_Solicitud.aspx");


        }

    }



    void buscarSocio()
    {
        so.IS_Dni = int.Parse(txtdni.Text);
        Nso.BuscarSocioxdni(so);
        txtfksocio.Text = "" + so.PK_IS_Cod;
  
    }

    void registrarUsuario()
    {
        usu.VU_Correo = txtCorreo.Text;
        usu.IU_Dni = int.Parse(txtdni.Text);
        usu.FK_IS_Cod =int.Parse(txtfksocio.Text);
        Nusu.RegistrarUsuario(usu);
    }
    void validarCorreo()
    {
        SqlConnection sc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        {
            SqlCommand cmd = new SqlCommand("ValidarCorreo", sc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
            try
            {
                sc.Open();
                SqlDataReader lector = cmd.ExecuteReader();
                if (lector.Read() == true)
                {
                    GenerarNuevaContrasena(txtCorreo.Text);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error()", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "" + ex.Message + "');", true);
            }
        }
    }

    void GenerarNuevaContrasena(string email)
    {
        Random rd = new Random(DateTime.Now.Millisecond);
        int nuevaContrasena = rd.Next(100000, 999999);
        SqlConnection sc = new SqlConnection(GD_ConexionBD.CadenaConexion);
        SqlCommand cmd = new SqlCommand("NuevaContrasena", sc);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@correo", email);
        cmd.Parameters.AddWithValue("@contrasena", nuevaContrasena);
        try
        {
            sc.Open();
            int filasAfectadas = cmd.ExecuteNonQuery();
            if (filasAfectadas != 0)
            {
                enviarCredenciales(nuevaContrasena, email);
            }
        }
        catch
        {

        }
    }




    void enviarCredenciales(int contrasenaNueva, string correo)
    {
        string contraseña = this.Contrasena;
        string mensaje = string.Empty;
        //Creando el correo electronico
        string destinatario = correo;
        //ingresar el correo de GOMIVI
        string remitente = "coopacsancosmeltda@gmail.com";
        string asunto = "CREDENCIALES COOPAC SAN COSME";
        string stCuerpoHTML = "<!DOCTYPE html>";
        stCuerpoHTML += "<html lang='es'>";
        stCuerpoHTML += "<head>";
        stCuerpoHTML += "<meta charset='utf - 8'>";
        stCuerpoHTML += "<title>CREDENCIALES COOPAC SAN COSME</title>";
        stCuerpoHTML += "</head>";
        stCuerpoHTML += "<body style='background - color: black '>";
        stCuerpoHTML += "<table style='max - width: 600px; padding: 0px; margin: 0 auto; border - collapse: collapse; '>	";
        stCuerpoHTML += "<tr>";
        stCuerpoHTML += "<td style='padding: 0'>";
        stCuerpoHTML += "<img style='padding: 0; display: block' src='cid:Fondo' width='100%' height='10%'>";
        stCuerpoHTML += "</td>";
        stCuerpoHTML += "</tr>";
        stCuerpoHTML += "<tr>";
        stCuerpoHTML += "<td style='background - color: #ecf0f1'>";
        stCuerpoHTML += "<div style='color: #34495e; text-align: justify;font-family: sans-serif'>";
        stCuerpoHTML += "<h2 style='color:#E36C1E; margin: 0 0 7px'>Hola " + txtnombrecompleto.Text + " (" +txtdni.Text +") </h2>";
        stCuerpoHTML += "<p style='margin: 2px; font - size: 15px'>";
        stCuerpoHTML += "Con el gusto de saludarle y esperando que todo marche a la perfección, Hemos aceptado su solicitud ( N°"+txtcodSoliAceptada.Text+") que realizó el día  "+ txtfechaRegistro.Text+", Así mismo, le escribimos para facilitarle su contraseña de acceso,";
        stCuerpoHTML += "<br/>";
        stCuerpoHTML += "Su contraseña de acesso es: ";
        stCuerpoHTML += "</p>";
        stCuerpoHTML += "<p class='centered'>"+ Convert.ToString(contrasenaNueva) + "</p>";
        stCuerpoHTML += "<br/>";
        stCuerpoHTML += "Si no ha realizado esta solicitud, puede ignorar este mensaje ";
        stCuerpoHTML += "</div>";
        stCuerpoHTML += "</td>";
        stCuerpoHTML += "</tr>";
        stCuerpoHTML += "</table>";
        stCuerpoHTML += "</body>";
        stCuerpoHTML += "</html>";
        MailMessage ms = new MailMessage(remitente, destinatario, asunto, stCuerpoHTML);

        ms.IsBodyHtml = true;
        ms.Body = stCuerpoHTML;
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(" " + stCuerpoHTML + "COOPAC SAN COSME <br/>  <a href='https://www.coopacsancosme.com/'>www.coopacsancosme.com</a>   <br/>  <img src=cid:companylogo style='margin: 4% 10% 2%; text-align: justify;font-family'><br>" + txtAmaterno.Text + "<p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>NOTA DE CONFIDENCIALIDAD: La información contenida en este e-mail es confidencial, privilegiada y está dirigida exclusivamente a su destinatario. Cualquier revisión, difusión, distribución o copiado de este mensaje está prohibido. De conformidad con lo establecido en la Ley N° 29733 - Ley de Protección de Datos Personales - y su Reglamento, aprobado por D.S. N° 003-2013-JUS, declaro conocer los alcances de dichas normas y doy mi consentimiento en forma libre, expresa e inequívoca, para el tratamiento -con estrictas medidas de seguridad- de mis datos personales,</p> <br/> <p style='color: #b3b3b3; font-size: 12px; text-align: center;margin: 30px 0 0'>Copyright © ME 2021</p> ", null, "text/html");

        ms.BodyEncoding = UTF8Encoding.UTF8;
        ms.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
        var aa = System.AppDomain.CurrentDomain.BaseDirectory;

        System.Net.Mail.LinkedResource imageResource = new System.Net.Mail.LinkedResource(aa + @"img\SanCosme.png");


        //System.Net.Mail.LinkedResource imageResource1 = new System.Net.Mail.LinkedResource(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/assets/img/pc1.png");


        imageResource.ContentId = "companylogo";

        htmlView.LinkedResources.Add(imageResource);

        ms.AlternateViews.Add(htmlView);

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
        smtp.EnableSsl = true;
        //ingresar el correo de san cosme
        smtp.Credentials = new NetworkCredential("coopacsancosmeltda@gmail.com", contraseña);

        try
        {
            Task.Run(() => {
                smtp.Send(ms);
                ms.Dispose();
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "correcto()", true);
            }

            );
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "temporizador()", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + "Error al enviar correo electronico: " + "');" + ex.Message, true);
        }
    }


    public string Contrasena
    {
        get
        { return "ME12345@"; }
    }





    //igresar la contrtaseña de san cosme


    protected void gv_Tabla_Lista_Solicitud_Aceptada_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Solicitud_Aceptada.PageIndex = e.NewPageIndex;
        listarsolicitudAceptada();
    }

    protected void gv_Tabla_Lista_Solicitud_Aceptada_DataBound(object sender, EventArgs e)
    {
       
    }

    protected void gv_Tabla_Lista_Solicitud_Aceptada_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType== DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem,"VEsol_Estado_Solicitud").ToString();
            if (estado == "Aceptado")
            {
                e.Row.Cells[11].BackColor = System.Drawing.Color.DarkSeaGreen;
                e.Row.Cells[11].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[11].Width = 100;


            }
        }
    }

    protected void txtFillter_TextChanged(object sender, EventArgs e)
    {
      
    }
}