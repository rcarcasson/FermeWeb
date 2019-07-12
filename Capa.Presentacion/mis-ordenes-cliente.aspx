<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="mis-ordenes-cliente.aspx.cs" Inherits="Capa.Presentacion.mis_ordenes_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-light" role="alert">
        <h3>Mis Ordenes</h3>
        <p class="text-justify">En esta p&aacute;gina puede visualizar todas las ordenes que ha generado en nuestro sistema para su revisi&oacute;n. El valor total que puede visualizar corresponde a los totales netos. Haga click en Detalles para m&aacute;s informaci&oacute;n:</p>
        <asp:Panel ID="panelPrincipal" runat="server">
            <asp:GridView ID="gridOrdenes" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound="gridOrdenes_RowDataBound" OnRowCommand="gridOrdenes_RowCommand">
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
                    <asp:BoundField HeaderText="N° de Orden" DataField="NumDocumento" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Fecha de Orden" DataField="FechaDocumento" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Total Neto" DataField="Total" ItemStyle-HorizontalAlign="Right" />
                    <asp:ButtonField HeaderText="" Text="Ver detalles" ControlStyle-CssClass="btn btn-info" CommandName="VerDetalles" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="panelDetalles" runat="server" Visible="false">
            <asp:GridView ID="gridDetalles" AutoGenerateColumns="False" Width="100%" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCommand="gridDetalles_RowCommand" OnRowDataBound="gridDetalles_RowDataBound">
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
                    <asp:BoundField HeaderText="C&oacute;digo de Producto" DataField="CodigoProducto" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="PrecioUnitario" ItemStyle-HorizontalAlign="Right" />
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

            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="btnVolver_Click" />
        </asp:Panel>
        <asp:Label ID="lbCantidadCarro" runat="server" Text="" Visible="true" ForeColor="White"></asp:Label>
    </div>
</asp:Content>
