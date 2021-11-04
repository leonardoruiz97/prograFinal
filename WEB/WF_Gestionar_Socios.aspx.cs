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



public partial class WF_Gestionar_Socios : System.Web.UI.Page
{
    Socio soc = new Socio();
    N_Socio Nsoc = new N_Socio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            listarSociosHabilitados();
            txtcantidad.Text = Convert.ToString(this.gv_Tabla_Lista_Socios.Rows.Count);


        }
    }

    void listarSociosHabilitados()
    {
       
        gv_Tabla_Lista_Socios.DataSource = Nsoc.listarSociosHabilitados(soc);
        gv_Tabla_Lista_Socios.DataBind();

    }
    protected void gv_Tabla_Lista_Socios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Suspender")//DENEGAR

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodSocioGrid.Text = gv_Tabla_Lista_Socios.Rows[index].Cells[0].Text;
            soc.PK_IS_Cod = int.Parse(txtcodSocioGrid.Text);
            soc.FK_IESocio_Cod = 2;
            Nsoc.ActualizarEstadoSocio(soc);

            listarSociosHabilitados();

        }

    }

    protected void gv_Tabla_Lista_Socios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Socios.PageIndex = e.NewPageIndex;
        listarSociosHabilitados();
    }

    protected void gv_Tabla_Lista_Socios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem, "VESocio_Estado_Socio").ToString();
            if (estado == "Habilitado")
            {
              

                e.Row.Cells[7].BackColor = System.Drawing.Color.LightBlue;
                e.Row.Cells[7].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[7].Height = 4;
                e.Row.Cells[7].Width = 100;



            }
        }

    }
}