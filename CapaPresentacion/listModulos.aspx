<%@ Page Title="Lista Modulos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="listModulos.aspx.vb" Inherits="CapaPresentacion.listModulos" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <style type="text/css">
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
    </style>
    <script type="text/javascript">
        $(function () {
            $('.collapse').on('shown.bs.collapse', function () {
                $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
            }).on('hidden.bs.collapse', function () {
                $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
            });
        });
        $(function () {
            $("#<%=gvmodulos.ClientID%> tr").hover(
                function () {
                    $(this).addClass('highlight');
                },
                function () {
                    $(this).removeClass('highlight');
                }
            );

            $("#<%= gvmodulos.ClientID%> td").hover(
                function () {
                    $(this).removeClass('highlight');
                    $(this).addClass('highlight-td');
                },
                function () {
                    $(this).removeClass('highlight-td');
                }
            );
        });

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
        <button id="btn_Nuevo" runat="server" onserverclick="btn_Nuevo_Click" class="btn btn-primary custom btn-sm-3"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
        <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " <%--style="display:none;"--%>><span class="glyphicon glyphicon-edit"></span>Editar</button>
        <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" <%--style="display:none;"--%>><span class="glyphicon glyphicon-erase"></span>Eliminar</button>

    </nav>


    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row col-lg-9">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <asp:Label runat="server" ID="LabelModulo" Text="Nombre Modulo" CssClass="control-label"></asp:Label>
                                <asp:TextBox runat="server" ID="Text_Banco" CssClass="form-control" placeholder="Nombre Banco"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <%--<asp:Label runat="server" ID="Label" Text="Clave"></asp:Label>
                                <asp:TextBox runat="server" ID="TextBox7" CssClass="form-control" placeholder="Clave"></asp:TextBox>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3">
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-7">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="container-fluid" style="width: 100%">
                    <asp:GridView ID="gvmodulos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" Style="width: 100%" ShowFooter="true">
                        <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Modulo_ID" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                        </Columns>
                        <EmptyDataRowStyle />
                        <EmptyDataTemplate>
                            <span>No hay registros para mostrar</span>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
