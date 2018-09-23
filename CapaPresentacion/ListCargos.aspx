<%@ Page Title="Lista Cargos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListCargos.aspx.vb" Inherits="CapaPresentacion.ListCargos"  Culture="es-MX" UICulture="es-MX" %>


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
    <%--runat="server" onserverclick="btnNuevo_Click"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3" style="display: none;"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " style="display: none;"><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" style="display: none;"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>
    <div class="clearfix visible-sm-block"></div>
    <div class="row">
        <div class="col-xs-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelMatricula" runat="server" Text="Matricula" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextMatricula" runat="server" CssClass="form-control" placeholder="Matricula"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <asp:Label ID="Label1" runat="server" Text="Fecha" CssClass="control-label col-sm-3"></asp:Label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <asp:TextBox ID="TextFecha" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" runat="server" CssClass="form-control" data-provide="datepicker"></asp:TextBox>

                        </div>

                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Buscar_Click">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Limpiar_Click">Limpiar </button>

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

                    <asp:GridView ID="gvCargos" CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>

                            <%--                           <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%#(gvCargos.PageSize * gvCargos.PageIndex) + gvCargos.Rows.Count + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="black" />
                            </asp:TemplateField>--%>

                            <asp:BoundField DataField="Cargos_Id" HeaderText="ID">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Cargos_Matricula" HeaderText="Matricula">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Cargos_CicloEscolar" HeaderText="CicloEscolar">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <%--  <asp:BoundField DataField="Cargos_FechaDeVencimiento" HeaderText="Fecha Vencimiento" />--%>

                            <asp:BoundField DataField="Cargos_Importe" HeaderText="Importe" DataFormatString="{0:N2}"
                                ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#001f3f" />

                        <%-- <EmptyDataTemplate>
                                No Record Available
                            </EmptyDataTemplate>--%>
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
