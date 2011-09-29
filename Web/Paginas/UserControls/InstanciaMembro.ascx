<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstanciaMembro.ascx.cs"
    Inherits="Bananas.Administrativo.UserControls.InstanciaMembro" %>
<asp:Panel runat="server" ID="pnContent">
    <asp:TextBox runat="server" ID="txtCodigoCliente" Visible="false"></asp:TextBox>
    <table>
        <tr>
            <th>
                <label>
                    Nome:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtNomeFantasia" Width="370px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Logradouro:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtLogradouro" Width="410px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Bairro:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtBairro" Width="198px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Complemento:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtComplemento" Width="367px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Cidade:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtCidade" Width="178px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Estado:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtEstado" Width="36px" MaxLength="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Email:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtEmail" Width="246px"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="Campo email obrigatório"
                    Text="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    Display="Dynamic" ErrorMessage="*Informe um email válido." ForeColor="#FF0000"
                    SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Login:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
                <%--                <asp:CustomValidator runat="server" ID="cvLogin" ErrorMessage="Login já existe na base."
                    Text="*" ControlToValidate="txtLogin" OnServerValidate="cvLogin_ServerValidate">
                </asp:CustomValidator>--%>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Senha:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtSenha" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <label>
                    Digite a Senha Novamente:</label>
            </th>
            <td>
                <asp:TextBox runat="server" ID="txtSenhaNovamente" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator runat="server" ID="cpSenha" ControlToValidate="txtSenhaNovamente"
                    ControlToCompare="txtSenha" Operator="Equal" ErrorMessage="Campo senha estão diferentes"
                    Text="*" Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox runat="server" ID="chkReceberEmail" Text="Fique por dentro dos eventos" />
            </td>
        </tr>
    </table>
</asp:Panel>
