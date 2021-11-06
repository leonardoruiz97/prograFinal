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

public partial class WF_Lista_Registrar_Penalidad : System.Web.UI.Page
{

    Penalidad pena = new Penalidad();
    N_Penalidad Npena = new N_Penalidad();
    Cuota cuo = new Cuota();
    N_Cuota Ncuota = new N_Cuota();
    protected void Page_Load(object sender, EventArgs e)
    {
        listarCuota();
    }

    protected void txtFillter_TextChanged(object sender, EventArgs e)
    {
      
    }

    void listarCuota()
    {

        
        cuo.FK_IECU_Cod = 3;
        gv_Tabla_Lista_Registrar_Penalidad.DataSource = Ncuota.ListarCuotaMoroso(cuo);
        gv_Tabla_Lista_Registrar_Penalidad.DataBind();

    }

    protected void gv_Tabla_Lista_Registrar_Penalidad_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gv_Tabla_Lista_Registrar_Penalidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Registrar_Penalidad.PageIndex = e.NewPageIndex;
        listarCuota();
    }

    protected void gv_Tabla_Lista_Registrar_Penalidad_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem, "VEcu_Estado_Cuota").ToString();
            if (estado == "Moroso")
            {

                e.Row.Cells[7].BackColor = System.Drawing.Color.LightCoral;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[7].Height = 4;
                e.Row.Cells[7].Width = 100;


            }
        }

    }
}