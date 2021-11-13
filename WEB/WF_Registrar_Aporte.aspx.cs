using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

public partial class WF_Registrar_Aporte : System.Web.UI.Page
{
    Socio soci = new Socio();
    N_Socio Nsoc = new N_Socio();
    Movimiento movi = new Movimiento();
    N_Movimiento Nmovi = new N_Movimiento();


    Afiliacion afi = new Afiliacion();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtfecha.Text = DateTime.Now.ToShortDateString();
            txtmonto.Text = "S/100";
            txtobservacion.Text = "APORTE / APOYO / SEPELIO";

        }

    }

    void buscarDniSocio()
    {
        soci.IS_Dni = int.Parse(txtsocio.Text);
        Nsoc.BuscarSocii(soci);
        txtsociocod.Text = Convert.ToString(soci.PK_IS_Cod);
        txtnombres.Text = "" + soci.VS_Nombre_Completo;
        txtapellido.Text = "" + soci.VS_Apellido_Paterno + " " + soci.VS_Apellido_Materno;

    }

    void registrarAporte()
    {
        movi.DMove_Fecha_Registro = Convert.ToDateTime(txtfecha.Text);
        movi.FMove_Importe = 100.00;
        movi.VMove_Detalle = txtobservacion.Text;
        movi.FK_IS_Cod = int.Parse(txtsociocod.Text);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "RegistrarAporte()", true);
        Nmovi.registrarMovimiento(movi);
        Console.WriteLine(txtobservacion.Text);
    }


    protected void btnBuscarSocio_Click(object sender, EventArgs e)
    {
        buscarDniSocio();
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        txtsocio.Text = "";
        txtnombres.Text = "";
        txtapellido.Text = "";
      

    }

    protected void btnAporte_Click(object sender, EventArgs e)
    {
        registrarAporte();
    }
}