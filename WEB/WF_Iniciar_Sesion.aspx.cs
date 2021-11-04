using System;
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
using System.Windows;

public partial class WF_Iniciar_Sesion : System.Web.UI.Page
{

    Usuario usu = new Usuario();
    N_Usuario Nusu = new N_Usuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    void ValidarIniciarSesion()
    {
        if (txtDNI.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "dniVacio()", true);
            return;
        }
        if (txtContraseña.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaVacia()", true);
            return;
        }



        usu.IU_Dni = int.Parse(txtDNI.Text);
        Nusu.buscarUsuarioDni(usu);
        txtpkiu.Text = "" + usu.PK_IU_Cod;
        if (int.Parse(txtpkiu.Text) != 0)
        {
            txtdnibus.Text = "" + usu.IU_Dni;
            txtcontraseñabus.Text = "" + usu.VU_Contraseña;
            if(txtContraseña.Text == txtcontraseñabus.Text)
            {
                txtfkrol.Text = "" + usu.FK_IRo_Cod;
                if(int.Parse(txtfkrol.Text) == 1)
                {
                    //gerente general
                    txtusu.Text = "" + usu.PK_IU_Cod;
                    txtdnibus.Text = "" + usu.IU_Dni;
                    txtcontraseñabus.Text = "" + usu.VU_Contraseña;
                    txtcorreobus.Text = "" + usu.VU_Correo;
                    txtfkrol.Text = "" + usu.FK_IRo_Cod;
                    txtfksocio.Text = "" + usu.FK_IS_Cod;
                    txtfkpatrocinador.Text = "" + usu.FK_IPa_Cod;
                    Session["dni"] = "" + txtdnibus.Text;
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "gerenteGeneral()", true);
                    Response.Redirect("WF_Listar_Solicitud_Afiliacion.aspx");
                }
                else if(int.Parse(txtfkrol.Text) == 2)
                {
                    //cajera
                    txtusu.Text = "" + usu.PK_IU_Cod;
                    txtdnibus.Text = "" + usu.IU_Dni;
                    txtcontraseñabus.Text = "" + usu.VU_Contraseña;
                    txtcorreobus.Text = "" + usu.VU_Correo;
                    txtfkrol.Text = "" + usu.FK_IRo_Cod;
                    txtfksocio.Text = "" + usu.FK_IS_Cod;
                    txtfkpatrocinador.Text = "" + usu.FK_IPa_Cod;
                    Session["dni"] = "" + txtdnibus.Text;
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "cajera()", true);
                    Response.Redirect("WF_Gestionar_Socios.aspx");
                }
                else if(int.Parse(txtfkrol.Text) == 3)
                {
                    //socio
                    txtusu.Text = "" + usu.PK_IU_Cod;
                    txtdnibus.Text = "" + usu.IU_Dni;
                    txtcontraseñabus.Text = "" + usu.VU_Contraseña;
                    txtcorreobus.Text = "" + usu.VU_Correo;
                    txtfkrol.Text = "" + usu.FK_IRo_Cod;
                    txtfksocio.Text = "" + usu.FK_IS_Cod;
                    txtfkpatrocinador.Text = "" + usu.FK_IPa_Cod;
                    Session["dni"] = "" + txtdnibus.Text;
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "Socio()", true);
                    Response.Redirect("WF_Inicio_Socio.aspx");
                }
            }

            else if (txtContraseña.Text != txtcontraseñabus.Text)
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "contraseñaincorrecta()", true);
            }
        }
        else if (int.Parse(txtpkiu.Text) == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "noexisteUsuario()", true);
            txtDNI.Text = "";

        }

       
        //usu.VU_Contraseña = Convert.ToString(txtContraseña.Text);
        //Nusu.IniciarSesion(usu);
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        ValidarIniciarSesion();
     
    }
}
