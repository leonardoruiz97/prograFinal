<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Socio.master" AutoEventWireup="true" CodeFile="WF_Listar_Prestamo_Aceptado_Socio.aspx.cs" Inherits="WF_Listar_Prestamo_Aceptado_Socio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <link href="css/sitegridview.css" rel="stylesheet" />

    <link href="dist/StyleSheet1.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>

    <link href="dist/StyleSheet1.css" rel="stylesheet" />

    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <section style="padding: 20px;"></section>
    <div id="nombreProducto" style="margin-left: 158px">Lista de Prestamo Aceptados</div>


    <div class="sub_head_right">
    <img src="img/cabecera.png" alt="..." " height="82"  >
        
          
            <div class="body_head" style="margin-left:148px;width:1350px" >
                  <b>Mis Prestamos Aceptados</b>
                </div>

        <section style="padding: 20px;"></section>
        <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
        <section style="padding: 20px;"></section>
        <asp:Label ID="txtCodPatrocinador" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtCodSocio" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtNomSocioprestamoAceptada" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtImportePrestamoAceptado" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtNumPrestamo" runat="server" Text="" Visible="false"></asp:Label>
          <asp:Label ID="txttcea" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtNumCuotas" runat="server" Text="" Visible="false"></asp:Label>
                  <asp:Label ID="txtFechaRegistro" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="txtfechafin" runat="server" Text="" Visible="false"></asp:Label>
          <asp:Label ID="txtMontoCuotas" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtRangoFecha" runat="server" Text="" Visible="false"></asp:Label>
         <section style="padding: 10px;"></section>

        <asp:GridView ID="gv_Tabla_Prestamo_Aceptado_Socio" runat="server" EmptyDataText="Usted no tiene prestamos aceptados" OnRowCommand="gv_Tabla_Prestamo_Aceptado_Socio_RowCommand" OnPageIndexChanging="gv_Tabla_Prestamo_Aceptado_Socio_PageIndexChanging" OnRowDataBound="gv_Tabla_Prestamo_Aceptado_Socio_RowDataBound" CssClass="table table-bordered table-hover" Width="80%" AutoGenerateColumns="False" GridLines="None">

            <columns>

                 <asp:BoundField DataField="PK_IPre_Cod" HeaderText="Nº Prestamo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>

        

                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">

                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>

                </asp:BoundField>

                <asp:BoundField DataField="NumeroCuotas" HeaderText="Numero Cuotas" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>


                <asp:BoundField DataField="LugarResidencia" HeaderText="Residencia" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>


                <asp:BoundField DataField="Importe" HeaderText="Importe" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>

                <asp:BoundField DataField="TasaMensual" HeaderText="Tasa Mensual" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="TCEA" HeaderText="TCEA" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>
                <asp:BoundField DataField="EstadoDePrestamo" HeaderText="Estado del Prestamo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <headerstyle cssclass="text-center"></headerstyle>

                    <itemstyle cssclass="text-center"></itemstyle>
                </asp:BoundField>

                <asp:TemplateField HeaderText="Generar Comprobante" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <itemtemplate>
                        <asp:LinkButton ID="btnGenerar" CssClass="btn btn-success" runat="server" CommandName="Generar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Generar" Style="color: white">
                            <span class="glyphicon glyphicon-download-alt" aria-hidden="true"></span>

                        </asp:LinkButton>
                    </itemtemplate>
                </asp:TemplateField>

            </columns>


            <headerstyle backcolor="#6fdefc" forecolor="Black" font-bold="true" />
        </asp:GridView>
 </div>

   <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.0.0-rc2/css/bootstrap-glyphicons.css">
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="js/scripts.js"></script>
    <script src="dist/https://code.jquery.com/jquery-3.5.1.min.js" crossorigin="anonymous"></script>
    <script src="dist/https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="dist/js/scripts.js"></script>
    <script src="dist/https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    <script src="dist/assets/demo/chart-area-demo.js"></script>
    <script src="dist/assets/demo/chart-bar-demo.js"></script>
    <script src="dist/https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js" crossorigin="anonymous"></script>
    <script src="dist/https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js" crossorigin="anonymous"></script>
    <script src="dist/assets/demo/datatables-demo.js"></script>
    <%--  </main>--%>


    <script src="plugins/jquery-datatable/jquery.dataTables.js"></script>
    <!-- Jquery DataTable Plugin Js -->
    <script src="plugins/jquery-datatable/jquery.dataTables.js"></script>
    <script src="plugins/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="plugins/jquery-datatable/extensions/export/buttons.print.min.js"></script>

    <!-- Custom Js -->
    <script src="js/admin.js"></script>
    <script src="js/pages/tables/jquery-datatable.js"></script>

    <!-- Demo Js -->
    <script src="js/demo.js"></script>
    <script type="text/javascript" charset="utf-8" src="https://cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>


 
        
</asp:Content>

