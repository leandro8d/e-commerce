app.controller("produtoController", function ($scope, $http, $location, userService, produtosService, $uibModal, $stateParams, carrinhoService, $mdToast) {
    $scope.titulo = "Comercios S.I"
    $scope.produto;
    $scope.usuarioLogado = userService.getUsuarioLogado();

    $http.get('/api/produto/' + $stateParams.id).then(function (data) {
        $scope.produto = data.data;
    });
    $http.get('/api/produto/comentarios/'+ $stateParams.id).then(function (data) {
        $scope.comentarios = data.data;
    });

    $scope.logar = function (usuario, senha) {
        userService.logar(usuario, senha, function (usuario) {
            $scope.usuarioLogado = usuario;
        });
    }

    $scope.postarComentario = function (comentario) {
        comentario.IdUsuario = userService.getUsuarioLogado().IdUsuario;
        comentario.IdProduto = $stateParams.id;
        $http.post('/api/produto/comentario',comentario).then(function (data) {
            $http.get('/api/produto/comentarios/' + $stateParams.id).then(function (data) {
                $scope.comentarios = data.data;
            });
        });
    }
    $scope.adicionarCarrinho = function (qnt) {
        if (userService.getUsuarioLogado()) {
            carrinhoService.adicionarProduto(qnt, $stateParams.id, function () {
                    $mdToast.show(
                        $mdToast.simple()
                            .textContent("Produto Adicionado ao Carrinho.")
                            .position('bottom right')
                            .hideDelay(3000)
                    );
            });
        }
        else {

            $mdToast.show(
                $mdToast.simple()
                    .textContent("Faça login para adicionar um produto ao carrinho.")
                    .position('bottom right')
                    .hideDelay(3000)
            );
        }
    }

    $scope.logout = function (usuario, senha) {
        userService.logout();
        $scope.usuarioLogado = null;
    }

    $scope.openProduct = function () {


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


