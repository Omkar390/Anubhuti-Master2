<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Randomtext.aspx.vb" Inherits="Randomtext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <div >
                    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="display nowrap ac_list" >--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0"  >
            	        <thead>
                        <tr>
                            <th><span>Numbers</span></th>
                            <th><span>Numbers</span></th>
                            <th><span>Numbers</span></th>                            
                           
                        </tr>
                        </thead>
                        <tbody>
                        <asp:Repeater ID="rptallsurvey" runat="server">
                            <ItemTemplate>
                                <tr>                                   
                                  <th><%#Eval("Numbers")%></th>                                
                                    <th><%#Eval("Numbers1")%></th> 
                                    <th><%#Eval("Numbers2")%></th> 
        	                        <%--<td>
    	                            <%--  <asp:LinkButton CommandName="Pre" CommandArgument='<%#Eval("Numbers")%>' ID="ActPre" runat="server"
                                        Text="Preview" ToolTip="Preview" ></asp:LinkButton>--%>
                                   <%-- </td>--%>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>                             
                     </tbody>
                    </table>
    			
                </div>
        <div>
            <asp:Label ID="lbltest1" runat="server" />
            <asp:Label ID="lbltest2" runat="server" />
            <asp:Label ID="lbltest3" runat="server" />
            <asp:Label ID="lbltest4" runat="server" />
            <asp:Label ID="lblerror" runat="server" />
            <asp:Button ID="btnrandom" runat="server" Text="Generate random text" OnClick="btnrandom_Click" />
        </div>
         <asp:Label ID="lblchk" runat="server" />
    </form>
</body>
</html>
