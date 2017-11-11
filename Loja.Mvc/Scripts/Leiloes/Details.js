// Kyle Simpson
// object literal
var Details = {
    produtoId: 0,
    nomeParticipante: null,
    leilaoHub: {},
    connectionId : "",

    inicializar: function (produtoId) {
        this.produtoId = produtoId;
        this.conectarLeilaoHub();
        this.vincularEventos();
    },

    conectarLeilaoHub: function () {
        var details = this;
        //var connection = $.hubConnection("localhost ou servidor");
        var connection = $.hubConnection();
        this.leilaoHub = connection.createHubProxy("LeilaoHub");

        connection.start().done(function () { details.connectionId = connection.id});
    },

    vincularEventos: function () {
        var details = this;
        $("#entrarButton").on("click", function () {
            details.entrarLeilao();
        });

        $("#enviarLanceButton").on("click", function () {
            details.realizarLance();
        });

        this.leilaoHub.on("adicionarMensagem", function (nomeParticipante, connectionId, mensagem) {
            details.adicionarMensagem(nomeParticipante, connectionId, mensagem);
        });

        this.leilaoHub.on("receberJoinha", function (nomeRemetente, connectionId) {
            details.receberJoinha(nomeRemetente, connectionId);
        });

        $(document).on("click", "a[data-connection-id]", function () {
            details.enviarJoinha($(this).data("connection-id"));
        });
    },

    entrarLeilao: function () {
        this.nomeParticipante = $("#nomeParticipante").val();
        this.leilaoHub.invoke("Participar", this.nomeParticipante, this.produtoId);

        $("#participanteDiv").hide();
        $("#lanceDiv").show();
        $("#valorLance").focus();
    },

    adicionarMensagem: function (nomeParticipante, connectionId, mensagem) {
        $("#lancesRealizadosTable").append(this.montarMensagem(nomeParticipante, connectionId, mensagem))
    },

    montarMensagem: function (nomeRemetente, connectionId, mensagem) {
        var tr = "<tr>";
        tr += "<td>" + nomeRemetente + "</td>";
        tr += "<td>" + mensagem + "</td>";

        var like = "<a data-connection-id='" + connectionId + "' href='#'>" +
                    "<span class='glyphicon glyphicon-thumbs-up' style='font-size:18px'></span></a>";

        var enviadaPorMim = this.connectionId === connectionId;

        tr += "<td>" + (enviadaPorMim ? "" : like) + "</td>";

        tr += "</tr>";

        return tr;
    },

    realizarLance: function () {
        this.leilaoHub.invoke("RealizarLance", this.nomeParticipante, this.connectionId, $("#valorLance").val(), this.produtoId);
    },

    receberJoinha: function (nomeRemetente) {
        $("#sinoNotificacoes")
            .popover("destroy")
            .popover({
                content: "<span class='glyphicon glyphicon-thumbs-up' style='font-size:24px'></span>",
                html: true,
                placement: "left",
                title: nomeRemetente + " diz:"
            })
            .popover("show");
    },

    enviarJoinha: function (connectionIdDestinatario) {
        this.leilaoHub.invoke("EnviarJoinha", this.nomeParticipante, connectionIdDestinatario);
    }
};