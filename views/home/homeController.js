app.controller("homeController", function ($scope, $http, $location, userService, produtosService) {
    $scope.titulo = "Comercios S.I"
    $scope.usuarioLogado = userService.getUsuarioLogado();
    $scope.produtos = produtosService.list;

    $scope.logar = function (usuario, senha) {
        $scope.usuarioLogado = userService.logar(usuario, senha);
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


