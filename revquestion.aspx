<%@ Page Language="VB" AutoEventWireup="false" CodeFile="revquestion.aspx.vb" Inherits="revquestion" %>

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
<%--<body class="red">--%>
    <body >
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblErrorMessage" Visible="false" ForeColor="Red"></asp:Label>
         <asp:HiddenField ID="hdnSurveyID" runat="server" />
       <asp:Timer ID="testtimer" runat="server" OnTick="testbtn_Click"></asp:Timer>
        <asp:ScriptManager ID="SManager" runat="server" ></asp:ScriptManager>
       
 <%-- <div class="new_btab dataTables_wrapper">--%><!--table listing!--> 
        <div >
                    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="display nowrap ac_list" >--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0"  >
            	        <thead>
                        <tr>
                            <th><span>SurveyID</span></th>
                            <th><span>Question Text</span></th>
                            <th><span>Answer Type</span></th>
                          <%--  <th><span>Links</span></th>--%>
                        </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="rptallsurvey" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <asp:HiddenField ID="SurveyID" runat="server" />
                                     <td><%#Eval("surveyid")%></td>
                                    <td><%#Eval("qtext")%></td>
                                    <td><%#Eval("anstype")%></td>
                                   

        	                        <%--<td>
    	                              <asp:LinkButton CommandName="Pre" CommandArgument='<%#Eval("SurveyID")%>' ID="ActPre" runat="server"
                                        Text="Preview" ToolTip="Preview"></asp:LinkButton>
                                    </td>--%>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>                                            
                     </tbody>
                    </table>
    			
                </div><!--table listing!-->
        <asp:Button ID="testbtn" runat="server" Text="Hide Label" OnClick="testbtn_Click" />
          <asp:Label ID="lbltest" runat="server" />

        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="js/jquery-1.9.1.min.js"><\/script>')</script>
        <script src="js/main.js"></script>
    </form>
</body>
</html>

