<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SurveyFiles.aspx.vb" Inherits="SurveyFiles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if lt IE 7 ]> <html class="ie ltie7 ltie8 ltie9" lang="en"> <![endif]-->
<!--[if IE 7 ]>    <html class="ie ie7 ltie8 ltie9" lang="en"> <![endif]-->
<!--[if IE 8 ]>    <html class="ie ie8 ltie9" lang="en"> <![endif]-->
<!--[if IE 9 ]>    <html class="ie ie9 ltie10" lang="en"> <![endif]-->
<!--[if gt IE 9]><!--> <html lang="en" class=""> <!--<![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
<meta name="keywords" content=""/>
<meta name="description" content=""/>
<meta name="viewport" content="width=device-width">
    <title></title>
<!--[if lt IE 9]><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><![endif]-->

<link rel="stylesheet" type="text/css" href="css/style.css"/>

<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700' rel='stylesheet' type='text/css'>

<script type="text/javascript">
    function validate(grpname) {
        var validated = Page_ClientValidate(grpname);
        if (validated) {
            return true;
        }
        else
            return false;
    }
</script>

</head>
<body class="red">
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblErrorMessage" Visible="false" ForeColor="Red"></asp:Label>
    <br />
 <!--       <div class="wrap">          -->     
                <main id="main_content">             
                    <div class="popup">
            <input id="btnBack" class="button" type="submit" value="Back to Survey List" runat="server" onserverclick="backtolist"/>
            <h2>Upload Docs / Photos:</h2>
                    <table class="add_new">
                        <tr>
                            <td>
                                <h3>Doc Description</h3>
                                <input type="text" validationgroup="addattach" maxlength="100" id="txtAttachDesc" name="txtAttachDesc" runat="server"/>
                                <asp:RequiredFieldValidator validationgroup="addattach" runat="server" ControlToValidate="txtAttachDesc" ErrorMessage="*" Display="Dynamic" InitialValue=""></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3>Click "Choose File" to Attach a File or Take a Photo and then click "Upload".</h3>
                                <asp:FileUpload  ID="txtFileUpload" runat="server" Width="75%"/>
                                <input id="btnAttach" validationgroup="addattach" class="button" type="submit" value="Upload" runat="server" onserverclick="AddAttachment" onclick="return validate('addattach');" />
                            </td>
                        </tr>
                    </table>             
                    <br />
                    <asp:GridView runat="server" ID="grdAttachList" AutoGenerateColumns="false" HeaderStyle-CssClass="header" CssClass="grid" 
                            EmptyDataText="No Attachments so far.">
                    <Columns>
                        <asp:BoundField DataField="txtDesc" HeaderText="Description" ItemStyle-Width="60%" />
                        <asp:TemplateField HeaderText="Attach." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                          <ItemTemplate>
                                <center>
                                  <asp:ImageButton runat="server" ID="imgbtn" ImageUrl="~/images/attach.png" ToolTip="Open Attachment"
                                        CommandArgument='<%#Eval("SurveyAttachID")%>' OnClick="showattachments"
                                        CausesValidation="false" Visible='<%# not(Eval("AttachmentFile")="")%>' />
                                    </center>
                           </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
                          <ItemTemplate>
                                <center>
                                <asp:LinkButton CommandArgument='<%#Eval("SurveyAttachID")%>' CssClass="icon delete" ID="btndelete" runat="server" CausesValidation="false" CommandName="Delete"
                                  OnClientClick="var con = confirm('Are you sure you want to delete?');if (con){return true;}else{return false;}"></asp:LinkButton>
                                  </center>
                           </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
        </div>
                </main><!--end main_content-->
                <footer id="footer">
                </footer>

  <%--      </div><!--end page-->--%>

        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="js/jquery-1.9.1.min.js"><\/script>')</script>
        <script src="js/main.js"></script>
    </form>
</body>
</html>
