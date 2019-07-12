<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index-cliente.aspx.cs" Inherits="Capa.Presentacion.index_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-2 p-3" style="background-color: burlywood; height: 655px;">
        <p class="h3">Productos</p>
        <div id="listaproductos">
        <asp:BulletedList ID="listaProductos" runat="server" DataTextField="DESCRIPCION" DataValueField="ID" DisplayMode="LinkButton" OnClick="listaProductos_Click" BulletImageUrl="~/img/tool.png" BulletStyle="CustomImage"></asp:BulletedList>
        </div>
    </div>
    <div class="col-10 p-3">
        <asp:Label ID="lbTipoProducto" runat="server" Text="Bienvenido a Ferme Web" CssClass="h3"></asp:Label>
        <asp:Panel ID="panelSaludo" runat="server">
            <div class="alert alert-info" role="alert">
                Nos complace tenerlo de regreso a nuestro portal. Esperamos que tenga una experiencia agradable en nuestro sitio conociendo y comprando 
                nuestros productos desde la comodidad de su hogar.<br /><br />
                Al lado izquierdo ver&aacute; un men&uacute; con los distintos tipos de productos que tenemos a su 
                disposici&oacute;n. Haga click en alguno de ellos para ver un listado de los diferentes productos 
                relacionados.<br /><br />
                En la parte superior del sitio encontrar&aacute; las siguientes opciones:<br /><br />
                <ul>
                    <li><b>Mis &oacute;rdenes:</b> Aqu&iacute; podr&aacute; visualizar las distintas &oacute;rdenes generadas por usted ya sea por este portal o a trav&eacute; de compra directa con nuestro local.</li>
                    <li><b>Mis datos:</b> Aqu&iacute; podr&aacute; visualizar sus datos personales y modificarlos. Por favor mantenga su informaci&oacute;n al d&iacute;a ya que es la que utilizamos para el despacho de los productos a su destino.</li>
                    <li><b>Ver carro:</b> Podr&aacute; ver los diferentes art&iacute;culos que ha seleccionado para su posterior proceso de compra en nuestro sistema.</li>
                </ul>
                El equipo Ferme Web
            </div>
        </asp:Panel>
        <asp:Panel ID="panelProductos" runat="server" Visible="false">
            <asp:GridView ID="gridProductos" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" DataKeyNames="Id" OnRowCommand="gridProductos_RowCommand" OnRowDataBound="gridProductos_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="C&oacute;digo producto" DataField="IdProducto" />
                    <asp:BoundField HeaderText="Descripci&oacute;n" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Stock" DataField="Stock" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" ItemStyle-HorizontalAlign="Right" />
                    <asp:ButtonField HeaderText="" Text="Agregar al carro" ButtonType="Button" CommandName="AgregarAlCarro" ControlStyle-CssClass="btn btn-info" ItemStyle-HorizontalAlign="Center" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="panelSinExistencias" runat="server" Visible="false">
            <div class="alert alert-danger">
                A&uacute;n no contamos con productos de la opci&oacute;n seleccionada. Disculpe las molestias.
            </div>
        </asp:Panel>
        <asp:Panel ID="panelAgregarAlCarro" runat="server" Visible="false">
           <div class="alert alert-info">
               <p class="text-center font-weight-bold">Stock actual: <asp:Label ID="lbStock" runat="server" Text="Stock"></asp:Label></p>
               <p class="text-center">Precio: $ <asp:Label ID="lbPrecio" runat="server" Text="Precio"></asp:Label></p>
               <p class="text-center">Cantidad: <asp:TextBox ID="txtCantidad" TextMode="Number" runat="server" Text="0" MaxLength="4" Width="50px"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnCalcular" runat="server" Text="Calcular" CausesValidation="false" CssClass="btn btn-info" OnClick="btnCalcular_Click"/></p>
               <div class="alert alert-warning" style="width:30%; margin:0 auto">
                   <p class="text-center">Total: $ <asp:Label ID="lbTotal" runat="server" Text="0"></asp:Label></p>
               </div>
               <p class="text-center text-danger"><asp:Label ID="lbAlertaCarro" runat="server" Text=""></asp:Label></p>
               <asp:Button ID="btnAgregar" runat="server" Text="Agregar al carro" CssClass="btn btn-success" OnClick="btnAgregar_Click"/>
               <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-warning" OnClick="btnVolver_Click" />
               <asp:Label ID="lbId" runat="server" Text="" Visible="false"></asp:Label>
           </div>
        </asp:Panel>
        <asp:Panel ID="panelAgregadoAlCarro" runat="server" Visible="false">
            <div class="alert alert-success">
                <p class="text-center">Producto agregado al carro satisfactoriamente.</p>
                <asp:Button ID="btnAceptarProceso" runat="server" Text="Aceptar" CssClass="btn btn-info" OnClick="btnAceptarProceso_Click" />
            </div>
        </asp:Panel>
        <asp:Label ID="lbCantidadCarro" runat="server" Text="" Visible="true" ForeColor="White"></asp:Label>
    </div>

</asp:Content>
