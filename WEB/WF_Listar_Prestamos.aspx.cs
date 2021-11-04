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


public partial class WF_Listar_Prestamos : System.Web.UI.Page
{

    Prestamo pre = new Prestamo();
    N_Prestamo Npre = new N_Prestamo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listarPrestamo();
            


        }
    }

    void listarPrestamo()
    {
        //    txtpkusuario.Text = "" + 2;
       pre.FK_IEPre= 1;
        gv_Tabla_Lista_Prestamo.DataSource= Npre.listarPrestamoPendiente(pre);
        gv_Tabla_Lista_Prestamo.DataBind();

    }



    protected void gv_Tabla_Lista_Prestamo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        


        if (e.CommandName == "Aprobar")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            txtcodPrestamoGrid.Text = gv_Tabla_Lista_Prestamo.Rows[index].Cells[0].Text;
           pre.PK_IPre_Cod = int.Parse(txtcodPrestamoGrid.Text);
            pre.FK_IEPre = 2;
     
            Npre.ActualizarEstadoPrestamo(pre);

            listarPrestamo();
        
        }
        
        if (e.CommandName == "Ver")//VER 

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodPrestamoGrid.Text = gv_Tabla_Lista_Prestamo.Rows[index].Cells[0].Text;
            Session["CodPreGrid"] = "" + txtcodPrestamoGrid.Text;
            Response.Redirect("WF_Detalle_Prestamo.aspx");

        }

        if (e.CommandName == "VerImagenes")//VER IMAGNES

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodPrestamoGrid.Text = gv_Tabla_Lista_Prestamo.Rows[index].Cells[0].Text;
            txtestadoGrid.Text = gv_Tabla_Lista_Prestamo.Rows[index].Cells[10].Text;
            Session["CodEstadoGrid"] = "" + txtestadoGrid.Text;
            Session["CodPreGrid"] = "" + txtcodPrestamoGrid.Text;
            Response.Redirect("WF_Detalle_Prestamo_Imagenes.aspx");

        }

        if (e.CommandName == "Denegar")//DENEGAR

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodPrestamoGrid.Text = gv_Tabla_Lista_Prestamo.Rows[index].Cells[0].Text;
            pre.PK_IPre_Cod = int.Parse(txtcodPrestamoGrid.Text);
            pre.FK_IEPre = 3;
            Npre.ActualizarEstadoPrestamo(pre);

            listarPrestamo();

        }

    }

    protected void gv_Tabla_Lista_Prestamo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Prestamo.PageIndex = e.NewPageIndex;
        listarPrestamo();

    }

    protected void gv_Tabla_Lista_Prestamo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem, "VEPre_Estado_Prestamo").ToString();
            if (estado == "En Proceso")
            {



                e.Row.Cells[10].BackColor = System.Drawing.Color.LightSalmon;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[10].Height = 4;
                e.Row.Cells[10].Width = 100;


            }
        }


  
    }



    protected void txtfiltro_TextChanged(object sender, EventArgs e)
    {
        //string filterField = "Nombre";
        //((DataTable)gv_Tabla_Lista_Prestamo.DataSource).DefaultView.RowFilter = "VTP_Nombre like"+txtfiltro.Text;


    }

    protected void txtFillter_TextChanged(object sender, EventArgs e)
    {

    }
}