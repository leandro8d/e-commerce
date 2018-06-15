app.factory("mensagemService", function ($cookies, $uibModal) {
    msg = {};
    msg.confirmacao = function (titulo, msg, casosim, casonao) {

        return $uibModal.open({
            animation: true,
            ariaLabelledBy: 'Seleção de Usuários',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'views/mensagens/confirmacao.html',
            controller: function ($scope, $uibModalInstance) {
                $scope.mensagem = msg;
                $scope.titulo = titulo;
                $scope.ok = function () {
                    $uibModalInstance.close(true);
                }
                $scope.cancel = function () {
                    $uibModalInstance.close(false);
                };
            },
            size: 'md'
        }).result.then(function (res) {
            if (res) {
                if (casosim) {
                    casosim();
                }
            }
            else {
                if (casonao) {
                    casonao();
                }
            }

        }, function (res) { produtosService.adicionarProduto(res); });

    }


    return msg;

});