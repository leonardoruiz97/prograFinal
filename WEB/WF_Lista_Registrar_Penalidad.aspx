﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cajera.master" AutoEventWireup="true" CodeFile="WF_Lista_Registrar_Penalidad.aspx.cs" Inherits="WF_Lista_Registrar_Penalidad" %>

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
    <script src="scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="scripts/jquery.quicksearch.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <section style="padding: 50px;"></section>
    <h3 style="text-align: center; color: black"><b>LISTA DE CUOTAS MOROSAS</b></h3>

    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=gv_Tabla_Lista_Registrar_Penalidad.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >=0)
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
    <section style="margin-top:30px"></section>
    <div style="margin-left: 50px">

        <asp:GridView ID="gv_Tabla_Lista_Registrar_Penalidad" runat="server" OnRowCommand="gv_Tabla_Lista_Registrar_Penalidad_RowCommand" OnPageIndexChanging="gv_Tabla_Lista_Registrar_Penalidad_PageIndexChanging" EmptyDataText="No hay listado de penalidad" CssClass="table-responsive-sm table-hover" Width="95%" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv_Tabla_Lista_Registrar_Penalidad_RowDataBound">
            <Columns>
                <asp:BoundField DataField="PK_IPre_Cod" HeaderText="N° Prestamo" />
                <asp:BoundField DataField="DatosCompletos" HeaderText="Datos Completos" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                  <asp:BoundField DataField="IS_Dni" HeaderText="DNI" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="DC_FechaFin" HeaderText="Fecha Fin" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="IC_NumeroCuota" HeaderText="Numero Cuota" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="FC_MontoCuota" HeaderText="Importe" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>


                <asp:BoundField DataField="DiasRetraso" HeaderText="Dias Retraso" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="VEcu_Estado_Cuota" HeaderText="Estado Cuota" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>



                <asp:TemplateField HeaderText="Registrar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnRegistrarPenalidad" CssClass="btn btn-success" runat="server" CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Aprobar" Style="color: white"> <span  aria-hidden="true">Registrar Penalidad</span>
                                                    
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
        </asp:GridView>




    </div>

</asp:Content>

