<%@ Page Title="Man. Familias" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ManFamilias.aspx.vb" Inherits="CapaPresentacion.ManFamilias" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2">
        <div class="alert alert-success" id="Msg_Success" style="display: none">
            <asp:Label runat="server" ID="LabelMessage" Text=""></asp:Label>
        </div>
        <div class="alert alert-danger" id="MsgDanger" style="display: none">
            <asp:Label runat="server" ID="Label7" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-th-list"></span></a>
                <label><%: Page.Title %></label>
            </nav>
        </div>
    </div>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
                    <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-floppy-disk"></span>Guardar </button>
                    <button id="btn_Regresar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-arrow-left"></span>Regresar </button>
                </nav>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-1">
                        <div class="form-group">
                            <asp:Label runat="server" ID="LabelTutor" Text="Tutor" CssClass="control-label" ></asp:Label>
                            <asp:TextBox runat="server" Enabled="false" ID="Text_nombre" CssClass="form-control" placeholder="Tutor"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-11">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label8" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox7" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" Text="Sexo"></asp:Label>
                            <asp:DropDownList ID="DropDownListSexo" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label2" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label6" Text="Estado Civil"></asp:Label>
                            <asp:DropDownList ID="DropDownListEstadoCivil" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label3" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label4" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label5" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox5" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
