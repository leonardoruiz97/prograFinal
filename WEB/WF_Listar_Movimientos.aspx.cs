using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
public partial class WF_Listar_Movimientos : System.Web.UI.Page
{
    Movimiento movi = new Movimiento();
    N_Movimiento Nmovi = new N_Movimiento();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listarMovimientos();

            txtcantidad.Text = Convert.ToString(this.gv_Tabla_Lista_Movimientos.Rows.Count);

        }

    }
    void listarMovimientos()
    {

        gv_Tabla_Lista_Movimientos.DataSource = Nmovi.listarMovimiento();
        gv_Tabla_Lista_Movimientos.DataBind();

    }
    protected void gv_Tabla_Lista_Movimientos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gv_Tabla_Lista_Movimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}