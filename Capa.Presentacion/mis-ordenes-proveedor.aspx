<%@ Page Title="" Language="C#" MasterPageFile="~/Proveedor.Master" AutoEventWireup="true" CodeBehind="mis-ordenes-proveedor.aspx.cs" Inherits="Capa.Presentacion.mis_ordenes_proveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-light" role="alert">
        <h3>Mis Ordenes</h3>
        <p class="text-justify">En esta p&aacute;gina puede visualizar todas las ordenes de compra asociadas a usted. Haga click en Detalles para m&aacute;s informaci&oacute;n:</p>
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
                    <asp:BoundField HeaderText="N° de Orden" DataField="NumOrden" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Fecha de Orden" DataField="FechaDocumento" ItemStyle-HorizontalAlign="Right" />
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
                    <asp:BoundField HeaderText="C&oacute;digo de Producto" DataField="ProductoId" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Observacion" DataField="Observacion" /> 
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-info" OnClick="btnVolver_Click" />
        </asp:Panel>
    </div>

</asp:Content>
