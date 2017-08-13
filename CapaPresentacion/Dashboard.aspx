<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="Dashboard.aspx.vb" Inherits="CapaPresentacion.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <!-- Info boxes -->
        <div class="row">
            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-aqua">
                    <div class="inner">
                        <h2>150</h2>
                        <p>Unidades de Negocio</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-home"></i>
                    </div>
                    <a href="wfunegocio.aspx" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-fuchsia">
                    <div class="inner">
                        <h2>10000</h2>

                        <p>Numero de Socios</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-person-add"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h2>100,000<sup style="font-size: 20px">%</sup></h2>

                        <p>Ventas</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-cash"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <!-- ./col -->
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-blue">
                    <div class="inner">
                        <h2>44</h2>

                        <p>Socios Nuevos</p>
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
                <div class="small-box bg-red">
                    <div class="inner">
                        <h2>65</h2>

                        <p>Venta Productos</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-cash"></i>
                    </div>
                    <a href="#" class="small-box-footer">Mas Información <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>
            <div class="col-lg-2 col-xs-6">
                <!-- small box -->
                <div class="small-box bg-orange">
                    <div class="inner">
                        <h2>65</h2>

                        <p>Venta Cuotas</p>
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
    </section>
    <section class="content">
         <div class="col-md-12">
                <div class="box box-info">
                    <div class="box-header">
                        <h3 class="box-title">Estadistica Ventas</h3>
<%--                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>--%>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <p class="text-center">
                                    <%--<strong>Donativos: 1 Jan, 2014 - 30 Jul, 2014</strong>--%>
                                    <strong>
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></strong>
                                </p>

                                <div class="chart">
                                    <!-- Sales Chart Canvas -->
                                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                                    <canvas id="salesChart" style="height: 200px;"></canvas>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </div>
    </section>

    <section class="content">
         <div class="col-md-12">
                <div class="box box-info">
                    <div class="box-header with-border">
                        <h3 class="box-title">Estadistica Ventas</h3>

<%--                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                <i class="fa fa-minus"></i>
                            </button>
                        </div>--%>
                    </div>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <p class="text-center">
                                    <%--<strong>Donativos: 1 Jan, 2014 - 30 Jul, 2014</strong>--%>
                                    <strong>
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></strong>
                                </p>

                                <div class="chart">
                                    <!-- Sales Chart Canvas -->
                                    <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                                    <canvas id="UsersChart" style="height: 200px;"></canvas>
                                </div>
                                <!-- /.chart-responsive -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </div>
    </section>
</asp:Content>
