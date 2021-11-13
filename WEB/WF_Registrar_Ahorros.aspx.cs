using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

public partial class WF_Registrar_Ahorros : System.Web.UI.Page
{
    Socio soci = new Socio();
    N_Socio Nsoc = new N_Socio();
    Movimiento movi = new Movimiento();
    N_Movimiento Nmovi = new N_Movimiento();

    double total = 0;
    double monto = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelHistorial.Visible = false;


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
    void registrarAhorro()
    {
        movi.DMove_Fecha_Registro = Convert.ToDateTime(txtfechstransaccion.Text);
        movi.FMove_Importe = Convert.ToDouble(txtmonto.Text);
        movi.VMove_Detalle = txtobservacion.Text;
        movi.FK_IS_Cod = int.Parse(txtsociocod.Text);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "RegistrarAhorro()", true);
        Nmovi.registrarAhorro(movi);
    }
    void listarMovimientos()
    {
      
        soci.PK_IS_Cod = Convert.ToInt32(txtsociocod.Text);
        gv_Tabla_Lista_Movimientos.DataSource = Nmovi.listarMovimientoxSocio(soci);
        gv_Tabla_Lista_Movimientos.DataBind();

       
    }

    protected void btnBuscarSocio_Click(object sender, EventArgs e)
    {
        buscarDniSocio();
        listarMovimientos();
        PanelHistorial.Visible = true;
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {

    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        registrarAhorro();
        listarMovimientos();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
    }

    protected void gv_Tabla_Lista_Movimientos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        
            total = total + Convert.ToDouble(e.Row.Cells[4].Text);
            string tipo = e.Row.Cells[2].Text;
            if (tipo == "DEPOSITO APORTACION") //&& tipo =="DESEMBOLSO"
            {
                 monto = monto + Convert.ToDouble(e.Row.Cells[4].Text);
                txtsaldodisponible.Text = Convert.ToString(monto);
            }

            int valor = Convert.ToInt32(this.gv_Tabla_Lista_Movimientos.Rows.Count) + 1;
            txtmovimiento.Text = valor.ToString();

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = total.ToString();
        }

        txtsaldoactual.Text = Convert.ToString(total);
    }

    protected void gv_Tabla_Lista_Movimientos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      

    

    }

}
