<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Capa.Presentacion.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema Ferme Web</title>
    <meta charset="utf-8" />
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="js/bootstrap.js" type="text/javascript"></script>
    <script src="js/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 50%" class="m-auto pt-5">
        <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" DisplayRememberMe="False" FailureText="El usuario o contraseña no es válido. Intente nuevamente." Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" InstructionText="Bienvenido a Ferme Web. Favor ingrese sus credenciales para acceder a nuestro portal:" PasswordRecoveryText="Recuperar clave" TitleText="Iniciar sesión - Ferme Web" OnAuthenticate="Login1_Authenticate" PasswordRequiredErrorMessage="Clave es requerida" UserNameRequiredErrorMessage="Nombre de usuario es requerido" PasswordRecoveryUrl="~/resetearpassword.aspx">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </div>
    </form>
</body>
</html>
