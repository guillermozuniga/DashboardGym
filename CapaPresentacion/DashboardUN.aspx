<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="DashboardUN.aspx.vb" Inherits="CapaPresentacion.DashboardUN" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            var ctx = document.getElementById("salesChart").getContext('2d');
            $.ajax({
                url: "DashboardUN.aspx/getChartDataUN",
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

            <div class="col-lg-3 col-xs-6">
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
            <div class="col-lg-3 col-xs-6">
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
            <div class="col-lg-3 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h2>
                            <asp:Label ID="LabelPorVencer" runat="server" Text="0"></asp:Label></h2>

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


    <!-- Info boxes -->
    <div class="row">
        <!-- fix for small devices only -->
        <div class="clearfix visible-sm-block"></div>
        <div class="col-lg-12">
            <div class="box box-primary">
                <div class="box-header">
                    <h3 class="box-title" style="text-align: center">
                        <asp:Label ID="LabelTitulo" runat="server" Text="Label"></asp:Label></h3>
                </div>
                <div class="box-body">
                    <p class="text-center">
                        <strong>
                            <asp:Label ID="LabelTituloGrafica" runat="server" Text=""></asp:Label>

                        </strong>
                    </p>
                    <div class="chart">
                        <canvas id="salesChart" style="height: 250px; width: 1100px" height="250" width="1100"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </section>
</asp:Content>
