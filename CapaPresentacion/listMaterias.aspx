<%@ Page Title="Asignaturas" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="listMaterias.aspx.vb" Inherits="CapaPresentacion.listMaterias" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-3">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title.ToUpper %></label>
            </nav>
        </div>
    </div>
    <%--runat="server" onserverclick="btnNuevo_Click" style="display: none;--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <button id="Btn_Nuevo" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Nuevo_Click" type="button"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="Btn_Editar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Editar_Click" type="button"><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="Btn_Eliminar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Eliminar_Click" type="button"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>
    </nav>
    <div class="clearfix visible-sm-block"></div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nombre" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 form-horizontal">
                        <asp:Label ID="LabelClave" runat="server" Text="Nombre Corto" CssClass="control-label col-sm-5"></asp:Label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="TextNombreCorto" runat="server" CssClass="form-control" placeholder="Nombre Corto"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-sm-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-md-8">
                            </div>
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-4" runat="server" onserverclick="Btn_Buscar_Click" type="button">Buscar </button>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8">
                            </div>
                            <button id="Btn_Limpiar" class="btn btn-primary custom btn-sm-4" runat="server" onserverclick="Btn_Limpiar_Click" type="button">Limpiar </button>
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
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-print fa-xs"></span>Print</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span>PDF</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span>Excel</a>
                    </div>
                    <h4 class="panel-title">Información de Materias o Cursos</h4>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="GvMaterias" CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="25" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Materias_Id" HeaderText="Id">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Materias_Nombre" HeaderText="Nombre" HtmlEncode="False">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Materias_NombreCorto" HeaderText="Nombre Corto" HtmlEncode="False">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Materias_CicloEscolar" HeaderText="Ciclo Escolar">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Materias_Nivel" HeaderText="Nivel">
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
