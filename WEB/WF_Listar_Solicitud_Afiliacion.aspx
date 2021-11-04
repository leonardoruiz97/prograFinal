<%@ Page Title="" Language="C#" MasterPageFile="~/GerenteGeneral.master" AutoEventWireup="true" CodeFile="WF_Listar_Solicitud_Afiliacion.aspx.cs" Inherits="WF_Listar_Solicitud_Afiliacion" %>

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
  <script src="scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="scripts/jquery.quicksearch.js" type="text/javascript"></script>


    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <section style="padding: 50px;"></section>
       <h3 style="text-align: center; color:black"><b>LISTA DE SOLICITUDES PENDIENTES</b></h3>


    <script class="cssdeck" src="//cdnjs.cloudflare.com/ajax/libs/jquery/1.8.0/jquery.min.js"></script>
    <section style="padding: 20px;"></section>
    <asp:Label ID="txtCodSolicitud" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtcodSoliGrid" runat="server" Text="" Visible="false"></asp:Label>
       <asp:Label ID="txtCorreo" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="txtdni" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="txtdnisocio" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtnombrecompleto" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtApaterno" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtAmaterno" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfechaNacimiento" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfechaRegistro" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="txtdireccion" runat="server" Text="" Visible="false"></asp:Label>  
    <asp:Label ID="txtcelular" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="txttelefono" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtFKsol" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfksocio" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="txtfkocu" runat="server" Text="" Visible="false"></asp:Label>
      <asp:Label ID="txtfkec" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtfkdistri" runat="server" Text="" Visible="false"></asp:Label>

    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=gv_Tabla_Lista_Solicitud.ClientID %>");
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
        <asp:TextBox Text="Ingresar elemento a buscar" ID="txtFillter" runat="server" AutoPostBack="true" onkeyup="Search_Gridview(this)" OnTextChanged="txtFillter_TextChanged" />
        <button type="button" id="search">Buscar</button>
    </div>
    <div style="margin-left:50px">

        <asp:GridView ID="gv_Tabla_Lista_Solicitud" runat="server" OnRowCommand="gv_Tabla_Lista_Solicitud_RowCommand" OnPageIndexChanging="gv_Tabla_Lista_Solicitud_PageIndexChanging" EmptyDataText="No hay Solicitudes pendientes" CssClass="table-responsive-sm table-hover" Width="95%" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv_Tabla_Lista_Solicitud_RowDataBound">
            <columns>
            <asp:BoundField DataField="PK_ISol_Cod" HeaderText="N°" />
            <asp:BoundField DataField="ISol_Dni" HeaderText="Dni" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VSol_Nombre_Completo" HeaderText="Nombre Completo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
                    <asp:BoundField DataField="VSol_Apellido_Paterno" HeaderText="Apellido Paterno" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VSol_Apellido_Materno" HeaderText="Apellido Materno" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
          
  
            <asp:BoundField DataField="DSol_Fecha_Nacimiento" HeaderText="Fecha Nacimiento" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="DSol_Fecha_Registro" HeaderText="Fecha Registro" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VSol_Direccion" HeaderText="Direccion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VSol_Correo" HeaderText="Correo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

                   <asp:BoundField DataField="ISol_Celular" HeaderText="Celular" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

                  <asp:BoundField DataField="ISol_Telefono_Fijo" HeaderText="Telefono" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="VEsol_Estado_Solicitud" HeaderText="Estado" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>
                <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
                 <asp:TemplateField HeaderText="Ver" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnver" CssClass="btn btn-info" runat="server" CommandName="Ver" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Ver" Style="color: white"> <span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span>
                                                    
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aprobar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnAprobar" CssClass="btn btn-success" runat="server" CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Aprobar" Style="color: white"> <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                                    
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Denegar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDenegar" CssClass="btn btn-danger" runat="server" CommandName="Denegar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Denegar" Style="color: white"> <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                    
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </columns>

              <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
        </asp:GridView>






    </div>


        <!-- Alertas -->
        <script src="js/sweetalert.js"></script>
        <script>
            function temporizador() {

                const Toast = Swal.mixin({
                    toast: true,
                    showConfirmButton: false,
                    timer: 3000,
                    timerProgressBar: true,
                    onOpen: (toast) => {
                        toast.addEventListener('mouseenter', Swal.stopTimer)
                        toast.addEventListener('mouseleave', Swal.resumeTimer)
                    }
                })
                Toast.fire({
                    icon: 'success',
                    title: '¡Mensaje enviado con exito! Revise su bandeja de entrada'
                })
            }
            function error() {
                Swal.fire({
                    icon: 'error',
                    title: 'Uups...',
                    text: 'Correo no existente!'
                })
            }
            function correcto() {
                Swal.fire({
                    icon: 'success',
                    title: 'Correo enviado!',
                    text: 'Revise su bandeja de entrada'
                })
            }

            function alertSolicitudDenegado() {
                Swal.fire({
                    title: 'Estas seguro?',
                    text: "Usted denegara una solicitud!",
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
                            'La solicitud se ha denegado.',
                            'success'
                        )
                    }
                })
            }

        </script>




</asp:Content>

