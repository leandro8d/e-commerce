app.controller("registrarController", function ($scope, $http, $location, userService, $state, produtosService) {
    $scope.titulo = "Comercios S.I"

    $scope.produtos = produtosService.list;

    $scope.cadastrar = function (usuario) {
        userService.adicionarUsuario(usuario);
        $state.go('home')
    }
    // $scope.condicoes;
    // $http({z
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


