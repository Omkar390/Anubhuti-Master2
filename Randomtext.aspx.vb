
Imports System.Data
Imports System.Linq
Imports System.Collections.Generic

Partial Class Randomtext
    Inherits System.Web.UI.Page
    Private Sub Randomtext_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            btnrandom_Click(btnrandom, New EventArgs())
        Catch ex As Exception
            lblerror.Visible = True
            lblerror.Text = ex.StackTrace + "-" + ex.Message
        End Try
    End Sub
    Protected Sub btnrandom_Click(sender As Object, e As EventArgs) Handles btnrandom.Click
        Try
            Dim rdm1 As New Random()
            Dim db As New DBHelperClient
            Dim strSql As String
            Session("client_id") = "2"
            Session("dbname") = "2002"
            strSql = "select * from tblrandomnumber"

            Dim dt As New DataTable
            dt = db.DataAdapter(CommandType.Text, strSql).Tables(0)
            'For i As Integer = 1 To 3
            '    For j As Integer = 1 To 3
            '        dt.Rows(2).Item("Numbers").ToString()
            '        dt.Rows(2).Item("Numbers").ToString()
            '        'dt.Rows(0).Item(rdm1.Next(i, j)).ToString()
            '        dt.Rows.Add(dt.Rows(rdm1.Next(1, 9)))
            '    Next
            'Next

            'dt.AcceptChanges()
            Dim dtRandomRows As New Data.DataTable
            dtRandomRows = dt.Clone
            Dim i As Integer
            If dt.Rows.Count > 0 Then
                For ctr As Integer = 0 To 0
                    For ctr1 As Integer = 0 To 2
                        i = rdm1.Next(0, 9)
                        'dtRandomRows.Rows.Add(dt.Rows(i))
                        dtRandomRows.ImportRow(dt.Rows(i))
                    Next
                Next
            End If


            dtRandomRows.AcceptChanges()
            rptallsurvey.DataSource = dtRandomRows
            rptallsurvey.DataBind()




            If dt.Rows.Count = 1 Then
                Session("client_id") = dt.Rows(0).Item("client_id").ToString()
                Session("dbname") = dt.Rows(0).Item("dbname").ToString()
            End If



        Catch ex As Exception
            lblerror.Visible = True
            lblerror.Text = ex.StackTrace + "-" + ex.Message
        End Try




        Dim rdm As New Random()
        Dim chars1 As String
        chars1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        lbltest1.Text = "The generated Random number for Label1 is " + "&nbsp&nbsp&nbsp&nbsp" + (chars1(rdm.Next(chars1.Length))) + " &nbsp&nbsp&nbsp&nbsp " + "  " + chars1(rdm.Next(chars1.Length)) + "<br/>"
        lbltest2.Text = "The generated Random number for Label1 is " + "&nbsp&nbsp&nbsp&nbsp" + (chars1(rdm.Next(chars1.Length))) + " &nbsp&nbsp&nbsp&nbsp " + "  " + chars1(rdm.Next(chars1.Length)) + "<br/>"
        lbltest3.Text = "The generated Random number for Label1 is " + "&nbsp&nbsp&nbsp&nbsp" + (chars1(rdm.Next(chars1.Length))) + " &nbsp&nbsp&nbsp&nbsp " + "  " + chars1(rdm.Next(chars1.Length)) + "<br/>"
        lbltest4.Text = "The generated Random number for Label1 is " + "&nbsp&nbsp&nbsp&nbsp" + (chars1(rdm.Next(chars1.Length))) + " &nbsp&nbsp&nbsp&nbsp " + "  " + chars1(rdm.Next(chars1.Length)) + "<br/>"
        'Dim dt As New Data.DataTable("YourDataTable")
        'Dim dtRandomRows As New Data.DataTable("RandomTable")
        'dtRandomRows = dt.Clone
        'Dim rDom As New Random
        'Dim i As Integer
        'For ctr As Integer = 1 To 15
        '    i = rDom.Next(1, 20)
        '    dtRandomRows.Rows.Add(dt.Rows(i))
        'Next
        'dtRandomRows.AcceptChanges()
        'lbltest2.Text = "The generated Random number for Label2 is " + (Convert.ToString(rdm.Next(1, 20))) + "<br/>"
        'lbltest3.Text = "The generated Random number for Label3 is " + (Convert.ToString(rdm.Next(1, 20))) + "<br/>"
        'lbltest4.Text = "The generated Random number for Label4 is " + (Convert.ToString(rdm.Next(1, 20))) + "<br/>


    End Sub

End Class
