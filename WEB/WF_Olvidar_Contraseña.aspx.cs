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

public partial class WF_Olvidar_Contraseña : System.Web.UI.Page
{
    Usuario usu = new Usuario();
    N_Usuario Nusu = new N_Usuario();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            panel2.Visible = false;
            panel3.Visible = false;
          
        }

    } 
    void ValidarDNI()
    {
        if (txtDNI1.Text == "")
        { 
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "DNIVacio()", true);
            return;
        }
        usu.IU_Dni = int.Parse(txtDNI1.Text);
        Nusu.buscarUsuarioDni(usu);
        txtpkiu1.Text = "" + usu.PK_IU_Cod;
        if (int.Parse(txtpkiu1.Text) != 0)
        {
            txtdnibus1.Text = "" + usu.IU_Dni;
            txtcontraseñabus1.Text = "" + usu.VU_Contraseña;
            
            if (txtDNI1.Text == txtdnibus1.Text)
            {
                changesPanel();
            }
            else if (txtDNI1.Text != txtdnibus1.Text)
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "DNIincorrecta()", true);
            }
        }
        else if (int.Parse(txtpkiu1.Text) == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "noexisteUsuario()", true);
            txtDNI.Text = "";

        }

    }
    void ActualizarContraseña()
    {
        if (txtContraseña.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaVacia()", true);
            return;
        }

        if (txtContraseña2.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaVacia()", true);
            return;
        }

        if (txtContraseña.Text != txtContraseña2.Text)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "IgualarContraseñas()", true);
            return;
        }

        //txtContraseña.Text = "" + usu.VU_Contraseña;
        //usu.IU_Dni = int.Parse(txtContraseña.Text);
        usu.VU_Contraseña = (txtContraseña.Text).ToString();
        usu.IU_Dni = int.Parse(txtDNI1.Text);
        Nusu.actualizarContraseña(usu);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "ContraseñaActualizada()", true);
        panel2.Visible = false;
        panel3.Visible = true;
        return;
        
        // Response.Redirect("WF_Iniciar_Sesion.aspx");
    }




    protected void Unnamed_Click(object sender, EventArgs e)
    {
        ValidarDNI();
        

    }
    protected void Actualizar(object sender, EventArgs e)
    {
        ActualizarContraseña();


    }

    void changesPanel()
    {
        panel1.Visible = false;
        panel2.Visible = true;

    }

    protected void Retroceder(object sender, EventArgs e)
    {
        Response.Redirect("WF_Iniciar_Sesion.aspx");
    }



    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        Response.Redirect("WF_Iniciar_Sesion.aspx");
    }
}
