<%@ Page Title="Listado Empresas" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="empresas.aspx.vb" Inherits="CapaPresentacion.empresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left titleuser">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label>Listado Empresas</label>
            </nav>
        </div>
    </div>
    <nav class="btn-toolbar text-center well" id="MenuBar">
        <button class="btn btn-primary btn-color btn-bg-color btn-sm" id="MenuBar__MB_EXIT" onclick="">
            <span class="glyphicon glyphicon-arrow-left"></span>
            Regresar</button>

    </nav>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">

                        <div class="form-group">
                            <label class="control-label col-md-2">Nombre</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="input100" Font-Bold="True" Font-Size="Small" ForeColor="#333399" ToolTip="Información de ayuda"></asp:TextBox>
                                <%--<small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>  --%>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 form-horizontal">

                        <div class="form-group">
                            <label class="control-label col-md-2">Apellido</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="input100" Font-Bold="True" Font-Size="Small" ForeColor="#333399" ToolTip="Información de ayuda"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-md-12">
                                <button class="btn btn-primary btn-color btn-bg-color btn-sm" id="MenuBar__MB_EXIT1"><span class="glyphicon glyphicon-refresh"></span>Buscar</button>

                            </div>
                        </div>
                    </div>


                </div>
            </div>

        </div>
        <div class="col-lg-12">
            <div class="panel panel-default">

                <div class="panel-body">
                   
                </div>
            </div>
        </div>
    </div>


</asp:Content>
