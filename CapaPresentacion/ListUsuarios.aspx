<%@ Page Title="Lista Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListUsuarios.aspx.vb" Inherits="CapaPresentacion.ListUsuarios" %>

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

        <%--runat="server" onserverclick="btnNuevo_Click"--%>
        <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="btn_Nuevo_Click"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " <%--style="display:none;"--%>><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelUserName" runat="server" Text="User Name" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Text_UserName" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelEmail" runat="server" Text="Email" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control" placeholder="Correo Electronico"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="User Name" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Email" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Correo Electronico"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
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
                <div class="table-responsive">                   
 <%--                   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="false" CssClass="table table-bordered" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="UserName" EmptyDataText="There are no data records to display.">--%>
                         <asp:GridView ID="gvUsuarios"  CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="Nombre de Usuario">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="email" HeaderText="Correo Electronico">
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
