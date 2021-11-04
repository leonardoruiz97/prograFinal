<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WF_Inicio_Socio.aspx.cs" Inherits="WF_Inicio_Socio" %>
<!DOCTYPE html>

<html lang="en" >
<head>
  <meta charset="UTF-8">
  <title></title>
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400" rel="stylesheet">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.4.1/css/all.css" integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz" crossorigin="anonymous">
    <link rel="stylesheet" href="css/main.css">
    <link rel="shortcut icon" type="image/png" href="#"><link rel="stylesheet" href="dist/style.css">
         
</head>
<body>
<!-- partial:index.partial.html -->

<div class="grid">
  <header class="header">
    <i class="fas fa-bars header__menu"></i>
    <div class="header__search">
      <input class="header__input" placeholder="Buscar..." />
    </div>
    <div class="header__avatar">
      <div class="dropdown">
        <ul class="dropdown__list">
          <li class="dropdown__list-item">
            <span class="dropdown__icon"><i class="far fa-user"></i></span>
            <span class="dropdown__title" style="color:skyblue">Mi Perfil</span>
          </li>
          <li class="dropdown__list-item">
            <span class="dropdown__icon"><i class="fas fa-clipboard-list"></i></span>
            <span class="dropdown__title" style="color:skyblue">Mi cuenta</span>
          </li>
          <li class="dropdown__list-item">
            <span class="dropdown__icon"><i class="fas fa-sign-out-alt"></i></span>
           <a href="WF_Iniciar_Sesion.aspx" style="color:skyblue"><i class="dropdown__title"></i>Cerrar Sesion</a>
          </li>
        </ul>
      </div>
    </div>
  </header>

  <aside class="sidenav">
    <div class="sidenav__brand">
      <img src="img/iconoCosme.png" alt="..." class="img-circle" height="40" width="40">
      <a class="sidenav__brand-link" href="#">San<span class="text-light">Cosme</span></a>
      <i class="fas fa-times sidenav__brand-close"></i>
    </div>
    <div class="sidenav__profile">
      <%--<div class="sidenav__profile-avatar"></div>--%>
       <%-- <div class="profile clearfix">--%>
                            <div class="profile_pic" style="margin-left: 45px">
                                <img src="img/images.png" alt="..." class="img-circle" height="109" width="114">
                            </div>
         </div>
 
 <%--     <div class="sidenav__profile">

                            <div class="profile_info" style="margin-left: 40px; margin-top: -20px">
                                <asp:Label ID="txtpatrocinador" runat="server" Text="" Visible="false"></asp:Label>
                               <%-- <span>Bienvenido,</span>
                                <h2>Gerente General</h2>
                                <asp:Label ID="txtnombre" runat="server" Text=""></asp:Label>
                               <asp:Label ID="txtapellidopaterno" runat="server" Text="" ></asp:Label>
                            </div>
                       
      </div>--%>

        <div class="sidenav__profile">                 
                            <div class="profile_info" style="margin-left: 20px;margin-top: -20px">
                                 <asp:Label ID="txtpatrocinador" runat="server" Text="" Visible="false"></asp:Label>
                              <span style="margin-left:40px">Bienvenido,</span>
                                <br />
                                <asp:Label ID="txtnombre" runat="server" Text=""></asp:Label>
                               <asp:Label ID="txtapellidopaterno" runat="server" Text="" ></asp:Label>
                            </div>
                        </div>





    <div class="row row--align-v-center row--align-h-center">
      <ul class="navList">
          
        <li class="navList__heading">DATOS PERSONALES<i class="far fa-file-alt"></i></li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-book"></i></span>
            <span class="navList__subheading-title">Datos Personales</span>
          </div>
          <ul class="subList subList--hidden">
   <li class="subList__item"><a href="WF_Actualizar_Datos_Cliente.aspx" style="color:white">Actualizar mis datos</a></li>
          
           <%-- <li class="subList__item">investments</li>
            <li class="subList__item">spend log</li>
            <li class="subList__item">owed</li>--%>
          </ul>
        </li>
       <%-- <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-eye"></i></span>
            <span class="navList__subheading-title">Mi cuenta</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">Abonos</li>
          
          </ul>
        </li>--%>
        <li>
         <%-- <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-plane"></i></span>
            <span class="navList__subheading-title">trip logs</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">amsterdam</li>
            <li class="subList__item">buenos aires</li>
            <li class="subList__item">cambodia</li>
            <li class="subList__item">greenland</li>
          </ul>
        </li>--%>
        <li class="navList__heading">Operaciones<i class="fas fa-chart-bar"></i></li>
          
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-users"></i></span>
            <span class="navList__subheading-title">Afiliaciones</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item"><a href="WF_Listar_Afiliaciones.aspx" style="color:white">Verificar Afiliaciones</a></li>
              
               
           <%-- <li class="subList__item">foreign</li>
            <li class="subList__item">misc</li>--%>
          </ul>
        </li>
          <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-briefcase-medical"></i></span>
            <span class="navList__subheading-title">Servicios</span>
          </div>
          <ul class="subList subList--hidden">
         <%--   <li class="subList__item">Simular Prestamos</li>--%>
              <li class="subList__item"><a href="WF_Simular_Prestamos.aspx" style="color:white">Simular Prestamo</a></li>
            <li class="subList__item"><a href="WF_Solicitar_Prestamo.aspx" style="color:white">Solicitar Prestamo</a></li>
     
            
          </ul>
        </li>
              
       <%-- <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-credit-card"></i></span>
            <span class="navList__subheading-title">Pagos</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">Historial de Pagos</li>
            <li class="subList__item">archives</li>
          </ul>
        </li>--%>

            <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-list"></i></span>
            <span class="navList__subheading-title">Mis Prestamos</span>
          </div>
          <ul class="subList subList--hidden">
                <li class="subList__item"><a href="WF_Listar_Prestamo_Pendiente_Socio.aspx" style="color:white">Pendientes</a></li>
                 <li class="subList__item"><a href="WF_Listar_Prestamo_Aceptado_Socio.aspx" style="color:white">Aceptados</a></li>
            <%--<li class="subList__item">archives</li>--%>
          </ul>
        </li>

       <%-- <li class="navList__heading">messages<i class="far fa-envelope"></i></li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-envelope"></i></span>
            <span class="navList__subheading-title">inbox</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">primary</li>
            <li class="subList__item">social</li>
            <li class="subList__item">promotional</li>
          </ul>
        </li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-eye"></i></span>
            <span class="navList__subheading-title">unread</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">primary</li>
            <li class="subList__item">social</li>
            <li class="subList__item">promotional</li>
          </ul>
        </li>
         <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-book-open"></i></span>
            <span class="navList__subheading-title">archives</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">primary</li>
            <li class="subList__item">social</li>
            <li class="subList__item">promotional</li>
          </ul>
        </li>

        <li class="navList__heading">photo album<i class="far fa-image"></i></li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-mountain"></i></span>
            <span class="navList__subheading-title">vacation</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">cambodia</li>
            <li class="subList__item">new york</li>
          </ul>
        </li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-wine-glass-alt"></i></span>
            <span class="navList__subheading-title">anniversary</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">dive trip</li>
            <li class="subList__item">hikathon</li>
            <li class="subList__item">buffalo river</li>
          </ul>
        </li>--%>
     <%--   <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-graduation-cap"></i></span>
            <span class="navList__subheading-title">university</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">wild horse saloon</li>
            <li class="subList__item">service corps</li>
            <li class="subList__item">graduation</li>
            <li class="subList__item">internships</li>
          </ul>
        </li>--%>

        
        <%--<li class="navList__heading">Events<i class="fas fa-calendar-alt"></i></li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-wine-glass-alt"></i></span>
            <span class="navList__subheading-title">weddings</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">past</li>
            <li class="subList__item">present</li>
            <li class="subList__item">future</li>
          </ul>
        </li>
        <li>
          <div class="navList__subheading row row--align-v-center">
            <span class="navList__subheading-icon"><i class="fas fa-school"></i></span>
            <span class="navList__subheading-title">playdates</span>
          </div>
          <ul class="subList subList--hidden">
            <li class="subList__item">weirdos</li>
            <li class="subList__item">smarties</li>
            <li class="subList__item">nerds</li>
          </ul>
        </li>
        <li>
              <div class="navList__subheading row row--align-v-center">
                <span class="navList__subheading-icon"><i class="fas fa-users"></i></span>
                <span class="navList__subheading-title">networking</span>
              </div>
              <ul class="subList subList--hidden">
                <li class="subList__item">tech</li>
                <li class="subList__item">automotive</li>
                <li class="subList__item">UX research</li>
                <li class="subList__item">development</li>
              </ul>
            </li>--%>
      </ul>
    </div>
  </aside>
     <main class="main">
    <div class="main-header">
      <div class="main-header__intro-wrapper">
        <div class="main-header__welcome">
          <div class="main-header__welcome-title text-light">Bienvenido <strong></strong></div>
          <div class="main-header__welcome-subtitle text-light">¡Solicita tu prestamo y pagalo en cuotas!</div>
        </div>
        <div class="quickview">
          <div class="quickview__item">
            <div class="quickview__item-total">2</div>
            <div class="quickview__item-description">
              <i class="far fa-calendar-alt"></i>
              <span class="text-light">Eventos</span>
            </div>
          </div>
          <div class="quickview__item">
            <div class="quickview__item-total">64</div>
            <div class="quickview__item-description">
              <i class="far fa-comment"></i>
              <span class="text-light">Notificaciones</span>
            </div>
          </div>
          <div class="quickview__item">
            <div class="quickview__item-total">27&deg;</div>
            <div class="quickview__item-description">
              <i class="fas fa-map-marker-alt"></i>
              <span class="text-light">Lima, Peru</span>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="main-overview">
      <div class="overviewCard">
        <div class="overviewCard-icon overviewCard-icon--document">
           <i class="far fa-file-alt"></i>
        </div>
        <div class="overviewCard-description">
          <h3 class="overviewCard-title text-light"> <strong>Documentos</strong></h3>
          <%--<p class="overviewCard-subtitle">Europe Trip</p>--%>
        </div>
      </div>
      <div class="overviewCard">
        <div class="overviewCard-icon overviewCard-icon--calendar">
           <i class="far fa-calendar-check"></i>
        </div>
        <div class="overviewCard-description">
          <h3 class="overviewCard-title text-light"> <strong>Eventos</strong></h3>
          <%--<p class="overviewCard-subtitle">Chili Cookoff</p>--%>
        </div>
      </div>
      <div class="overviewCard">
        <div class="overviewCard-icon overviewCard-icon--mail">
           <i class="far fa-envelope"></i>
        </div>
        <div class="overviewCard-description">
          <h3 class="overviewCard-title text-light"><strong>Notificaciones</strong></h3>
          <p class="overviewCard-subtitle">+10</p>
        </div>
      </div>
      <div class="overviewCard">
        <div class="overviewCard-icon overviewCard-icon--photo">
           <i class="far fa-file-image"></i>
        </div>
        <div class="overviewCard-description">
          <h3 class="overviewCard-title text-light"><strong>Reportes</strong></h3>
       <%--   <p class="overviewCard-subtitle">House Concert</p>--%>
        </div>
      </div>
    </div> <!-- /.main__overview -->
    <div class="main__cards">
      <div class="card">
        <div class="card__header">
          <div class="card__header-title text-light"><strong>Eventos del Mes</strong>
            <a href="#" class="card__header-link text-bold">View All</a>
          </div>
          <div class="settings">
            <div class="settings__block"><i class="fas fa-edit"></i></div>
            <div class="settings__block"><i class="fas fa-cog"></i></div>
          </div>
        </div>
        <div class="card__main">
          <div class="card__row">
            <div class="card__icon"><i class="fas fa-book"></i></div>
            <div class="card__time">
              <div>06/10/2021</div>
            </div>
             <div class="card__detail">
              <div class="card__source text-bold">Charla sobre Lavado de Activos</div>
              <div class="card__description">Charla brindada por la Cooperativa San Cosme, para mayor conocimineto de los socios</div>
              <div class="card__note">7:30 p.m. Plataforma Zoom</div>
            </div>
          </div>
          <div class="card__row">
            <div class="card__icon"><i class="fas fa-book"></i></div>
            <div class="card__time">
              <div>31/10/2021</div>
            </div>
            <div class="card__detail">
              <div class="card__source text-bold">Día de la canción criolla</div>
              <div class="card__description">La música criolla es un género musical costeño, una forma de vida, un signo para afirmar la identidad cultural nuestra, el cual involucra a la marinera, el vals, la polka, el golpe tierra, el tondero</div>
              <div class="card__note">7:30 p.m. Plataforma Zoom</div>
            </div>
          </div>
         <%-- <div class="card__row">
            <div class="card__icon"><i class="fas fa-book"></i></div>
            <div class="card__time">
              <div>Thursday</div>
            </div>
            <div class="card__detail">
              <div class="card__source text-bold">National Institute of Science</div>
              <div class="card__description">Join the institute for an in-depth look at Stephen Hawking</div>
              <div class="card__note">7:30pm, Carnegie Center for Science</div>
            </div>
          </div>
          <div class="card__row">
            <div class="card__icon"><i class="fas fa-heart"></i></div>
            <div class="card__time">
              <div>Friday</div>
            </div>
            <div class="card__detail">
              <div class="card__source text-bold">24th Annual Heart Ball</div>
              <div class="card__description">Join us and contribute to your favorite local charity.</div>
              <div class="card__note">6:45pm, Austin Convention Ctr</div>
            </div>
          </div>
          <div class="card__row">
            <div class="card__icon"><i class="fas fa-heart"></i></div>
            <div class="card__time">
              <div>Saturday</div>
            </div>
            <div class="card__detail">
              <div class="card__source text-bold">Little Rock Air Show</div>
              <div class="card__description">See the Blue Angels fly with roaring thunder</div>
              <div class="card__note">11:00pm, Jacksonville Airforce Base</div>
            </div>
          </div>--%>
        </div>
      </div>
      <div class="card">
        <div class="card__header">
          <div class="card__header-title text-light"> <strong>Documentos Recientes</strong>
            <a href="#" class="card__header-link text-bold">View All</a>
          </div>
          <div class="settings">
            <div class="settings__block"><i class="fas fa-edit"></i></div>
            <div class="settings__block"><i class="fas fa-cog"></i></div>
          </div>
        </div>
        <div class="card">
          <div class="documents">
            <div class="document">
              <div class="document__img"></div>
              <div class="document__title">historial-de-pago-julio</div>
              <div class="document__date">07/16/2018</div>
            </div>
            <div class="document">
              <div class="document__img"></div>
              <div class="document__title">recibo-luz</div>
              <div class="document__date">09/04/2018</div>
            </div>
            <div class="document">
              <div class="document__img"></div>
              <div class="document__title">recibo-agua</div>
              <div class="document__date">10/10/2018</div>
            </div>
            <div class="document">
              <div class="document__img"></div>
              <div class="document__title">declaracion-patrocinador</div>
              <div class="document__date">11/01/2018</div>
            </div>
          </div>
        </div>
      </div>
      <div class="card card--finance">
        <div class="card__header">
          <div class="card__header-title text-light"> <strong>Abonos</strong>
            <a href="#" class="card__header-link text-bold">View All</a>
          </div>
          <div class="settings">
            <div class="settings__block"><i class="fas fa-edit"></i></div>
            <div class="settings__block"><i class="fas fa-cog"></i></div>
          </div>
        </div>
        <div id="chartdiv"></div>
      </div>
    </div> <!-- /.main-cards -->
  </main>

 

    <!-- partial -->
  <script src='https://code.jquery.com/jquery-3.3.1.min.js'></script>
<script src='https://www.amcharts.com/lib/3/amcharts.js'></script>
<script src='https://www.amcharts.com/lib/3/serial.js'></script>
<script src='https://www.amcharts.com/lib/3/themes/light.js'></script><script  src="dist/script.js"></script>
            
</body>
</html>
