<%@ Page Title="Ventas" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="wfventas.aspx.vb" Inherits="CapaPresentacion.wfventas" %>

<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
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
                fixedColumns:   {
                    heightMatch: 'none'
                },
                "pagingType": "full_numbers",
            "zeroRecords": "Nothing found - sorry",
            "infoEmpty": "No records available"          
            });
        });

        function SumarColumna(grilla, columna) {

            var resultVal = 0.0;

            $("#" + grilla + " tbody tr").not(':first').not(':last').each(
                function () {

                    var celdaValor = $(this).find('td:eq(' + columna + ')');

                    if (celdaValor.val() != null)
                        resultVal += parseFloat(celdaValor.html().replace(',', '.'));

                } //function

            ) //each

            $("#" + grilla + " tbody tr:last td:eq(" + columna + ")").html(resultVal.toFixed(2).toString().replace('.', ','));

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content wrapper">
        <section class="content-header">
            <p style="text-align: center">
                <asp:DropDownList ID="DropDownListunegocio" CssClass="btn btn-def" runat="server" Style="width: 50%" AutoPostBack="false"></asp:DropDownList>
            </p>
        </section>
        <section class="content">
            <div class="row">

                <!-- fix for small devices only -->
                <div class="clearfix visible-sm-block"></div>
                <div class="col-lg-5 col-md-5">

                    <!-- small box -->
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                        <asp:TextBox ID="txtFecha" Style="width: 80%" data-inputmask="'alias': 'dd/mm/yyyy'"
                            data-mask="" runat="server" CssClass="form-control" data-provide="datepicker"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-5 col-md-5">
                    <!-- small box -->
                    <div class="input-group">
                        <div class="input-group-addon">
                            <i class="fa fa-calendar"></i>
                        </div>
                        <asp:TextBox ID="TxtFechaFin" Style="width: 80%" data-inputmask="'alias': 'dd/mm/yyyy'"
                            data-mask="" runat="server" CssClass="form-control" data-provide="datepicker"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-2 col-md-5">
                    <!-- small box -->
                    <div class="info">
                        <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" />
                    </div>
                </div>
            </div>
            <br />


            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-solid">
                        <div class="box-header">
                            <i class="fa fa-table"></i>
                            <h5>Reporte de Ventas </h5>
                        </div>
                        <div class="container-fluid" style="width:100%">
                            <asp:GridView ID="gvVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" style="width:90%" ShowFooter="true">                  
                                <%--<AlternatingRowStyle BackColor="White" ForeColor="#284775" />--%>
                                <Columns>
                                    <asp:BoundField DataField="IDGimnasio" HeaderText="U.Negocio" />
                                    <asp:BoundField DataField="NombreCorto" HeaderText="Nombre"/>
                                    <asp:BoundField DataField="IDFolio" HeaderText="Folio"  />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Hora" HeaderText="Hora"  />
                                    <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:N2}"
        ItemStyle-HorizontalAlign="Right"  />
                                    <asp:BoundField DataField="IVA" HeaderText="IVA" DataFormatString="{0:N2}"
        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:N2}"
        ItemStyle-HorizontalAlign="Right" />
                                </Columns>

                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </section>
    </section>


</asp:Content>
