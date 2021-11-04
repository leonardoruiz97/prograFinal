using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronPdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Image = iTextSharp.text.Image;
using Dominio;
using Negocio;

public partial class WF_Simulacion_Pagos : System.Web.UI.Page
{
    Socio soci = new Socio();
    N_Socio Nsocio = new N_Socio();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtcodsocio.Text = Session["dni"].ToString();
            lbltipoprestamo.Text = Session["Prestamo"].ToString();
            lblimporte.Text = Session["monto"].ToString();
            lbldiapago.Text = Session["diapago"].ToString();
            lblfecha.Text = Session["fecha"].ToString();
            lbltasa.Text = Session["tasa"].ToString();
            lblmeses.Text = Session["meses"].ToString();
            lblconstancias.Text = Session["virtual"].ToString();
            lblconstancias1.Text = Session["fisico"].ToString();
            lblconstancias2.Text = Session["ambos"].ToString();
            lblcuotas.Text = Session["cuotas"].ToString();
            lblperiodo.Text = Session["periodo"].ToString();
            lblvalor.Text = Session["valor"].ToString();
            lblbcuotasmeses.Text = Session["mesesAdicionales"].ToString();
            lblfechapago.Text = Session["fechapago"].ToString();
            validaciones();
            cuota();
            subProducto();
            calcular();
        }
    }

    void buscarSocioSimulacion ()
    {
        soci.IS_Dni = int.Parse(txtcodsocio.Text);
        Nsocio.BuscarSocio(soci);
        txtnomsocio.Text = "" + soci.VS_Nombre_Completo + " " + soci.VS_Apellido_Paterno + " " + soci.VS_Apellido_Materno;
    }

    public static bool KeepActiveSession()
    {
        if (HttpContext.Current.Session["datos"] != null)
            return true;
        else
            return false;
    }

 
    public static void SessionAbandon()
    {
        HttpContext.Current.Session.Remove("datos");
    }

    void validaciones()
    {
        //cuotas
        if (lblbcuotasmeses.Text == "")
        {
            lblbcuotasmeses.Text = "No";
        }

        //valor bien
        if (lblvalor.Text == "")
        {
            lblvalor.Text = "-";
        }

        //periodo
        if (lblperiodo.Text == "")
        {
            lblperiodo.Text = "-";
        }

        //comision

        if (lblconstancias1.Text == "" && lblconstancias2.Text == "")
        {
            lblcomision.Text = "-";
        }
        else
        {
            lblcomision.Text = "7 soles";
        }
    }

    void subProducto()
    {
        if(lbltipoprestamo.Text== "CRÉDITO A SOLA FIRMA")
        {
            lblsubproducto.Text = "CSF001 - A Sola Firma";
            lbltcea.Text = "12.68%";
           
        }
        if (lbltipoprestamo.Text == "CRÉDITO ORDINARIOS Y SOBREPRESTAMOS")
        {
            lblsubproducto.Text = "COS002 - Ordinario";
            lbltcea.Text = "42.57%";
       
        }
        if (lbltipoprestamo.Text == "CRÉDITO HIPOTECARIO Y GARANTIA HIPOTECARIA")
        {
            lblsubproducto.Text = "CHGH003 - Hipotecario";
            lbltcea.Text = "19.56%";
            btnSolicitar.Visible = false;
        }
    }
 
    public void cuota()
    {
        int importe = int.Parse(lblimporte.Text);
        int meses = int.Parse(lblmeses.Text);
        double tasa = double.Parse(lbltasa.Text);
        double tasaxinteres = tasa / 100.00;
        double potenciaNumero = (1 + tasaxinteres);
        double potenciaVariable = Math.Pow(potenciaNumero, -meses);

        double cuotaconinteres = importe * (tasaxinteres / (1 - potenciaVariable));

        double numCuota = Math.Round(cuotaconinteres, 3);

        lblcuota.Text = numCuota.ToString() + " " + "soles";
        lblcuotamos.Text = numCuota.ToString();
        lblimporte.Text = importe+ " " + "soles";
        lblimportemos.Text = importe.ToString();
        lblmeses.Text = meses + " " + "meses";
        lblmesesmos.Text = meses.ToString();
        lbltasa.Text = tasa + "%";
        lbltasamos.Text = tasa.ToString();
    }

    protected void btnSolicitar_Click(object sender, EventArgs e)
    {
        Response.Redirect("WF_Solicitar_Prestamo.aspx");
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("WF_Simular_Prestamos.aspx");
    }





   public void calcular()
    {
        double strMonto = double.Parse(lblimportemos.Text);
        int meses = int.Parse(lblmesesmos.Text);
        double InterecAnual = Convert.ToDouble(lbltasamos.Text);
       double tasaPorcentual = InterecAnual / 100;
        double potenciaNumero = (1 + tasaPorcentual);
        double potenciaVariable = Math.Pow(potenciaNumero, -meses);
       double Cuotaaa = strMonto * (tasaPorcentual / (1 - potenciaVariable));
        double numCuota = Math.Round(Cuotaaa, 2);
        double INTERES = 0;
        double TINTERES = 0;
        double CAPITAL = 0;
        double TAMORTIZADO = 0;
        double TCUOTA = 0;
        double SALDOINICIAL = 0;
        double SALDORESTANTE = 0;
        double ACUMULADO = 0;
        double SALDOFINAL = strMonto;
        for (int I = 1; I < meses + 1; I++)
        {

            TableRow row = new TableRow();
         
             //INTERES APLICADO A LA TASA
            TINTERES += INTERES;
            ACUMULADO += INTERES; //
            SALDOINICIAL =Math.Round(SALDOFINAL,2);
            CAPITAL =  Math.Round(numCuota,2);
            SALDOFINAL -= CAPITAL;
            SALDORESTANTE = SALDOINICIAL - CAPITAL;
            INTERES = Math.Round(SALDOINICIAL * tasaPorcentual,2);
            TAMORTIZADO = Math.Round(numCuota - INTERES,2);

            if(SALDORESTANTE < 0)
            {
                SALDORESTANTE = 0;
            }

            DateTime FFecha = Convert.ToDateTime(lblfechapago.Text);
            FFecha = FFecha.AddMonths(I );
            TableCell cell2 = new TableCell();
            cell2.Text = String.Format("Mes {0}", I);
            row.Cells.Add(cell2);
            cell2 = new TableCell();
            cell2.Text = FFecha.ToString("dd/MM/yyyy");
            row.Cells.Add(cell2);
            cell2 = new TableCell();
            cell2.Text = SALDOINICIAL.ToString();
            row.Cells.Add(cell2);
            cell2 = new TableCell();
            cell2.Text = TAMORTIZADO.ToString();
            row.Cells.Add(cell2);

            cell2 = new TableCell();
            cell2.Text = INTERES.ToString();
            row.Cells.Add(cell2);


            cell2 = new TableCell();
            cell2.Text = numCuota.ToString();
            row.Cells.Add(cell2);

            cell2 = new TableCell();
            cell2.Text = SALDORESTANTE.ToString();
            row.Cells.Add(cell2);
            myTable.Rows.Add(row);

        }
    }

    DataTable MakeDataTable()
    {
        double strMonto = double.Parse(lblimportemos.Text);
        int meses = int.Parse(lblmesesmos.Text);
        double InterecAnual = Convert.ToDouble(lbltasamos.Text);
        double tasaPorcentual = InterecAnual / 100;
        double potenciaNumero = (1 + tasaPorcentual);
        double potenciaVariable = Math.Pow(potenciaNumero, -meses);
        double Cuotaaa = strMonto * (tasaPorcentual / (1 - potenciaVariable));
        double numCuota = Math.Round(Cuotaaa, 2);
        double INTERES = 0;
        double TINTERES = 0;
        double CAPITAL = 0;
        double TAMORTIZADO = 0;
        double TCUOTA = 0;
        double SALDOINICIAL = 0;
        double SALDORESTANTE = 0;
        double ACUMULADO = 0;
        double SALDOFINAL = strMonto;
        DataTable data = new DataTable();
        data.Columns.Add("Mes");
        data.Columns.Add("Fecha");
        data.Columns.Add("Saldo Inicial");
        data.Columns.Add("Amortizacion");
        data.Columns.Add("Interes");
        data.Columns.Add("Cuota");
        data.Columns.Add("Saldo Capital");
        for (int I = 1; I < meses + 1; I++)
        {
            //INTERES APLICADO A LA TASA
            TINTERES += INTERES;
            ACUMULADO += INTERES; //
            SALDOINICIAL = SALDOFINAL;
            CAPITAL = Math.Round(numCuota, 2);
            SALDOFINAL -= CAPITAL;
            SALDORESTANTE = SALDOINICIAL - CAPITAL;
            INTERES = Math.Round(SALDOINICIAL * tasaPorcentual, 2);
            TAMORTIZADO = Math.Round(numCuota - INTERES, 2);

            if (SALDORESTANTE < 0)
            {
                SALDORESTANTE = 0;
            }
            DateTime FFecha = Convert.ToDateTime(lblfechapago.Text);
            FFecha = FFecha.AddMonths(I);

           

            data.Rows.Add(String.Format("Mes {0}", I), FFecha.ToString("dd/MM/yyyy"), SALDOINICIAL.ToString(), TAMORTIZADO.ToString(), INTERES.ToString(),numCuota.ToString(), SALDORESTANTE.ToString());
           
        }
        return data;

    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {

        try
        {
            DataTable dtbl = MakeDataTable();
            tablitapdf(dtbl, "COOPAC SAN COSME LTDA");
           
        }
        catch (Exception ex)
        {
            
        }
      
  

    }

    public void tablitapdf(DataTable dtblTable, string strHeader)
    {
        try
        {
            buscarSocioSimulacion();
            //FileStream fs2 = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document pdfDoc = new Document(PageSize.A4, 15.0f, 15.0f, 30.0f, 30.0f);

            PdfWriter pdfwrite = PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);



            #region TIPOS DE FUENTE
            Font FontB = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.NORMAL));
            Font FontB8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, Font.BOLD));
            Font FontB12 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.BOLD));
            #endregion
            PdfPCell CVacio = new PdfPCell(new Phrase(""));
            CVacio.Border = 0;
            pdfDoc.Open();
            float[] a = { 4.0f, 7.0f, 1.0f, 4.0f };
            PdfPTable tabla = new PdfPTable(4);
            PdfPCell col1 = new PdfPCell();
            PdfPCell col2 = new PdfPCell();
            PdfPCell col3 = new PdfPCell();
            PdfPCell col4 = new PdfPCell();
            PdfPCell col5 = new PdfPCell();
            PdfPCell col6 = new PdfPCell();
            PdfPCell col7 = new PdfPCell();
            int ILine = 0;
            int iFila = 0;
            tabla.WidthPercentage = 95;
            tabla.SetWidths(a);
            #region Tabla1-Encabezado
            string imagenURL = Server.MapPath("/img/SanCosme.png");
            Image imagenBMP = Image.GetInstance(imagenURL);
            imagenBMP.ScaleToFit(100.0f, 100.0f);
            imagenBMP.SpacingBefore = 10.0f;
            imagenBMP.SpacingAfter = 20.0f;
            imagenBMP.SetAbsolutePosition(40, 765);
            pdfDoc.Add(imagenBMP);

            tabla.AddCell(CVacio);
            col2 = new PdfPCell(new Phrase("COOPAC SAN COSME LTDA.", FontB8));
            col2.Border = 0;
            tabla.AddCell(col2);

            tabla.AddCell(CVacio);

            col3 = new PdfPCell(new Phrase("CRONOGRAMA DE", FontB8));

            col3.Border = 0;
            tabla.AddCell(col3);

            tabla.AddCell(CVacio);
            col2 = new PdfPCell(new Phrase("Pasaje Enrique Meiggs 2123", FontB));
            col2.Border = 0;
            tabla.AddCell(col2);

            tabla.AddCell(CVacio);
            col3 = new PdfPCell(new Phrase("        PAGOS", FontB8));
            col3.Border = 0;
            tabla.AddCell(col3);

            tabla.AddCell(CVacio);
            col2 = new PdfPCell(new Phrase("La Victoria - Lima - Perú", FontB));
            col2.Border = 0;
            tabla.AddCell(col2);

            tabla.AddCell(CVacio);
            col3 = new PdfPCell(new Phrase("RUC:10078799884", FontB8));
            col3.Border = 0;
            tabla.AddCell(col3);

            tabla.AddCell(CVacio);
            col2 = new PdfPCell(new Phrase("(993403034)", FontB));
            col2.Border = 0;
            tabla.AddCell(col2);

            tabla.AddCell(CVacio);
            col3 = new PdfPCell(new Phrase("", FontB8));
            col3.Border = 0;
            tabla.AddCell(col3);

            tabla.AddCell(CVacio);
            col2 = new PdfPCell(new Phrase("www.coopacsancosme.com", FontB));
            col2.Border = 0;
            tabla.AddCell(col2);

            tabla.AddCell(CVacio);
            col3 = new PdfPCell(new Phrase("       ", FontB8));
            col3.Border = 0;
            tabla.AddCell(col3);
            pdfDoc.Add(tabla);
            #endregion

            Paragraph p = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 3)));


            pdfDoc.Add(new Paragraph("."));

            #region Tabla2-Cliente
            PdfPTable Table2 = new PdfPTable(4);
            float[] widths2 = { 2.0f, 8.0f, 3.0f, 2.0f };
            Table2.WidthPercentage = 95;
            Table2.SetWidths(widths2);
            Table2.AddCell(CVacio);
            Table2.AddCell(CVacio);
            Table2.AddCell(CVacio);
            Table2.AddCell(CVacio);
            col1 = new PdfPCell(new Phrase("Socio :", FontB8));
            col1.Border = 0;
            Table2.AddCell(col1);
            col2 = new PdfPCell(new Phrase(txtnomsocio.Text.ToUpper(), FontB));
            col2.Border = 0;
            Table2.AddCell(col2);
            col3 = new PdfPCell(new Phrase("Fecha Emisión:", FontB8));
            col3.Border = 0;
            Table2.AddCell(col3);
            col4 = new PdfPCell(new Phrase(DateTime.Today.ToShortDateString(), FontB));
            col4.Border = 0;
            Table2.AddCell(col4);

            col5 = new PdfPCell(new Phrase("Importe:", FontB8));
            col5.Border = 0;
            Table2.AddCell(col5);
            col5 = new PdfPCell(new Phrase(lblimporte.Text, FontB));
            col5.Border = 0;
            Table2.AddCell(col5);

            col1 = new PdfPCell(new Phrase("Tasa Efectiva Mensual:", FontB8));
            col1.Border = 0;
            Table2.AddCell(col1);
            col2 = new PdfPCell(new Phrase(lbltasa.Text, FontB));
            col2.Border = 0;
            Table2.AddCell(col2);

            col1 = new PdfPCell(new Phrase("Distrito:", FontB8));
            col1.Border = 0;
            Table2.AddCell(col1);
            col2 = new PdfPCell(new Phrase("LIMA", FontB));
            col2.Border = 0;
            Table2.AddCell(col2);


            col3 = new PdfPCell(new Phrase("Sub-Producto:", FontB8));
            col3.Border = 0;
            Table2.AddCell(col3);
            col4 = new PdfPCell(new Phrase(lblsubproducto.Text, FontB));
            col4.Border = 0;
            Table2.AddCell(col4);
            Table2.AddCell(CVacio);
            Table2.AddCell(CVacio);
            pdfDoc.Add(Table2);

            #endregion
            pdfDoc.Add(p);




            pdfDoc.Add(new Phrase("\n", FontB8));

            pdfDoc.Add(new Paragraph(12, "                                            CRONOGRAMA DE SIMULACIÓN DE PAGOS", FontB12));
            pdfDoc.Add(new Phrase("\n", FontB8));

            #region Tabla4-Detalles
            PdfPTable Table4 = new PdfPTable(dtblTable.Columns.Count);
            float[] widths4 = { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f };
            Table4.WidthPercentage = 95;
            Table4.SetWidths(widths4);



            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            for (int j = 0; j < dtblTable.Columns.Count; j++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[j].ColumnName.ToUpper(), FontB8));
                Table4.AddCell(cell);

            }


            //table data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    PdfPCell prueba = new PdfPCell(new Phrase(dtblTable.Rows[i][j].ToString(), FontB8));
                    Table4.AddCell(dtblTable.Rows[i][j].ToString());


                }

            }

            pdfDoc.Add(Table4);

            #endregion

            for (iFila = 1; iFila < 15; iFila++)
            {
                pdfDoc.Add(new Paragraph(" "));
                if (ILine < 200)
                {
                    ILine = (int)pdfwrite.GetVerticalPosition(true);
                }

            }

            pdfDoc.Close();
            pdfwrite.Close();
            //fs2.Close();

            Response.ContentType = "application/pdf";

            //Set default file Name as current datetime 
            Response.AddHeader("content-disposition", "attachment; filename=CronogramaPagos.pdf");
            System.Web.HttpContext.Current.Response.Write(pdfDoc);

            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }







}