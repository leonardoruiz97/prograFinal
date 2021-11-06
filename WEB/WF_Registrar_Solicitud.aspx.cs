﻿using System;
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

public partial class WF_Registrar_Solicitud : System.Web.UI.Page
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

    N_Sexo nSexo = new N_Sexo();
    N_Distrito nDistri = new N_Distrito();
    N_Vivienda nVivienda = new N_Vivienda();

    Solicitud soli = new Solicitud();
    N_Solicitud Nsoli = new N_Solicitud();
    Patrocinador patro = new Patrocinador();
    N_Patrocinador Npatro = new N_Patrocinador();



   

    string fecha = DateTime.Now.ToString("dd/MM/yyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CodAfilia"] == null && Session["CodPatro"] == null && Session["DatosPatro"] == null && Session["Dni"] == null && Session["Nom"] == null && Session["Apaterno"] == null && Session["Amaterno"] == null && Session["correo"] == null)
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {

                listarCamposDdl();
                txtafiliacion.Text = Session["CodAfilia"].ToString();
                txtCodPatrocinador.Text = Session["CodPatro"].ToString();
                txtDatPatrocinador.Text = Session["DatosPatro"].ToString();
                txtDni.Text = Session["Dni"].ToString();
                txtNombre.Text = Session["Nom"].ToString(); 
                txtApaterno.Text = Session["Apaterno"].ToString(); 
                txtAmaterno.Text = Session["Amaterno"].ToString(); 
                txtCorreo.Text = Session["correo"].ToString();
                txtFechaRegistro.Text = fecha;
                txtCodPatrocinador.Enabled = false;
                txtDatPatrocinador.Enabled = false;
                txtDepartamento.Enabled = false;
               
            }
        }

    }

   public void listarCamposDdl()
    {
        ddlLugarNacimiento.DataSource = Ndep.listarDepartamento();
        ddlLugarNacimiento.DataTextField = "VD_Nombre";
        ddlLugarNacimiento.DataValueField = "PK_ID_Cod";
        ddlLugarNacimiento.DataBind();
        ddlLugarNacimiento.Items.Insert(0, "--seleccionar--");


        ddlEstadoCivil.DataSource = Necivil.listarEstadoCivil();
        ddlEstadoCivil.DataTextField = "VEc_Nombre";
        ddlEstadoCivil.DataValueField = "PK_IEc_Cod";
        ddlEstadoCivil.DataBind();
        ddlEstadoCivil.Items.Insert(0, "--seleccionar--");


        ddlOcupacion.DataSource = Nocu.listarOcupacion();
        ddlOcupacion.DataTextField = "VOcu_Nombre";
        ddlOcupacion.DataValueField = "PK_IOcu_Cod";
        ddlOcupacion.DataBind();
        ddlOcupacion.Items.Insert(0, "--seleccionar--");


        ddlProvincia.DataSource = Nprovi.listarProvincia();
        ddlProvincia.DataTextField = "VPro_Nombre";
        ddlProvincia.DataValueField = "PK_IPro_Cod";
        ddlProvincia.DataBind();
        ddlProvincia.Items.Insert(0, "--seleccionar--");

        ddlSexo.DataSource = nSexo.listarSexo();
        ddlSexo.DataTextField = "VSe_Nombre";
        ddlSexo.DataValueField = "PK_ISe_Cod";
        ddlSexo.DataBind();
        ddlSexo.Items.Insert(0, "--seleccionar--");

        ddlDistrito.DataSource = nDistri.listarDistrito();
        ddlDistrito.DataTextField = "VDi_Nombre";
        ddlDistrito.DataValueField = "PK_IDi_Cod";
        ddlDistrito.DataBind();
        ddlDistrito.Items.Insert(0, "--seleccionar--");

    }


    protected void btnRegistrarSolicitud_Click(object sender, EventArgs e)
    {
        if (txtDni.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertDnivacio()", true);
            return;
        }

        if (txtDni.Text.Trim().Length != 8)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertDnidigitos()", true);
            return;
        }
        if (txtNombre.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertNombreVacio()", true);
            return;
        }
        if (txtApaterno.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertApaVacio() ", true);
            return;
        }
        if (txtAmaterno.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertAmaVacio()", true);
            return;
        }
        if (ddlEstadoCivil.SelectedValue== "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertEstadoCivilVacio()", true);
            return;
        }

        if (txtfechaNacimiento.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertFechaNacVacio()", true);
            return;
        }
        

        if (txtDireccion.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertDireccionVacio()", true);
            return;
        }
        if (ddlLugarNacimiento.SelectedValue == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertDepartamentoVacio()", true);
            return;
        }
        if (ddlProvincia.SelectedValue == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertProvinciaVacio()", true);
            return;
        }
        if (ddlDistrito.SelectedValue == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertDistritoVacio()", true);
            return;
        }
        if (txtCorreo.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertCorreoVacio()", true);
            return;
        }
        if (txtCelular.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertCelularVacio()", true);
            return;
        }
        if (txtTelfijo.Text == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertTelefonoVacio()", true);
            return;
        }
        if (ddlOcupacion.SelectedValue== "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "alertOcupacionVacio()", true);
            return;
        }
        registrarSolicitud();
        validarAfiliacionPatrocinador();
        deshabilitarCampos();



    }

    void deshabilitarCampos()
    {
        txtDni.Enabled = false;
        txtNombre.Enabled = false;
        txtApaterno.Enabled = false;
        txtAmaterno.Enabled = false;
        txtfechaNacimiento.Enabled = false;
        txtFechaRegistro.Enabled = false;
        txtDireccion.Enabled = false;
        txtCorreo.Enabled = false;
        txtCelular.Enabled = false;
        txtTelfijo.Enabled = false;
        FileUpReciboLuz.Enabled = false;
        FileUpReciboAgua.Enabled = false;
        FileUpVivienda.Enabled = false;
        FileUpConstancia.Enabled = false;
        ddlDistrito.Enabled = false;
        ddlEstadoCivil.Enabled = false;
        ddlLugarNacimiento.Enabled = false;
        ddlOcupacion.Enabled = false;
        ddlProvincia.Enabled = false;
        ddlSexo.Enabled = false;
        btnRegistrarSolicitud.Visible = false;


    }



    public void registrarSolicitud()
    {
        soli.ISol_Dni = int.Parse(txtDni.Text);
        soli.VSol_Nombre_Completo = txtNombre.Text;
        soli.VSol_Apellido_Paterno = txtApaterno.Text;
        soli.VSol_Apellido_Materno = txtAmaterno.Text;
        soli.DSol_Fecha_Nacimiento = Convert.ToDateTime(txtfechaNacimiento.Text);
        soli.DSol_Fecha_Registro = Convert.ToDateTime(txtFechaRegistro.Text);
        soli.VSol_Direccion = txtDireccion.Text;
        soli.VSol_Correo = txtCorreo.Text;
        soli.ISol_Celular = int.Parse(txtCelular.Text);
        soli.ISol_Telefono_Fijo = int.Parse(txtTelfijo.Text);
        soli.DepartamentoResidencia = "Lima";
        if(FileUpReciboLuz != null)
        {

            int tamanio = FileUpReciboLuz.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpReciboLuz.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpReciboLuz.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            soli.IMSol_Recibo_Luz = ImagenOriginal;

        }
       if (FileUpReciboAgua != null)
        {
            int tamanio = FileUpReciboAgua.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpReciboAgua.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpReciboAgua.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            soli.IMSol_Recibo_agua = ImagenOriginal;

        }
       if (FileUpVivienda != null)
        {
            int tamanio = FileUpVivienda.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpVivienda.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpVivienda.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            soli.IMSol_Imagen_Vivienda = ImagenOriginal;

        }

        if (FileUpConstancia != null)
        {
            int tamanio = FileUpConstancia.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamanio];
            FileUpConstancia.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
            Bitmap ImagenOriginalBinaria = new Bitmap(FileUpConstancia.PostedFile.InputStream);


            string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);
            soli.IMSol_Constancia = ImagenOriginal;

        }

        soli.FK_ID_Cod = ddlLugarNacimiento.SelectedIndex;
        soli.FK_IPro_Cod = ddlProvincia.SelectedIndex;
        soli.FK_IEc_Cod = ddlEstadoCivil.SelectedIndex;
        soli.FK_IOcu_Cod = ddlOcupacion.SelectedIndex;
        soli.FK_ISe_Cod = ddlSexo.SelectedIndex;
        soli.FK_IDi_Cod = ddlDistrito.SelectedIndex;
        soli.FK_IESol_Cod = 1;
        soli.FK_IA_Cod = int.Parse(txtafiliacion.Text);
        ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "RegistrarSolicitud()", true);
       
        Nsoli.RegistrarSolicitud(soli);
     

    }

    void validarAfiliacionPatrocinador()
    {
        patro.IPa_Dni = int.Parse(txtCodPatrocinador.Text);
        Npatro.buscarPatrocinadorDni(patro);
        lblpkpatrobus.Text = "" + patro.PK_IPa_Cod;

        if(int.Parse(lblpkpatrobus.Text) != 0)
        {
            lbldniPatrobus.Text = "" + patro.IPa_Dni;
            lblcantafiliabus.Text = "" + patro.IPa_Cantidad_Afiliaciones;

            if(txtCodPatrocinador.Text == lbldniPatrobus.Text)
            {
                if(int.Parse(lblcantafiliabus.Text) < 3)
                {
                   
                    patro.IPa_Dni = int.Parse(txtCodPatrocinador.Text);
                    patro.IPa_Cantidad_Afiliaciones = int.Parse(lblcantafiliabus.Text) + 1;
                    Npatro.ActualizarAfiliacionPatrocinador(patro);
                }
              
                
            }
        }
        
    }


  


    /*  void insertarphoto()
      {
          if (fupLoadImagen.FileName != "")
          {
              //txtimg.Text = fupLoadImagen.FileName;


              int tamanio = fupLoadImagen.PostedFile.ContentLength;
              byte[] ImagenOriginal = new byte[tamanio];
              fupLoadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
              Bitmap ImagenOriginalBinaria = new Bitmap(fupLoadImagen.PostedFile.InputStream);


              string ImagenDataURL64 = "data:image/png;base64," + Convert.ToBase64String(ImagenOriginal);


              SqlConnection conexionSQL = new SqlConnection(GD_ConexionBD.CadenaConexion);
              SqlCommand cmd = new SqlCommand();
              cmd.CommandText = "INSERT T_Solicitud (IMDS_Recibo_Luz,IMDS_Recibo_agua,IMS_Imagen_Vivienda) VALUES (@IMDS_Recibo_Luz,@IMDS_Recibo_agua,@IMS_Imagen_Vivienda)";
              cmd.Parameters.Add("@IMDS_Recibo_Luz", SqlDbType.Image).Value = ImagenOriginal;
              cmd.Parameters.Add("@IMDS_Recibo_agua", SqlDbType.Text).Value = ImagenOriginal;
              cmd.Parameters.Add("@IMS_Imagen_Vivienda", SqlDbType.Float).Value = ImagenOriginal;


              cmd.CommandType = CommandType.Text;
              cmd.Connection = conexionSQL;
              conexionSQL.Open();
              cmd.ExecuteNonQuery();




              ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alertRegistrar()", true);

              fupLoadImagen.Enabled = false;
          }
          else if (fupLoadImagen.FileName == "")
          {
              ClientScript.RegisterStartupScript(this.Page.GetType(), "alerta", "alterimagen()", true);
          }

      }


      */


    protected void btnatras_Click(object sender, EventArgs e)
    {
        Response.Redirect("Inicio.aspx");
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    public DataSet Consultar(string strSQL)
    {
        string strconn = "Data Source =EDUARDO;Initial Catalog=BD_SWGISC;Integrated Security=True";
        SqlConnection con = new SqlConnection(strconn);
        con.Open();
        SqlCommand cmd = new SqlCommand(strSQL, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

    protected void ddlLugarNacimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        int DepartamentoID = Convert.ToInt32(ddlLugarNacimiento.SelectedValue);
        ddlProvincia.DataSource = Consultar("SELECT * FROM T_Provincia WHERE FK_Departamento=" + DepartamentoID);
        //ddlProvincia.DataTextField = "T_Provincia";
        //ddlProvincia.DataValueField = "PK_IPro_Cod";
        ddlProvincia.DataBind();
        ddlProvincia.Items.Insert(0, new ListItem("Seleccionar", "0")); 
    }

    protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}