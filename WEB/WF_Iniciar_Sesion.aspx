<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Iniciar_Sesion.aspx.cs" Inherits="WF_Iniciar_Sesion" %>

<!DOCTYPE html>
<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title></title>
  <meta name="viewport" content="width=device-width, initial-scale=1"><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.2.3/animate.min.css'>
    <link rel="stylesheet" href="dist/style_login1.css">


    <!--Pequeño script para el movimiento del title-->
<script type="text/javascript">
   
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


</head>
<body>
<form id="LOGIN" runat="server">

<div class='box'>
  <div class='box-form'>
    <div class='box-login-tab'></div>
    <div class='box-login-title'>
      <div class='i i-login'></div><h2>LOGIN</h2>
    </div>
    <div class='box-login'>
      <div class='fieldset-body' id='login_form'>
        <button onclick="openLoginInfo();" class='b b-form i i-more' title='Mais Informações'></button>
        	<p class='field'>
                <asp:Label ID="txtcontraseñabus" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="txtpkiu" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtusu" runat="server" Text="" Visible="false"></asp:Label>
                       <asp:Label ID="txtdnibus" runat="server" Text="" Visible="false"></asp:Label>
                         <asp:Label ID="txtcorreobus" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtfkrol" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="txtfksocio" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="txtfkpatrocinador" runat="server" Text="" Visible="false"></asp:Label>

          <img src="img/iconoCosme.png" width="100" height="100">
          <label for='user'>USUARIO</label>
           <asp:TextBox ID="txtDNI" onkeypress="javascript:return SoloNumeros(event)"  minlength="8" MaxLength="8" runat="server" placeholder="DNI"></asp:TextBox>
          <span id='valida' class='i i-warning'></span>
        </p>
      	  <p class='field'>
          <label for='pass'>CONTRASEÑA</label>
           <asp:TextBox TextMode="Password" ID="txtContraseña" runat="server" placeholder="Contraseña"></asp:TextBox>
          <span id='valida' class='i i-close'></span>
        </p>

          <label class='checkbox'>
            <input type='checkbox' value='TRUE' title='Keep me Signed in' /> ¿Quieres guardar la contraseña?
          </label>

           <asp:Button class="btnIniciar" runat="server" Text="INICIAR SESION" OnClick="Unnamed_Click"></asp:Button>
        	
    </div>
  </div>
  <div class='box-info'>
					    <p><button onclick="closeLoginInfo();" class='b b-info i i-left' title='Back to Sign In'></button><h3>¿Necesitas Ayuda?</h3>
    </p>
					    <div class='line-wh'></div>
    					<button  class='b-support' title='Forgot Passwor?'> <a style="color:#032942" href="WF_Olvidar_Contraseña.aspx"> Olvidaste tu Contraseña</a></button>
    <button onclick="" class='b-support' title='Contact Support'> Contactate con Soporte</button>
    					<div class='line-wh'></div>
    <%--<button onclick="" class='b-cta' title='Sign up now!'> CREATE ACCOUNT</button>--%>
  				</div>
</div>
    </div>

 <%--<div class='icon-credits'>Icons made by <a href="http://www.freepik.com" title="Freepik">Freepik</a>, <a href="http://www.flaticon.com/authors/budi-tanrim" title="Budi Tanrim">Budi Tanrim</a> & <a href="http://www.flaticon.com/authors/nice-and-serious" title="Nice and Serious">Nice and Serious</a> from <a href="http://www.flaticon.com" title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a></div>--%>
<!-- partial -->


     <script src="../js/sweetalert.js"></script>
                    <script>
                        function dniVacio() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Ingrese su DNI',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function ContraseñaVacia() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Ingrese su Contraseña',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function inicioExitoso() {
                            Swal.fire({
                                position: 'center',
                                icon: 'success',
                                title: 'Bienvenido',
                                text: 'Inicio sesion exitosamente',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        } 
                        function contraseñaincorrecta() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'No coincide la contraseña',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function noexisteUsuario() {
                            Swal.fire({
                                position: 'center',
                                icon: 'warning',
                                title: 'No existe Usuario',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function gerenteGeneral() {
                            Swal.fire({
                                position: 'center',
                                icon: 'success',
                                title: 'Usted, es gerente general',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function cajera() {
                            Swal.fire({
                                position: 'center',
                                icon: 'success',
                                title: 'Usted, es cajera',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }

                        function errordatos() {
                            Swal.fire({
                                position: 'center',
                                icon: 'error',
                                title: 'Ingrese sus Datos nuevamente',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }
                        function Socio() {
                            Swal.fire({
                                position: 'center',
                                icon: 'success',
                                title: 'Usted es socio',
                                showConfirmButton: false,
                                timer: 2000
                            })
                        }

                    </script>
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
<script src='https://cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js'></script><script  src="dist/script_login1.js"></script>
    </form>
</body>
</html>
