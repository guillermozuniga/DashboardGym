<%@ Page Title="Cargos" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListCargos.aspx.vb" Inherits="CapaPresentacion.ListCargos" Culture="es-MX" UICulture="es-MX" %>

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
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
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
                        <asp:Label ID="Label1" runat="server" Text="Fecha" CssClass="control-label col-sm-3"></asp:Label>
                        <div class="input-group">
                            <div class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </div>
                            <asp:TextBox ID="TextFecha" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask="" runat="server" CssClass="form-control" data-provide="datepicker"></asp:TextBox>

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


    <div class="row" id="ListaAlumnos" runat="server" visible="false">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading"><strong>Listado </strong>Alumnos </div>
                <div class="panel-body">
                    <asp:GridView ID="GvAlum" CssClass="table table-bordered" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="10" EmptyDataText="No hay registros para mostrar. Selecciona un alumno" runat="server" EnablePersistedSelection="True" DataKeyNames="Alumnos_Matricula">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>

                            <asp:BoundField DataField="Alumnos_Id" Visible="False" />

                            <asp:BoundField DataField="Alumnos_Matricula" HeaderText="Matricula">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
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

    <div class="row">
        <%--        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title %></label>
            </nav>
        </div>--%>

        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="btn-group pull-right">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default btn-xs"></asp:DropDownList>

                    </div>

                    <div class="btn-group pull-right">
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-print fa-xs"></span> Print</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> PDF</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> Excel</a>
                    </div>
                    <h4 class="panel-title">Información de Cargos</h4>
                </div>
                <div class="panel-body">
                    <%-- <h2 class="headline text-yellow">Pagos</h2>--%>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />

                    <%-- <p runat="server" id="panel1" class="text-left text-info text-justify">"Selecciona el Alumno haciendo click sobre su Nombre"</p>--%>

                    <div class="scrolling-table-container">
                        <asp:GridView ID="gvCargos" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="25" EmptyDataText="No hay registros para mostrar." runat="server" DataKeyNames="Cargos_Id">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>
                                <%--                                <asp:TemplateField HeaderText="Seleccion">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSeleccion" runat="server" CssClass="controlSeleccion" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%#(gvCargos.PageSize * gvCargos.PageIndex) + gvCargos.Rows.Count + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="black" />
                            </asp:TemplateField>--%>

                                <asp:BoundField DataField="Cargos_Id" HeaderText="ID" Visible="false">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cargos_Matricula" HeaderText="Matricula">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cargos_Nombre" HeaderText="Nombre">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cargos_CicloEscolar" HeaderText="CicloEscolar">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cargos_Descripcion" HeaderText="Concepto">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <%--<asp:BoundField DataField="Cargos_Referencia" HeaderText="Referencia">                               
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>--%>

                                <asp:TemplateField HeaderText="Referencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReferenciaBanco"
                                            runat="server"
                                            Text='<%# "" + Eval("Cargos_Referencia").ToString()%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:TemplateField>


                                <asp:BoundField DataField="Cargos_FechaVencimiento" DataFormatString="{0:d MMMM, yyyy}" HtmlEncode="false" HeaderText="Fecha Vencimiento">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Cargos_Importe" HeaderText="Importe" DataFormatString="{0:N2}"
                                    ItemStyle-HorizontalAlign="Right">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkGenerar"
                                            runat="server"
                                            CommandName="GENERAR"
                                            ToolTip="Imprimir Recibo"
                                            Class="btn btn-success btn-raised btn-xs zmdi zmdi-refresh"
                                            Text="">
                                            <span class="glyphicon glyphicon-print"></span>                         
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Btnpagotarjeta" OnClientClick="targetMeBlank()"
                                            runat="server"
                                            CommandName="EnLinea"
                                            ToolTip="Pago en Linea"
                                            CommandArgument='<%# Eval("Cargos_Descripcion") + "/" + Eval("Cargos_Referencia") + "@" + CType(Eval("Cargos_Importe"), String)%>'
                                            Class="btn btn-danger btn-raised btn-xs zmdi zmdi-refresh">
                                            <span class="glyphicon glyphicon-shopping-cart"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnfactura"
                                            runat="server"
                                            CommandName="Facturar"
                                            ToolTip="Generar Factura"
                                            Class="btn btn-warning btn-raised btn-xs zmdi zmdi-refresh"
                                            Text="">
                                            <span class="glyphicon glyphicon-inbox"></span>                      
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

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
