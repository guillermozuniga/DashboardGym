<%@ Page Title="Familias" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListFamilias.aspx.vb" Inherits="CapaPresentacion.ListFamilias" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <style type = "text/css">
        .HoverRow{background-color:WhiteSmoke}
        .SelectedRow{background-color:#B0C4DE}
        .FijarRow{background-color:gray}
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=gvFamilias] tr').not($('[id*=gvFamilias] tr').hasClass("SelectedRow")).not($('[id*=gvFamilias] tr:first-child')).hover(function () {
                $(this).addClass('HoverRow'); /* HoverRow is a css class Here i apply background color */
            }, function () {
                $(this).removeClass('HoverRow');
            }).click(function () {
                $('[id*=gvFamilias] tr').removeClass("SelectedRow");
                $(this).addClass('SelectedRow');
            });
        });
    </script>--%>
    <style type="text/css">
         .scrolling-table-container {
    height: 378px;
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
    <%--style="display:none;"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
        <button id="Btn_Nuevo" onserverclick="Btn_Nuevo_Click" runat="server" class="btn btn-primary custom btn-sm-3" ><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="Btn_Editar" onserverclick="Btn_Editar_Click" runat="server" class="btn btn-primary custom btn-sm-3 "><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="Btn_Eliminar" onserverclick="Btn_Eliminar_Click" runat="server" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelFirstName" runat="server" Text="Nombre" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextFirstName" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelLastName" runat="server" Text="Apellido" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextLastName" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="LabelRFC" runat="server" Text="R.F.C." CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextRFC" runat="server" CssClass="form-control" placeholder="RFC"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelCURP" runat="server" Text="CURP" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextCURP" runat="server" CssClass="form-control" placeholder="CURP"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="Btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Buscar_Click">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="Btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server" onserverclick="Btn_Limpiar_Click">Limpiar </button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
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
                    <h4 class="panel-title">Información de Alumnos</h4>
                </div>
                <div class="panel-body">
                    <div class="scrolling-table-container">
                        <asp:GridView ID="gvFamilias" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="25" EmptyDataText="No hay registros para mostrar." runat="server" DataKeyNames="Tutores_Tutor">
                            <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Tutores_Tutor" HeaderText="Tutor ID">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:BoundField DataField="NombreMama" HeaderText="Nombre Mama" HtmlEncode="False">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <asp:BoundField DataField="NombrePapa" HeaderText="Nombre Papa" HtmlEncode="False">
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                </asp:BoundField>

                                <%--                            <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true"
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
