<%@ Page Title="Lista Familias" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListFamilias.aspx.vb" Inherits="CapaPresentacion.ListFamilias" %>
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
                    <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="btnNuevo_Click"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
                    <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " <%--style="display:none;"--%>><span class="glyphicon glyphicon-edit"></span>Editar</button>
                    <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

               </nav>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                         <div class="form-group">
                            <asp:Label ID="LabelFirstName" runat="server" Text="Nombre" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextFirstName" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelLastName" runat="server" Text="Apellido" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextLastName" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="LabelRFC" runat="server" Text="R.F.C." CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextRFC" runat="server" CssClass="form-control" placeholder="RFC"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelCURP" runat="server" Text="CURP" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextCURP" runat="server" CssClass="form-control" placeholder="CURP"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="btn_Buscar_Click">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="btn_Limpiar_Click">Limpiar </button>

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
                   <asp:GridView ID="gvFamilias" CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                       <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Tutores_Tutor" HeaderText="Tutor ID">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="NombreMama" HeaderText="Nombre Mama">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="NombrePapa" HeaderText="Nombre Papa">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

<%--                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" DeleteText="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i>"
                                CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" />--%>
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
