﻿using System;
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

public partial class WF_Visualizar_Prestamos : System.Web.UI.Page
{
    Prestamo pre = new Prestamo();
    N_Prestamo Npre = new N_Prestamo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listarPrestamo();
            txtcantidad.Text = Convert.ToString(this.gv_Tabla_Lista_Prestamos.Rows.Count);
        }

    }

    void listarPrestamo()
    {
        
        gv_Tabla_Lista_Prestamos.DataSource = Npre.listarPrestamos(pre);
        gv_Tabla_Lista_Prestamos.DataBind();

    }

    protected void gv_Tabla_Lista_Prestamos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gv_Tabla_Lista_Prestamos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Prestamos.PageIndex = e.NewPageIndex;
        listarPrestamo();
    }

    protected void gv_Tabla_Lista_Prestamos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem, "VEPre_Estado_Prestamo").ToString();
            if (estado == "Aceptado")
            {
           
                e.Row.Cells[10].BackColor = System.Drawing.Color.DarkSeaGreen;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[10].Height = 4;
                e.Row.Cells[10].Width = 100;

            }

            if (estado == "Rechazado")
            {
              
                e.Row.Cells[10].BackColor = System.Drawing.Color.LightCoral;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[10].Height = 4;
                e.Row.Cells[10].Width = 100;



            }

            if (estado == "En Proceso")
            {
                e.Row.Cells[10].BackColor = System.Drawing.Color.LightSalmon;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[10].Width = 100;


            }

            if (estado == "Desembolsado")
            {
              
                e.Row.Cells[10].BackColor = System.Drawing.Color.SeaGreen;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[10].Width = 100;

            }

            if (estado == "Finalizado")
            {
            

                e.Row.Cells[10].BackColor = System.Drawing.Color.LightBlue;
                e.Row.Cells[10].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[10].Height = 4;
                e.Row.Cells[10].Width = 100;


            }
        }
    }
}