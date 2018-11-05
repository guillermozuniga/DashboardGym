<%@ Page Title="Mant. Roles" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="manRoles.aspx.vb" Inherits="CapaPresentacion.manRoles" %>

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
        <button id="Btn_Nuevo" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-floppy-disk"></span>Guardar </button>
        <button id="Btn_Regresar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-arrow-left"></span>Regresar </button>
        <asp:LinkButton ID="btnAgregarHorario" runat="server" CssClass="btn btn-primary" href="#imodal" data-toggle="modal">Agregar Horario</asp:LinkButton>

    </nav>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-body">

                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
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
                            <asp:Label runat="server" ID="Label6" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="TextBox6" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    

    <div class="modal fade" id="imodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Actualizar registro</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>NOMBRES Y APELLIDOS</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtFullName" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>DIRECCIÓN</label>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtModalDireccion" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnactualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
