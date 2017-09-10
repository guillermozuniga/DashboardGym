<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Dashboard.aspx.vb" Inherits="CapaPresentacion.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            var ctx = document.getElementById("SalesChart").getContext('2d');
            $.ajax({
                url: "Dashboard.aspx/getChartData",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var chartLabel = eval(response.d[0]); //Labels
                    var chartData = eval(response.d[1]); //Data
                    var barData = {
                        labels: chartLabel,
                        datasets: [
                            {
                                label: '',
                                fillColor: "rgba(225,225,225,0.2)",
                                strokeColor: "Blue",
                                pointColor: "rgba(220,220,220,1)",
                                pointStrokeColor: "Green",
                                pointHighlightFill: "#fff",
                                pointHighlightStroke: "rgba(220,220,220,1)",
                                data: chartData
                            }
                        ]
                    };
                    var skillsChart = new Chart(ctx).Line(barData);
                }

            });
        }
        );

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content">
        <!-- Info boxes -->

        <div class="row">

            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-aqua">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelUnidadNegocio" runat="server" Text=""></asp:Label></h2>
                        <p>Unidades de Negocio</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-home"></i>
                    </div>
                    <a href="DetalleUN.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-orange">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelSociosActivos" runat="server" Text="0"></asp:Label></h2>
                        <p>Socios Activos</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-stalker"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-blue">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelSociosNuevos" runat="server" Text="0"></asp:Label></h2>

                        <p>Nuevos Socios</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-add"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelPorVencer" runat="server" Text=""></asp:Label></h2>

                        <p>Socios que Vencen</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelVentas" runat="server" Text="0.00"></asp:Label><sup style="font-size: 20px">$</sup></h2>
                        <p>Ventas</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-cash"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->


        </div>
        <!-- /.row -->


        <div class="row">
            <div class="col-md-12">
                <div class="box">
<%--                    <div class="box-header with-border">
                        <h3 class="box-title">Monthly</h3>
                    </div>--%>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <!-- LINE CHART -->
                                <div class="box box-solid">
                                    <div class="box-header ui-sortable-handle" style="cursor: move;">
                                        <i class="fa fa-th"></i>
                                        <h3 class="box-title">
                                            <asp:Label ID="LabelSalesVentas" runat="server" Text=""></asp:Label></h3>
                                        <div class="box-tools pull-right">
                                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                <i class="fa fa-minus"></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class="box-body">
                                        <div class="chart">
                                            <canvas id="SalesChart" style="height: 242px; " height="242" width="920"></canvas>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                                </div>
                                <!-- /.box -->
                            </div>

                            
                        </div>
                         <div class="row">
                            

                            <div class="col-md-12">
                                <!-- LINE CHART -->
                                <div class="box box-info">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h3>

                                        <div class="box-tools pull-right">
                                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                <i class="fa fa-minus"></i>
                                            </button>

                                        </div>
                                    </div>
                                    <div class="box-body">
                                        <div class="chart">
                                            <canvas id="UsersChart" style="height: 250px"></canvas>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                                </div>
                                <!-- /.box -->
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

     
    </section>

</asp:Content>
