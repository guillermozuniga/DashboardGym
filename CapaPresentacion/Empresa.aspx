<%@ Page Title="Listar Empresas" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Empresa.aspx.vb" Inherits="CapaPresentacion.Empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left titleuser">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label>Empresas</label>
            </nav>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-12 col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:Button ID="btn_BACK" runat="server" Text="Regresar" CssClass="btn btn-primary" />
                    <button id="btn_Nuevo" class="btn btn-primary btn-outlined btn-square" <%--style="display:none;"--%>><span class="glyphicon glyphicon-plus-sign"></span>Nuevo </button>
                </div>
                <div class="panel-body" id="panel">
                    <table id="jqGrid"></table>
                    <div id="jqGridPager"></div>
                </div>
            </div>

        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
