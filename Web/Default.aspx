<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Principal.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="JeitoCaipira.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="manugiratorio">
        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0"
            width="580" height="270" id="menu" align="middle">
            <param name="allowScriptAccess" value="sameDomain" />
            <param name="allowFullScreen" value="false" />
            <param name="movie" value="menu.swf" />
            <param name="quality" value="high" />
            <embed src="menu.swf" quality="high" bgcolor="#GGGGG" width="580" height="270"
                name="menu" align="middle" allowscriptaccess="sameDomain" allowfullscreen="false"
                type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
        </object>
    </div>
    <div class="oquevemporai">
        <img src="Imagens/home/oquevemporai.png" class="imgTituloVemPorAi" alt="Título" />
        <asp:DataList runat="server" ID="dtlVemPorAi" RepeatDirection="Vertical" RepeatColumns="3">
            <ItemTemplate>
                <div class="quadradoVemPorAi">
                    <img src="../Imagens/home/vemporai.png" class="imgVemPorAi" alt="" />
                    <asp:ImageButton runat="server" ID="btnMais" Width="18" Height="18" ImageUrl="~/Imagens/home/btn+.png"
                        CssClass="btnMais" />
                </div>
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
