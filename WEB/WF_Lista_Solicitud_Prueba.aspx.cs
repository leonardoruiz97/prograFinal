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


public partial class WF_Lista_Solicitud_Prueba : System.Web.UI.Page
{
    Departamento dep = new Departamento();
    N_Departamento Ndep = new N_Departamento();

    Afiliacion afilia = new Afiliacion();
    N_Afiliacion Nafilia = new N_Afiliacion();

    Estado_Civil ecivil = new Estado_Civil();
    N_EstadoCivil Necivil = new N_EstadoCivil();

    Ocupacion ocu = new Ocupacion();
    N_Ocupacion Nocu = new N_Ocupacion();

    Provincia pro = new Provincia();
    N_Provincia Nprovi = new N_Provincia();

    Solicitud sol = new Solicitud();
    N_Solicitud Nsol = new N_Solicitud();

    Socio so = new Socio();
    N_Socio Nso = new N_Socio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listarsolicitud();

        }
    }



    void listarsolicitud()
    {
        //    txtpkusuario.Text = "" + 2;
        sol.FK_IESol_Cod = 2;
        gv_Tabla_Lista_Solicitud.DataSource = Nsol.listarsolicitudAceptada(sol);
        gv_Tabla_Lista_Solicitud.DataBind();

    }
    protected void gv_Tabla_Lista_Solicitud_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Aprobar")
        {

            int index = Convert.ToInt32(e.CommandArgument);
            txtCodSolicitud.Text = gv_Tabla_Lista_Solicitud.Rows[index].Cells[0].Text;
            sol.PK_ISol_Cod = int.Parse(txtCodSolicitud.Text);
            sol.FK_IESol_Cod = 2;
            string codSol = gv_Tabla_Lista_Solicitud.Rows[index].Cells[0].Text;
            string dni = gv_Tabla_Lista_Solicitud.Rows[index].Cells[1].Text;
            string nombre = gv_Tabla_Lista_Solicitud.Rows[index].Cells[2].Text;
            string paterno = gv_Tabla_Lista_Solicitud.Rows[index].Cells[3].Text;
            string materno = gv_Tabla_Lista_Solicitud.Rows[index].Cells[4].Text;
            string fechaNacimiento = gv_Tabla_Lista_Solicitud.Rows[index].Cells[5].Text;
            string fechaRegistro = gv_Tabla_Lista_Solicitud.Rows[index].Cells[6].Text;
            string correo = gv_Tabla_Lista_Solicitud.Rows[index].Cells[8].Text;
            txtFKsol.Text = codSol;
            txtdni.Text = dni;
            txtnombrecompleto.Text = nombre;
            txtApaterno.Text = paterno;
            txtAmaterno.Text = materno;
            txtfechaNacimiento.Text = fechaNacimiento;
            txtfechaRegistro.Text = fechaRegistro;
            txtCorreo.Text = correo;



            Nsol.ActualizarEstadoSolicitud(sol);
            registrarSocio();
            listarsolicitud();

        }

        if (e.CommandName == "Ver")//VER 

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtcodSoliGrid.Text = gv_Tabla_Lista_Solicitud.Rows[index].Cells[0].Text;
            Session["CodSoliGrid"] = "" + txtcodSoliGrid.Text;
            Response.Redirect("WF_Detalle_Solicitud.aspx");


        }



        if (e.CommandName == "Denegar")//DENEGAR

        {
            int index = Convert.ToInt32(e.CommandArgument);
            txtCodSolicitud.Text = gv_Tabla_Lista_Solicitud.Rows[index].Cells[0].Text;
            sol.PK_ISol_Cod = int.Parse(txtCodSolicitud.Text);
            sol.FK_IESol_Cod = 3;
            Nsol.ActualizarEstadoSolicitud(sol);
            listarsolicitud();

        }





    }


    void registrarSocio()
    {
        so.IS_Dni = int.Parse(txtdni.Text);
        so.VS_Nombre_Completo = txtnombrecompleto.Text;
        so.VS_Apellido_Paterno = txtApaterno.Text;
        so.VS_Apellido_Materno = txtAmaterno.Text;
        so.DS_Fecha_Nacimiento = Convert.ToDateTime(txtfechaNacimiento.Text);
        so.DS_Fecha_Registro = Convert.ToDateTime(txtfechaRegistro.Text);
        so.FK_ISol_Cod = int.Parse(txtFKsol.Text);
        Nso.RegistrarSocio(so);


    }



    protected void gv_Tabla_Lista_Solicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Tabla_Lista_Solicitud.PageIndex = e.NewPageIndex;
        listarsolicitud();
    }

    protected void gv_Tabla_Lista_Solicitud_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string estado = DataBinder.Eval(e.Row.DataItem, "VEsol_Estado_Solicitud").ToString();
            if (estado == "Aceptado")
            {
                e.Row.Cells[9].BackColor = System.Drawing.Color.LightBlue;
                e.Row.Cells[9].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[9].Height = 4;
                e.Row.Cells[9].Width = 100;

               

            }
        }
    }
}