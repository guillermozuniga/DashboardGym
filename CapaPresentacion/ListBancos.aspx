<%@ Page Title="Lista Bancos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListBancos.aspx.vb" Inherits="CapaPresentacion.ListBancos" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title %></label>
            </nav>
        </div>
    </div>

    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <%--   runat="server" onserverclick="btnNuevo_Click"--%>
        <button id="btn_Nuevo" runat="server" onserverclick="Btn_Nuevo_Click" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " <%--style="display:none;"--%>><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>


    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row col-lg-9">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelBanco" Text="Nombre Banco" CssClass="control-label"></asp:Label>
                                <asp:TextBox runat="server" ID="TextBanco" CssClass="form-control" placeholder="Nombre Banco"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelClave" Text="Clave"></asp:Label>
                                <asp:TextBox runat="server" ID="TextClave" CssClass="form-control" placeholder="Clave"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3">
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="Btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="container-fluid" style="width: 100%">
                        <asp:GridView ID="gvBancos" CssClass="table table-bordered" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>

                                <asp:TemplateField HeaderText="No">
                                    <ItemTemplate>
                                        <%#(gvBancos.PageSize * gvBancos.PageIndex) + gvBancos.Rows.Count + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="Bancos_ClaveOficial" HeaderText="Clave Oficial">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Bancos_Nombre" HeaderText="Nombre">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#001f3f" />

                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
