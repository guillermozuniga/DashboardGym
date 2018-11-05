<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="manGenerarUsuarios.aspx.vb" Inherits="CapaPresentacion.manGenerarUsuarios" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <section class="content-header">
        <div class="text-center">
            <h3>Generación de Usuario</h3>
        </div>
    </section>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelRFC" runat="server" Text="Generar Usuarios Tutores" CssClass="control-label col-sm-8"></asp:Label>
                            <div class="col-sm-4">
                                <button id="Btn_Generar_Tutores" class="btn btn-primary custom btn-sm-4" runat="server" onserverclick="Btn_Generar_Tutores_Click" type="button">Generar </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
