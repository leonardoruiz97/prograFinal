<%@ Page Title="" Language="C#" MasterPageFile="~/Cajera.master" AutoEventWireup="true" CodeFile="WF_Historial_Patrocinador.aspx.cs" Inherits="WF_Historial_Patrocinador" %>

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
     <style>
        fieldset {
            background-color: #D5D8DC;
            border-radius: 4px;
             padding-bottom:50px;
        }

        legend {
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 4px;
            color: var(--purple);
            font-size: 17px;
            font-weight: bold;
            padding: 3px 5px 3px 7px;
            width: auto;
           
        }

        }
    </style>

    <fieldset>
        <h3 style="text-align: center; color: black"><b>HISTORIAL DEL PATROCINADOR</b></h3>
                  
        <section style="padding: 10px;"></section>
        <div class="row register-form" style="margin-left: 190px">
            <asp:Label ID="txtdniPatro" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="txtCodPatroGrid" runat="server" Text="" Visible="false"></asp:Label>
            <div class="col-sm-3 col-md-5">
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Dni"></asp:Label>
                    <asp:TextBox ID="txtDni" runat="server" class="form-control" Width="100%"></asp:TextBox>
                </div>
                   <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Apellido Paterno"></asp:Label>
                    <asp:TextBox ID="txtapellidopaterno" runat="server" class="form-control" Width="100%"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label10" runat="server" Text="Vigencia"></asp:Label>
                    <asp:TextBox ID="txtVigencia" runat="server" class="form-control" Width="100%"></asp:TextBox>
                </div>

            </div>

            <div class="col-sm-3 col-md-5">
                <div class="form-group">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Nombre Completo"></asp:Label>
                        <asp:TextBox ID="txtNombreCompleto" runat="server" class="form-control" Width="100%"></asp:TextBox>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Apellido Materno"></asp:Label>
                        <asp:TextBox ID="txtapellidomaterno" runat="server" class="form-control" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="N° Afiliaciones"></asp:Label>
                        <asp:TextBox ID="txtafiliaciones" runat="server" class="form-control" Width="100%"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

    </fieldset>




    <fieldset class="border" style="width: 100%">
        <legend>Historial de Afiliaciones</legend>

                     <asp:GridView ID="gv_Tabla_Lista_Afiliaciones" runat="server" EmptyDataText="El socio no ha patrocinado aun a ninguna persona" CssClass="table-responsive-sm table-hover" Width="70%" AutoGenerateColumns="False" GridLines="None" style="text-align:center; margin-left:auto;margin-right:auto">
        
             <columns>
    
            <asp:BoundField DataField="PK_IA_Cod" HeaderText="N°" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                 <HeaderStyle CssClass="text-center"></HeaderStyle>
                    <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
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
      

             <HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
        </asp:GridView>


    </fieldset>




</asp:Content>

