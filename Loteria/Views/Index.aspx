<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Loteria.Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../Resources/css/default.css" rel="stylesheet" />

    <title>MEGASENA</title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="centerDiv">
            <h2>Informe os numeros do Jogo da MegaSena:</h2>

            <asp:TextBox ID="txtPrimeiro" runat="server" CssClass="text" MaxLength="2"></asp:TextBox>
            <asp:TextBox ID="txtSegundo" runat="server" CssClass="text" MaxLength="2"></asp:TextBox>
            <asp:TextBox ID="txtTerceiro" runat="server" CssClass="text" MaxLength="2"></asp:TextBox>
            <asp:TextBox ID="txtQuarto" runat="server" CssClass="text" MaxLength="2"></asp:TextBox>
            <asp:TextBox ID="txtQuinto" runat="server" CssClass="text" MaxLength="2"></asp:TextBox>
            <asp:TextBox ID="txtSexto" runat="server" CssClass="text" MaxLength="2"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="btnAddJogo" runat="server" Text="ADICIONAR JOGO" OnClick="btnAddJogo_Click" />
            <asp:Button ID="btnSurpresinha" runat="server" Text="SURPRESINHA" OnClick="btnSurpresinha_Click" />
            <asp:Button ID="btnSortear" runat="server" Text="SORTEAR" OnClick="btnSortear_Click" />
            <asp:Button ID="btnResetar" runat="server" Text="RESETAR" OnClick="btnResetar_Click"/>

            <br /><br />

            <asp:Label ID="lblRetorno" runat="server"></asp:Label>

            <br />
            <br />

            <h2>Jogo(s):</h2>

            <asp:GridView ID="gridJogo" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="id" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador" HeaderStyle-Width="20%" />
                    <asp:BoundField DataField="jogo" ItemStyle-HorizontalAlign="Center" HeaderText="Jogo" HeaderStyle-Width="50%" />
                    <asp:BoundField DataField="dataHora" ItemStyle-HorizontalAlign="Center" HeaderText="Data/Hora" HeaderStyle-Width="40%" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
