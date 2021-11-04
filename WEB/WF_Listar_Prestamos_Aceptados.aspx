﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GerenteGeneral.master" AutoEventWireup="true" CodeFile="WF_Listar_Prestamos_Aceptados.aspx.cs" Inherits="WF_Listar_Prestamos_Aceptados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
       <h3 style="text-align: center; color:black"><b>LISTA DE PRESTAMOS ACEPTADOSS</b></h3>




   <%-- <div class="field" id="searchform">
        <input type="text" id="searchterm" placeholder="Ingresar elemento a buscar" />
        <button type="button" id="search">Buscar</button>
    </div>--%>

    <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>

       <section style="padding: 20px;"></section>
    <asp:Label ID="txtcodPrestamoGrid" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="txtestadoGrid" runat="server" Text="" Visible="false"></asp:Label>
       <div style="margin-left:50px">

        <asp:GridView ID="gv_Tabla_Lista_Prestamo_Aceptados" runat="server" OnRowCommand="gv_Tabla_Lista_Prestamo_Aceptados_RowCommand" OnPageIndexChanging="gv_Tabla_Lista_Prestamo_Aceptados_PageIndexChanging" EmptyDataText="No hay Prestamos aceptados" CssClass="table-responsive-sm table-hover" Width="95%" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv_Tabla_Lista_Prestamo_Aceptados_RowDataBound">
            <columns>
            <asp:BoundField DataField="PK_IPre_Cod" HeaderText="N°" />
            <asp:BoundField DataField="DPre_Fecha_Registro" HeaderText="Fecha Registro" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="VTP_Nombre" HeaderText="Tipo Prestamo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FPre_Importe" HeaderText="Importe" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="IPre_Cuotas" HeaderText="Nº Cuotas" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FPre_Tasa_Mensual" HeaderText="Tasa Mensual" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="FPre_Tcea" HeaderText="TCEA" ItemStyle-CssClass="text-center" DataFormatString="{0}%" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VPre_PrestamoVigente" HeaderText="Prestamo Vigente" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VPre_DeudaVigente" HeaderText="Deuda Vigente" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>    
           <asp:BoundField DataField="NombreCompleto" HeaderText="Codigo Socio" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>
                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VEPre_Estado_Prestamo" HeaderText="Estado" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>
                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
                 <asp:TemplateField HeaderText="Ver" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnver" CssClass="btn btn-info" runat="server" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Ver" Style="color: white"> <span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span>
                                                    
                    </asp:LinkButton>

                    <asp:LinkButton ID="btnverImagenes" CssClass="btn btn-warning" runat="server" CommandName="VerImagenes" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Ver" Style="color: white"> <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                                                    
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
          
           
         

        </columns>

             <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
        </asp:GridView>

        </div>

      <!-- Alertas -->
        <script src="js/sweetalert.js"></script>
       


    

</asp:Content>

