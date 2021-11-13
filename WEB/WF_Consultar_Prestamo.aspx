<%@ Page Title="" Language="C#" MasterPageFile="~/GerenteGeneral.master" AutoEventWireup="true" CodeFile="WF_Consultar_Prestamo.aspx.cs" Inherits="WF_Consultar_Prestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="scripts/jquery.quicksearch.js" type="text/javascript"></script>
          
    <style type="text/css">
        body {
            background-color: #E6E6E7;
        }

        .field {
            display: flex;
            position: relative;
            margin-left: 1100px;
            width: 25%;
            flex-direction: row;
            box-shadow: 1px 1px 0 rgb(22, 160, 133), 2px 2px 0 rgb(22, 160, 133), 3px 3px 0 rgb(22, 160, 133), 4px 4px 0 rgb(22, 160, 133), 5px 5px 0 rgb(22, 160, 133), 6px 6px 0 rgb(22, 160, 133), 7px 7px 0 rgb(22, 160, 133);
        }

            .field > input[type=text],
            .field > button {
                display: block;
                font: 1.1em 'Montserrat Alternates';
            }

            .field > input[type=text] {
                flex: 1;
                padding: 0.3em;
                border: 0.3em solid rgb(26, 188, 156);
            }

            .field > button {
                padding: 0.6em 0.7em;
                background-color: rgb(26, 188, 156);
                color: white;
                border: none;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <section style="padding: 50px;"></section>
    <h3 style="text-align: center; color: black"><b>CONSULTAR PRESTAMO</b></h3>
    <asp:Label ID="txtCorreo" runat="server" Text="" Visible="false"></asp:Label>

    <%--registro de socio--%>
    <asp:Label ID="txtdni" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtdnisocio" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtnombrecompleto" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtApaterno" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtAmaterno" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfechaNacimiento" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfechaRegistro" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtFKsol" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfksocio" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtcodSoliAceptada" runat="server" Text="" Visible="false"></asp:Label>

    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=gv_Tabla_Consuktar_Prestamo.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>


  <div class="field" id="searchform">
        <asp:TextBox placeholder="Ingresar elemento a buscar" ID="txtFillter" runat="server" AutoPostBack="true" onkeyup="Search_Gridview(this)" OnTextChanged="txtFillter_TextChanged" />
        <button type="button" id="search">Buscar</button>
    </div>

    <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>

    <section style="padding: 20px;"></section>
     
         <div style="margin-left:50px">
    <asp:GridView ID="gv_Tabla_Consuktar_Prestamo" runat="server" OnRowCommand="gv_Tabla_Consuktar_Prestamo_RowCommand" OnPageIndexChanging="gv_Tabla_Consuktar_Prestamo_PageIndexChanging" EmptyDataText="No hay Solicitudes aceptadas" CssClass="table-responsive-sm table-hover" Width="95%" AutoGenerateColumns="False" GridLines="None" OnDataBound="gv_Tabla_Consuktar_Prestamo_DataBound" OnRowDataBound="gv_Tabla_Consuktar_Prestamo_RowDataBound">
        <Columns>
            <asp:BoundField DataField="PK_IPre_Cod" HeaderText="N° Prestamo" />
            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VTP_Nombre" HeaderText="Tipo Prestamo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
         <asp:BoundField DataField="Importe" HeaderText="Importe" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="NumeroCuotas" HeaderText="Numero Cuotas" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
          
            <asp:BoundField DataField="FPre_Tasa_Mensual" HeaderText="Tasa Mensual" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FPre_Tcea" HeaderText="TCEA" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="EstadoDePrestamo" HeaderText="Estado Prestamo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

        </Columns>

      <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
    </asp:GridView>
</div>
</asp:Content>

