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
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Data.SqlClient;

public partial class WF_Consultar_Prestamo : System.Web.UI.Page
{
    Prestamo pre = new Prestamo();
    N_Prestamo npre = new N_Prestamo();
    protected void Page_Load(object sender, EventArgs e)
    {
        listarprestamo();
    }

    void listarprestamo()
    {
        gv_Tabla_Consuktar_Prestamo.DataSource = npre.ListarConsultarPrestamo();
        gv_Tabla_Consuktar_Prestamo.DataBind();
    }

    protected void gv_Tabla_Consuktar_Prestamo_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gv_Tabla_Consuktar_Prestamo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {   
        gv_Tabla_Consuktar_Prestamo.PageIndex = e.NewPageIndex;
        listarprestamo();

    }

    protected void gv_Tabla_Consuktar_Prestamo_DataBound(object sender, EventArgs e)
    {

    }

    protected void gv_Tabla_Consuktar_Prestamo_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void txtFillter_TextChanged(object sender, EventArgs e)
    {

    }
}