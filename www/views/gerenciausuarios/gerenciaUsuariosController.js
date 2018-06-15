app.controller("gerenciaUsuariosController", function ($scope, $http, $location, userService, produtosService, $uibModal, mensagemService) {
    $scope.titulo = "Comercios S.I";
    $scope.selectedItem = null;
    $scope.usuarioLogado = userService.getUsuarioLogado();

    if (!$scope.usuarioLogado || !$scope.usuarioLogado.IdTipoUsuario == 1) {
        $location.path("/home");
    }

    $scope.$watch(function () {
        return userService.list;
    }, function (newValue) {
        $scope.usuarios = newValue;

    });



    $scope.selectRow = function (produto) {
        $scope.selectedItem = produto;
    }
    $scope.editarUsuario = function (usuarioO) {
        // var parentElem = parentSelector ?
        // angular.element($document[0].querySelector('.myModal ' + parentSelector)) : undefined;
        $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'views/gerenciausuarios/editarUsuario.html',
            controller: function ($scope, usuario, $uibModalInstance) {
                $scope.usr = angular.copy(usuario);
                $scope.edicao = true;
                $scope.ok = function () {
                    $uibModalInstance.close($scope.usr);
                }
                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                };
            },
            size: 'md',
            resolve: {
                usuario: function () {
                    return usuarioO;
                }
            },
        }).result.then(function (res) { userService.editarUsuario(res);  });
    };

    
    $scope.removerUsuario = function (p) {
        mensagemService.confirmacao("Exclusão de Usuário", "Você confirma a exclusão do usuário selecionado?", function () {
            userService.removerUsuario(p)
        })
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


