Public Class FileNotFound
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim errMessage As System.Text.StringBuilder =
        New System.Text.StringBuilder()
        Dim appException As System.Exception = Server.GetLastError()
        If (TypeOf (appException) Is HttpException) Then
            Dim checkException As HttpException =
                CType(appException, HttpException)
            Select Case checkException.GetHttpCode
                Case 403
                    errMessage.Append(
                        "You are not allowed to view that page.")
                Case 404
                    errMessage.Append(
                        "The page you requested cannot be found.")
                Case 408
                    errMessage.Append(
                        "The request has timed out.")
                Case 500
                    errMessage.Append(
                      "The server cannot fulfill your request.")
                Case Else
                    errMessage.Append(
                      "The server has experienced an error.")
            End Select
        Else
            ' The exception was not an HttpException.
            errMessage.AppendFormat(
              "The following error occurred<br />{0}",
                  appException.ToString)
        End If
        errMessage.Append("<br />Please contact the server administrator.")
        Label1.Text = errMessage.ToString()
        Server.ClearError()
    End Sub

End Class