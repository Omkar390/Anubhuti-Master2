
Imports System.Data

Partial Class SurveyTest
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            bindsurvey()
            Session("SurveyID") = "6"
        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.StackTrace + " - " + ex.Message
        End Try
    End Sub

    Protected Sub bindsurvey()

        Dim db As New DBHelperClient
        Dim strSql As String
        Dim dt As New DataTable
        Session("client_id") = "2"
        Session("dbname") = "2002"
        Session("SurveyId") = "6"


        strSql = "Select s.SurveyID,s.SurveyName,s.SurveyType,s.Description " &
         "from tblsurvey s"
        'rtpallsurvey.DataSource = db.DataAdapter(CommandType.Text, strSql)
        'rtpallsurvey.DataBind()
        dt = db.DataAdapter(CommandType.Text, strSql).Tables(0)
        rptallsurvey.DataSource = dt
        rptallsurvey.DataBind()
        If dt.Rows.Count = 1 Then
            Session("client_id") = dt.Rows(0).Item("client_id").ToString
            Session("dbname") = dt.Rows(0).Item("dbname").ToString
        End If
    End Sub

    Protected Sub rptallsurvey_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptallsurvey.ItemCommand

        Try


            If e.CommandName = "Pre" Then
                Response.Redirect("revquestion.aspx?SurveyID=" & e.CommandArgument, False)
            End If
        Catch ex As Exception
            lblErrorMessage.Text = "Sorry ... this page does not appear to be working. The error has been logged and we are reviewing it."
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.StackTrace + " - " + ex.Message
        End Try
    End Sub


End Class
