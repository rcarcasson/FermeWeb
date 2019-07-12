<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="mis-datos-cliente.aspx.cs" Inherits="Capa.Presentacion.mis_datos_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelDatos" runat="server">
       <h3 class="p-3">Mis Datos</h3>
        <div class="form-row p-3">
            <div class="col-4">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" MaxLength="50" ValidationGroup="MisDatos"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="MisDatos"></asp:RequiredFieldValidator>
            </div>
            <div class="col-2">
                <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" Placeholder="Rut" MaxLength="12" ValidationGroup="MisDatos" ReadOnly="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtRut" Display="Dynamic" ForeColor="Red" ValidationGroup="MisDatos"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
             <div class="col-6">
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Direcci&oacute;n" MaxLength="50" ValidationGroup="MisDatos"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtDireccion" Display="Dynamic" ForeColor="Red" ValidationGroup="MisDatos"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-2">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Tel&eacute;fono" MaxLength="15" ValidationGroup="MisDatos"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtTelefono" Display="Dynamic" ForeColor="Red" ValidationGroup="MisDatos"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Campo solo debe ser num&eacute;rico" ValidationExpression="\d+" ControlToValidate="txtTelefono"  ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" TextMode="Email" MaxLength="50" ValidationGroup="MisDatos"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red" ValidationGroup="MisDatos"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-2">
                <asp:Button ID="btnGuardarDatos" runat="server" Text="Actualizar" CssClass="btn btn-info" CausesValidation="true" ValidationGroup="MisDatos" OnClick="btnGuardarDatos_Click" />
            </div>
        </div>
        <h3 class="p-3">Mi clave</h3>
        <div class="form-row p-3">
            <div class="col-4">
                <asp:TextBox ID="txtClaveActual" runat="server" CssClass="form-control" Placeholder="Contrase&ntilde;a actual" TextMode="Password" ValidationGroup="NuevaClave"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqValClave" runat="server" ErrorMessage="Campo obligatorio" Display="Dynamic" ForeColor="Red" ControlToValidate="txtClaveActual" ValidationGroup="NuevaClave"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-4">
                <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="form-control" Placeholder="Nueva contrase&ntilde;a" TextMode="Password" ValidationGroup="NuevaClave"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo obligatorio" Display="Dynamic" ForeColor="Red" ControlToValidate="txtNuevaClave" ValidationGroup="NuevaClave"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-4">
                <asp:TextBox ID="txtNuevaClave2" runat="server" CssClass="form-control" Placeholder="Repetir nueva contrase&ntilde;a" TextMode="Password" ValidationGroup="NuevaClave"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo obligatorio" Display="Dynamic" ForeColor="Red" ControlToValidate="txtNuevaClave2" ValidationGroup="NuevaClave" ></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las claves no coinciden" ControlToValidate="txtNuevaClave2" ControlToCompare="txtNuevaClave" ForeColor="Red" ValidationGroup="NuevaClave"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-2">
                <asp:Button ID="btnActualizarClave" runat="server" Text="Actualizar contrase&ntilde;a" CausesValidation="true" ValidationGroup="NuevaClave" CssClass="btn btn-warning" OnClick="btnActualizarClave_Click"/>
            </div>
        </div>
        <h3 class="p-3">Pregunta secreta</h3>
        <p class="text-justify p-3">Esta opci&oacute;n le permite indicar una pregunta y respuesta secreta en caso de que olvide su contrase&ntilde;a para efectos de recuperaci&oacute;n. Solo ver&aacute; la pregunta pero no la respuesta que haya 
            especificado con anterioridad por motivos de seguridad. Para actualizar su pregunta y respuesta secreta tendr&aacute; que ingresar su contrase&ntilde;a actual:
        </p>
        <div class="form-row p-3">
            <div class="col-6">
                <asp:TextBox ID="txtPregunta" runat="server" CssClass="form-control" Placeholder="Pregunta" ValidationGroup="PreguntaSecreta" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo obligatorio" ForeColor="Red" ValidationGroup="PreguntaSecreta" Display="Dynamic" ControlToValidate="txtPregunta"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-6">
                <asp:TextBox ID="txtRespuesta" runat="server" CssClass="form-control" Placeholder="Respuesta" ValidationGroup="PreguntaSecreta" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Campo obligatorio" ForeColor="Red" ValidationGroup="PreguntaSecreta" Display="Dynamic" ControlToValidate="txtRespuesta"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-4">
                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" Placeholder="Contrase&ntilde;a actual" ValidationGroup="PreguntaSecreta" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqClave2" runat="server" ErrorMessage="Campo obligatorio" ValidationGroup="PreguntaSecreta" ForeColor="Red" Display="Dynamic" ControlToValidate="txtClave"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-row p-3">
            <div class="col-6">
                <asp:Button ID="btnActualizarPregunta" runat="server" Text="Actualizar pregunta/respuesta" CausesValidation="true" ValidationGroup="PreguntaSecreta" CssClass="btn btn-warning" OnClick="btnActualizarPregunta_Click"/>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="panelMisDatos" runat="server" Visible="false">
        <div class="alert alert-info p-3" role="alert">
            <h3>Informaci&oacute;n actualizada</h3>
            <p class="text-justify">Se ha actualizado su informaci&oacute;n personal de manera correcta. Si modific&oacute;n su email tenga presente que el nuevo email ser&aacute; su nuevo usuario de acceso para iniciar sesi&oacute;n.</p>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-info" OnClick="btnAceptar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="panelClave" runat="server" Visible="false">
        <div class="alert alert-info p-3" role="alert">
            <h3>Contrase&ntilde;a modificada</h3>
            <p class="text-justify">Se ha cambiado su contrase&ntilde;a correctamente.</p>
            <asp:Button ID="btnAceptar2" runat="server" Text="Aceptar" CssClass="btn btn-info" OnClick="btnAceptar2_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="panelPregunta" runat="server" Visible="false">
        <div class="alert alert-info p-3" role="alert">
            <h3>Pregunta/respuesta actualizada</h3>
            <p class="text-justify">Se ha actualizado tanto la pregunta como su respuesta secreta correctamente.</p>
            <asp:Button ID="btnAceptar3" runat="server" Text="Aceptar" CssClass="btn btn-info" OnClick="btnAceptar3_Click" />
        </div>
    </asp:Panel>
    <asp:Label ID="lbCantidadCarro" runat="server" Text="" Visible="true" ForeColor="White"></asp:Label>

</asp:Content>
