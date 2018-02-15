<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="DetalleUN.aspx.vb" Inherits="CapaPresentacion.DetalleUN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $.extend(true, $.fn.dataTable.defaults, {
            "searching": true,
            "ordering": true
        });
        $(function () {
            $('[id*=gvVentas]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                //"info": false,
                "pageLength": 25,
                fixedColumns: {
                    heightMatch: 'none'
                },
                "pagingType": "full_numbers",
                "zeroRecords": "Nothing found - sorry",
                "infoEmpty": "No records available"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <!-- Custom tabs (Charts with tabs)-->
        <div class="nav-tabs-custom">
            <!-- Tabs within a box -->
            <ul class="nav nav-tabs pull-right">        
                
                <li class="active"><a href="#revenue-chart" data-toggle="tab"><i class="fa fa-square"></i></a></li>               
                <li><a href="#sales-chart" data-toggle="tab"><i class="fa fa-reorder"></i></a></li>
                <li class="pull-left header"><i class="fa fa-inbox"></i>Unidades de Negocio</li>
            </ul>
            <div class="tab-content no-padding">
                <!-- Morris chart - Sales -->
                <div class="chart tab-pane active" id="revenue-chart" style="position: relative;">
                    <asp:DataList ID="dlUNegocio" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                        <ItemTemplate>
                            <%-- <div class="row">--%>
                            <div class="col-sm-4">
                                <!--THUMBNAIL#2-->
                                <div class="panel-body">
                                    <span class="label label-info"><%# Eval("IDGimnasio")%></span>
                                    <div class="thumbnail label-success">
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/img/logo.png"%>' Width="85px" Height="85px" />
                                        <p style="text-align: center"><%# Eval("Nombre")%> </p>
                                        <p><strong>Negocio: </strong><small><%# Eval("NombreCorto")%></small></p>
                                        <p><strong>Nombre: </strong><small><%# Eval("NombreSucursal")%> </small></p>
                                        <%--'<a href="  <%# Eval("IdGimnasio", "DashboardUN.aspx?Id={0}")%>"  class="btn btn-success">Detalles</a>--%>
                                         <a href=" <%# String.Format("DashboardUN.aspx?Id={0}&Name={1}",
HttpUtility.UrlEncode(Eval("IdGImnasio").ToString()), HttpUtility.UrlEncode(Eval("NombreSucursal").ToString()))%>"
                                            class="btn btn-success">Detalles</a>


                                    </div>
                                </div>
                            </div>
                            <%--</div>--%>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="chart tab-pane" id="sales-chart" style="position: relative;">

                    <asp:GridView ID="gvGimnasios" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" CellSpacing="0">
                        <%--<AlternatingRowStyle BackColor="White" ForeColor="#284775" />--%>
                        <Columns>
                            <asp:BoundField DataField="IDGimnasio" HeaderText="U.Negocio" />
                            <asp:BoundField DataField="NombreCorto" HeaderText="Nombre Corto" />
                            <asp:BoundField DataField="NombreSucursal" HeaderText="Nombre" />
                            <asp:TemplateField HeaderText="Selecciona">
                                <ItemTemplate>
                                   <a href=" <%# String.Format("DashboardUN.aspx?Id={0}&Name={1}",
HttpUtility.UrlEncode(Eval("IdGImnasio").ToString()), HttpUtility.UrlEncode(Eval("NombreSucursal").ToString()))%>"
                                            class="btn btn-success">Detalles</a>
                                </ItemTemplate>
                                <ItemStyle Width="68px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>

    </section>

</asp:Content>
