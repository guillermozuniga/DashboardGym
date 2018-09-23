<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logout.aspx.vb" Inherits="CapaPresentacion.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Refresh" content="5;url=<%=Page.ResolveClientUrl("~/")%>Dashboard.aspx" />
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <h1>Logout</h1>
            <p>
                
Se ha desconectado del sistema. Para iniciar sesión, vuelva a <a href="<%=Page.ResolveClientUrl("~/")%>default.aspx" target="_self">login page</a> , o espere 5 segundos para ser redireccionado.
            </p>
        </div>
    </form>
    <script type="text/javascript">
       //' document.execCommand('ClearAuthenticationCache');
    </script>
</body>
</html>
