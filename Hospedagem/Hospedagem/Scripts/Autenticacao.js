$(document).ready(function () {
    $("#status").hide();
    $("#botao-entrar").click(function () {
        $.ajax({
            url: "/Autenticacao/AutenticarUsuario",
            data: { Login: $("#txtLogin").val(), Senha: $("#txtSenha").val() },
            dataType: "json",
            type: "POST",
            async: true,
            beforeSend: function () {
                $("#status").html("Autenticando Usuário...");
                $("#status").show();
            },
            success: function (dados) {
                if (dados.OK) {
                    $("#status").html(dados.Mensagem)
                    setTimeout(function (){window.location.href="/Home"}, 2000);
                    $("#status").show();
                } else {
                    $("#status").html(dados.Mensagem);
                    $("#status").show();
                }
            },
            error: function (dados) {
                $("#status").html(dados.Mensagem);
                $("#status").show();
            }
        });
    });
});