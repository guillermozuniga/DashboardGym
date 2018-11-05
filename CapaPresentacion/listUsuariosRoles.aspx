<%@ Page Title="List Usuario Role" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="listUsuariosRoles.aspx.vb" Inherits="CapaPresentacion.listUsuariosRoles" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <style type="text/css">
        .highlight {
            background-color: #F7F5CB;
        }

        .highlight-td {
            background-color: #E5DE78;
        }

        td {
            cursor: pointer;
        }

        a.five:link {
            color: #ff0000;
            text-decoration: none;
        }

        a.five:visited {
            color: #0000ff;
            text-decoration: none;
        }

        a.five:hover {
            text-decoration: underline;
        }
    </style>--%>
    <script type="text/javascript">
        <%--$(function () {
            $('.collapse').on('shown.bs.collapse', function () {
                $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hidden.bs.collapse', function () {
                $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });
        });
        $(function () {
            $("#<%=gvUsauriosRoles.ClientID%> tr").hover(
                function () {
                    $(this).addClass('highlight');
                },
                function () {
                    $(this).removeClass('highlight');
                }
            );

            $("#<%= gvUsauriosRoles.ClientID%> td").hover(
                function () {
                    $(this).removeClass('highlight');
                    $(this).addClass('highlight-td');
                },
                function () {
                    $(this).removeClass('highlight-td');
                }
            );
        });--%>

       <%-- $(document).ready(function () {
            var gvUsers = $("#<%= GvUsuarios.ClientID%>").prepend($("<thead></thead>").append($("#<%= GvUsuarios.ClientID%>").find("tr:first"))).DataTable();

            $('input[type=search]').on("keyup", function () {
                // Search only in FileName column i.e. Column 1.
                gvUsers.column(1).search($(this).val()).draw();

                var searchTerm = $(this).val();
                $(".forHighlight").each(function () {
                    var searchPattern = new RegExp('(' + searchTerm + ')', 'ig');
                    $(this).html($(this).text().replace(searchPattern, "<span class = 'highlight'>" + searchTerm + "</span>"));
                });
            });
        });--%>
</script>
    <script type="text/javascript">
        //$.extend(true, $.fn.dataTable.defaults, {
        //    "searching": true,
        //    "ordering": true
        //});

        //$(function () {
        //    $('[id*=gdvCargos]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
        //        "responsive": true,
        //        //"info": true,
        //        "pageLength": 50,
        //        fixedColumns: {
        //            heightMatch: 'none'
        //        },
        //        "pagingType": "full_numbers",
        //        "zeroRecords": "Nothing found - sorry",
        //        "infoEmpty": "No records available"
        //    });
        //});
    </script>
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
        <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " <%--style="display:none;"--%>><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelRole" runat="server" Text="Role" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextRole" runat="server" CssClass="form-control" placeholder="Role"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="col-lg-4 form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="LabelUsuario" runat="server" Text="Usuario" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="TextUsuario" runat="server" CssClass="form-control" PlaceHolder="Usuario"></asp:TextBox>
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
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-print fa-xs"></span> Print</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> PDF</a>
                        <a href="#" class="btn btn-default btn-xs"><span class="fa fa-file-pdf-o fa-xs"></span> Excel</a>
                    </div>
                    <h4 class="panel-title">Información de Usuarios - Roles</h4>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvUsauriosRoles" CssClass="table table-bordered table-hover table-condensed small-top-margin" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="RoleName" HeaderText="Nombre Role">
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                            </asp:BoundField>

                            <asp:BoundField DataField="UserName" HeaderText="Nombre Usuario">
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
