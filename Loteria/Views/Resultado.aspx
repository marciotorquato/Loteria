<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultado.aspx.cs" Inherits="Loteria.Views.Resultado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../Resources/css/default.css" rel="stylesheet" />

    <title>RESULTADO</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerDiv">

            <strong>RESULTADO:</strong> <asp:Label ID="lblResultado" CssClass="resultado" runat="server"></asp:Label>

            <br /><br /><br />

            <asp:GridView ID="gridResultado" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="id" ItemStyle-HorizontalAlign="Center" HeaderText="Identificador" />
                    <asp:BoundField DataField="jogo" ItemStyle-HorizontalAlign="Center" HeaderText="Jogo" />
                    <asp:BoundField DataField="dataHora" ItemStyle-HorizontalAlign="Center" HeaderText="Data/Hora" />
                    <asp:BoundField DataField="quantidadeAcertos" ItemStyle-HorizontalAlign="Center" HeaderText="Quantidade de Acertos" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />

        </div>
    </form>
</body>
</html>