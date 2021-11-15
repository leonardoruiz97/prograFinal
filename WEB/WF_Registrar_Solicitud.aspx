<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Registrar_Solicitud.aspx.cs" Inherits="WF_Registrar_Solicitud" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>San Cosme</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="keywords" />
    <meta content="" name="description" />

    <!-- Favicons -->


    <link href="img/SanCosme.png" rel="shortcut icon" />


    <!-- Bootstrap CSS File -->
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <!-- Nivo Slider Theme -->
    <link href="css/nivo-slider-theme.css" rel="stylesheet" />

    <!-- Main Stylesheet File -->
    <link href="css/style.css" rel="stylesheet" />

    <!-- Responsive Stylesheet File -->
    <link href="css/responsive.css" rel="stylesheet" />

</head>


<!--Pequeño script para el movimiento del title-->
<script type="text/javascript">
    var txt = "San Cosme - Coorperativa de ahorro y crédito  -  ";
    var espera = 100;
    var refresco = null;
    function rotulo_title() {
        document.title = txt;
        txt = txt.substring(1, txt.length) + txt.charAt(0);
        refresco = setTimeout("rotulo_title()", espera);
    }

    rotulo_title();


    function SoloNumeros(e) {
        var key_press = document.all ? key_press = e.keyCode : key_press = e.which;
        return ((key_press > 47 && key_press < 58) || key_press == 46);
    }

    function SoloLetrasYEsp() {

        if ((event.keyCode >= 65) && (event.keyCode <= 90) || (event.keyCode >= 97) && (event.keyCode <= 122) || event.keyCode == 32 || event.keyCode >= 192 && event.keyCode <= 255) {
            event.returnValue = true;
        }
        else {
            event.returnValue = false;
        }
    }

</script>





