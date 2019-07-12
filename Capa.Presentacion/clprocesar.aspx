<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="clprocesar.aspx.cs" Inherits="Capa.Presentacion.clprocesar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelPrincipal" runat="server">
        <div class="alert alert-info" role="alert">
            <h3>Procesar Orden</h3>
            <p class="text-justify">La orden de despacho y la documentaci&oacute;n de venta se emitir&aacute; con los siguientes datos. 
                Estos mismos datos serán utilizados para efectos de despacho de sus productos. Si necesita actualizar sus datos puede hacerlo 
                a través de este mismo formulario antes de generar la orden.</p>
        </div>
        <div class="alert alert-light col-10" role="alert">
            <h6>Informaci&oacute;n de despacho y facturaci&oacute;n:</h6>
        </div>
        <div class="row ml-0">
            <div class="form-group col-md-4">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre" MaxLength="50" ValidationGroup="Procesar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtNombre" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-6">
                <asp:TextBox ID="txtRut" runat="server" CssClass="form-control col-md-4" Placeholder="Rut" MaxLength="12" ValidationGroup="Procesar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtRut" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="form-group col-md-6">
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Direcci&oacute;n" MaxLength="50" ValidationGroup="Procesar"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtDireccion" Display="Dynamic"></asp:RequiredFieldValidator>
         </div>
        <div class="row ml-0">
            <div class="form-group col-md-2">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Tel&eacute;fono" MaxLength="15" ValidationGroup="Procesar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtTelefono" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Campo solo debe ser num&eacute;rico" ValidationExpression="\d+" ControlToValidate="txtTelefono" ></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-md-4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" TextMode="Email" MaxLength="50" ValidationGroup="Procesar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo obligatorio" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="col-12 p-3">
            <asp:GridView ID="gridFinal" Width="100%" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound="gridFinal_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                <Columns>
                    <asp:BoundField HeaderText="C&oacute;digo de producto" DataField="IdProducto" />
                    <asp:BoundField HeaderText="Descripci&oacute;n" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Total" ItemStyle-HorizontalAlign="Right" />
                </Columns>
            </asp:GridView>
                <div class="row">
                  <div class="col-md-10 ml-md-auto text-right font-weight-bold">Total Neto $:</div>
                  <div class="col-md-2 ml-md-auto text-right font-weight-bold"><asp:Label ID="lbNeto" runat="server" Text="13000.-"></asp:Label></div>
                </div>
                <div class="row">
                  <div class="col-md-10 ml-md-auto text-right font-weight-bold">IVA 19% $:</div>
                  <div class="col-md-2 ml-md-auto text-right font-weight-bold"><asp:Label ID="lbIva" runat="server" Text="1290.-"></asp:Label></div>
                </div>
                <div class="row">
                  <div class="col-md-10 ml-md-auto text-right font-weight-bold">Total $:</div>
                  <div class="col-md-2 ml-md-auto text-right font-weight-bold"><asp:Label ID="lbTotal" runat="server" Text="14290.-"></asp:Label></div>
                </div>
            <div class="row">
                <div class="col-md-6 ml-md-auto"><asp:Button ID="btnGenerarOrden" runat="server" Text="Generar Orden" CssClass="btn btn-info" OnClick="btnGenerarOrden_Click" ValidationGroup="Procesar" CausesValidation="true" />&nbsp;&nbsp;<asp:Button ID="btnCancelarOrden" runat="server" Text="Cancelar Orden" CssClass="btn btn-danger" CausesValidation="false" /></div>
            </div>

        </div>
        <asp:Label ID="lbCantidadCarro" runat="server" Text="" ForeColor="White"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="panelProcesado" runat="server" Visible="false">
        <div class="alert alert-success" role="alert">
            <h3>Orden generada</h3>
            <p class="text-justify">Se ha generado la orden <asp:Label ID="lbNumOrden" runat="server" Text="ORDEN"></asp:Label> satisfactoriamente para su procesamiento en nuestras dependencias. Para obtener información de esta u otras 
                &oacute;rdenes generadas haga click en Mis Ordenes en el menú superior.</p>
        </div>
    </asp:Panel>
</asp:Content>
