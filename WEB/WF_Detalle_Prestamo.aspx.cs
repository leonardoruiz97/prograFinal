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
public partial class WF_Detalle_Prestamo : System.Web.UI.Page
{
    Socio soc = new Socio();
    N_Socio Nsoci = new N_Socio();

    Tipo_Prestamo TPres = new Tipo_Prestamo();
    N_Tipo_Prestamo NTPres = new N_Tipo_Prestamo();

    Estado_Civil ecivil = new Estado_Civil();
    N_EstadoCivil Necivil = new N_EstadoCivil();

    Sexo sex = new Sexo();
    Distrito dis = new Distrito();

    
    N_Provincia Nprovi = new N_Provincia();

    Ocupacion ocu = new Ocupacion();
    N_Ocupacion Nocu = new N_Ocupacion();

    Prestamo pre = new Prestamo();
    N_Prestamo Npre = new N_Prestamo();

    Tipo_Prestamo tpre = new Tipo_Prestamo();
    Tipo_Vivienda tv = new Tipo_Vivienda();
    Profesion pro = new Profesion();
    Situacion_Laboral sl = new Situacion_Laboral();
    Rubro ru = new Rubro();
    Frecuencia fre = new Frecuencia();
    Solicitud sol = new Solicitud();
    Estado_Civil ec = new Estado_Civil();
    Distrito di = new Distrito();
    Estado_Prestamo epre = new Estado_Prestamo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CodPreGrid"] == null)
            {
                Response.Redirect("Inicio.aspx");

            }
            else
            {
                EnabledDatos();
                txtCodSoliGrid.Text = Session["CodPreGrid"].ToString();
                
                mostrarDatosPrestamo();
                btnDetalleDeuda.Visible = false;
                btnDetallePrestamoDeutda.Visible = false;

                validadCampo();
                validarAccion();
            }

        }

    }
    void mostrarDatosPrestamo()
    {
        pre.PK_IPre_Cod = int.Parse(txtCodSoliGrid.Text);
        Npre.consultarPrestamo(pre, tpre, soc, tv, pro, ru, sl, fre, sol, sex, ec, di, ocu, epre);
        txtfecharegistro.Text = "" + pre.DPre_Fecha_Registro;
        txttipoprestamo.Text = "" + tpre.VTP_Nombre;
        txtcuotas.Text = "" + pre.IPre_Cuotas;
        txtimporte.Text = "" + pre.FPre_Importe;
        txttasamensual.Text = "" + pre.FPre_Tasa_Mensual;
        txttcea.Text = "" + pre.FPre_Tcea;
        txtnombre.Text = "" + soc.VS_Nombre_Completo;
        txtapellidos.Text = "" + soc.VS_Apellido_Paterno;
        txtmiembros.Text = "" + pre.IPre_Miembros;
        txtvivienda.Text = "" + tv.VTVi_Nombre;
        txtprofesion.Text = "" + pro.VPro_Nombre;
        txtrubro.Text = "" + ru.VRu_Nombre;
        txtsituacion.Text = "" + sl.VSit_Nombre;
        txtantiguedad.Text = "" + pre.IPre_Antiguedad;
        txtfrecuencia.Text = "" + fre.VFre_Nombre;
        txtingresosfijos.Text = "" + pre.FPre_Ingresosfijos;
        txtingresosvariables.Text = "" + pre.FPre_Ingresosvariables;
        txtegresosfijos.Text = "" + pre.FPre_Egresosfijos;
        txtegresosvariables.Text = "" + pre.FPre_Egresosvariables;
        txtprestamovigente.Text = "" + pre.VPre_PrestamoVigente;
        txttipoprevigente.Text = "" + pre.VPre_TipoPreVigente;
        txtmontoprevigente.Text = "" + pre.FPre_MontoPreVigente;
        txtprecuotasvigente.Text = "" + pre.IPre_CuotasPreVigente;
        txtmoprevigente.Text = "" + pre.FPre_MoMensualPreVigente;
        txtdeudavigente.Text = "" + pre.VPre_DeudaVigente;
        txttipodeuda.Text = "" + pre.VPre_TipoDeVigente;
        txtbanco.Text = "" + pre.VPre_BancoDeVigente;
        txtmodeuda.Text = "" + pre.FPre_MontoDeVigente;
        txtdecuotas.Text = "" + pre.IPre_CuotasDeVigente;
        txtmomensualdeuda.Text = "" + pre.FPre_MoMensualDeVigente;
        txtsexo.Text = "" + sex.VSe_Nombre;
        txtestadocivil.Text = "" + ec.VEc_Nombre;
        txtdepartamento.Text = "" + pre.VPre_Residencia;
        txttrabajo.Text = "" + ocu.VOcu_Nombre;
        txtdistrito.Text = "" + di.VDi_Nombre;
        txtestado.Text = "" + epre.VEPre_Estado_Prestamo;


    }

    void EnabledDatos()
    {
       
        txtfecharegistro.Enabled=false;
        txttipoprestamo.Enabled = false;
        txtcuotas.Enabled = false;
        txtimporte.Enabled = false;
        txttasamensual.Enabled = false;
        txttcea.Enabled = false;
        txtnombre.Enabled = false;
        txtapellidos.Enabled = false;
        txtmiembros.Enabled = false;
        txtvivienda.Enabled = false;
        txtprofesion.Enabled = false;
        txtrubro.Enabled = false;
        txtsituacion.Enabled = false;
        txtantiguedad.Enabled = false;
        txtfrecuencia.Enabled = false;
        txtingresosfijos.Enabled = false;
        txtingresosvariables.Enabled = false;
        txtegresosfijos.Enabled = false;
        txtegresosvariables.Enabled = false;
        txtprestamovigente.Enabled = false;
        txttipoprevigente.Enabled = false;
        txtmontoprevigente.Enabled = false;
        txtprecuotasvigente.Enabled = false;
        txtmoprevigente.Enabled = false;
        txtdeudavigente.Enabled = false;
        txttipodeuda.Enabled = false;
        txtbanco.Enabled = false;
        txtmodeuda.Enabled = false;
        txtdecuotas.Enabled = false;
        txtmomensualdeuda.Enabled = false;
        txtsexo.Enabled = false;
        txtestadocivil.Enabled = false;
        txtdepartamento.Enabled = false;
        txttrabajo.Enabled = false;
        txtdistrito.Enabled = false;
        txtestado.Enabled = false;


    }

    void validadCampo()
    {
        if (txtprestamovigente.Text == "Si")
        {

            btnDetalleDeuda.Visible = true;

        }
        else
        {
            btnDetalleDeuda.Visible = false;
        }

        if (txtdeudavigente.Text == "Si")
        {
            btnDetallePrestamoDeutda.Visible = true;
        }
        else
            btnDetallePrestamoDeutda.Visible = false;
    }

    protected void btnDetalleDeuda_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "exampleModalPrestamoVigente", "$('#exampleModalCenter').modal('show');", true);
    }

    protected void btnDetallePrestamoDeutda_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "exampleModalPrestamooDeuda", "$('#exampleModalPrestamooDeuda').modal('show');", true);

    }

    protected void btnatras_Click(object sender, EventArgs e)
    {
        Response.Redirect("WF_Listar_Prestamos.aspx");
    }

    void validarAccion()
    {
        if (txtestado.Text == "En Proceso")
        {
            aceptadas.Visible = true;
            aceptadas.Visible = false;
            denegadas.Visible = false;
            btnatras.Visible = true;
        }
        if (txtestado.Text == "Aceptado")
        {
           
            aceptadas.Visible = true;
            denegadas.Visible = false;
            btnatras.Visible = false;
        }
        if (txtestado.Text == "Rechazado")
        {
           
            aceptadas.Visible = false;
            denegadas.Visible = true;
            btnatras.Visible = false;
        }
    }
}