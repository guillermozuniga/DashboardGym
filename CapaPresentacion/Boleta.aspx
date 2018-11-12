<%@ Page Title="Calificaciones" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Boleta.aspx.vb" Inherits="CapaPresentacion.Boleta" Culture="es-MX" UICulture="es-MX" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function targetMeBlank() {
            document.forms[0].target = "_blank";
        }
    </script>
    <style type="text/css">
        .scrolling-table-container {
            height: 350px;
            overflow-y: scroll;
            overflow-x: hidden;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- style="display: none;"--%>
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-danger">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title.ToUpper %></label>
            </nav>
        </div>
    </div>

    <nav class="btn-toolbar text-center well-sm" id="MenuBar" runat="server">
        <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3" style="display: none;"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " style="display: none;"><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" style="display: none;"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>
    </nav>

    <div class="row" id="MenuSelect" runat="server">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelMatricula" runat="server" Text="Matricula" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextMatricula" runat="server" CssClass="form-control" placeholder="Matricula"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="input-group">
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Buscar_Click">Buscar </button>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Limpiar_Click">Limpiar </button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="row" id="ListaAlumnos" runat="server">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading"><strong>Listado </strong>Alumnos </div>
                <div class="panel-body">
                    <asp:GridView ID="GvAlum" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="10" EmptyDataText="No hay registros para mostrar. Selecciona un Alumno" runat="server" EnablePersistedSelection="True" DataKeyNames="Alumnos_Matricula">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>

                            <asp:BoundField DataField="Alumnos_Id" Visible="False" />

                            <asp:BoundField DataField="Alumnos_Matricula" HeaderText="Matricula">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HtmlEncode="False">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Alumnos_NombreNivel" HeaderText="Nivel">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Alumnos_GrupoGrado" HeaderText="Grupo ">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Alumnos_FechaDeNacimiento" DataFormatString="{0:d MMMM, yyyy}" HtmlEncode="false" HeaderText="Fecha Nacimiento">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                        </Columns>

                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" FirstPageText="Primero" LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#001f3f" />
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>


    <nav class="btn-toolbar text-center well-sm" id="Nav1" runat="server">
        <%--<button id="Btn_Imprimir" type="button" runat="server" class="btn btn-primary custom btn-sm-3" onserverclick="Btn_Imprimir_Click"><span class="glyphicon glyphicon-print"></span>Boleta </button>--%>
    </nav>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                 <div class="panel-heading">
                    <div class="btn-group pull-right">
                        <button id="Btn_Imprimir" type="button" runat="server" class="btn btn-default btn-xs" onserverclick="Btn_Imprimir_Click"><span class="fa fa-print fa-xs"></span> Boleta </button>
                       
                      <%--  <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> PDF</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> Excel</a>--%>
                    </div>
                    <h4 class="panel-title">Información de Calificaciones</h4>
                </div>
                <div class="panel-body">
                    <%-- <h2 class="headline text-yellow">Pagos</h2>--%>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />

                    <%-- <p runat="server" id="panel1" class="text-left text-info text-justify">"Selecciona el Alumno haciendo click sobre su Nombre"</p>--%>

                    <div class="scrolling-table-container">
                        <asp:GridView ID="GVBoleta" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar. Selecciona un Alumno" runat="server" DataKeyNames="Boleta_Matricula">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>

                                <asp:BoundField DataField="Boleta_Matricula" HeaderText="ID">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Boleta_NombreMateria" HeaderText="FORMACION ACADEMICA">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Boleta_Evaluacion1" HeaderText="SEP">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Boleta_Evaluacion2" HeaderText="OCT">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField  HeaderText="NOV">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="P1">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="DIC">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ENE">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="FEB">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="MAR">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="P2">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ABR">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="MAY">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="JUN">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="P3">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="PF">
                                    <HeaderStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#001f3f" />

                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
