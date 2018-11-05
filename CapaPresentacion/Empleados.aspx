<%@ Page Title="Empleados" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Empleados.aspx.vb" Inherits="CapaPresentacion.Empleados" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .scrolling-table-container {
            height: 350px;
            overflow-y: scroll;
            overflow-x: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title.ToUpper %></label>
            </nav>
        </div>
    </div>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar" runat="server">
        <%--   runat="server" onserverclick="btnNuevo_Click"--%>
        <%--style="display:none;"--%>
        <button id="Btn_Nuevo" runat="server" onserverclick="Btn_Nuevo_Click" class="btn btn-primary custom btn-sm-3" type="button"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="Btn_Editar" runat="server" onserverclick="Btn_Editar_Click" class="btn btn-primary custom btn-sm-3 " type="button" ><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="Btn_Eliminar" runat="server" onserverclick="Btn_Eliminar_Click" class="btn btn-primary custom btn-sm-3" type="button"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>

    <div class="row" id="MenuSelect" runat="server">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class=" row col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="LabelNumero" runat="server" Text="Numero" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextNumero" runat="server" CssClass="form-control" placeholder="Numero"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nombre" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class=" row col-lg-5">

                        <div class="form-group">
                            <asp:Label ID="LabelCURP" runat="server" Text="CURP" CssClass="control-label col-sm-2"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextCurp" runat="server" CssClass="form-control" PlaceHolder="CRUP"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class=" row col-lg-1">
                        <div class="form-group">
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>
                        </div>
                        <div class="form-group">
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
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-print fa-xs"></span>Print</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span>PDF</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span>Excel</a>
                    </div>
                    <h4 class="panel-title">Información de Empleados</h4>
                </div>
                <div class="panel-body">
                    <div class="scrolling-table-container">

                        <asp:GridView ID="GVEmpleados" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="25" EmptyDataText="No hay registros para mostrar." runat="server" EnablePersistedSelection="True" DataKeyNames="Empleados_Numero">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <HeaderStyle BackColor="#001f3f" />
                            <Columns>
                                <asp:BoundField DataField="Empleados_ID" HeaderText="ID" Visible="false">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                                <asp:BoundField DataField="Empleados_Numero" HeaderText="Numero Empleado">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />                                     
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre ">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />                                     
                                </asp:BoundField>
                                <asp:BoundField DataField="Empleados_CURP" HeaderText="CURP Empleado">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />                                     
                                </asp:BoundField>
                                <asp:BoundField DataField="Empleados_Imss" HeaderText="IMSS Empleado">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />                                     
                                </asp:BoundField>
                                <asp:BoundField DataField="Empleados_RFC" HeaderText="RFC Empleado">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />                                     
                                </asp:BoundField>
                                <asp:BoundField DataField="Empleados_AreaLaboral" HeaderText="Area">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />                                     
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
