﻿<%@ Page Title="Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Dashboard.aspx.vb" Inherits="CapaPresentacion.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function number_format(amount, decimals) {

            amount += ''; // por si pasan un numero en vez de un string
            amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto

            decimals = decimals || 0; // por si la variable no fue fue pasada

            // si no es un numero o es igual a cero retorno el mismo cero
            if (isNaN(amount) || amount === 0)
                return parseFloat(0).toFixed(decimals);

            // si es mayor o menor que cero retorno el valor formateado como numero
            amount = '' + amount.toFixed(decimals);

            var amount_parts = amount.split('.'),
                regexp = /(\d+)(\d{3})/;

            while (regexp.test(amount_parts[0]))
                amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');

            return amount_parts.join('.');
        }

        $(function () {
            var ctx = document.getElementById("salesChart").getContext('2d');
            var ctxSocios = document.getElementById("UsersChart").getContext('2d');

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
                                fillColor: "rgba(220,220,220,0.2)",
                                strokeColor: "rgba(220,220,220,1)",
                                pointColor: "rgba(220,220,220,1)",
                                pointStrokeColor: "Green",
                                pointHighlightFill: "#fff",
                                pointHighlightStroke: "rgba(220,220,220,1)",
                                options: {
                                    responsive: true,
                                    scales: {
                                        xAxes: [{
                                            barPercentage: 0.95,
                                            stacked: true
                                        }],
                                        yAxes: [{
                                            barPercentage: 0.95,
                                            stacked: true
                                        }]
                                    },
                                    data: chartData
                                }
                        ]
                    };
                    var skillsChart = new Chart(ctx).Line(barData);
                    var total = 0;
                    for (var i = 0; i < chartData.length; i += 1) {
                        total = total + chartData[i];
                    }


                    <%--//document.getElementById("<%=LabelVentas.ClientID%>").innerHTML = number_format(total, 2)--%>
                }

            });

            $.ajax({
                url: "Dashboard.aspx/getChartDataSocios",
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
                                fillColor: "rgba(220,220,220,0.2)",
                                strokeColor: "rgba(220,220,220,1)",
                                pointColor: "rgba(220,220,220,1)",
                                pointStrokeColor: "Green",
                                pointHighlightFill: "#fff",
                                pointHighlightStroke: "rgba(220,220,220,1)",
                                barThickness: 60,
                                categoryPercentage: 0.8,
                                maintainAspectRatio: true,
                                options: {
                                    responsive: true,
                                    scales: {
                                        xAxes: [{
                                            barPercentage: 0.95,
                                            stacked: true
                                        }],
                                        yAxes: [{
                                            barPercentage: 0.95,
                                            stacked: true
                                        }]
                                    }
                                },
                                data: chartData
                            }
                        ]
                    };
                    var skillsChart = new Chart(ctxSocios).Bar(barData);
                    var total = 0;
                    for (var i = 0; i < chartData.length; i += 1) {
                        total = total + chartData[i];
                    }


                    <%-- document.getElementById("<%=LabelUsersGrafic.ClientID%>").innerHTML = number_format(total, 2)--%>
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
            <div class="col-lg-4">
                <!-- small box -->
                <div class="small-box bg-light-blue">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="LabelUnidadNegocio" runat="server" Text=""></asp:Label>1</h3>
                        <p>Alumnos</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-4">
                <!-- small box -->
                <div class="small-box bg-light-blue">
                    <div class="inner">
                        <h3>
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>1</h3>
                        <p>Maestros</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-man"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-4">
                <!-- small box -->
                <div class="small-box bg-light-blue">
                    <div class="inner">
                         <h3>
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>1</h3>
                        <p>Administrativos</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-android-contacts"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            
        </div>
        <%--<div class="row">

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

        </div>--%>
        <!-- /.row -->

        <%--        <div class="row">
            <div class="col-md-6">
                <div class="box box-info">
                    <div class="box-header with-border">
                        <div class="box-header with-border">
                            <i class="fa fa-line-chart"></i>
                            <h3 class="box-title">Reporte Mensual</h3>
                        </div>
                    </div>
                    <div class="box-body">
                        <p class="text-center">
                            <strong>
                                <asp:Label ID="LabelTituloGrafica" runat="server" Text=""></asp:Label></strong>
                            <strong>
                                <asp:Label ID="LabelSalesVentas" runat="server" Text=""></asp:Label></strong>
                        </p>
                        <div class="chart">
                            <!-- Sales Chart Canvas -->
                            <canvas id="salesChart" style="height: 300px; width: 520px;" width="520" height="300"></canvas>
                        </div>
                        <!-- /.chart-responsive -->
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="box box-success">
                    <div class="box-header with-border">
                        <div class="box-header with-border">
                            <i class="fa fa-line-chart"></i>
                            <h3 class="box-title">Reporte Diario</h3>
                        </div>
                    </div>
                    <div class="box-body">
                        <p class="text-center">
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></strong>
                            <strong>
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></strong>
                        </p>
                        <p class="text-center">
                            <strong>
                                <asp:Label ID="LabelUsersGrafic" runat="server" Text=""></asp:Label></strong>
                        </p>

                        <div class="chart">
                            <canvas id="UsersChart" style="height: 300px; width: 520px;" width="520" height="300"></canvas>
                        </div>
                        <!-- /.chart-responsive -->
                    </div>
                </div>
            </div>


        </div>--%>
        <div class="row">
            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-lg-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title" style="text-align: center">
                            <asp:Label ID="LabelTitulo" runat="server" Text="Grafica"></asp:Label></h3>
                    </div>
                    <div class="box-body">
                        <p class="text-center">
                            <strong>
                                <asp:Label ID="LabelTituloGrafica" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>

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
