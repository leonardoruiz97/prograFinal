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
public partial class WF_Simular_Prestamos : System.Web.UI.Page
{
    Tipo_Prestamo TPres = new Tipo_Prestamo();
    N_Tipo_Prestamo NTPres = new N_Tipo_Prestamo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            listarCamposDdl();
            
        }
        //TextBox1.ScrollBars = ScrollBars.Both;
        
    }
    public void listarCamposDdl()
    {
        ddlPrestamo.DataSource = NTPres.listarTipoPrestamo();
        ddlPrestamo.DataTextField = "VTP_Nombre";
        ddlPrestamo.DataValueField = "PK_ITP_Cod";
        ddlPrestamo.DataBind();
        ddlPrestamo.Items.Insert(0, "Seleccione");
    }


        protected void Unnamed_Click(object sender, EventArgs e)
    {
        SeleccionarCampos();
      
       
        DateTime nuevafecha = DateTime.Now.Date;
        nuevafecha = nuevafecha.AddDays(5);
        

        lblprestamo.Text = ddlPrestamo.Items[ddlPrestamo.SelectedIndex].ToString();
        txtfecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
        txtdiapago.Text = nuevafecha.ToString("dd/MM/yyyy");
        txtfechapago.Text = nuevafecha.ToString("dd/MM/yyyy");
        ValorBien();

    }



    void SeleccionarCampos()
    {
        if (ddlPrestamo.SelectedIndex == 0)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertddlprestamoVacio()", true);
            return;
        }
        if (txtmonto.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertMontoVacio()", true);
            return;
        }
        if (txtmeses.Text == "")
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertTiempoVacio()", true);
            return;
        }

        prestamo.Visible = true;
        btnContinuar.Visible = false;

        if (checkcuota.Checked == true)
        {
            panelcuotas.Visible = true;

            periodoGracia.Visible = true;
            lblcuotas.Text = "Si";

        }
        else
        {
            panelcuotas.Visible = false;
            periodoGracia.Visible = false;
        }


    }
    //SessionPageStatePersister["txtxlblbmes"] =  txtxlblmeses.text

    protected void btncuota_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page,Page.GetType(), "openModal", "$('#openModal').modal('show');", true);
     
    }

    void validarSeleccionModal()
    {
        if(checKEnero.Checked == true)
        {
            lblMesesAdicionales.Text = "Enero";
        
        }
        if (checkFebrero.Checked == true)
        {
            lblMesesAdicionales.Text = "Febrero";
        }
        if (checkMarzo.Checked == true)
        {
            lblMesesAdicionales.Text = "Marzo";
        }
        if (checkAbril.Checked == true)
        {
            lblMesesAdicionales.Text = "Abril";
        }
        if (checkMayo.Checked == true)
        {
            lblMesesAdicionales.Text = "Mayo";
        }
        if (checkJunio.Checked == true)
        {
            lblMesesAdicionales.Text = "Junio";
        }
        if (checkJulio.Checked == true)
        {
            lblMesesAdicionales.Text = "Julio";
        }
        if (checkAgosto.Checked == true)
        {
            lblMesesAdicionales.Text = "Agosto";
        }
        if (checkSeptiembre.Checked == true)
        {
            lblMesesAdicionales.Text = "Septiembre";
        }
        if (checkOctubre.Checked == true)
        {
            lblMesesAdicionales.Text = "Octubre";
        }
        if (checkNoviembre.Checked == true)
        {
            lblMesesAdicionales.Text = "Noviembre";
        }
        if (checkDiciembre.Checked == true)
        {
            lblMesesAdicionales.Text = "Diciembre";
        }


    }


    protected void PrestamoSeleccionado(object sender, EventArgs e)
    {
        if(ddlPrestamo.SelectedIndex==1)
        {
            txttasa.Text =Convert.ToString(1.03);
        }
        if (ddlPrestamo.SelectedIndex == 2)
        {
            txttasa.Text = Convert.ToString(3.00);
        }
        if (ddlPrestamo.SelectedIndex == 3)

        {
            txttasa.Text = Convert.ToString(1.50);
        }

        if (ddlPrestamo.SelectedIndex == 0)

        {
            txttasa.Text = null;
        }

    }


    protected void btnEjecutar_Click1(object sender, EventArgs e)
    {
      
        validarContenido();

    }


    void validarContenido()
    {
        if (checkenviovi.Checked == true)
        {
            lblvirtual.Text = "Virtual";

            if ((checkenviovi.Checked == true && checkenviofi.Checked == true))
            {
                lblambos.Text = " y Fisico ";
            }

        }
        else
        {
            lblfisico.Text = "Fisico";

        }



        bool isCaptchaValid = false;
        if (Session["captchaText"] != null && Session["captchaText"].ToString() == txtCaptchaText.Text)
        {
            isCaptchaValid = true;
        }
        if (isCaptchaValid)
        {
           
        }
        else
        {
           
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertCaptcha()", true);
            return;
        }



        Session["Prestamo"] = "" + lblprestamo.Text;
        Session["monto"] = "" + txtmonto.Text;
        Session["meses"] = "" + txtmeses.Text;
        Session["tasa"] = "" + txttasa.Text;
        Session["fecha"] = "" + txtfecha.Text;
        Session["diapago"] = "" + txtdiapago.Text;
        Session["virtual"] = "" + lblvirtual.Text;
        Session["fisico"] = "" + lblfisico.Text;
        Session["ambos"] = "" + lblambos.Text;
        Session["periodo"] = "" + txtperiodogracia.Text;
        Session["valor"] = "" + txtvalorbien.Text;
        Session["cuotas"] = "" + lblcuotas.Text;
        Session["mesesAdicionales"] = "" + lblMesesAdicionales.Text;
        Session["fechapago"] = "" + txtfechapago.Text;

        Response.Redirect("WF_Simulacion_Pagos.aspx");
    }



    void ValorBien()
    {
        if(ddlPrestamo.SelectedIndex == 3)
        {
            valorBien.Visible = true;
        }
        else
        {
            valorBien.Visible = false;
        }
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        validarSeleccionModal();

     

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        ddlPrestamo.SelectedIndex = 0;
        txtmonto.Text = "";
        checkcuota.Checked = false;
    
        txtmeses.Text = "";
        txttasa.Text = "";
    }
}