Imports System.Data
Imports System.Data.Common

Partial Class SurveyList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim strConnString As String = ConfigurationManager.AppSettings("DATA.CONNECTIONSTRING")
                Session("clientconnstring") = strConnString.Replace("client_master", ConfigurationManager.AppSettings("SMCLIENTDB"))

                'Show all surveys for logged in user!
                Dim db As New DBHelperClient
                Dim parms(0) As DBHelperClient.Parameters
                Dim ds1 As New DataSet
                'parms(0) = New DBHelperClient.Parameters("i_userid", Session("user_id"))
                parms(0) = New DBHelperClient.Parameters("i_userid", Session("user_id"))
                ds1 = db.DataAdapter(CommandType.StoredProcedure, "SP_GetSurveyListByUserid", parms)
                If ds1.Tables.Count > 0 Then
                    If ds1.Tables(0).Rows.Count > 0 Then
                        grdSurveyList.DataSource = ds1
                        grdSurveyList.DataBind()
                    End If
                End If
            End If

        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub

    Protected Sub initsurvey(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("surveypage.aspx?id=" + Session("surveyguid"), True)
    End Sub
End Class
