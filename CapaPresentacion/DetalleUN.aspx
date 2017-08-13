<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="DetalleUN.aspx.vb" Inherits="CapaPresentacion.DetalleUN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            width: 200px;
        }
        .table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: bold;
        }
        .table th, .table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h2 style="text-align: center">Unidades de Negocio</h2>
    </section>
    <section class="content">
        <!-- Info boxes -->
        <div class="row">
            <!-- fix for small devices only -->
            <div class="clearfix visible-sm-block"></div>
            <div class="col-lg-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <asp:DataList ID="dlUnidadesNegocio" Width="100%" runat="server" RepeatColumns="3" CellSpacing="3" RepeatLayout="Table">
                            <ItemTemplate>
                                <table class="table">
                                    <tr>
                                        <th colspan="2">
                                            <b><%# Eval("NombreSucursal")%></b>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <%# Eval("Direccion")%>,
                    <%# Eval("PrefijoFolio") %><br />
                                            <%# Eval("IDGimnasio")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Phone:
                                        </td>
                                        <td>
                                            <%# Eval("NombreCorto")%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Fax:
                                        </td>
                                        <td>
                                            <%# Eval("IDGimnasio")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
