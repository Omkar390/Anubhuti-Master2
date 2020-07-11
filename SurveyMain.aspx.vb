Imports System.Data
Imports System.Data.Common

Partial Class survey_SurveyMain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim strSQL As String
                Dim dt As New DataTable

                Session("CGUID") = "716eff48-cb2f-11e6-a817-065cea4aa6c1"

                Dim db As New DBHelper
                strSQL = "Select CM.client_name, CM.client_id, SUBSTRING(database_name,8,4) AS dbname " & _
                        " from client_master CM " & _
                        " where CM.Active = 1 and GUID = '" & Session("CGUID") & "'"
                dt = db.DataAdapter(CommandType.Text, strSQL).Tables(0)
                If dt.Rows.Count = 1 Then
                    Session("client_id") = dt.Rows(0).Item("client_id").ToString
                    Session("dbname") = dt.Rows(0).Item("dbname").ToString
                End If

                'Dim strConnString As String = ConfigurationManager.AppSettings("DATA.CONNECTIONSTRING")
                'Session("clientconnstring") = strConnString.Replace("client_master", ConfigurationManager.AppSettings("SMCLIENTDB"))

                'Session("surveyguid") = Request.QueryString("id")
                'Session("surveyguid") = "8586d177-e9b5-4de8-a18b-bb42ac812ce3"
                'Session("surveyguid") = Request.QueryString("id")

                Session("GUID") = "1B187EC2-8D98-45BF-99B3-6FE9845A9692"

                If Request.QueryString("PMode") = "P" Then
                    Session("SurveyId") = Request.QueryString("SurveyId")
                    Session("SurveyId") = 1
                Else
                    'Get Survey Id Based on GUID'
                End If
                Session("SurveyId") = 1

                Dim db1 As New DBHelperClient

                'bind the images here
                strSql = "select logo from tblSurveyDesign where SurveyId = " & Session("SurveyId")
                Dim dsImg As New DataSet("Image")
                Dim buffer As Byte()

                dsImg = db1.DataAdapter(CommandType.Text, strSql)
                If dsImg.Tables(0).Rows.Count = 0 Then
                Else
                    buffer = DirectCast(dsImg.Tables(0).Rows(0)(0), Byte())
                    If buffer IsNot Nothing Then

                        imgsmalllogo.Src = "data:image/gif;base64," + System.Convert.ToBase64String(buffer)
                    End If
                End If

                strSql = "select CSLBackColor, STBackColor, STTextColor,  PTTextColor,  PTBackColor, CSFont,  STFont, PTFont, LPText, LPUse from tblSurveyDesign where SurveyId = " & Session("SurveyId")
                dsImg = db1.DataAdapter(CommandType.Text, strSql)
                form1.Style.Item("background-color") = "#" & dsImg.Tables(0).Rows(0).Item("STBackColor").ToString
                lblMeeting.Style.Item("Color") = "#" & dsImg.Tables(0).Rows(0).Item("STTextColor").ToString
                lblMeeting.Style.Item("font-family") = dsImg.Tables(0).Rows(0).Item("CSFont").ToString
                lblMeeting.Style.Item("font-size") = dsImg.Tables(0).Rows(0).Item("STFont").ToString & "px"
                logodiv.Style.Item("background-color") = "#" & dsImg.Tables(0).Rows(0).Item("CSLBackColor").ToString



                Dim dbc As New DBHelperClient
                Dim parms(0) As DBHelperClient.Parameters
                Dim ds1 As New DataSet
                parms(0) = New DBHelperClient.Parameters("i_surveyguid", Session("surveyguid"))
                ds1 = dbc.DataAdapter(CommandType.StoredProcedure, "SP_GetSurveyCompanyByGUID", parms)
                If dsImg.Tables(0).Rows(0).Item("LPUse").ToString = 1 Then
                    lblMeeting.InnerHtml = Server.HtmlDecode(dsImg.Tables(0).Rows(0).Item("LPText").ToString)
                Else
                    If ds1.Tables(0).Rows.Count > 0 Then
                        Button1.Visible = True
                        lblMeeting.InnerHtml = ds1.Tables(0).Rows(0)(0) + "<br/>Contact: " + ds1.Tables(0).Rows(0)(1) + _
                                                "<br/>Meeting Date: " + ds1.Tables(0).Rows(0)(2)
                    Else
                        Button1.Visible = False
                    End If
                End If
            End If

        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub

    Protected Sub initsurvey(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("surveypage.aspx?id=" + Session("surveyguid").ToString + "&PMode=" + Session("PMode"), True)
    End Sub
End Class
