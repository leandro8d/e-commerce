app.controller("homeController", function ($scope, $http, $location, userService, produtosService, $uibModal, $timeout, carrinhoService, $mdToast) {
    $scope.titulo = "Comercios S.I"
    $scope.usuarioLogado = userService.getUsuarioLogado();
    $scope.total = 0;
    $scope.$watch(function () {
        return produtosService.list;
    }, function (newValue) {
        $scope.produtos = newValue;
       
        });

    $scope.$watch(function () {
        return carrinhoService.carrinho;
    }, function (newValue) {
        $scope.carrinho = newValue;
        $scope.total = 0;
        for (var i = 0 in $scope.carrinho) {
            $scope.total += $scope.carrinho[i].Quantidade * $scope.carrinho[i].IdProdutoNavigation.Preco;
        }
    });


    $scope.logar = function (usuario, senha) {
        userService.logar(usuario, senha, function (usuario) {
            $scope.usuarioLogado = usuario;
        });
    }

    $scope.logout = function (usuario, senha) {
        userService.logout();
        $scope.usuarioLogado = null;
    }

    $scope.verProduto = function (id) {

        $location.path('/produto/' + id);
    };
    $scope.verCarrinho = function () {
        if (userService.getUsuarioLogado()) {
            $location.path('/carrinho');
        }
        else {
            $mdToast.show(
                $mdToast.simple()
                    .textContent("Logue para ver o carrinho!")
                    .position('bottom right')
                    .hideDelay(3000)
            );
        
        }
    };
    


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


