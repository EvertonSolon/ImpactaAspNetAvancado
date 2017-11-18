var Index = {
    viewModel: {
        produtos: ko.observableArray()
    },
    inicializar: function () {
        this.conectarLeilaoHub();
        ko.applyBindings(this.viewModel);
        this.obterOfertas();
    },

    conectarLeilaoHub: function () {
        var connection = $.hubConnection();
        var hub = connection.createHubProxy("LeilaoHub");

        hub.on("atualizarOfertas",
            this.obterOfertas.bind(this));

        connection.start();
    },

    obterOfertas: function () {
        var thisIndex = this;
        $.getJSON("/api/Vendas/Leiloes", function (response) {
            thisIndex.viewModel.produtos(response)
        });
    }

    //atualizarOfertas: function () {
    //    this.viewModel.produtos.push({
    //        id: 3,
    //        nome: "Grampeador",
    //        preco: 11.01,
    //        estoque: 1,
    //        categoriaNome: "Papelaria"
    //    })
    //}
};
