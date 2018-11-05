<%@ Page Title="Mant. Bancos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ManBancos.aspx.vb" Inherits="CapaPresentacion.ManBancos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .alert {
            display: block;
            position: fixed;
            top: 50px;
            z-index: 100000;
            margin-left: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    <asp:HiddenField ID="HiddenFieldValor" runat="server" />

    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-th-list"></span></a>
                <label><%: Page.Title.ToUpper %></label>
            </nav>
        </div>
    </div>
    <%--style="display:none;"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <button id="Btn_Guardar" runat="server" class="btn btn-primary custom btn-sm-3" onserverclick="Btn_Guardar_Click" type="button" onclientclick="this.disabled = true;"><span class="glyphicon glyphicon-floppy-disk"></span> Guardar </button>
        <button id="Btn_Regresar" runat="server" class="btn btn-primary custom btn-sm-3" onserverclick="Btn_Regresar_Click" type="button"> <span class="glyphicon glyphicon-arrow-left"></span> Regresar </button>
    </nav>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-7">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelNombreCom" Text="Nombre"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxNombre" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelClave" Text="Clave"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxClave" CssClass="form-control" placeholder="Clave"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
