app.factory("carrinhoService", function ($cookies, $http, userService, $mdToast) {
    car = {};
    car.carrinho = [];

    car.getCarrinho = function () {
        if (userService.getUsuarioLogado() != null) {
            $http.get('/api/carrinho/' + userService.getUsuarioLogado().IdUsuario).then(function (data) {

                car.carrinho = data.data;
            });
        }
    }
    car.getCarrinho();

    car.adicionarProduto = function (qnt,idProduto,event) {
        var carrinho = {};
        carrinho.IdUsuario = userService.getUsuarioLogado().IdUsuario;
        carrinho.IdProduto = idProduto;
        carrinho.Quantidade = qnt;
        $http.post('/api/carrinho/ProdutoCarrinho', carrinho).then(function (data) {
            car.getCarrinho();

            if (event)
                event();

        }, function (data) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(data.data)
                    .position('bottom right')
                    .hideDelay(3000)
            );
            car.getCarrinho();
        });
    }
    car.finalizar = function (id) {
        $http.post('/api/carrinho/Finalizar', { IdUsuario:id }).then(function (data) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(data.data)
                    .position('bottom right')
                    .hideDelay(3000)
            );
            car.getCarrinho();
        });

    }

    car.apagarProduto = function (carrinho) {
        $http.delete('/api/carrinho/ProdutoCarrinho', { params: {idcarrinho:carrinho.IdCarrinhoCompras,idUsuario:carrinho.IdUsuario } }).then(function (data) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(data.data)
                    .position('bottom right')
                    .hideDelay(3000)
            );
            car.getCarrinho();
        });
    }
  




    return car;

});