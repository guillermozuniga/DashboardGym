<%@ Page Title="Lista Tareas" Language="vb"  EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="listTareas.aspx.vb" Inherits="CapaPresentacion.listTareas" %>

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
    
    <%--runat="server" onserverclick="btnNuevo_Click"  style="display: none;"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar" runat="server">
        <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3" ><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " ><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" ><span class="glyphicon glyphicon-erase"></span>Eliminar</button>
    </nav>

    <div class="row" id="MenuSelect" runat="server">
        <div class="col-xs-12">
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

                        <div class="form-group">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nom. Alumno" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextNombreAlumno" runat="server" CssClass="form-control" placeholder="Nombre Alumno"></asp:TextBox>
                            </div>
                        </div>


                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="Btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="row" id="ListaAlumnos" runat="server" visible="false">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                   <h4 class="headline text-yellow">Alumnos</h4>
                    <asp:GridView ID="GvAlum" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server" EnablePersistedSelection="True" DataKeyNames="Alumnos_Matricula">
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
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title %></label>
            </nav>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">

                <div class="panel-body">

                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <div class="scrolling-table-container">
                        <asp:GridView ID="gvInsidencias" CssClass="table table-bordered" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server" DataKeyNames="Cargos_Id">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>

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
                                    <ItemStyle HorizontalAlign="Center" />
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



                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" FirstPageText="Primero" LastPageText="Ultimo" />
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
