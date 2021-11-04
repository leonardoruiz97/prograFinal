<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Socio.master" AutoEventWireup="true" CodeFile="WF_Listar_Afiliaciones.aspx.cs" Inherits="WF_Listar_Afiliaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
     <link href="css/StyleSheet.css" rel="stylesheet" />
    <link href="css/sitegridview.css" rel="stylesheet" />

    <link href="dist/StyleSheet1.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    
   <link href="dist/StyleSheet1.css" rel="stylesheet" />
</asp:content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <section style="padding: 20px;"></section>
     <div id="nombreProducto" style="margin-left:328px">Lista de Afiliaciones</div>
  
    
    <div class="sub_head_right">
    <img src="img/cabecera.png" alt="..." " height="60"  >
        
            <div class="body_head" style="margin-left:328px" >
                  <b>Afiliaciones Realizadas</b>
                </div>

         <section style="padding: 20px;"></section>
     <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
    <section style="padding: 20px;"></section>
     <asp:Label ID="txtCodPatrocinador" runat="server" Text="" Visible="false"></asp:Label>

    <%--<h5 style="position:center; text-align:center">Afiliaciones Disponibles</h5>--%>

    <table width="900" border="0" cellpadding="0" cellspacing="0" class="table">
				<tbody>
                    <tr> 
                    <td class="td_left celda_arriba">Afiliaciones Disponibles:</td>
    <td class="td_right_col2 celda_arriba">
                   		
   <asp:TextBox ID="txtcantidad" runat="server" class="form-control" Width="25%" Height="50%" CssClass="auto-style1" Enabled="false"></asp:TextBox>
						
                    </tbody>
        </table>

  <%--     <asp:Label ID="Label1"  runat="server"  Text="Afiliaciones Disponibles:" Visible="true" style="margin-left:300px"></asp:Label>  
     <asp:Label ID="txtcantidad" runat="server" Text="" Visible="true" style="margin-left:5px"  ></asp:Label>--%>
   <section style="padding: 10px;"></section>
    <asp:GridView ID="gv_Tabla_Lista_Afiliaciones" runat="server" EmptyDataText="Usted no ha patrocinado aun a ninguna persona" CssClass="table table-striped table-hover" Width="60%" AutoGenerateColumns="False" GridLines="None" style="text-align:center; margin-left:auto;margin-right:auto">
        
        <columns>
    
            <asp:BoundField DataField="PK_IA_Cod" HeaderText="N°" />
            <asp:BoundField DataField="IA_Dni" HeaderText="Dni" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>
                    <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="VA_Nombre_Completo" HeaderText="Nombre Completo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>


            <asp:BoundField DataField="VA_Apellido_Paterno" HeaderText="Apellido Paterno" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>


             <asp:BoundField DataField="VA_Apellido_Materno" HeaderText="Apellido Materno" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="VA_Correo" HeaderText="Correo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" Visible="false">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
                  </columns>
      

            <headerstyle backcolor="#6fdefc" forecolor="Black" font-bold="true" />
        </asp:GridView>
 

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

    </asp:form>  

</asp:content>