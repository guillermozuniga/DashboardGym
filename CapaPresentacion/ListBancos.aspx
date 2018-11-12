<%@ Page Title="Bancos" Language="vb"  EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListBancos.aspx.vb" Inherits="CapaPresentacion.ListBancos" %>

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

    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <%--   runat="server" onserverclick="btnNuevo_Click" <%--style="display:none;"--%>
        <button id="btn_Nuevo" runat="server" onserverclick="Btn_Nuevo_Click" type="button" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" runat="server" onserverclick="Btn_Editar_Click" type="button" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" runat="server" onserverclick="Btn_Eliminar_Click" type="button" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>


    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row col-lg-9">
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelBanco" Text="Nombre Banco" CssClass="control-label"></asp:Label>
                                <asp:TextBox runat="server" ID="TextBanco" CssClass="form-control" placeholder="Nombre Banco"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-4">
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
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server"  onserverclick="Btn_Buscar_Click" type="button" > Buscar </button>
                            

                        </div>
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="Btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server"> Limpiar </button>

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
                    <h4 class="panel-title">Información de Bancos</h4>
                </div>
                <div class="panel-body">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="GVBancos" CssClass="table table-bordered table-hover table-condensed small-top-margin" 
                            AutoGenerateColumns="false" AllowPaging="true" PageSize="25" EmptyDataText="No hay registros para mostrar." runat="server" EnablePersistedSelection="True" DataKeyNames="Bancos_BancoID">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>
                                <%--<asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <%#(GVBancos.PageSize * GVBancos.PageIndex) + GVBancos.Rows.Count + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:TemplateField>--%>
                                <asp:BoundField DataField="Bancos_BancoID" HeaderText="ID">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Banco_ClaveOficial" HeaderText="Clave Oficial">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Banco_Nombre" HeaderText="Nombre" HtmlEncode="False">
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
