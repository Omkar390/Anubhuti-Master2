<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SurveyList.aspx.vb" Inherits="SurveyList" %>

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
</head>
<body class="red">
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblErrorMessage" Visible="false" ForeColor="Red"></asp:Label>
<%--	        <div class="wrap">                --%>
                <main id="main_content">             
        <div class="popup">
            <h2>Surveys for you:</h2>
                    <asp:GridView runat="server" ID="grdSurveyList" AutoGenerateColumns="false" HeaderStyle-CssClass="header" CssClass="grid" >
                        <Columns>
                            <%--<asp:BoundField DataField="CompanyName" HeaderText="Company" ItemStyle-Width="35%" />--%>
                            <asp:BoundField DataField="SurveyName" HeaderText="Survey" ItemStyle-Width="35%" />
                            <asp:HyperLinkField DataNavigateUrlFields="GUID" HeaderText="Link" Text="Go"
                            DataNavigateUrlFormatString="SurveyPage.aspx?id={0}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" />                            
                            <asp:HyperLinkField DataNavigateUrlFields="SurveyResultHeaderID" HeaderText="Attach." Text="View" 
                            DataNavigateUrlFormatString="SurveyFiles.aspx?id={0}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%" />
                        </Columns>
                    </asp:GridView>
        </div>
                </main><!--end main_content-->
                <footer id="footer">
                </footer>
<%--            </div><!--end page-->--%>

        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="js/jquery-1.9.1.min.js"><\/script>')</script>
        <script src="js/main.js"></script>
    </form>
</body>
</html>
