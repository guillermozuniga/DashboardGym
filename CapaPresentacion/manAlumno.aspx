﻿<%@ Page Title="Man. Alumno" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="manAlumno.aspx.vb" Inherits="CapaPresentacion.manAlumno" %>
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
     <%--style="display:none;"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <button id="Btn_Guardar" onserverclick="Btn_Guardar_Click" runat="server" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-floppy-disk"></span>Guardar </button>
        <button id="Btn_Regresar" onserverclick="Btn_Regresar_Click" runat="server" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-arrow-left"></span>Regresar </button>
    </nav>


    <div class="col-md-12">
        <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#activity" data-toggle="tab">Información Alumno</a></li>
                <li><a href="#settings" data-toggle="tab">Familia</a></li>
                <li><a href="#logos" data-toggle="tab">Foto</a></li>

            </ul>
            <div class="tab-content">
                <div class="active tab-pane" id="activity">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="inputName" class="col-sm-2 control-label">R.F.C.</label>
                                        <asp:TextBox runat="server" ID="TextRFC" CssClass="form-control" Enabled="false" placeholder="R.F.C."></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-9">
                                    <div class="form-group">
                                        <label for="inputName1" class="col-sm-2 control-label">Razon Social</label>
                                        <asp:TextBox runat="server" ID="TextRazonSocial" CssClass="form-control" Enabled="false" placeholder="Razon Social"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LabelNombreCom" Text="Nombre Comercial"></asp:Label>
                                        <asp:TextBox runat="server" ID="TextBoxNombreCom" CssClass="form-control" placeholder="Nombre Comercial"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LabelCurp" Text="C.U.R.P."></asp:Label>
                                        <asp:TextBox runat="server" ID="TextCURP" CssClass="form-control" placeholder="C.U.R.P."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <%--  Informacion de Direccion--%>
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LabelCalle" Text="Dirección"></asp:Label>
                                        <asp:TextBox runat="server" ID="TextCalle" CssClass="form-control" placeholder="Dirección"></asp:TextBox>
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

                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LabelEmail" Text="Correo Electronico"></asp:Label>
                                        <asp:TextBox runat="server" ID="TextEmail" CssClass="form-control" placeholder="Correo Electronico"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-5">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LabelDominio" Text="Dominio"></asp:Label>
                                        <asp:TextBox runat="server" ID="TextDominio" CssClass="form-control" placeholder="Dominio"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-2">
                                    <div class="form-group">
                                        <asp:Label runat="server" ID="LabelNombreCorto" Text="Nombre Corto"></asp:Label>
                                        <asp:TextBox runat="server" ID="TexNombreCorto" CssClass="form-control" placeholder="Nombre Corto"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
                <div class="tab-pane" id="settings">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="inputName" class="col-sm-2 control-label">Nombre</label>

                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextNombreRep" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputEmail" class="col-sm-2 control-label">Correo Electronico</label>

                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextEmailRep" runat="server" class="form-control" placeholder="Correo Electronico"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputName" class="col-sm-2 control-label">RFC</label>

                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextRFCRep" runat="server" class="form-control" placeholder="R.F.C."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputExperience" class="col-sm-2 control-label">CURP</label>

                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextCURPRep" runat="server" class="form-control" placeholder="C.U.R.P."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputSkills" class="col-sm-2 control-label">Telefono</label>

                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextTelefonoRep" runat="server" class="form-control" placeholder="Telefono"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox">
                                            I agree to the <a href="#">terms and conditions</a>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <button type="submit" class="btn btn-danger">Submit</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="tab-pane" id="logos">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="inputName" class="col-sm-2 control-label">Nombre Imagen</label>

                                <div class="col-sm-10">
                                    <asp:TextBox ID="Text" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                                </div>
                            </div>

                            <%--<div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox">
                                            I agree to the <a href="#">terms and conditions</a>
                                        </label>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <button type="submit" class="btn btn-danger">Aceptar</button>
                                </div>
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
