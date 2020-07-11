
Imports System.Data
Imports System.Web.UI.HtmlControls
Imports System.Threading

Partial Class revquestion
    Inherits System.Web.UI.Page
    Private Sub revquestion_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbltest.Text = DateTime.Now.ToLocalTime()
        Try
            hdnSurveyID.Value = Request.QueryString("SurveyID")
            BindQuestions()
            'if we want to trigger click event from the page load
            'testbtn_Click(testbtn,New EventArgs())
        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.StackTrace + "-" + ex.Message
        End Try

    End Sub

    Private Sub testtimer_Tick(sender As Object, e As EventArgs) Handles testtimer.Tick
        '    'If testtimer.Interval = 5000 Then
        testtimer.Enabled = False
            lbltest.Visible = False
            '    'Else
        '    '    lbltest.Visible = True
        'End If

    End Sub


    Protected Sub testbtn_Click(sender As Object, e As EventArgs)
        testtimer.Enabled = True
        testtimer.Interval = 5000
        testtimer_Tick(testtimer, New EventArgs())
    End Sub


    Protected Sub BindQuestions()
        Try

            Dim strSql As String
            Dim db As New DBHelperClient
            Dim param(0) As DBHelperClient.Parameters
            param(0) = New DBHelperClient.Parameters("Surveyid", hdnSurveyID.Value)
            strSql = "select sq.surveyid,sq.qtext,sq.anstype " &
            " from tblsurveyquestion sq where surveyid=@Surveyid "
            Dim dt As New DataTable
            dt = db.DataAdapter(CommandType.Text, strSql, param).Tables(0)
            rptallsurvey.DataSource = dt
            rptallsurvey.DataBind()


            'If dt.Rows.Count = 1 Then
            '    Session("client_id") = dt.Rows(0).Item("client_id").ToString()
            '    Session("dbname") = dt.Rows(0).Item("dbname").ToString()
            'End If

        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.StackTrace + "-" + ex.Message
        End Try

    End Sub


End Class
