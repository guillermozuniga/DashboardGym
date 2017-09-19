<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="wfventas.aspx.vb" Inherits="CapaPresentacion.wfventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align: center">Ventas</h1>
    </section>
    <section class="content-header">
        <p style="text-align: center">
            <asp:DropDownList ID="DropDownListunegocio" CssClass="btn btn-def" runat="server" Style="width: 55%" AutoPostBack="false"></asp:DropDownList>
        </p>
    </section>
    <section class="content">
        <div class="row">

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-lg-6 col-xs-6">
                <!-- small box -->
                <div class="input-group">
                    <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <asp:TextBox ID="txtFechaIni" CssClass="form-control" Style="width: 90%" data-inputmask="'alias': 'dd/mm/yyyy'"
                        data-mask="" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-6 col-xs-6">
                <!-- small box -->
                <div class="input-group">
                    <div class="input-group-addon">
                        <i class="fa fa-calendar"></i>
                    </div>
                    <asp:TextBox ID="TxtFechaFin" CssClass="form-control" Style="width: 90%" data-inputmask="'alias': 'dd/mm/yyyy'"
                        data-mask="" runat="server"></asp:TextBox>
                </div>
            </div> 

        </div>
    </section>
</asp:Content>
