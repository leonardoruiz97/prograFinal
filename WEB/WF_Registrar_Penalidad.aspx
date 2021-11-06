<%@ Page Title="" Language="C#" MasterPageFile="~/Cajera.master" AutoEventWireup="true" CodeFile="WF_Registrar_Penalidad.aspx.cs" Inherits="WF_Registrar_Penalidad" %>

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
    <!--main content start-->
        <h3 style="text-align: center; color: black"><b>REGISTRAR PENALIDAD</b></h3>
    <!-- /row -->
    <!-- FORM VALIDATION -->
    <div class="row mt" style="margin-left:100px">
         <div class="col-lg-11">
            <h4><i class="fa fa-angle-right"></i>DATOS DEL PRESTAMO</h4>
            <div class="form-panel">
                <div class=" form">
                    <form1 class="cmxform form-horizontal style-form" id="commentForm" method="get" action="">
                        <section style="padding-top: 25px"></section>



                        <div class="col-sm-3 col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="N° PRESTAMO"></asp:Label>
                                <asp:TextBox ID="txtDni" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>



                        </div>

                        <div class="col-sm-9 col-md-6">
                            <div class="form-group">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="N° CUOTA"></asp:Label>
                                    <asp:TextBox ID="txtNombreCompleto" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>

                            </div>
                        </div>


                        <section style="padding-top: 75px"></section>
                    </form1>
                </div>
            </div>
            <!-- /form-panel -->
        </div>
        <!-- /col-lg-12 -->
    </div>

    <div class="row mt" style="margin-left:100px">
      <div class="col-lg-11">
            <h4><i class="fa fa-angle-right"></i>DATOS SOCIO</h4>
            <div class="form-panel">
                <div class=" form">
                    <form1 class="cmxform form-horizontal style-form" id="commentForm2" method="get" action="">
                        <section style="padding-top: 25px"></section>



                        <div class="col-sm-3 col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="DNI"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label5" runat="server" Text="APELLIDOS"></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>


                        </div>

                        <div class="col-sm-9 col-md-6">
                            <div class="form-group">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="NOMBRES COMPLETOS"></asp:Label>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label6" runat="server" Text="PATROCINADOR"></asp:Label>
                                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <section style="padding-top: 160px"></section>
                    </form1>
                </div>
            </div>
            <!-- /form-panel -->
        </div>
        <!-- /col-lg-12 -->
    </div>

    <div class="row mt" style="margin-left:100px">
        <div class="col-lg-11">
            <h4><i class="fa fa-angle-right"></i>DATOS CUOTAS</h4>
            <div class="form-panel">
                <div class=" form">
                    <form1 class="cmxform form-horizontal style-form" id="commentForm2" method="get" action="">
                        <section style="padding-top: 25px"></section>



                        <div class="col-sm-3 col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label7" runat="server" Text="FECHA FIN CUOTA"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label8" runat="server" Text="DÍAS RETRASO"></asp:Label>
                                <asp:TextBox ID="TextBox6" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>


                        </div>

                        <div class="col-sm-9 col-md-6">
                            <div class="form-group">
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" Text="ESTADO CUOTA"></asp:Label>
                                    <asp:TextBox ID="TextBox7" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="IMPORTE"></asp:Label>
                                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <section style="padding-top: 160px"></section>
                    </form1>
                </div>
            </div>
            <!-- /form-panel -->
        </div>
        <!-- /col-lg-12 -->
    </div>

           <div class="row mt" style="margin-left:100px">
        <div class="col-lg-11">
            <h4><i class="fa fa-angle-right"></i>DATOS PENALIDAD</h4>
            <div class="form-panel">
                <div class=" form">
                    <form1 class="cmxform form-horizontal style-form" id="commentForm2" method="get" action="">
                        <section style="padding-top: 25px"></section>



                        <div class="col-sm-3 col-md-6">
                            <div class="form-group">
                                <asp:Label ID="Label11" runat="server" Text="FECHA FIN CUOTA"></asp:Label>
                                <asp:TextBox ID="TextBox9" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label12" runat="server" Text="DÍAS RETRASO"></asp:Label>
                                <asp:TextBox ID="TextBox10" runat="server" class="form-control" Width="80%"></asp:TextBox>
                            </div>


                        </div>

                        <div class="col-sm-9 col-md-6">
                            <div class="form-group">
                                <div class="form-group">
                                    <asp:Label ID="Label13" runat="server" Text="ESTADO CUOTA"></asp:Label>
                                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label14" runat="server" Text="IMPORTE"></asp:Label>
                                    <asp:TextBox ID="TextBox12" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </div>

                            </div>
                        </div>

                        <section style="padding-top: 160px"></section>
                    </form1>
                </div>
            </div>
            <!-- /form-panel -->
        </div>
        <!-- /col-lg-12 -->
    </div>

</asp:Content>

