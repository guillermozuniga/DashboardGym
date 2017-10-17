<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="wfsocios.aspx.vb" Inherits="CapaPresentacion.wfsocios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <!-- Info boxes -->
        <div class="row">
            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-lg-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title" style="text-align: center">Detalle Socios por Unidad de Negocio</h3>
                    </div>
                    <div class="box-body">                        
                        <div class="box-body table-responsive">
                            <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="IDGimnasio" HeaderText="U.Negocio" SortExpression="IDGImnasio" />
                                    <asp:BoundField DataField="IDCliente" HeaderText="Numero de Socio" SortExpression="IDCliente" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                    <asp:BoundField DataField="FechaUltimoPago" HeaderText="Fecha de Pago" />
                                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha de Vencimiento" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
               
                </div>
            </div>
        </div>
    </section>
</asp:Content>
