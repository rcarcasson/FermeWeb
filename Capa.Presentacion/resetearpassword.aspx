<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetearpassword.aspx.cs" Inherits="Capa.Presentacion.resetearpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Ferme Web - Restauraci&oacute;n de contrase&ntilde;a</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link href="css/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <link href="css/starter-template.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/bootstrap.min.js" ></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/script.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <asp:Panel ID="panelPrincipal" runat="server">
            <div class="row">
                <div class="col-12">
                    <div class="alert alert-info" role="alert">
                        <h3>Restauraci&oacute;n de contrase&ntilde;a</h3>
                        <p>Ingrese su correo electr&oacute;nico con el que inicia sesi&oacute;n para empezar el proceso de 
                            restauraci&oacute;n de su clave de acceso:
                        </p>
                    </div>
                </div>
            </div>
            <asp:Panel ID="panelEmail" runat="server">
                <div class="form-row">
                    <div class="col-4">
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Email" ValidationGroup="Correo"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente >>" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="Correo" OnClick="btnSiguiente_Click" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="col">
                        <asp:RequiredFieldValidator ID="validarCorreo" runat="server" ErrorMessage="Campo obligatorio" ForeColor="Red" ControlToValidate="txtCorreo" Display="Dynamic" ValidationGroup="Correo"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="panelPregunta" runat="server" Visible="false">
                <div class="form-row">
                    <div class="col-8">
                        <asp:Label ID="Label1" runat="server" Text="Pregunta: "></asp:Label><asp:Label ID="lbPregunta" runat="server" Text=""></asp:Label>
                    </div>
                    
                </div>
                <div class="form-row">
                    <div class="col-md-6">
                        <asp:TextBox ID="txtRespuesta" runat="server" TextMode="Password" ValidationGroup="Respuesta" CssClass="form-control" Placeholder="Respuesta"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnValidar" runat="server" Text="Validar respuesta" CssClass="btn btn-primary" CausesValidation="true"  ValidationGroup="Respuesta" OnClick="btnValidar_Click"/>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col">
                        <asp:RequiredFieldValidator ID="validarRespuesta" runat="server" ErrorMessage="Campo obligatorio" ValidationGroup="Respuesta" ControlToValidate="txtRespuesta" ForeColor="Red"></asp:RequiredFieldValidator>

                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="panelNuevaClave" runat="server" Visible="false">
                <div class="form-group">
                    <div class="col-md-8">
                        <asp:TextBox ID="txtNuevaClave1" runat="server" CssClass="form-control" ValidationGroup="NuevaClave" TextMode="Password" Placeholder="Nueva contrase&ntilde;a"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-8">
                        <asp:TextBox ID="txtNuevaClave2" runat="server" CssClass="form-control" ValidationGroup="NuevaClave" TextMode="Password" Placeholder="Repetir nueva contrase&ntilde;a"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-2">
                        <asp:Button ID="btnCambiarClave" runat="server" Text="Cambiar" CssClass="btn btn-success" ValidationGroup="NuevaClave" CausesValidation="true" OnClick="btnCambiarClave_Click" />
                    </div>
                </div>
                <div class="form-row">
                    <div class="col">
                        <asp:RequiredFieldValidator ID="claveVacia" runat="server" ErrorMessage="Los campos no pueden estar vac&iacute;os" ForeColor="Red" ValidationGroup="NuevaClave" ControlToValidate="txtNuevaClave1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-row">
                    <div class="col">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las contrase&ntilde;as no coinciden." ControlToCompare="txtNuevaClave1" ControlToValidate="txtNuevaClave2" ValidationGroup="NuevaClave" ForeColor="Red"></asp:CompareValidator>
                    </div>
                </div>
            </asp:Panel>
        </asp:Panel>
            <asp:Panel ID="panelExito" runat="server" Visible="false">
                <div class="alert alert-success" role="alert">
                    <h2>Cambio de clave realizado</h2>
                    <p class="text-justify">Se ha realizado el cambio de su clave satisfactoriamente. Haga click <a href="login.aspx">aqu&iacute;</a> para iniciar sesi&oacute;n con su nueva clave.</p>
                </div>
            </asp:Panel>
    </div>
    </form>
</body>
</html>