<body data-spy="scroll" data-target="#navbar-example">

    <form id="form1" runat="server">

        <section style="margin-top: 50px; margin-left: 250px">
            <img src="img/SanCosme.png" alt="Alternate Text" />
        </section>
        <h1 class="hdrText1" style="text-align: center; margin-top: -95PX">FORMULARIO REGISTRAR SOLICITUD</h1>

        <style>
            .hdrText1 {
                color: #73879C;
                font-weight: bold;
            }

            fieldset {
                background-color: #eeeeee;
                border-radius: 4px;
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

            .tab-content {
                width: 95%;
                height: 50%;
                background: #215a65;
                margin-left: 50px;
            }
        </style>


        <section style="padding: 40px"></section>
        <asp:Label ID="lblpkpatrobus" runat="server" Text="Codigo" Visible="false"></asp:Label>
              <asp:Label ID="lbldniPatrobus" runat="server" Text="Codigo" Visible="false"></asp:Label>
              <asp:Label ID="lblcantafiliabus" runat="server" Text="Codigo" Visible="false"></asp:Label>
        <div class="tab-content" id="myTabContent">
            <section style="padding: 40px"></section>
            <fieldset class="border" style="width: 90%; margin-left: 90px">
                <legend class="hdrText">Datos del Patrocinador</legend>

                <div class="col-sm-3 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="txtafiliacion" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="Codigo"></asp:Label>
                        <asp:TextBox ID="txtCodPatrocinador" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                </div>

                <div class="col-sm-9 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Socio"></asp:Label>
                        <asp:TextBox ID="txtDatPatrocinador" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                </div>
            </fieldset>

            <section style="padding: 10px;"></section>



            <fieldset class="border" style="width: 90%; margin-left: 90px">
                <legend class="hdrText">Datos</legend>
                <div class="col-sm-3 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Documento de Identidad"></asp:Label>
                        <asp:TextBox ID="txtDni" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Apellido Paterno"></asp:Label>
                        <asp:TextBox ID="txtApaterno" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                    <div class="form-group">

                        <asp:Label ID="Label12" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                        <asp:TextBox ID="txtfechaNacimiento" runat="server" class="form-control" TextMode="Date" Width="85%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label16" runat="server" Text="Fecha Registro"></asp:Label>
                        <asp:TextBox ID="txtFechaRegistro" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblNacimiento" runat="server" Text="Lugar de Nacimiento"></asp:Label>
                        <asp:DropDownList ID="ddlLugarNacimiento" runat="server" CssClass="form-control" Width="85%" OnSelectedIndexChanged="ddlLugarNacimiento_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="">Seleccione una opción </asp:ListItem>


                        </asp:DropDownList>
                    </div>




                </div>
                <div class="col-sm-9 col-md-6">

                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Nombre Completo"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Apellido Materno"></asp:Label>
                        <asp:TextBox ID="txtAmaterno" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Estado Civil"></asp:Label>
                        <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control" Width="85%">
                            <asp:ListItem Value="">Seleccione una opción </asp:ListItem>


                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label21" runat="server" Text="Sexo"></asp:Label>
                        <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control" Width="85%" OnSelectedIndexChanged="ddlSexo_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="">Seleccione una opción </asp:ListItem>


                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="Label22" runat="server" Text="Provincia"></asp:Label>
                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-control" Width="85%" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="">Seleccione una opción </asp:ListItem>


                        </asp:DropDownList>
                    </div>




                </div>
            </fieldset>

            <section style="padding: 10px;"></section>

            <fieldset class="border" style="width: 90%; margin-left: 90px">
                <legend class="hdrText">Domicilio</legend>


                <div class="col-sm-3 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label11" runat="server" Text="Direccion"></asp:Label>
                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" Width="200%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Departamento"></asp:Label>
                        <section style="padding: 2px;"></section>
                        <asp:TextBox ID="txtDepartamento" runat="server" Text="Lima" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                </div>


                <div class="col-sm-9 col-md-6">
                    <section style="padding: 35px;"></section>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Distrito"></asp:Label>
                        <asp:DropDownList ID="ddlDistrito" runat="server" CssClass="form-control" Width="85%">
                            <asp:ListItem Value="">Seleccione una opción </asp:ListItem>


                        </asp:DropDownList>
                    </div>

                </div>


            </fieldset>
            <section style="padding: 10px;"></section>

            <fieldset class="border" style="width: 90%; margin-left: 90px">
                <legend class="hdrText">Complementario</legend>

                <div class="col-sm-3 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Correo"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" class="form-control" Width="85%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label14" runat="server" Text="Telefono Fijo"></asp:Label>
                       <asp:TextBox ID="txtTelfijo" onkeypress="javascript:return SoloNumeros(event)" MaxLength="7" MinLength="7" runat="server" class="form-control" Width="85%"></asp:TextBox>
 
                    </div>
                </div>

                <div class="col-sm-9 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label15" runat="server" Text="Celular"></asp:Label>
                          <asp:TextBox ID="txtCelular"  onkeypress="javascript:return SoloNumeros(event)" MaxLength="9" MinLength="9" runat="server" class="form-control" Width="85%"></asp:TextBox>
             
                    </div>
                    <asp:Label ID="Label4" runat="server" Text="Ocupaciòn"></asp:Label>
                    <asp:DropDownList ID="ddlOcupacion" runat="server" CssClass="form-control" Width="85%">
                        <asp:ListItem Value="">Seleccione una opción </asp:ListItem>


                    </asp:DropDownList>
                </div>

            </fieldset>
            <section style="padding: 10px;"></section>

            <fieldset class="border" style="width: 90%; margin-left: 90px">
                <legend class="hdrText">Detalle</legend>

                <div class="col-sm-3 col-md-6">
                    <div class="form-group">
                        <asp:Label ID="Label17" runat="server" Text="Adjunte un Recibo de luz"></asp:Label>
                        <itemtemplate>

                            <asp:FileUpload ID="FileUpReciboLuz" CssClass="form-control glyphicon glyphicon-download-alt" runat="server" Width="100%" Height="6%" />
                        </itemtemplate>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label18" runat="server" Text="Adjunte un Recibo de Agua"></asp:Label>
                        <itemtemplate>
                            <asp:FileUpload ID="FileUpReciboAgua" CssClass="form-control glyphicon glyphicon-download-alt" runat="server" Width="100%" Height="6%" />
                        </itemtemplate>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label19" runat="server" Text="Adjunte un Recibo de Vivienda"></asp:Label>
                        <itemtemplate>
                            <asp:FileUpload ID="FileUpVivienda" CssClass="form-control glyphicon glyphicon-download-alt" runat="server" Width="100%" Height="6%" />
                        </itemtemplate>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label20" runat="server" Text="Adjunte Constancia Patrocinador"></asp:Label>

                        <itemtemplate>
                            <asp:FileUpload ID="FileUpConstancia" CssClass="form-control glyphicon glyphicon-download-alt" runat="server" Width="100%" Height="6%" />
                        </itemtemplate>
                    </div>
                </div>

                <div class="col-sm-9 col-md-6">
                    <%-- <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success" runat="server" Text="Enviar"> <span class="glyphicon glyphicon-download-alt" aria-hidden="true" style="color:white"></span>
                                                        <p5 style="color:white">Cargar</p5>
                            </asp:LinkButton>
                            <section style="padding: 2px;"></section>
                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-success" runat="server" Text="Enviar"> <span class="glyphicon glyphicon-download-alt" aria-hidden="true" style="color:white"></span>
                                                        <p5 style="color:white">Cargar</p5>
                            </asp:LinkButton>
                            <section style="padding: 2px;"></section>
                            <asp:LinkButton ID="LinkButton3" CssClass="btn btn-success" runat="server" Text="Enviar"> <span class="glyphicon glyphicon-download-alt" aria-hidden="true" style="color:white"></span>
                                                        <p5 style="color:white">Cargar</p5>
                            </asp:LinkButton>--%>
                </div>

            </fieldset>




            <section style="padding: 10px; margin-left: 100px">

                <asp:LinkButton ID="btnRegistrarSolicitud" CssClass="btn btn-success" Width="10%" runat="server" OnClick="btnRegistrarSolicitud_Click" Text="Enviar"> <span class="glyphicon glyphicon-pencil" aria-hidden="true" style="color:white"></span>
                                                        <p5 style="color:white">Registrar Solicitud</p5>
                </asp:LinkButton>
                <asp:LinkButton ID="btnatras" CssClass="btn btn-danger" Width="10%" runat="server" Text="Atras" OnClick="btnatras_Click"> <span class="glyphicon glyphicon-remove" style="color:white" aria-hidden="true"></span>
                                                        <p5 style="color:white">Cancelar</p5>
                </asp:LinkButton>
            </section>


        </div>



        <footer>
            <div class="footer-area">
                <div class="container">
                    <div class="row">
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <div class="footer-content">
                                <div class="footer-head">
                                    <div class="footer-logo">
                                        <h2><span>San</span>Cosme</h2>
                                    </div>

                                    <p>Somos una Cooperativa de Ahorro y Crédito que tiene 64 años de vida institucional; lo cual habla mucho de nuestra solidez y confianza retribuida por nuestros asociados; los cuales a través de estos años han ido logrando concretar muchas de sus metas personales y familiares.La solidez de nuestros 64 años nos hace ser considerada la más exitosa y representativa del Distrito de La Victoria.</p>
                                    <div class="footer-icons">
                                        <ul>
                                            <li>
                                                <a href="#"><i class="fab fa-facebook"></i></a>
                                            </li>
                                            <li>
                                                <a href="#"><i class="fab fa-twitter"></i></a>
                                            </li>
                                            <li>
                                                <a href="#"><i class="fab fa-google"></i></a>
                                            </li>
                                            <li>
                                                <a href="#"><i class="fab fa-instagram"></i></a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end single footer -->
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <div class="footer-content">
                                <div class="footer-head">
                                    <h4>información</h4>
                                    <p>
                                        Cooperativa de ahorro y crédito.
               
                                    </p>
                                    <div class="footer-contacts">
                                        <p><span>Teléfono:</span>993 403 034</p>
                                        <p><span>Correo:</span> informes@coopacsancosme.com</p>
                                        <p><span>Horario de Trabajo:</span> 9am-6pm</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end single footer -->
                        <div class="col-md-4 col-sm-4 col-xs-12">
                            <div class="footer-content">
                                <div class="footer-head">
                                    <h4>Blog</h4>
                                    <div class="flicker-img">
                                        <a href="#">
                                            <img src="img/portfolio/7.jpg" alt="" /></a>
                                        <a href="#">
                                            <img src="img/portfolio/8.jpg" alt="" /></a>
                                        <a href="#">
                                            <img src="img/portfolio/9.jpg" alt="" /></a>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer-area-bottom">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="copyright text-center">
                                <p>
                                    &copy; Copyright <strong>SanCosme</strong>. Todos los derechos reservados
             
                                </p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </footer>


        <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>

        <!-- JavaScript Libraries -->
        <script src="lib/jquery/jquery.min.js"></script>
        <script src="lib/bootstrap/js/bootstrap.min.js"></script>
        <script src="lib/owlcarousel/owl.carousel.min.js"></script>
        <script src="lib/venobox/venobox.min.js"></script>
        <script src="lib/knob/jquery.knob.js"></script>
        <script src="lib/wow/wow.min.js"></script>
        <script src="lib/parallax/parallax.js"></script>
        <script src="lib/easing/easing.min.js"></script>
        <script src="lib/nivo-slider/js/jquery.nivo.slider.js" type="text/javascript"></script>
        <script src="lib/appear/jquery.appear.js"></script>
        <script src="lib/isotope/isotope.pkgd.min.js"></script>





        <!-- Contact Form JavaScript File -->
        <script src="contactform/contactform.js"></script>
        <script src="jquery.validationEngine-en.js" type="text/javascript"></script>

        <script src="js/main.js"></script>


        <!-- Alertas -->
        <script src="js/sweetalert.js"></script>
        <script>
            function alertDnivacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese su DNI',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
            function alertDnidigitos() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'El DNI solo puede contener 8 digitos',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
            function alertNombreVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Nombre completo',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertApaVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Apellido Paterno',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
            function alertAmaVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Apeliido Materno',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertEstadoCivilVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Seleccione su Estado Civil',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
            function alertSexolVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Seleccione su Sexo',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertFechaNacVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Fecha de Nacimiento',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
            function alertFechaNacMayor18() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Tiene que ser persona mayor a 18 años',
                    showConfirmButton: false,
                    timer: 2000
                })
            }



            function alertDireccionVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Direccion',
                    showConfirmButton: false,
                    timer: 2000
                })
            }


            function alertDepartamentoVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Seleccione su Lugar de Nacimiento',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertDistritoVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Seleccione su Distrito',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertProvinciaVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Seleccione su Provincia',
                    showConfirmButton: false,
                    timer: 2000
                })
            }


            function alertCorreoVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Correo Electronico',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertCelularVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Numero celular',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertTelefonoVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Ingrese Telefono Fijo',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

            function alertOcupacionVacio() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Seleccione su Ocupacion',
                    showConfirmButton: false,
                    timer: 2000
                })
            }


            function RegistrarSolicitud() {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'Registrado',
                    text: 'Se Registro la Solicitud exitosamente, esperar credenciales en su bandeja de correo',
                    showConfirmButton: false,
                    timer: 4000
                })
            }

            function alertErrorImagen() {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'Adjunte Archivo Solicitado',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        </script>
    </form>
</body>
</html>
