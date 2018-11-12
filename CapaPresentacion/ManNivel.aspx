<%@ Page Title="Man Secciones" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ManNivel.aspx.vb" Inherits="CapaPresentacion.ManNivel" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>

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
        <button id="Btn_Guardar" runat="server" class="btn btn-primary custom btn-sm-3" onserverclick="Btn_Guardar_Click" type="button" onclientclick="this.disabled = true;"><span class="glyphicon glyphicon-floppy-disk"></span>Guardar </button>
        <button id="Btn_Regresar" runat="server" class="btn btn-primary custom btn-sm-3" onserverclick="Btn_Regresar_Click" type="button"><span class="glyphicon glyphicon-arrow-left"></span>Regresar </button>
    </nav>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelNombre" Text="Nombre"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxNombre" CssClass="form-control" placeholder="Nombre" ToolTip="Nombre de la Sección"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-1">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelClave" Text="Clave"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxClave" CssClass="form-control" placeholder="Clave" ToolTip="Clave de la Sección"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-1">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelGrados" Text="Grados"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxGrados" CssClass="form-control" placeholder="Grado" ToolTip="Grados por Sección"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-1">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Labelinci" Text="Inicial"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxGradoInicial" CssClass="form-control" placeholder="Inicial" ToolTip="Grado Inicial"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelPeriodos" Text="Periodos"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxPeriodos" CssClass="form-control" placeholder="Periodo" ToolTip="Periodos Sección"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelBanco" Text="Banco"></asp:Label>
                        <asp:DropDownList ID="DropDownListBancos" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">Seleccione un Item</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label4" Text=" Eva Por Periodo"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxNivelPorPeriodos" CssClass="form-control" placeholder="Eva Por Periodo" ToolTip="Eva Por Periodo"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label1" Text="Sistema Oficial"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxSistemaOficial" CssClass="form-control" placeholder="Sistema Oficial" ToolTip="Sistema Oficial"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label2" Text="Nombre Comercial"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxNombreComercial" CssClass="form-control" placeholder="Nombre Comercial" ToolTip="Nombre Comercial"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label3" Text="Razon Social"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxRazonSocial" CssClass="form-control" placeholder="Razon Social" ToolTip="Razon Social"></asp:TextBox>
                    </div>
                </div>


            </div>
            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label5" Text="RFC"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxRFC" CssClass="form-control" placeholder="RFC" ToolTip="RFC"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label6" Text="CURP"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxCURP" CssClass="form-control" placeholder="CURP" ToolTip="CURP"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label7" Text="Representante"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxRepresentante" CssClass="form-control" placeholder="Representante" ToolTip="Representante"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label8" Text="Rep RFC"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxRepresentanteRFC" CssClass="form-control" placeholder="Rep RFC" ToolTip="Rep RFC"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="Label9" Text="Rep CURP"></asp:Label>
                        <asp:TextBox runat="server" ID="TextBoxRepresentanteCURP" CssClass="form-control" placeholder="Rep CURP" ToolTip="Rep CURP"></asp:TextBox>
                    </div>
                </div>
            </div>

            
            <hr />
            <%--  Informacion de Direccion--%>
            <div class="row">
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelCalle" Text="Dirección"></asp:Label>
                        <asp:TextBox runat="server" ID="TextCalle" CssClass="form-control" placeholder="Dirección"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelCodigop" Text="C.P."></asp:Label>
                        <asp:TextBox runat="server" ID="TextCodigoP" CssClass="form-control" placeholder="Codigo"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-1">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelNumExt" Text="Exterior"></asp:Label>
                        <asp:TextBox runat="server" ID="TextNumExt" CssClass="form-control" placeholder="Num"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-1">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelNumInt" Text="Interior"></asp:Label>
                        <asp:TextBox runat="server" ID="TextNumInt" CssClass="form-control" placeholder="Num"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelColonia" Text="Colonia"></asp:Label>
                        <asp:TextBox runat="server" ID="TextColonia" CssClass="form-control" placeholder="Colonia"></asp:TextBox>
                    </div>
                </div>
            </div>
            <%--  Informacion de Localidad Municip Estado--%>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelLocalidad" Text="Localidad"></asp:Label>
                        <asp:TextBox runat="server" ID="TextLocalidad" CssClass="form-control" placeholder="Localidad"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelMunicipio" Text="Municipio"></asp:Label>
                        <asp:TextBox runat="server" ID="TextMunicipio" CssClass="form-control" placeholder="Municipio"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelEstado" Text="Estado"></asp:Label>
                        <asp:TextBox runat="server" ID="TextEstado" CssClass="form-control" placeholder="Estado"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelTel1" Text="Teléfono"></asp:Label>
                        <asp:TextBox runat="server" ID="TextTel1" CssClass="form-control" placeholder="Teléfono"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelTelefono2" Text="Teléfono 2"></asp:Label>
                        <asp:TextBox runat="server" ID="TextTel2" CssClass="form-control" placeholder="Teléfono 2"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelTel3" Text="Teléfono 3"></asp:Label>
                        <asp:TextBox runat="server" ID="TextTel3" CssClass="form-control" placeholder="Teléfono 3"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelMovil" Text="Movil "></asp:Label>
                        <asp:TextBox runat="server" ID="TextMovil" CssClass="form-control" placeholder="Movil"></asp:TextBox>

                    </div>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-5">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelEmail" Text="Correo Electronico"></asp:Label>
                        <asp:TextBox runat="server" ID="TextEmail" CssClass="form-control" placeholder="Correo Electronico"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelDominio" Text="Dominio"></asp:Label>
                        <asp:TextBox runat="server" ID="TextDominio" CssClass="form-control" placeholder="Dominio"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="form-group">
                        <asp:Label runat="server" ID="LabelNombreCorto" Text="Nombre Corto"></asp:Label>
                        <asp:TextBox runat="server" ID="TextNombreCorto" CssClass="form-control" placeholder="Nombre Corto"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
