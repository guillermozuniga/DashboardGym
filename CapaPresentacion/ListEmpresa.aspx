<%@ Page Title="Lista Empresas" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListEmpresa.aspx.vb" Inherits="CapaPresentacion.ListEmpresa" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<div class="container-fluid">
        <div class="page-header">
            <h4 class="text-titles"><small><%: Page.Title %></small></h4>
        </div>
     </div>--%>
    <div class="row">
        <div class="col-sm-6">
            <nav class="btn-toolbar text-left text-danger">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title.ToUpper %></label>
            </nav>
        </div>
    </div>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <%--   runat="server" onserverclick="btnNuevo_Click"--%>
        <%--style="display:none;"--%>

        <%--<asp:Button ID="Btn_Nuevo" runat="server" Text="Nuevo" class="btn btn-primary custom btn-sm-3"></asp:Button>--%>

        <button id="Btn_Nuevo" runat="server" onserverclick="Btn_Nuevo_Click" class="btn btn-primary custom btn-sm-3" type="button"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="Btn_Editar" runat="server" onserverclick="Btn_Editar_Click" class="btn btn-primary custom btn-sm-3 " type="button"><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="Btn_Eliminar" runat="server" onserverclick="Btn_Eliminar_Click" class="btn btn-primary custom btn-sm-3" type="button"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>


    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row col-sm-11">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelRFC" Text="R.F.C." CssClass="control-label"></asp:Label>
                                <asp:TextBox runat="server" ID="Text_Rfc" CssClass="form-control" placeholder="R.F.C."></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelRazonSocial" Text="Razon Social" ToolTip="RFC"></asp:Label>
                                <asp:TextBox runat="server" ID="TextBox7" CssClass="form-control" placeholder="Razon Social"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row col-sm-1">
                        <div class="form-group">
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="btn-group pull-right">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default btn-xs"></asp:DropDownList>

                    </div>

                    <div class="btn-group pull-right">
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-print fa-xs"></span> Print</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> PDF</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> Excel</a>
                    </div>
                    <h4 class="panel-title">Información de Empresas</h4>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="GvEmpresa" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="25" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>

                            <asp:BoundField DataField="Empresa_ID" HeaderText="ID">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Empresa_RFC" HeaderText="R F C">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Empresa_RazonSocial" HeaderText="Razon Social" HtmlEncode="False">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Empresa_NombreCorto" HeaderText="Nombre Corto" HtmlEncode="False">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
