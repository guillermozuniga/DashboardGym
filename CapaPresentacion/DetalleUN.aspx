<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="DetalleUN.aspx.vb" Inherits="CapaPresentacion.DetalleUN" %>

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
                        <h3 class="box-title" style="text-align: center">Listado de Unidades de Negocio</h3>
                    </div>
                    <div class="box-body">

                        <asp:DataList ID="dlUNegocio" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="row">
                            <ItemTemplate>
                                <%-- <div class="row">--%>
                                <div class="col-sm-4">
                                    <!--THUMBNAIL#2-->
                                    <div class="panel-body">
                                        <span class="label label-info"><%# Eval("IDGimnasio")%></span>
                                        <div class="thumbnail label-success">
                                           <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/img/logo.png"%>' Width="100px" Height="100px" />
<%--                                           <asp:Image ID="Image2" runat="server" ImageUrl='<%# "~/" +Eval("image1").ToString().Trim() %>' Width="150px" Height="150px" />--%>
                                           <div class="caption">
                                                <h4>U. Negocio <small> <%# Eval("IDGimnasio")%></small></h4>
                                                <strong><%# Eval("Nombre")%></strong>
                                                <p>
                                                    <small>Nombre:<strong>  <%# Eval("NombreCorto")%> </strong> </small><%--<small>LB : <strong><%# Eval("IDGimnasio")%> m2</strong> </small>
                                                    <small>Setifikat : <strong><%# Eval("IDGimnasio")%></strong> </small>--%>
                                                    <br />
                                                   <%-- <small>Kamar : <strong><%# Eval("IDGimnasio")%></strong> </small>
                                                    <br />
                                                    <small>Kamar Mandi : <strong><%# Eval("IDGimnasio")%></strong> </small>--%>
                                                </p>
                                                <a href="DashboardUN.aspx" class="btn btn-success">Detalles</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--</div>--%>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
