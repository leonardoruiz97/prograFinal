<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Cajera.master" AutoEventWireup="true" CodeFile="WF_Registrar_Penalidad.aspx.cs" Inherits="WF_Registrar_Penalidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    

    <asp:GridView ID="gv_Tabla_Lista_Registrar_Penalidad" runat="server">

        <Columns>
            <asp:BoundField DataField="PK_IPre_Cod" HeaderText="N° Prestamo"/>
            <asp:BoundField DataField="VS_Nombre_Completo" HeaderText="Datos Completos" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

            <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>


            <asp:BoundField DataField="VS_Nombre_Completo" HeaderText="Fecha Fin" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

            <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

             <asp:BoundField DataField="VS_Nombre_Completo" HeaderText="Numero Cuota" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

            <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>


             <asp:BoundField DataField="VS_Nombre_Completo" HeaderText="Importe" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

            <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

             <asp:BoundField DataField="VS_Nombre_Completo" HeaderText="Dias de Retraso" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

            <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="VS_Nombre_Completo" HeaderText="Estado del Prestamo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                <HeaderStyle CssClass="text-center"></HeaderStyle>

            <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>


            <asp:TemplateField HeaderText="Credenciales">
            <ItemTemplate>

                <asp:LinkButton runat="server">

                </asp:LinkButton>


            </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>
</asp:Content>

