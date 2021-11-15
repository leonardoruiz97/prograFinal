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
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Data.SqlClient;

public partial class WF_Gestionar_Prestamos : System.Web.UI.Page
{
    Prestamo pre = new Prestamo();
    Socio soc = new Socio();
    Distrito di = new Distrito();
    N_Prestamo Npre = new N_Prestamo();
    Cuota cuo = new Cuota();
    N_Cuota Ncuo = new N_Cuota();
    Pago pag = new Pago();
    N_Pagos Npag = new N_Pagos();
    Movimiento mov = new Movimiento();
    N_Movimiento Nmov = new N_Movimiento();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Limpiar();
            //MostrarPagar();
            btnPagar.Enabled = false;
        }
    }
    public void Limpiar()
    {
        txtCodPrestamo.Text = "";
        txtNombreCompleto.Text = "";
        txtApellidos.Text = "";
        txtNumeroDocumento.Text = "";
        txtCiudad.Text = "";
        txtMontoPrestamo.Text = "";
        txtInteres.Text = "";
        txtNumCuotas.Text = "";
        txtFechaRegistro.Text = "";
        txtNCuota.Text = "";
        txtFechaInicio.Text = "";
        txtFechaFin.Text = "";
        txtImporte.Text = "";
        txtEstadoPrestamo.Text = "";
    }
    public void OcultarPagar() 
    {
        btnPagar.Enabled = false;
    }
    public void MostrarPagar()
    {
        btnPagar.Enabled = true;
    }
    void listarCuotasxPrestamo()
    {
        cuo.FK_IPre_Cod = Convert.ToInt32(txtCodPrestamo.Text);
        gv_ListarCuotas.DataSource = Ncuo.ListarCuotasxPrestamo(cuo);
        gv_ListarCuotas.DataBind();
    }
    protected void btnPagar_Click(object sender, EventArgs e)
    {
        listarCuotasxPrestamo();

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        txtCodPrestamo.Focus();
        Limpiar();
        //MostrarPagar();
        btnPagar.Enabled = false;
    }
    
    
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        pre.PK_IPre_Cod = int.Parse(txtCodPrestamo.Text);

        List<Prestamo> mLista = null;
        mLista = new N_Prestamo().ListarPrestamosCod();
        var Buscar = mLista.Where(oB => oB.PK_IPre_Cod == pre.PK_IPre_Cod).ToList();
        if (Buscar.Count == 0)
        {
            Limpiar();
            btnPagar.Enabled = false;
            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "NoHayPrestamo()", true);
        }
        else 
        {
            Npre.ConsultarPrestamoxCodPres(pre, soc, di);

            txtFK_IS_Cod.Text = soc.PK_IS_Cod.ToString();
            txtNombreCompleto.Text = soc.VS_Nombre_Completo;
            txtApellidos.Text = soc.VS_Apellido_Paterno + " " + soc.VS_Apellido_Materno;
            txtNumeroDocumento.Text = soc.IS_Dni.ToString();
            txtCiudad.Text = di.VDi_Nombre;

            txtMontoPrestamo.Text = pre.FPre_Importe.ToString();
            txtInteres.Text = pre.FPre_Tcea.ToString();
            txtNumCuotas.Text = pre.IPre_Cuotas.ToString();
            txtFechaRegistro.Text = pre.DPre_Fecha_Registro.ToString();
            txtEstadoPrestamo.Text = pre.FK_IEPre.ToString();
            MostrarPagar();

            if (Convert.ToInt32(txtEstadoPrestamo.Text) == 5)
            {
                btnPagar.Enabled = false;
            }
        }
        
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        txtCodPrestamo.Focus();
        Limpiar();
        //MostrarPagar();
        btnPagar.Enabled = false;
    }

    protected void gv_ListarCuotas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = gv_ListarCuotas.Rows[index];

        Label PK_IC_Cod = (Label)row.FindControl("PK_IC_Cod");

        if (e.CommandName.Contains("Registrar")) 
        {           
            pag.VPago_Mes = gv_ListarCuotas.Rows[index].Cells[0].Text;
            pag.FPago_Monto = Convert.ToDouble(gv_ListarCuotas.Rows[index].Cells[4].Text);
            pag.FK_IC_Cod = Convert.ToInt32(PK_IC_Cod.Text);
            cuo.PK_IC_Cod = Convert.ToInt32(PK_IC_Cod.Text);
            mov.FMove_Importe = Convert.ToDouble(gv_ListarCuotas.Rows[index].Cells[4].Text);
            mov.FK_IS_Cod = Convert.ToInt32(txtFK_IS_Cod.Text);
            cuo.FK_IECU_Cod = Convert.ToInt32(gv_ListarCuotas.Rows[index].Cells[6].Text);

            Npag.RegistrarPagoxCuota(pag, cuo);            
            Nmov.RegistrarMovimientoxCuotaPagada(mov, cuo);
            //Ncuo.ActualizarEstadoCuota(cuo);
            if (Convert.ToInt32(txtNumCuotas.Text) == Convert.ToInt32(gv_ListarCuotas.Rows[index].Cells[1].Text))
            {
                pre.PK_IPre_Cod = Convert.ToInt32(txtCodPrestamo.Text);
                pre.FK_IEPre = 5;
                Npre.ActualizarEstadoPrestamo(pre);
            }

            ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "RegistrarPago()", true);
            return;
        }
        else if (e.CommandName.Contains("Penalizar"))
        {
            //int index = Convert.ToInt32(e.CommandArgument);
            txtNCuota.Text = gv_ListarCuotas.Rows[index].Cells[1].Text;            
            txtFechaFin.Text = gv_ListarCuotas.Rows[index].Cells[3].Text;
            txtImporte.Text = gv_ListarCuotas.Rows[index].Cells[4].Text;
            txtDiasRetraso.Text = gv_ListarCuotas.Rows[index].Cells[5].Text;
            txtIECU_Cod.Text = gv_ListarCuotas.Rows[index].Cells[7].Text;
                    
            Session["pkcuo"] = Convert.ToInt32(PK_IC_Cod.Text);
            Session["pre"] = "" + txtCodPrestamo.Text;
            Session["cuo"] = "" + txtNCuota.Text;
            Session["dni"] = "" + txtNumeroDocumento.Text;
            Session["fechafin"] = "" + txtFechaFin.Text;
            Session["estacuota"] = "" + txtIECU_Cod.Text;
            Session["retra"] = "" + txtDiasRetraso.Text;
            Session["importe"] = "" + txtImporte.Text;
            Response.Redirect("WF_Registrar_Penalidad.aspx");
        }
    }
    protected void gv_ListarCuotas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (!IsPostBack == false)
        {
            gv_ListarCuotas.PageIndex = e.NewPageIndex;
            listarCuotasxPrestamo();
        }            
    }
    protected void gv_ListarCuotas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem, "VEcu_Estado_Cuota").ToString();
            if (estado == "Moroso")
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.LightCoral;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[7].Height = 4;
                e.Row.Cells[7].Width = 80;
                e.Row.FindControl("btnRegistrarPago").Visible = false;
                e.Row.FindControl("btnPenalizacion").Visible = true;
            }
            else if (estado == "En Curso")
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.LightBlue;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[7].Height = 4;
                e.Row.Cells[7].Width = 80;
                e.Row.FindControl("btnRegistrarPago").Visible = true;
                e.Row.FindControl("btnPenalizacion").Visible = false;
            }
            else if (estado == "Pagado")
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.LightGreen;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[7].Height = 4;
                e.Row.Cells[7].Width = 80;
                e.Row.Cells[8].Enabled = false;
            }
            else if (estado == "Penalizado") 
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[7].Height = 4;
                e.Row.Cells[7].Width = 80;
            }
        }
    }
}