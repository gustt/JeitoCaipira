<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="CadastroMembro.aspx.cs" Inherits="JeitoCaipira.Paginas.CadastroMembro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" ID="btnSalvar" Text="Salvar" OnClick="btnSalvar_OnClick" />
    <UCAdmin:CadastroMembro runat="server" ID="ucCadastroMembro" />
</asp:Content>
