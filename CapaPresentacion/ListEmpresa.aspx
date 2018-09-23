<%@ Page Title="Lista Empresas" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListEmpresa.aspx.vb" Inherits="CapaPresentacion.ListEmpresa" %>

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
                                <asp:Label runat="server" ID="LabelRFC" Text="R.F.C." CssClass="control-label"></asp:Label>
                                <asp:TextBox runat="server" ID="Text_Rfc" CssClass="form-control" placeholder="R.F.C."></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelRazonSocial" Text="Razon Social"></asp:Label>
                                <asp:TextBox runat="server" ID="TextBox7" CssClass="form-control" placeholder="Razon Social"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3">
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>

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
                    <asp:GridView ID="gvEmpresa" CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">                        
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>

                            <asp:BoundField DataField="Empresa_ID" HeaderText="ID" />
                            <asp:BoundField DataField="Empresa_RazonSocial" HeaderText="Razon Social" />

                        </Columns>
                       <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#001f3f" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
