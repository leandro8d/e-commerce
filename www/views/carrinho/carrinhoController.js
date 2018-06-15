app.controller("carrinhoController", function ($scope, $http, $location, userService, produtosService, $uibModal, $stateParams, carrinhoService) {
    carrinhoService.getCarrinho();
    $scope.$watch(function () {
        return carrinhoService.carrinho;
    }, function (newValue) {
        $scope.carrinho = newValue;
    });



    $scope.finalizar = function () {
        carrinhoService.finalizar(userService.getUsuarioLogado().IdUsuario);
    }
    $scope.apagarProduto = function (produto) {
        carrinhoService.apagarProduto(produto);
    }
    $scope.adicionarCarrinho = function (qnt, idProduto) {
        carrinhoService.adicionarProduto(qnt, idProduto);
    }



    // $scope.condicoes;
    // $http({
    //     method: 'GET',
    //     url: 'api/servicoSX/getCondicoes',
    // }).then(function successCallback(response) {
    //     $scope.condicoes = response.data;
    // }, function errorCallback(response) {
    //     console.log(response);
    // }
    // );


    // $scope.comercarFormulario = function (email, nome)
    // {
    //     var today = new Date();
    //     var expiresValue = new Date(today);

    //     //Set 'expires' option in 1 minute
    //     expiresValue.setMinutes(today.getMinutes() + 10);

    //     $cookies.put('email', email, {'expires': expiresValue});
    //     $cookies.put('nome', nome, {'expires': expiresValue});
    //     $location.path("/questao1");
    // };

});


