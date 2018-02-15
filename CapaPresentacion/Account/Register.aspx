<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="CapaPresentacion.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Concentrador Web | Registration Page</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../css/AdminLTE.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="../plugins/iCheck/square/blue.css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition login-page">
    <div class="form-box" id="login-box">
        <div class="header">Forma de Registro</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />
                 
                <div class="form-group has-feedback">
                    <asp:TextBox ID="TextBoxFullName" runat="server" CssClass="form-control" placeholder="Nombre de usuario ..." ToolTip="ingresa un nombre de usuario"></asp:TextBox>
                    <span class="glyphicon glyphicon-user form-control-feedback"></span>
                </div>

                <div class="form-group has-feedback">
                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" placeholder="Email ..." ToolTip="Ingresa un Email" TextMode="Email"></asp:TextBox><span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="TextBoxContrasena" runat="server" CssClass="form-control" placeholder="Contraseña ..." TextMode="Password" ToolTip="Ingresa una contraseña"></asp:TextBox>
                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <asp:TextBox ID="TextBoxConfirmacion" runat="server" CssClass="form-control" placeholder="Confirmación " TextMode="Password" ToolTip="Ingresa una contraseña"></asp:TextBox>
                <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                    <a href="../Login.aspx" class="text-right">Cuento con clave de acceso</a>
                </div>               
            </div>
            <div class="footer">
                    <asp:Button ID="ButtonRegistrar" runat="server" Text="Registrar" CssClass="btn bg-olive btn-block" OnClick="RegisterUser" />
                </div>
        </form>
    </div>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

</body>
</html>
