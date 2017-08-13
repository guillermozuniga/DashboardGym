<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Acceso.aspx.vb" Inherits="CapaPresentacion.Acceso" %>

<!DOCTYPE html>

<html class="bg-black" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Concentrador Web</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />

</head>
<body class="hold-transition login-page bg-black">

    <div class="form-box" id="login-box">
        <div class="header">Login</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                <div class="form-group has-feedback">

                    <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="form-control" placeholder="Email ..." ToolTip="Ingresa un Email" TextMode="Email"></asp:TextBox>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>

                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="TextBoxContrasena" runat="server" CssClass="form-control" placeholder="Contraseña ..." TextMode="Password" ToolTip="Ingresa una contraseña"></asp:TextBox>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>

                </div>

                <div class="row">
                    <div class="col-xs-6">
                        <div class="checkbox icheck">
                            <label>
                                <asp:CheckBox ID="chkRememberMe" runat="server" Text="Recordarme" />
                            </label>
                        </div>
                    </div>
                    <div class="col-xs-6">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="footer">
                <asp:Button ID="ButtonIngresar" runat="server" Text="Iniciar Sesión" CssClass="btn bg-olive btn-block" />
            </div>

            <a href="Account/Registro.aspx" class="text-center">Registrar un nuevo miembro</a>
        </form>
    </div>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

</body>
</html>
