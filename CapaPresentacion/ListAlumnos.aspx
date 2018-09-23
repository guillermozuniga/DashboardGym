<%@ Page Title="Lista Alumnnos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListAlumnos.aspx.vb" Inherits="CapaPresentacion.ListAlumnos" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title %></label>
            </nav>
        </div>
    </div>

     <nav class="btn-toolbar text-center well-sm" id="MenuBar">
                    <%--   runat="server" onserverclick="btnNuevo_Click"--%>
                    <button id="Btn_Nuevo" onserverclick="Btn_Nuevo_Click" runat="server" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-plus"></span> Nuevo </button>
                    <button id="Btn_Editar" class="btn btn-primary custom btn-sm-3 " <%--style="display:none;"--%>><span class="glyphicon glyphicon-edit"></span> Editar</button>
                    <button id="Btn_Eliminar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-erase"></span> Eliminar</button>

             </nav>

    <div class="row">
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

                        <div class="form-group">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nombre" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="LabelCURP" runat="server" Text="CURP" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextCurp" runat="server" CssClass="form-control" PlaceHolder="CRUP"></asp:TextBox>
                            </div>
                        </div>


                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="btn_Buscar_Click">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="btn_Limpiar_Click">Limpiar </button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:GridView ID="gvAlumnos" CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Alumnos_Matricula" HeaderText="Matricula">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Alumnos_FechaDeNacimiento" dataformatstring="{0:d MMMM, yyyy}" htmlencode="false"  HeaderText="Fecha Nacimiento">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Alumnos_CURP" HeaderText="CURP">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

 <%--                           <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
                                EditText="<i aria-hidden='true' class='glyphicon glyphicon-pencil'></i>" DeleteText="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i>"
                                CancelText="<i aria-hidden='true' class='glyphicon glyphicon-remove'></i>" UpdateText="<i aria-hidden='true' class='glyphicon glyphicon-floppy-disk'></i>" />--%>
                        </Columns>
                         <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#001f3f" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
