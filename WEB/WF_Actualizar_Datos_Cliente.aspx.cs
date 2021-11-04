using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using GestionDatos;
using Negocio;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.ClientServices;
using System.Net;
using System.IO;
using System.Drawing;
public partial class WF_Actualizar_Datos_Cliente : System.Web.UI.Page
{
    Socio soc = new Socio();
    N_Socio Nsoci = new N_Socio();

    Solicitud sol = new Solicitud();
    Estado_Civil ec = new Estado_Civil();
    Distrito di = new Distrito();
    Ocupacion ocu = new Ocupacion();
    Provincia pro = new Provincia();
    Estado_Socio es = new Estado_Socio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["dni"] == null)
            {
                 
                Response.Redirect("Inicio.aspx");

            }
            else
            {

                EnabledDatos();
                txtCodSoliGrid.Text = Session["dni"].ToString();
              
                mostrarDatosSocio();
                afiSocio();
                DatosPatrocinador();
            }

        }
    }

    void mostrarDatosSocio()
    {
        soc.PK_IS_Cod = int.Parse(txtCodSoliGrid.Text);
        Nsoci.consultarSocio(soc, sol, ec, di, ocu, pro, es);

        txtsolicitud.Text = "" + sol.PK_ISol_Cod;
        txtdni.Text = "" + soc.IS_Dni;
        txtnombre.Text = "" + soc.VS_Nombre_Completo;
        txtapellido.Text = "" + soc.VS_Apellido_Paterno + " " + soc.VS_Apellido_Materno;
        txtcelular.Text = "" + sol.ISol_Celular;
        txtdirreccion.Text = "" + sol.VSol_Direccion;
        txtocupacion.Text = "" + ocu.VOcu_Nombre;
        txtdepartamento.Text = "" + sol.DepartamentoResidencia;
        txtestadocivil.Text = "" + ec.VEc_Nombre;
        txtdistrito.Text = "" + di.VDi_Nombre;
        txtprovincia.Text = "" + pro.VPro_Nombre;
        txtfecha.Text = "" + sol.DSol_Fecha_Nacimiento.ToString("dd/MM/yyyy");
        txttelefono.Text = "" + sol.ISol_Telefono_Fijo;
        txtemail.Text = "" + sol.VSol_Correo;
        txtestado.Text = "" + es.VESocio_Estado_Socio;
        txtregistro.Text = "" + sol.DSol_Fecha_Registro.ToString("dd/MM/yyyy");

    }


    void afiSocio()
    {
        Afiliacion afi = new Afiliacion();
        soc.IS_Dni = int.Parse(txtdni.Text);
        Nsoci.BuscarSocioAfiPatro(soc,afi);
        txtpkafi.Text = " " + afi.PK_IA_Cod;
        txtcodafi.Text = " " + afi.IA_Cod_Patrocinador;


    }
    void DatosPatrocinador() {

        Patrocinador patro = new Patrocinador();
        patro.IPa_Dni = int.Parse(txtcodafi.Text);
        Nsoci.BuscarSocioDatosPatro(patro);
        txtrepresentante.Text = patro.VPa_Nombre_Completo+ " " + patro.VPa_Apellido_Paterno + " " + patro.VPa_Apellido_Materno;
    }

    void EnabledDatos()
    {
        txtdni.Enabled = false;
        txtnombre.Enabled = false;
        txtapellido.Enabled = false;
        txtdistrito.Enabled = false;
        txtocupacion.Enabled = false;
        txtdepartamento.Enabled = false;
        txtestadocivil.Enabled = false;
        txtregistro.Enabled = false;
        txtestado.Enabled = false;
        txtrepresentante.Enabled = false;
        txtregistro.Enabled = false;
        txtfecha.Enabled = false;

    }

    protected void btnEnviarCotizacion_Click(object sender, EventArgs e)
    {
        sol.PK_ISol_Cod = int.Parse(txtsolicitud.Text);
        sol.VSol_Direccion = txtdirreccion.Text;
        sol.VSol_Correo = txtemail.Text;
        sol.ISol_Celular = int.Parse(txtcelular.Text);
        sol.ISol_Telefono_Fijo = int.Parse(txttelefono.Text);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertaagregar()", true);
        Nsoci.ActualizarDatosSocio(sol);

    }

    protected void btnatras_Click(object sender, EventArgs e)
    {
        Response.Redirect("WF_Inicio_Socio.aspx");
    }
}
