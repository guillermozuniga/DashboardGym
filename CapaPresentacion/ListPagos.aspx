<%@ Page Title="Lista Pagos" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterDefault.Master" CodeBehind="ListPagos.aspx.vb" Inherits="CapaPresentacion.ListPagos" %>
<%@ MasterType VirtualPath="~/MasterDefault.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <nav class="btn-toolbar text-left text-orange">
                <a href="#" data-toggle="sidebar"><span class="glyphicon glyphicon-option-vertical"></span></a>
                <label><%: Page.Title %></label>
            </nav>
        </div>
    </div>
    <%--runat="server" onserverclick="btnNuevo_Click"--%>
    <nav class="btn-toolbar text-center well-sm" id="MenuBar">
                    <button id="btn_Nuevo" class="btn btn-primary custom btn-sm-3" style="display:none;"><span class="glyphicon glyphicon-plus"></span>Nuevo </button>
                    <button id="btn_Editar" class="btn btn-primary custom btn-sm-3 " style="display:none;"><span class="glyphicon glyphicon-edit"></span>Editar</button>
                    <button id="btn_Eliminar" class="btn btn-primary custom btn-sm-3" style="display:none;"><span class="glyphicon glyphicon-erase"></span>Eliminar</button>
        </nav>
    <div class="row">
        <div class="col-xs-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="LabelMatricula" runat="server" Text="Matricula" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Text_Matricula" runat="server" CssClass="form-control" placeholder="Matricula"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelTutor" runat="server" Text="Tutor" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Text_Tutor" runat="server" CssClass="form-control" placeholder="Tutor"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">

                        <div class="form-group">
                            <asp:Label ID="LabelRazonSocial" runat="server" Text="Razon Social" CssClass="control-label col-sm-4 "></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Text_RazonSocial" runat="server" CssClass="form-control" placeholder="Razon Social"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="LabelNombre" runat="server" Text="Nom. Alumno" CssClass="control-label col-sm-4"></asp:Label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="Text_NombreAlumno" runat="server" CssClass="form-control" placeholder="Nombre Alumno"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Limpiar" class="btn btn-primary custom btn-sm-3" runat="server">Buscar </button>

                        </div>
                        <div class="form-group">
                            <div class="col-sm-8">
                            </div>
                            <button id="btn_Buscar" class="btn btn-primary custom btn-sm-3" runat="server">Limpiar </button>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="container-fluid" style="width: 100%">
                        <asp:GridView ID="gdvPagos" CssClass="table table-bordered" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="50" EmptyDataText="No hay registros para mostrar." runat="server">
                         <AlternatingRowStyle BackColor="WhiteSmoke" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Cargos_Id" HeaderText="ID" >
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                   </asp:BoundField>

                                <asp:BoundField DataField="Cargos_Matricula" HeaderText="Matricula" >
                                    <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                   </asp:BoundField>

                               <asp:BoundField DataField="Cargos_CicloEscolar" HeaderText="CicloEscolar" >
                                <HeaderStyle Font-Names="Arial" Font-Size="12px" ForeColor="white" />
                                   </asp:BoundField>

                               <%--  <asp:BoundField DataField="Cargos_FechaVencimiento" HeaderText="Fecha Vencimiento" />
                                <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:N2}"
                                    ItemStyle-HorizontalAlign="Right" />--%>

                            </Columns>
                             <PagerSettings Mode="NumericFirstLast" PageButtonCount="8" FirstPageText="Primero" LastPageText="Ultimo" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#001f3f" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
