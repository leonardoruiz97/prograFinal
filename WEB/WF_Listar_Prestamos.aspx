﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GerenteGeneral.master" AutoEventWireup="true" CodeFile="WF_Listar_Prestamos.aspx.cs" Inherits="WF_Listar_Prestamos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <script src="scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="scripts/jquery.quicksearch.js" type="text/javascript"></script>






</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <section style="padding: 50px;"></section>
    <h3 style="text-align: center; color: black"><b>LISTA DE PRESTAMOS PENDIENTE</b></h3>

  <script type="text/javascript">
      function Search_Gridview(strKey) {
          var strData = strKey.value.toLowerCase().split(" ");
          var tblData = document.getElementById("<%=gv_Tabla_Lista_Prestamo.ClientID %>");
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
    <asp:Label ID="txtcodPrestamoGrid" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtestadoGrid" runat="server" Text="" Visible="false"></asp:Label>
    <div style="margin-left: 50px">

        <asp:GridView ID="gv_Tabla_Lista_Prestamo" runat="server" OnRowCommand="gv_Tabla_Lista_Prestamo_RowCommand" OnPageIndexChanging="gv_Tabla_Lista_Prestamo_PageIndexChanging" EmptyDataText="No hay Prestamos pendientes" CssClass="table-responsive-sm table-hover" Width="95%" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv_Tabla_Lista_Prestamo_RowDataBound">
            <Columns>
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
                <asp:BoundField DataField="FPre_Tcea" HeaderText="TCEA" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0}%">
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
                <asp:BoundField DataField="NombreCompleto" HeaderText="Socio" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
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

                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Aprobar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnAprobar" CssClass="btn btn-success" runat="server" CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Aprobar" Style="color: white"> <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                                    
                        </asp:LinkButton>
                    </ItemTemplate>

                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Rechazar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnRechazar" CssClass="btn btn-danger" runat="server" CommandName="Denegar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Denegar" Style="color: white"> <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                    
                        </asp:LinkButton>
                    </ItemTemplate>

                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="text-center"></ItemStyle>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />

        </asp:GridView>


    </div>


    <!-- Alertas -->
    <script src="js/sweetalert.js"></script>
    <script>


        function alertPrestamoDenegado() {
            Swal.fire({
                title: 'Estas seguro?',
                text: "Usted denegara un prestamo!",
                icon: 'warning',
                showCancelButton: true,
                closeOnConfirm: false,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, Denegar',

            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire(
                        'Denegado!',
                        'El prestamo se ha denegado.',
                        'success'
                    )
                }
            })
        }

    </script>


</asp:Content>

