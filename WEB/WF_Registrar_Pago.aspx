<%@ Page Title="" Language="C#" MasterPageFile="~/Cajera.master" AutoEventWireup="true" CodeFile="WF_Registrar_Pago.aspx.cs" Inherits="WF_Gestionar_Prestamos" %>

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
    <script src="bootstrap/css/bootstrap.css" type="text/css"></script>
    <script src="bootstrap/css/bootstrap.min.css" type="text/css"></script>
    <script src="bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
	<script src="scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script src="scripts/jquery.quicksearch.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	
    <h3 style="text-align: center; color: black"><b>REGISTRAR PAGOS</b></h3>

    <div class="row mt" style="margin-left:100px">
		<div class="col-lg-8">
			<h4><i class="fa fa-angle-right"></i>BUSCAR PRÉSTAMO</h4>
			<div class="form-panel">
				<div class=" form">
					<form1 class="cmxform form-horizontal style-form" id="commentForm" method="get" action="">
						<section style="padding-top: 20px"></section>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">
								<asp:Label ID="lblCodPrestamo" runat="server" Text="N° PRÉSTAMO"></asp:Label>
                                <asp:TextBox ID="txtCodPrestamo" runat="server" class="form-control" Width="70%"></asp:TextBox>								
							</div>
						</div>

						<div class="col-sm-3 col-md-6">							
							<section style="padding-top: 18px"></section>
							<div class="form-group">
								<asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-theme" Width="30%" OnClick="btnBuscar_Click" />
								<asp:Button ID="btnBorrar" runat="server" Text="Borrar" class="btn btn-theme" Width="30%" OnClick="btnBorrar_Click" />
							</div>
						</div>

						<section style="padding-top: 75px"></section>
					</form1>
				</div>
			</div>
		</div>
    </div>

	<div class="row mt" style="margin-left:100px">
		<div class="col-lg-8">
			<h4><i class="fa fa-angle-right"></i>DATOS DEL SOCIO</h4>
			<div class="form-panel">
				<div class=" form">
					<form1 class="cmxform form-horizontal style-form" id="commentForm2" method="get" action="">
						<section style="padding-top: 20px"></section>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">
								<asp:Label ID="lblNumeroDocumento" runat="server" Text="DNI"></asp:Label>
								<asp:TextBox ID="txtNumeroDocumento" runat="server" class="form-control" Width="65%" Height="35px" ReadOnly="True" BackColor="White"></asp:TextBox>	
								<asp:TextBox ID="txtFK_IS_Cod" runat="server" class="form-control" Width="65%" Height="35px" ReadOnly="True" BackColor="White" visible="false"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:Label ID="lblApellidos" runat="server" Text="APELLIDOS"></asp:Label>
								<asp:TextBox ID="txtApellidos" runat="server" class="form-control" Width="65%" Height="35px" ReadOnly="True" BackColor="White"></asp:TextBox>								
							</div>
						</div>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">								
								<asp:Label ID="lblNombreCompleto" runat="server" Text="NOMBRES"></asp:Label>
								<asp:TextBox ID="txtNombreCompleto" runat="server" class="form-control" Width="65%" Height="35px" ReadOnly="True" BackColor="White"></asp:TextBox>
							</div>
						</div>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">
								<asp:Label ID="lblCiudad" runat="server" Text="CIUDAD"></asp:Label>
								<asp:TextBox ID="txtCiudad" runat="server" class="form-control" Width="65%" Height="35px" ReadOnly="True" BackColor="White"></asp:TextBox>
							</div>
						</div>
						<section style="padding-top: 140px"></section>
					</form1>
				</div>
			</div>
		</div>
	</div>

	<div class="row mt" style="margin-left:100px">
		<div class="col-lg-8">
			<h4><i class="fa fa-angle-right"></i>DATOS DEL PRÉSTAMO</h4>
			<div class="form-panel">
				<div class=" form">
					<form1 class="cmxform form-horizontal style-form" id="commentForm3" method="get" action="">
						<section style="padding-top: 20px"></section>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">
								<asp:Label ID="lblMontoPrestamo" runat="server" Text="IMPORTE"></asp:Label>&nbsp;<asp:Label ID="Label1" runat="server" Text=" (*)" ForeColor="Red"></asp:Label>
								<asp:TextBox ID="txtMontoPrestamo" runat="server" class="form-control" Width="65%" ReadOnly="True" BackColor="White"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:Label ID="lblInteres" runat="server" Text="Interés %:"></asp:Label>&nbsp;<asp:Label ID="Label2" runat="server" Text=" (*)" ForeColor="Red"></asp:Label>
								<asp:TextBox ID="txtInteres" runat="server" class="form-control" Width="65%" ReadOnly="True" BackColor="White"></asp:TextBox>
							</div>
						</div>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">
								<asp:Label ID="lblNumCuotas" runat="server" Text="N° Cuotas:"></asp:Label>&nbsp;<asp:Label ID="Label3" runat="server" Text=" (*)" ForeColor="Red"></asp:Label>
								<asp:TextBox ID="txtNumCuotas" runat="server" class="form-control" Width="65%" ReadOnly="True" BackColor="White"></asp:TextBox>
							</div>
							<div class="form-group">
								<asp:Label ID="lblFechaRegistro" runat="server" Text="Fecha de Registro:"></asp:Label>
								<asp:TextBox ID="txtFechaRegistro" runat="server" class="form-control" Width="65%" ReadOnly="True" BackColor="White"></asp:TextBox>

								<asp:TextBox ID="txtEstadoPrestamo" runat="server" class="form-control" Width="65%" visible="false"></asp:TextBox>
							</div>
						</div>

						<div class="col-sm-3 col-md-6">
							<div class="form-group">
								<asp:Button ID="btnPagar" runat="server" Text="Ir a pagar" class="btn btn-theme" OnClick="btnPagar_Click" />
								<asp:Button ID="btnVolver" runat="server" Text="Volver" class="btn btn-theme" OnClick="btnVolver_Click"/>							
							</div>														
						</div>

						<section style="padding-top: 200px"></section>
					</form1>
				</div>
			</div>
		</div>
	</div>

    <div class="container register">
        <div class="col-md-12 register-right">
			<div class="tab-content" id="myTabContent">                           
				
				<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
					<div class="modal-dialog modal-lg" role="document">
						<div class="modal-content">
							<div class="modal-header">
								<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
								<h4 class="modal-title" id="myModalLabel">INFORMACIÓN DE PAGO</h4>
							</div>
							
							<div class="modal-body modal-lg">								
								<div class="row">
									<div class="col">
										<asp:GridView ID="gv_ListarCuotas" onsubmit = "return false" runat="server" style="margin-left:25px" OnRowCommand="gv_ListarCuotas_RowCommand" OnPageIndexChanging="gv_ListarCuotas_PageIndexChanging" EmptyDataText="No hay listado de cuotas" CssClass="table-responsive-sm table-hover" Width="95%" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="gv_ListarCuotas_RowDataBound" AllowPaging="True" PageSize="10" >
											<Columns>
												<asp:TemplateField HeaderText="ID"  Visible="false">
													<ItemTemplate>
														<asp:Label ID="PK_IC_Cod" runat="server" Text='<%# Eval ("PK_IC_Cod") %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField DataField="IC_NumeroCuota" HeaderText="N° de Cuota" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>
												<asp:BoundField DataField="DC_FechaInicio" HeaderText="Fecha Inicio" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>
												<asp:BoundField DataField="DC_FechaFin" HeaderText="Fecha Fin" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" DataFormatString="{0:d}">
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>												
												<asp:BoundField DataField="FC_MontoCuota" HeaderText="Importe" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>
												<asp:BoundField DataField="DiasRetraso" HeaderText="Días de Retraso" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" >
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>
												<asp:BoundField DataField="FK_IECU_Cod" HeaderText="FK_IECU_Cod" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" >
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>
												<asp:BoundField DataField="VEcu_Estado_Cuota" HeaderText="Estado Cuota" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" >
													<HeaderStyle CssClass="text-center"></HeaderStyle>
													<ItemStyle CssClass="text-center"></ItemStyle>
												</asp:BoundField>
												<asp:TemplateField HeaderText="Pagar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
													<ItemTemplate>
														<asp:Button ID="btnRegistrarPago" CssClass="btn btn-success" runat="server" CommandName="Registrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Style="color: white" text="Pagar Cuota" aria-hidden="true"> </asp:Button>
														<asp:Button ID="btnPenalizacion" CssClass="btn btn-success" runat="server" CommandName="Penalizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Style="color: white" text=" Penalizar " aria-hidden="true" Visible="False"> </asp:Button>
														
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>
											<HeaderStyle BackColor="#008080" ForeColor="white" Font-Bold="true" />
										</asp:GridView>
									</div>
									<div class="col-sm-3 col-md-6">
									<div class="form-group">
										<asp:TextBox ID="txtNCuota" runat="server" class="form-control" Width="65%" ValidateRequestMode="Inherit" Enabled="False" Visible="false"></asp:TextBox>
									</div>
									<div class="form-group">
										<asp:TextBox ID="txtFechaInicio" runat="server" class="form-control" Width="65%" Enabled="False" Visible="false"></asp:TextBox>
									</div>
									<div class="form-group">
										<asp:TextBox ID="txtFechaFin" runat="server" class="form-control" Width="65%" Enabled="False" Visible="false"></asp:TextBox>
									</div>
									<div class="form-group">
										<asp:TextBox ID="txtImporte" runat="server" class="form-control" Width="65%" Enabled="false" Visible="false"></asp:TextBox>
										<asp:TextBox ID="txtIC_Cod" runat="server" class="form-control" Width="65%" Enabled="False" Visible="false"></asp:TextBox>
										<asp:TextBox ID="txtIECU_Cod" runat="server" class="form-control" Width="65%" Enabled="False" Visible="false"></asp:TextBox>
										<asp:TextBox ID="txtDNI" runat="server" class="form-control" Width="65%" Enabled="False" Visible="false"></asp:TextBox>
										<asp:TextBox ID="txtDiasRetraso" runat="server" class="form-control" Width="65%" Enabled="False" Visible="false"></asp:TextBox>
									</div>
								</div>
								</div>								
							</div>							
						</div>
					</div>
				</div>

			</div>
        </div>
    </div>

	<section>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
                              <script src="dist/bootstrap-input-spinner.js"></script>
        <script>
            $("input[type='number']").inputSpinner()
        </script>

        <!-- Alertas -->
        <script src="js/sweetalert.js"></script>
        <script>
            function RegistrarPago() {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'Enviado',
                    text: 'Se registró el pago exitosamente.',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        </script>
		<script>
            function NoHayPrestamo() {
                Swal.fire({
                    position: 'center',
                    icon: 'alert',
                    title: '!!!',
                    text: 'No existe préstamo..',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        </script>
		<script>
            function NoPagar() {
                Swal.fire({
                    position: 'center',
                    icon: 'alert',
                    title: '!!!',
                    text: 'Ya está pagado, no joda',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        </script>

    </section>

</asp:Content>
