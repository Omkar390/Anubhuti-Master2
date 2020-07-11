Imports System.Data

Partial Class SurveyAssigned
    Inherits System.Web.UI.Page

    Private Sub SurveyAssigned_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Private Sub lnkSurveyList_ServerClick(sender As Object, e As EventArgs) Handles lnkSurveyList.ServerClick
        Response.Redirect("SurveyList.aspx?userid=" & Session("user_id"))
    End Sub
End Class
