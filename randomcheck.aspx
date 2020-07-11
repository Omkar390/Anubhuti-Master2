<%@ Page Language="VB" AutoEventWireup="false" CodeFile="randomcheck.aspx.vb" Inherits="randomcheck" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table>
                    <thead>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    <//thead>

                    <asp:Repeater ID="rptnumber" runat="server">
                        <ItemTemplate>
                            <thead>
                                <tr><%# Eval("Numbers") %></tr>
                            </thead>
                        </ItemTemplate>
                    </asp:Repeater>

                    </table>
            </div>
            <asp:Label ID="lblerror" runat="server"></asp:Label>
            <asp:Button ID="btncheck" runat="server" Text="Check Random Number" OnClick="btncheck_Click" />
            <asp:Button ID="reset" runat="server" OnClick="reset_Click" Text="reset" />

        </div>
    </form>
</body>
</html>
