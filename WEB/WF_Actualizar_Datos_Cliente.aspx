<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Socio.master" AutoEventWireup="true" CodeFile="WF_Actualizar_Datos_Cliente.aspx.cs" Inherits="WF_Actualizar_Datos_Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="css/StyleSheet.css" rel="stylesheet" />
    <link href="css/nuevoestilo.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.1/jquery-ui.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <section style="padding: 20px;"></section>

    
    <h1 style="text-align:center;color:#73879C">ACTUALIZAR DATOS PERSONALES</h1>
  
     <asp:Label ID="txtCodSoliGrid" runat="server" Text="" Visible="false"></asp:Label>
     <asp:Label ID="txtdatPatro" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtpkafi" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="txtcodafi" runat="server" Text="" Visible="false"></asp:Label>

    <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

      <section class="auto-style1">

            <div class="container register">


                <div class="col-md-12 register-right">

                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                            
                           
                          
                                <div class="row register-form">
                                    <div class="col-sm-3 col-md-8" style="margin-left:-220px;margin-top:-90px">
                                        <asp:TextBox ID="txtsolicitud" runat="server" class="form-control" Width="95%" Visible ="false"></asp:TextBox>
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Representante"></asp:Label>
                                            <asp:TextBox ID="txtrepresentante" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Dni"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtdni" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Nombre Completo "></asp:Label>
                                            <asp:TextBox ID="txtnombre" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label9" runat="server" Text="Dirección"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtdirreccion" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="lbl" runat="server" Text="Celular"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtcelular" minlength="9" MaxLength="9" onkeypress="javascript:return SoloNumeros(event)" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>

                                            <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Departamento Residencia"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtdepartamento" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label12" runat="server" Text="Estado Civil"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtestadocivil" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>
                                         
                                     <div class="form-group">
                                            <asp:Label ID="Label10" runat="server" Text="Provincia" Visible ="false"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtprovincia" runat="server" class="form-control" Width="95%" Visible ="false"></asp:TextBox>
                                        </div>

                                         <div class="form-group">
                                            <asp:Label ID="Label13" runat="server" Text="Estado"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtestado" runat="server" class="form-control" Width="95%"></asp:TextBox>
                                        </div>
                                    </div>





                                   
                                    <div class="col-sm-9 col-md-6" style="margin-top:-95px" >
                                          

                                        <div class="form-group">
                                            <asp:Label ID="Label15" runat="server" Text="Fecha de Registro"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtregistro" runat="server" class="form-control" Width="130%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label8" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtfecha" runat="server" TextMode="Email" class="form-control" Width="130%"></asp:TextBox>
                                            <span id="emailOK"></span>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label7" runat="server" Text="Apellidos"></asp:Label>
                                            <asp:TextBox ID="txtapellido" runat="server" class="form-control" Width="130%"></asp:TextBox>
                                        </div>

                                         <div class="form-group">
                                            <asp:Label ID="Label14" runat="server" Text="Email"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtemail" runat="server" class="form-control" Width="130%"></asp:TextBox>
                                        </div>

                                         <div class="form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Telefono Fijo"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txttelefono" runat="server" class="form-control" Width="130%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label6" runat="server" Text="Distrito"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtdistrito" runat="server" class="form-control" Width="130%"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <asp:Label ID="Label11" runat="server" Text="Ocupacion"></asp:Label>
                                            <section style="padding: 0px;"></section>
                                            <asp:TextBox ID="txtocupacion" runat="server" class="form-control" Width="130%"></asp:TextBox>
                                        </div>
                                          
                                       
                                        

                                    </div>


                                    <div class="row align-items-start" style="margin-left:100px">
                                        <div class="col">
                                            <section style="padding: 10px;"></section>

                                            <asp:LinkButton ID="btnEnviarCotizacion" CssClass="btn btn-primary" Width="300px" runat="server" Text="Enviar" OnClick="btnEnviarCotizacion_Click"> <span class="glyphicon glyphicon-repeat" aria-hidden="true" style="color:white"></span>
                                                        <p5 style="color:white">Actualizar Datos</p5>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnatras" CssClass="btn btn-success" runat="server" Width="300px" Text="Atras" OnClick="btnatras_Click"> <span class="glyphicon glyphicon-backward" style="color:white" aria-hidden="true"></span>
                                                        <p5 style="color:white">Regresar</p5>
                                            </asp:LinkButton>

                                        </div>
                                    </div>


                                </div>
              


                       
                        </div>
                    </div>
                </div>
            </div>
            <script src="js/sweetalert.js"></script>
            <script>
                function alertaagregar() {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'Actualizado',
                        text: 'Se Actualizo Los datos Personales',
                        showConfirmButton: false,
                        timer: 2000
                    })
                }
                function celularVacio() {
                    Swal.fire({
                        position: 'center',
                        icon: 'error',
                        title: 'Incorrecto el formato del Numero',
                        showConfirmButton: false,
                        timer: 2000
                    })
                }
                function contraseñaVacio() {
                    Swal.fire({
                        position: 'center',
                        icon: 'error',
                        title: 'Ingrese su Contraseña',
                        showConfirmButton: false,
                        timer: 2000
                    })
                }
            </script>


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

    </section>

</asp:Content>

