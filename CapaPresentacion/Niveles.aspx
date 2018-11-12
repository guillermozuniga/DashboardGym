<%@ Page Title="Secciones" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Niveles.aspx.vb" Inherits="CapaPresentacion.Niveles" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-md-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title.ToUpper  %></label>
            </nav>
        </div>
    </div>
    <%--runat="server" onserverclick="btnNuevo_Click" style="display: none;"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <button id="Btn_Nuevo" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Nuevo_Click" type="button"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="Btn_Editar" class="btn btn-primary custom btn-sm-3 " runat="server" onserverclick="Btn_Editar_Click" type="button"><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="Btn_Eliminar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Eliminar_Click" type="button"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>
    </nav>
    <%--<div class="clearfix visible-sm-block"></div>--%>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nombre" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 form-horizontal">
                        <asp:Label ID="LabelClave" runat="server" Text="Clave" CssClass="control-label col-sm-3"></asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox ID="TextClave" runat="server" CssClass="form-control" placeholder="Clave"></asp:TextBox>
                        </div>

                    </div>

                    <div class="col-sm-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-md-8">
                            </div>
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8">
                            </div>
                            <button id="Btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
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
                    <h4 class="panel-title">Información de Secciones</h4>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="GvSeccion" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                             <asp:BoundField DataField="Nivel_ID" HeaderText="ID">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Nivel_Descripcion" HeaderText="Descripcion">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Nivel_Clave" HeaderText="Clave">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Nivel_Grados" HeaderText="Grados">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Nivel_GradoInicial" HeaderText="Grado Inicial">
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
