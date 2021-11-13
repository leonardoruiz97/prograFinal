﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Cajera.master" AutoEventWireup="true" CodeFile="WF_Listar_Movimientos.aspx.cs" Inherits="WF_Listar_Movimientos" %>

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
    <h3 style="text-align: center; color: black"><b>HISTORIAL DE MOVIMIENTOS</b></h3>

    <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>

    <section style="padding: 20px;"></section>
    <div style="margin-left: 200px">

        <table width="900" border="0" cellpadding="0" cellspacing="0" class="table">
            <tbody>
                <tr>
                    <td class="td_left celda_arriba">N° Movimienttos:</td>
                    <td class="td_right_col2 celda_arriba">

                        <asp:TextBox ID="txtcantidad" runat="server" class="form-control" Width="25%" Height="50%" CssClass="auto-style1" Enabled="false"></asp:TextBox>
            </tbody>
        </table>

        <asp:GridView ID="gv_Tabla_Lista_Movimientos" runat="server" OnRowCommand="gv_Tabla_Lista_Movimientos_RowCommand" OnPageIndexChanging="gv_Tabla_Lista_Movimientos_PageIndexChanging" EmptyDataText="Aun no hay ningun movimiento" CssClass="table-responsive-sm table-hover" Width="95%"  AutoGenerateColumns="False" GridLines="None">
            <Columns>
                <asp:BoundField DataField="PK_Numero_Transaccion" HeaderText="Nrº Transacción" />
                <asp:BoundField DataField="PK_TM_Cod" HeaderText="Codigo Operacion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
               </asp:BoundField>
                <asp:BoundField DataField="VTM_Nombre_Tipo_Movimiento" HeaderText="Tipo Ahorro" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="DMove_Fecha_Registro" HeaderText="Fecha Transacción" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                    <asp:BoundField DataField="FMove_Importe" HeaderText="Monto" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>
                    <asp:BoundField DataField="DatosSocio" HeaderText="Socio" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="VRo_Nombre_Rol" HeaderText="Usuario" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:BoundField>


            </Columns>

             <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
        </asp:GridView>
    
                </div>


    
    <!-- Alertas -->
    <script src="js/sweetalert.js"></script>


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

