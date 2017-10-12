<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Dashboard.aspx.vb" Inherits="CapaPresentacion.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            var ctx = document.getElementById("salesChart").getContext('2d');

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
                                //label: chartLabel,
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
                    var total = 0;
                    for (var i = 0; i < chartData.length; i += 1) {
                        total = total + chartData[i];
                    }


                    document.getElementById("<%=LabelVentas.ClientID%>").innerHTML = total
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
            <div class="col-lg-6 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-blue">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="LabelUnidadNegocio" runat="server" Text=""></asp:Label></h3>
                        <p>Unidades de Negocio</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-home"></i>
                    </div>
                    <a href="DetalleUN.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-6 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="LabelVentas" runat="server" Text="0.00"></asp:Label><sup style="font-size: 20px">$</sup></h3>
                        <p>Ventas</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-cash"></i>
                    </div>
                    <a href="wfventas.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->

        </div>
        <div class="row">

            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-primary">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelSociosActivos" runat="server" Text="0"></asp:Label></h2>
                        <p>Socios Activos</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-stalker"></i>
                    </div>
                    <a href="wfsocios.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-orange">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelSociosNuevos" runat="server" Text="0"></asp:Label></h2>
                        <p>Socios Nuevos</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-add"></i>
                    </div>
                    <a href="wfsocios.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-primary">
                    <div class="icon">
                        <i class="ion ion-person"></i>
                    </div>
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelPorVencer" runat="server" Text=""></asp:Label></h2>

                        <p>Socios por Vencer</p>
                    </div>

                    <a href="wfsocios.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-orange">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelRenovados" runat="server" Text="0"></asp:Label></h2>
                        <p>Socios Renovados</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-stalker"></i>
                    </div>
                    <a href="wfsocios.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-primary">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelNoRenovados" runat="server" Text="0"></asp:Label></h2>
                        <p>Socios NO Renovaron</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-stalker"></i>
                    </div>
                    <a href="wfsocios.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-orange">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="Label2" runat="server" Text="0"></asp:Label></h2>
                        <p>Pendiente</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-stalker"></i>
                    </div>
                    <a href="wfsocios.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

        </div>
        <!-- /.row -->

        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <div class="box-header with-border">
                        <i class="fa fa-line-chart"></i>
                        <h4 class="box-title">
                            <asp:Label ID="LabelSalesVentas" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <!-- LINE CHART -->
                    <div class="box-body">
                        <p class="text-center">
                            <strong>
                                <asp:Label ID="LabelTituloGrafica" runat="server" Text=""></asp:Label></strong>
                        </p>
                        <div class="chart">
                            <canvas id="salesChart" style="height: 250px; width: 1100px" height="250" width="1100"></canvas>
                        </div>

                    </div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="box">
                    <!-- LINE CHART -->
                    <div class="box box-info">
                        <div class="box-header with-border">
                            <i class="fa fa-line-chart"></i>

                            <h4 class="box-title">

                                <asp:Label ID="LabelUsersGrafic" runat="server" Text=""></asp:Label></h4>
                            <%--<div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>
                            </div>--%>
                        </div>
                        <div class="box-body">
                            <div class="chart">
                                <canvas id="UsersChart" style="height: 250px" height="250" width="980"></canvas>
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->
                </div>

            </div>

        </div>


    </section>

</asp:Content>
