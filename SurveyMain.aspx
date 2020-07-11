<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SurveyMain.aspx.vb" Inherits="survey_SurveyMain" %>

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
<body  id="formbody" runat="server">
    <form id="form1" runat="server" style="width:100%;height:100%">
    <asp:Label runat="server" ID="lblErrorMessage" Visible="false" ForeColor="Red"></asp:Label>
    
        <br /><br />    
        <div class="align_center" id="logodiv" runat="server">
           
            <img runat="server"  alt="" id="imgsmalllogo" height="140" width="340"/>
        </div>
        <br /><br />    

        <div class="wrap">                
            <main id="main_content">             
            </main><!--end main_content-->
            <footer id="footer">
            </footer>
        </div><!--end page-->
        <div class="popup">
            <h2>This survey is for your meeting with:</h2>
            <p><span class="bolder uppercase"><label runat="server" id="lblMeeting"></label></span></p><br />
            <asp:Button ID="Button1" runat="server" OnClick="initsurvey" Text="Proceed" CssClass="red_button wide" />
        </div>

        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="js/jquery-1.9.1.min.js"><\/script>')</script>
        <script src="js/main.js"></script>
    </form>
</body>
</html>
