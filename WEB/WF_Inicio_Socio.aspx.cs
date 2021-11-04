using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using GestionDatos;

public partial class WF_Inicio_Socio : System.Web.UI.Page
{
    Socio soci = new Socio();
    N_Socio Nsoci = new N_Socio();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtpatrocinador.Text= Session["dni"].ToString();

        soci.IS_Dni = Convert.ToInt32(txtpatrocinador.Text);
        Nsoci.BuscarSocio(soci);
        txtnombre.Text = soci.VS_Nombre_Completo;
        txtapellidopaterno.Text = soci.VS_Apellido_Paterno + ' ' + soci.VS_Apellido_Materno;

    }
}