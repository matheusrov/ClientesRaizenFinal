<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteATU.aspx.cs" Inherits="Cliente.UI.ClienteATU" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
    <!-- Adicionando JQuery -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"
            integrity="sha256-/JqT3SQfawRcv/BIHPThkBvs0OEvtFFmqPF/lYI/Cxo="
            crossorigin="anonymous"></script>
    <%--<script src="https://code.jquery.com/jquery.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery.maskedinput.js" type="text/javascript"></script>--%>
    <!-- Adicionando Javascript -->
    <script>

        function limpa_formulário_cep() {
            // Limpa valores do formulário de cep.
            $("#txtRua").val("");
            $("#txtBairro").val("");
            $("#txtCidade").val("");
            $("#txtEstado").val("");
        }

        //Quando o campo cep perde o foco.
        function CEP(element) {

            //Nova variável "cep" somente com dígitos.
            var cep = $(element).val().replace(/\D/g, '');

            //Verifica se campo cep possui valor informado.
            if (cep != "") {

                //Expressão regular para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                    $("#txtRua").val("...");
                    $("#txtBairro").val("...");
                    $("#txtCidade").val("...");
                    $("#txtEstado").val("...");

                    //Consulta o webservice viacep.com.br/
                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                        if (!("erro" in dados)) {
                            //Atualiza os campos com os valores da consulta.
                            $("#txtRua").val(dados.logradouro);
                            $("#txtBairro").val(dados.bairro);
                            $("#txtCidade").val(dados.localidade);
                            $("#txtEstado").val(dados.uf);
                        } //end if.
                        else {
                            //CEP pesquisado não foi encontrado.
                            limpa_formulário_cep();
                            alert("CEP não encontrado.");
                        }
                    });
                } //end if.
                else {
                    //cep é inválido.
                    limpa_formulário_cep();
                    alert("Formato de CEP inválido.");
                }
            } //end if.
            else {
                //cep sem valor, limpa formulário.
                limpa_formulário_cep();
            }
        };

    </script>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align: center">Cliente - Atualizar</h1>
            <a href="../default.aspx">Página inicial</a>
            <hr />
            Id:<asp:TextBox ID="txtID" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br/>
            Nome:
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator id="reqNome"
                    ControlToValidate="txtNome"
                    Display="Static"
                    ErrorMessage="Nome é Obrigatório"
                    runat="server"
                    ForeColor ="Red"/>
            <br/>
            Email:
            <asp:TextBox ID="txtEmail" runat="server" style="margin-left: 8px"></asp:TextBox>
            <asp:RequiredFieldValidator id="reqEmail"
                    ControlToValidate="txtEmail"
                    Display="Static"
                    ErrorMessage="Email é Obrigatório"
                    runat="server"
                    ForeColor ="Red"/>
            <br/>
            DtNascimento: <input id="txtDtNascimento" type="date" runat="server" value="2023-11-18"/> 
            <br />
            CEP:<asp:TextBox ID="txtCEP" runat="server" onblur="CEP(this);" ></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator1"
                    ControlToValidate="txtCEP"
                    Display="Static"
                    ErrorMessage="CEP é Obrigatório"
                    runat="server"
                    ForeColor ="Red"/>
            <br />
            Rua:<asp:TextBox ID="txtRua" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator2"
                    ControlToValidate="txtRua"
                    Display="Static"
                    ErrorMessage="Rua é Obrigatório"
                    runat="server"
                    ForeColor ="Red"/>
            <br />
            Bairro:<asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator3"
                    ControlToValidate="txtBairro"
                    Display="Static"
                    ErrorMessage="Bairro é Obrigatório"
                    runat="server"
                    ForeColor ="Red"/>
            <br />
            Cidade:<asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator4"
                    ControlToValidate="txtCidade"
                    Display="Static"
                    ErrorMessage="Cidade é Obrigatória"
                    runat="server"
                    ForeColor ="Red"/>
            <br />
            Estado:<asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator id="RequiredFieldValidator5"
                    ControlToValidate="txtEstado"
                    Display="Static"
                    ErrorMessage="Estado é Obrigatório"
                    runat="server"
                    ForeColor ="Red"/>
            <br />
            <br />
            <asp:Button ID="btnAtualizar" style="width:142px" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
        </div>
    </form>
</body>
</html>
