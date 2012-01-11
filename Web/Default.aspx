<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JeitoCaipira.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cConteudo" runat="server">
    <div>
        <div id="oqvemporai-titulo" class="elevarPlaceHolder"></div>
        <asp:DataList runat="server" ID="dtlVemPorAi" RepeatDirection="Vertical" RepeatColumns="3" CssClass="dtlVemPorAi">
            <ItemTemplate>
                <img src="Eventos/evento001.jpg" class="imgVemPorAi" alt="">
                    <div class="quadradoVemPorAi"></div>
                </img>
                <asp:HyperLink runat="server" ID="btnMais" CssClass="btnMais" NavigateUrl="#" Width="18" Height="18"/>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="calendario">
        <center>
            <img src="Imagens/rodape/cadastre.png" alt="Cadastre" />
            <br />
            <br />
            <div class="calendarioComponente">
                <div>
                    <asp:Calendar ID="calendario" runat="server" BorderColor="Transparent" CellPadding="4"
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="White"
                        ShowGridLines="True" Height="218px" Style="margin-left: 0px; margin-top: 0px"
                        Width="371px">
                        <TitleStyle BackColor="Transparent" />
                    </asp:Calendar>
                </div>
            </div>
        </center>
    </div>
</asp:Content>
