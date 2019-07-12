<%@ Page Title="" Language="C#" MasterPageFile="~/Proveedor.Master" AutoEventWireup="true" CodeBehind="index-proveedor.aspx.cs" Inherits="Capa.Presentacion.index_proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-12 p-3">
        <asp:Label ID="Label1" runat="server" Text="Bienvenido a Ferme Web" CssClass="h3"></asp:Label>
        <asp:Panel ID="panelSaludo" runat="server">
            <div class="alert alert-info" role="alert">
                En este portal podr&aacute; visualizar las &oacute;rdenes que hemos generado a usted para renovar nuestro stock de productos. En la parte superior del sitio encontrar&aacute; las siguientes opciones:
                <ul>
                    <li><b>Mis &oacute;rdenes:</b> Aqu&iacute; podr&aacute; visualizar las distintas &oacute;rdenes que hemos emitido a su empresa.</li>
                    <li><b>Mis datos:</b> Aqu&iacute; podr&aacute; visualizar sus datos personales y modificarlos. Por favor mantenga su informaci&oacute;n al d&iacute;a ya que es la que utilizamos para la generaci&oacute;n de nuestras &oacute;rdenes a ustedes.</li>
                </ul>
                El equipo Ferme Web
            </div>
        </asp:Panel>
        </div>
</asp:Content>
