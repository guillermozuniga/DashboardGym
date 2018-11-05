<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="manImportarDatos.aspx.vb" Inherits="CapaPresentacion.manImportarDatos" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="content-header">
        <div class="text-center">
            <h3>Importación de Datos</h3>
        </div>
    </section>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelTutores" runat="server" Text="Importar Tutores" CssClass="control-label col-sm-8"></asp:Label>
                            <div class="col-sm-4">
                                <button id="Btn_Importar_Tutores" class="btn btn-primary custom btn-sm-4" runat="server"> Tutores </button>
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

