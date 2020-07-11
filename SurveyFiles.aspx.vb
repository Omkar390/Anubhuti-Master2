Imports System.Data
Imports System.Data.Common
Imports System.IO
Imports System.Data.SqlClient

Partial Class SurveyFiles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim strConnString As String = ConfigurationManager.AppSettings("DATA.CONNECTIONSTRING")
                Session("clientconnstring") = strConnString.Replace("client_master", ConfigurationManager.AppSettings("SMCLIENTDB"))

                Session("SurveyResultHeaderID") = Request.QueryString("id")

                RefreshNotes(sender, e)
            End If

        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub

    Protected Sub AddAttachment(ByVal sender As Object, ByVal e As EventArgs)
        Try

            If HttpContext.Current.Session("SurveyResultHeaderID") <> 0 Then
                ' Read the file and convert it to Byte Array
                Dim br As BinaryReader = New BinaryReader(txtFileUpload.PostedFile.InputStream)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(txtFileUpload.PostedFile.InputStream.Length))
                br.Close()
                'insert the file into database
                Dim strQuery As String = "if not exists(select * from tblSurveyAttachments where txtDesc = @i_txtDesc and AttachmentFile = @i_AttachmentFile and attachmentcontenttype = @i_attachmentcontenttype and @i_SurveyResultHeaderID = SurveyResultHeaderID) Insert into tblSurveyAttachments values(@i_SurveyResultHeaderID,@i_txtDesc,@i_AttachmentFile,@Data,@i_attachmentcontenttype,@i_UserName,GETDATE(),NULL,NULL)"
                Dim cmd As SqlCommand = New SqlCommand(strQuery)
                cmd.Parameters.Add("@i_SurveyResultHeaderID", SqlDbType.Int).Value = HttpContext.Current.Session("SurveyResultHeaderID")
                cmd.Parameters.Add("@i_UserName", SqlDbType.VarChar).Value = Session("user_id")
                cmd.Parameters.Add("@i_txtDesc", SqlDbType.VarChar).Value = txtAttachDesc.Value.Trim
                cmd.Parameters.Add("@i_AttachmentFile", SqlDbType.VarChar).Value = txtFileUpload.PostedFile.FileName
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value = bytes
                cmd.Parameters.Add("@i_attachmentcontenttype", SqlDbType.VarChar).Value = txtFileUpload.PostedFile.ContentType

                Dim strConnString As String = Session("clientconnstring")
                Dim con As New SqlConnection(strConnString)
                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
            End If

            txtAttachDesc.Value = ""

            RefreshNotes(sender, e)

        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try

    End Sub

    Protected Sub showattachments(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim db As New DBHelperClient
            Dim ds As New DataSet
            'Dim strQuery As String = "select AttachmentFile, Attachment,Attachmentcontenttype from tblDocumentDiscussionNotes where noteid=111"
            Dim strQuery As String = "select AttachmentFile, Attachment,Attachmentcontenttype from tblSurveyAttachments where SurveyAttachID=" & DirectCast(sender, ImageButton).CommandArgument
            ds = db.DataAdapter(CommandType.Text, strQuery)
            Dim bytes() As Byte = CType(ds.Tables(0).Rows(0)("Attachment"), Byte())

            Response.Buffer = True
            Response.Charset = ""
            'Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = ds.Tables(0).Rows(0)("Attachmentcontenttype").ToString()
            Dim strFileName As String = ""
            If ds.Tables(0).Rows(0)("AttachmentFile").ToString().Contains("\") Then
                strFileName = ds.Tables(0).Rows(0)("AttachmentFile").ToString().Substring(InStrRev(ds.Tables(0).Rows(0)("AttachmentFile").ToString(), "\"), ds.Tables(0).Rows(0)("AttachmentFile").ToString().Length - InStrRev(ds.Tables(0).Rows(0)("AttachmentFile").ToString(), "\"))
            Else
                strFileName = ds.Tables(0).Rows(0)("AttachmentFile").ToString()
            End If
            Response.AddHeader("content-disposition", "attachment;filename=" & strFileName)
            Response.BinaryWrite(bytes)
            Response.Flush()
            'Response.Close()
            Response.End()


        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub

    Protected Sub grdAttachList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAttachList.RowCommand
        Try
            If e.CommandName = "Delete" Then
                Dim db As New DBHelperClient
                Dim parms(0) As DBHelperClient.Parameters
                parms(0) = New DBHelperClient.Parameters("i_SurveyAttachID", e.CommandArgument)
                db.ExecuteNonQuery(CommandType.StoredProcedure, "SP_DELETESURVEYATTACH", parms)
                RefreshNotes(sender, e)
            End If
        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub
    Protected Sub RefreshNotes(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Show all attachment surveys for header id!
            Dim parms(0) As DBHelperClient.Parameters
            Dim db As New DBHelperClient
            Dim ds1 As New DataSet
            parms(0) = New DBHelperClient.Parameters("i_SurveyResultHeaderID", Session("SurveyResultHeaderID"))
            ds1 = db.DataAdapter(CommandType.StoredProcedure, "SP_GetSurveyAttachList", parms)
            If ds1.Tables.Count > 0 Then
                If ds1.Tables(0).Rows.Count > 0 Then
                    grdAttachList.DataSource = ds1
                    grdAttachList.DataBind()
                Else
                    grdAttachList.DataSource = Nothing
                    grdAttachList.DataBind()
                End If
            Else
                grdAttachList.DataSource = Nothing
                grdAttachList.DataBind()
            End If


        Catch ex As Exception
            lblErrorMessage.Visible = True
            lblErrorMessage.Text = ex.Message
        End Try
    End Sub
    Protected Sub grdAttachList_OnRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles grdAttachList.RowDeleting

    End Sub

    Protected Sub backtolist(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("surveylist.aspx", True)
    End Sub
End Class
