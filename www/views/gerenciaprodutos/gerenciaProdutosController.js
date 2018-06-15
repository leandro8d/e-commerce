app.controller("gerenciaProdutosController", function ($scope, $http, $location,userService,produtosService,$uibModal,mensagemService) {
$scope.titulo="Comercios S.I";
$scope.selectedItem = null;
    $scope.usuarioLogado = userService.getUsuarioLogado();
    if (!$scope.usuarioLogado || !$scope.usuarioLogado.IdTipoUsuario == 1) {
        $location.path("/home");
    }

    $scope.$watch(function () {
        return produtosService.list;
    }, function (newValue) {
        $scope.produtos = newValue;

    });


$scope.logar = function(usuario,senha){
   $scope.usuarioLogado = userService.logar(usuario,senha);
}
$scope.selectRow = function(produto)
{
    $scope.selectedItem = produto;
}
$scope.editarProduto = function(produtoO){
    // var parentElem = parentSelector ?
    // angular.element($document[0].querySelector('.myModal ' + parentSelector)) : undefined;
    $uibModal.open({
        animation: true,
        ariaLabelledBy: 'Seleção de Usuários',
        ariaDescribedBy: 'modal-body',
        templateUrl: 'views/gerenciaprodutos/editarProduto.html',
        controller: function($scope,produto, $uibModalInstance) {
            $scope.prod = angular.copy(produto);
            $scope.edicao = true;
            $scope.ok = function(){
                $uibModalInstance.close($scope.prod);
            }
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
              };
          },
        size: 'md',
        resolve: {
            produto: function () {
              return produtoO;
            }
          },
    }).result.then(function(res){produtosService.editarProduto(res);}, function(res){produtosService.editarProduto(res);});
};
$scope.adicionarProduto = function(){
    // var parentElem = parentSelector ?
    // angular.element($document[0].querySelector('.myModal ' + parentSelector)) : undefined;
    $uibModal.open({
        animation: true,
        ariaLabelledBy: 'Seleção de Usuários',
        ariaDescribedBy: 'modal-body',
        templateUrl: 'views/gerenciaprodutos/editarProduto.html',
        controller: function($scope,$uibModalInstance) {
            $scope.prod = {};
            $scope.edicao = false;
            $scope.ok = function(){
                $uibModalInstance.close($scope.prod);
            }
            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
              };
          },
        size: 'md'
    }).result.then(function(res){produtosService.adicionarProduto(res);}, function(res){produtosService.adicionarProduto(res);});
};

$scope.removerProduto = function(p){
    mensagemService.confirmacao("Exclusão de Produto","Você confirma a exclusão do produto selecionado?",function(){produtosService.removerProduto(p)})
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


