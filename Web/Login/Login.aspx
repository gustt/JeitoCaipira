<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JeitoCaipira.Login.Login" Theme="Player" %>

<!doctype html public "-//w3c//dtd xhtml 1.0 transitional//en" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dFnd1">
        <div id="imgCadeado"></div>
        <span id="spArea">Área Restrita</span>
        <span id="spAreaBack">Área Restrita</span>
        <div id="dFnd2">
            <table id="tUsuarioSenha">
                <tr>
                    <th>
                        <span>Usuario:</span>
                        <asp:TextBox runat="server" ID="txtUserID"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <span>Senha:</span>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtSenhas"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div id="keys">
                <span id="sLogar">
                    <asp:LinkButton runat="server" ID="lnkLogar" Text="Logar" OnClick="lnkLogar_Click"></asp:LinkButton>
                </span>
                <span id="sLogarBack">Logar</span>                
            </div>
        </div>
    </div>
    </form>
</body>
</html>
