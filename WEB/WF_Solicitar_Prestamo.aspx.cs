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

public partial class WF_Solicitar_Prestamo : System.Web.UI.Page
{

    Socio soci = new Socio();
    N_Socio Nsoci = new N_Socio();

    Tipo_Prestamo TPres = new Tipo_Prestamo();
    N_Tipo_Prestamo NTPres = new N_Tipo_Prestamo();

    Estado_Civil ecivil = new Estado_Civil();
    N_EstadoCivil Necivil = new N_EstadoCivil();

    Sexo sex = new Sexo();
    Distrito dis = new Distrito();


    N_Vivienda nVivienda = new N_Vivienda();
    N_Profesion nProfe = new N_Profesion();
    N_Rubro nRu = new N_Rubro();
    N_Situacion_Laboral nSitua = new N_Situacion_Laboral();
    N_Frecuencia nFre = new N_Frecuencia();

    Ocupacion ocu = new Ocupacion();
    N_Ocupacion Nocu = new N_Ocupacion();


    Prestamo pre = new Prestamo();
    N_Prestamo Nprestamo = new N_Prestamo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtcodpatrocinador.Text = Session["dni"].ToString();

            soci.IS_Dni = Convert.ToInt32(txtcodpatrocinador.Text);
            Nsoci.consultarSocioPrestamoxdni(soci,sex,ecivil,dis,ocu);
            txtcodSocio.Text = "" + soci.PK_IS_Cod;
            lbldatos.Text = soci.VS_Nombre_Completo + ' ' + soci.VS_Apellido_Paterno + ' ' + soci.VS_Apellido_Materno;
            Label2.Text = soci.VS_Nombre_Completo + ' ' + soci.VS_Apellido_Paterno + ' ' + soci.VS_Apellido_Materno;
            Label4.Text = soci.VS_Nombre_Completo + ' ' + soci.VS_Apellido_Paterno + ' ' + soci.VS_Apellido_Materno;
            txtSexo.Text = "" + sex.VSe_Nombre;
            txtEstadoCivil.Text = "" + ecivil.VEc_Nombre;
            txtDistrito.Text = "" + dis.VDi_Nombre;
            txtTrabajo.Text = "" + ocu.VOcu_Nombre;
            txtdepartamento.Text = "Lima";
            listarCamposDdl();
            PanelPaso2.Visible = false;
            txtfecharegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
       

    }
    public void listarCamposDdl()
    {
        //ddlsexo.DataSource = Nprovi.listarSexo();
        //ddlsexo.DataTextField = "VSe_Nombre";
        //ddlsexo.DataValueField = "PK_ISe_Cod";
        //ddlsexo.DataBind();
        //ddlsexo.Items.Insert(0, "--seleccionar--");

        //ddldistrito.DataSource = Nprovi.listarDistrito();
        //ddldistrito.DataTextField = "VDi_Nombre";
        //ddldistrito.DataValueField = "PK_IDi_Cod";
        //ddldistrito.DataBind();
        //ddldistrito.Items.Insert(0, "--seleccionar--");


        ddltipoprestamo.DataSource = NTPres.listarTipoPrestamo();
        ddltipoprestamo.DataTextField = "VTP_Nombre";
        ddltipoprestamo.DataValueField = "PK_ITP_Cod";
        ddltipoprestamo.DataBind();
        ddltipoprestamo.Items.Insert(0, "Seleccione");

        //ddlEstadoCivil.DataSource = Necivil.listarEstadoCivil();
        //ddlEstadoCivil.DataTextField = "VEc_Nombre";
        //ddlEstadoCivil.DataValueField = "PK_IEc_Cod";
        //ddlEstadoCivil.DataBind();
        //ddlEstadoCivil.Items.Insert(0, "--seleccionar--");

        ddlvivienda.DataSource = nVivienda.listarVivienda();
        ddlvivienda.DataTextField = "VTVi_Nombre";
        ddlvivienda.DataValueField = "PK_ITVi_Cod";
        ddlvivienda.DataBind();
        ddlvivienda.Items.Insert(0, "--seleccionar--");

        ddlprofesion.DataSource = nProfe.listarProfesion();
        ddlprofesion.DataTextField = "VPro_Nombre";
        ddlprofesion.DataValueField = "PK_IPro_Cod";
        ddlprofesion.DataBind();
        ddlprofesion.Items.Insert(0, "--seleccionar--");

        ddlsituacionlaboral.DataSource = nSitua.listarSituacion();
        ddlsituacionlaboral.DataTextField = "VSit_Nombre";
        ddlsituacionlaboral.DataValueField = "PK_ISit_Cod";
        ddlsituacionlaboral.DataBind();
        ddlsituacionlaboral.Items.Insert(0, "--seleccionar--");

        ddlrubro.DataSource = nRu.listarRubro();
        ddlrubro.DataTextField = "VRu_Nombre";
        ddlrubro.DataValueField = "PK_IRu_Cod";
        ddlrubro.DataBind();
        ddlrubro.Items.Insert(0, "--seleccionar--");


        //ddltrabajo.DataSource = Nocu.listarOcupacion();
        //ddltrabajo.DataTextField = "VOcu_Nombre";
        //ddltrabajo.DataValueField = "PK_IOcu_Cod";
        //ddltrabajo.DataBind();
        //ddltrabajo.Items.Insert(0, "--seleccionar--");

        ddlprestamovigente.DataSource = NTPres.listarTipoPrestamo();
        ddlprestamovigente.DataTextField = "VTP_Nombre";
        ddlprestamovigente.DataValueField = "PK_ITP_Cod";
        ddlprestamovigente.DataBind();
        ddlprestamovigente.Items.Insert(0, "Seleccione");

        ddlingresos.DataSource = nFre.listarFrecuencia();
        ddlingresos.DataTextField = "VFre_Nombre";
        ddlingresos.DataValueField = "PK_IFre_Cod";
        ddlingresos.DataBind();
        ddlingresos.Items.Insert(0, "Seleccione");
    }

    protected void ddltipoprestamo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltipoprestamo.SelectedIndex == 1)
        {
            double tasamensual = 1.00;
            double tasaanual = 12.68;
            txttasamensual.Text = tasamensual.ToString();
            txttasaanual.Text = tasaanual.ToString();

        }
        if (ddltipoprestamo.SelectedIndex == 2)
        {

            double tasamensual = 3.00;
            double tasaanual = 42.57;
            txttasamensual.Text = tasamensual.ToString();
            txttasaanual.Text = tasaanual.ToString();
        }
        if (ddltipoprestamo.SelectedIndex == 3)

        {

            double tasamensual = 1.50;
            double tasaanual = 19.56;
            txttasamensual.Text = tasamensual.ToString();
            txttasaanual.Text = tasaanual.ToString();
        }

        if (ddltipoprestamo.SelectedIndex == 0)

        {

            txttasamensual.Text = null;
            txttasaanual.Text = null;
        }

    }



    protected void btnSolicitar_Click(object sender, EventArgs e)
    {
        if (ddltipoprestamo.SelectedIndex ==0) 
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertTipoPrestamoVacio()", true);
            return;
        }
        if (txtcuotass.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertCuotaVacio()", true);
            return;
        }
        if (txtimporte.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertImporteVacio()", true);
            return;
        }
        if (txtmienbros.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertMiembrosVacio()", true);
            return;
        }
        if (ddlvivienda.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertTipoViviendaVacio()", true);
            return;
        }

        if (ddlvivienda.SelectedIndex == 3)
        {
            if (txtalquiler.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertGastoAlquilerVacio()", true);
                return;
            }
        }
        if (ddlprofesion.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertProfesionVacio()", true);
            return;
        }

        if (ddlrubro.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertRubroVacio()", true);
            return;
        }

        if (ddlsituacionlaboral.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertSituacionLabVacio()", true);
            return;
        }

        if (txtantiguedad.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertAntiguedadLabVacio()", true);
            return;
        }

        if(checkInformacion.Checked != true)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertCheckSinMarcar()", true);
            return;

        }

        PanelPaso2.Visible = true;
        PanelPaso1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (ddlingresos.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertFrecuenciaIngresosVacio()", true);
            return;
        }

        if (txtingresos.Text =="")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertIngresosFijosMensualesVacio()", true);
            return;
        }


        if (txtingresosvariables.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertIngresosVariablesMensualesVacio()", true);
            return;
        }


        if (TextBox1.Text =="")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertEgresosFijosMensualesVacio()", true);
            return;
        }


        if (TextBox2.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertEgresosVariablesMensualesVacio()", true);
            return;
        }

        if (CheckBox1.Checked)
        {
            if (ddlprestamovigente.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertTipoPrestamoVigenteVacio()", true);
                return;
            }


            if (txtMontoPreVigente.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertMontoPrestamoVigenteVacio()", true);
                return;
            }


            if (TextBox8.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertNumeroCuotasVacio()", true);
                return;
            }


            if (TextBox9.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertMontoMensualVacio()", true);
                return;
            }
        }

        if (CheckBox4.Checked) 
        {
            if (ddlprestamodeuda.SelectedValue == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertPrestamoOdeudalVacio()", true);
                return;
            }


            if (TextBox5.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertBancoVacio()", true);
                return;
            }

            if (TextBox3.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertMontoTotalVacio()", true);
                return;
            }

            if (TextBox6.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertNumeroCuotaPanel3Vacio()", true);
                return;
            }


            if (TextBox7.Text == "")
            {
                ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertMontoMensualPanel3Vacio()", true);
                return;
            }
        }
      

      


        PanelPaso2.Visible = false;
        PanelPaso1.Visible = false;
        PanelPaso3.Visible = true;
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        PanelPaso2.Visible = true;
        PanelPaso1.Visible = false;
        PanelPaso3.Visible = false;
    }
    
    protected void ddlvivienda_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlvivienda.SelectedIndex == 3)
        {
            alquiler.Visible = true;
        }
        else
            alquiler.Visible = false;
    }

    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked == true)
        {
            PanelDeudas.Visible = true;
        }
        else
        {
            PanelDeudas.Visible = false;
        }
    }

    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox5.Checked == true)
        {
            PanelDeudas.Visible = false;
        }
        
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            Panelprestamo.Visible = true;
        }
        else
        {
            Panelprestamo.Visible =false;
        }
    }

    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox3.Checked == true)
        {
            Panelprestamo.Visible = false;
        }
    }


    public void registrarPrestamo()
    {
        pre.DPre_Fecha_Registro =Convert.ToDateTime(txtfecharegistro.Text);
        pre.FPre_Importe = double.Parse(txtimporte.Text);
        pre.IPre_Cuotas = int.Parse(txtcuotass.Text);
        pre.FPre_Tcea = double.Parse(txttasaanual.Text);
        pre.FPre_Tasa_Mensual = double.Parse(txttasamensual.Text);
        pre.VPre_Residencia = txtdepartamento.Text;
        pre.IPre_Miembros = int.Parse(txtmienbros.Text);
        pre.IPre_Antiguedad = int.Parse(txtantiguedad.Text);

        pre.FPre_Ingresosfijos = double.Parse(txtingresos.Text);

        pre.FPre_Ingresosvariables = double.Parse(txtingresosvariables.Text);

        pre.FPre_Egresosfijos = double.Parse(TextBox1.Text);
        pre.FPre_Egresosvariables = double.Parse(TextBox2.Text);
        if (CheckBox4.Checked == true)
        {
            txtprestamosi.Text = "Si";
            pre.VPre_PrestamoVigente = txtprestamosi.Text;
            pre.FPre_MontoPreVigente = double.Parse(txtMontoPreVigente.Text);
            pre.IPre_CuotasPreVigente = int.Parse(TextBox8.Text);
            pre.FPre_MoMensualPreVigente = double.Parse(TextBox9.Text);
            pre.VPre_TipoPreVigente = ddlprestamovigente.SelectedValue;
        }
       if (CheckBox4.Checked != true)
        {
            txtprestamosi.Text = "No";
            pre.VPre_PrestamoVigente = txtprestamosi.Text;
            pre.FPre_MontoPreVigente = 0;
            pre.IPre_CuotasPreVigente = 0;
            pre.FPre_MoMensualPreVigente =0;
            pre.VPre_TipoPreVigente = "";
        }
  
        if (CheckBox1.Checked == true)
        {
            txtdeudasi.Text = "Si";

            pre.VPre_DeudaVigente = txtdeudasi.Text;
            pre.VPre_TipoDeVigente = ddlprestamodeuda.SelectedValue;
            pre.VPre_BancoDeVigente = TextBox5.Text;
            pre.VPre_GastoAlquiler = txtalquiler.Text;
            pre.FPre_MontoDeVigente = double.Parse(TextBox3.Text);
            pre.IPre_CuotasDeVigente = int.Parse(TextBox6.Text);
            pre.FPre_MoMensualDeVigente = double.Parse(TextBox7.Text);

        }
       else if (CheckBox1.Checked != true)
        {
            txtdeudasi.Text = "No";

            pre.VPre_DeudaVigente = txtdeudasi.Text;
            pre.VPre_TipoDeVigente = "";
            pre.VPre_BancoDeVigente = "";
            pre.VPre_GastoAlquiler = "";
            pre.FPre_MontoDeVigente = 0;
            pre.IPre_CuotasDeVigente = 0;
            pre.FPre_MoMensualDeVigente = 0;
        }


        if (FileUpReciboLuz != null)
        {

            int tamanio = FileUpReciboLuz.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpReciboLuz.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpReciboLuz.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_Copia_DNI = ImagenOriginal;

        }
        if (FileUpload1 != null)
        {

            int tamanio = FileUpload1.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload1.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload1.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_Libreta_Socio  = ImagenOriginal;

        }
        if (FileUpload2 != null)
        {

            int tamanio = FileUpload2.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload2.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload2.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_Declaracion_Salud= ImagenOriginal;

        }

        if (FileUpload3 != null)
        {

            int tamanio = FileUpload3.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload3.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload3.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_FPP = ImagenOriginal;

        }

        if (FileUpload4 != null)
        {

            int tamanio = FileUpload4.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload4.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload4.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_Aportes_Sociales= ImagenOriginal;

        }

        if (FileUpload5 != null)
        {

            int tamanio = FileUpload5.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload5.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload5.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_Declaracion_Jurada = ImagenOriginal;

        }


        if (FileUpload7 != null)
        {

            int tamanio = FileUpload7.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload7.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload7.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            pre.IMPre_Boleta_Pago  = ImagenOriginal;

        }

        if (FileUpload6 != null)
        {

            int tamanio = FileUpload6.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload6.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload6.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);

            pre.IMPre_Declaracion_Ingresos = ImagenOriginal;

        }


        if (FileUpload8 != null)
        {

            int tamanio = FileUpload8.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpload8.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpload8.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);

            pre.IMPre_Ingresos_Notariales = ImagenOriginal;

        }

        pre.FK_ITPre_Cod = ddltipoprestamo.SelectedIndex;
        //pre.FK_ISe_Cod = ddlsexo.SelectedIndex;
        //pre.FK_IEc_Cod = ddlEstadoCivil.SelectedIndex;
        //pre.FK_IDis_Cod = ddldistrito.SelectedIndex;
        pre.FK_ITVi_Cod = ddlvivienda.SelectedIndex;
        pre.FK_IPro_Cod = ddlprofesion.SelectedIndex;
        pre.FK_IRu_Cod = ddlrubro.SelectedIndex;
        pre.FK_ISLa_Cod = ddlsituacionlaboral.SelectedIndex;
        //pre.FK_IOcu_Cod = ddltrabajo.SelectedIndex;
        pre.FK_IFre_Cod = ddlingresos.SelectedIndex;
        pre.Fk_IS_Cod = int.Parse(txtcodSocio.Text);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", " RegistrarPrestamo()", true);
        Nprestamo.RegistrarPrestamo(pre);

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        registrarPrestamo();
    }
}