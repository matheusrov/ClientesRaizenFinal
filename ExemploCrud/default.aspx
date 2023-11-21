 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Cliente._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cliente<br/>
            <asp:Button ID="btnCadastrarCliente" runat="server" OnClick="btnCadastrarCliente_Click" style="width:142px" Text="Cadastrar Cliente" />
            <asp:Button ID="btnConsultarCliente" runat="server" OnClick="btnConsultarCliente_Click" style="width:142px" Text="Consultar Cliente" />
        </div>
    </form>
</body>
</html>
