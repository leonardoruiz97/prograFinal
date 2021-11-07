<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Socio.master" AutoEventWireup="true" CodeFile="WF_Historial_Pagos.aspx.cs" Inherits="WF_Historial_Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <link href="css/StyleSheet.css" rel="stylesheet" />
    <link href="css/sitegridview.css" rel="stylesheet" />

    <link href="dist/StyleSheet1.css" rel="stylesheet" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    
   <link href="dist/StyleSheet1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <section style="padding: 20px;"></section>
     <div id="nombreProducto" style="margin-left:328px">Lista de Historial de Pagos</div>
  
    
    <div class="sub_head_right">
    <img src="img/cabecera.png" alt="..." " height="60"  >
        
            <div class="body_head" style="margin-left:328px;width:980px" >
                  <b>Historial de Pago</b>
                </div>

         <section style="padding: 20px;"></section>
     <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
    <section style="padding: 20px;"></section>
     <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
             <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>

    <%--<h5 style="position:center; text-align:center">Afiliaciones Disponibles</h5>--%>

     

    <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>

    <asp:Label ID="txtCodPatrocinador" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtcodSocio" runat="server" Text="" Visible="false"></asp:Label>
    <asp:GridView ID="gv_Tabla_Historial_Pago" runat="server" EmptyDataText="Usted no tiene ningun pago registrado" OnPageIndexChanging="gv_Tabla_Historial_Pago_PageIndexChanging" OnRowCommand="gv_Tabla_Historial_Pago_RowCommand" OnRowDataBound="gv_Tabla_Historial_Pago_RowDataBound" CssClass="table table-bordered table-hover" Width="45%" AutoGenerateColumns="False" GridLines="None">
        
        <columns>
            <asp:BoundField DataField="PK_IPago_Cod" HeaderText="N°" />
            <asp:BoundField DataField="DPago_Fecha" HeaderText="Fecha Pago" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="FPago_Monto" HeaderText="Monto" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            
            <asp:BoundField DataField="VEcu_Estado_Cuota" HeaderText="Estado" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            

        </columns>

            <headerstyle backcolor="#6fdefc" forecolor="Black" font-bold="true" />
        </asp:GridView>

     
    
 
        
</asp:Content>


