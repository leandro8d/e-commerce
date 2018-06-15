app.factory("userService", function ($cookies, $http, $state, $mdToast) {
    user = {};
    user.list = [];

    user.getUsers = function () {
        $http.get('api/usuario/listar', ).then(function (response) {
            user.list = response.data;
        });
    }

    user.getUsers();

    user.adicionarUsuario = function (usuario) {
        usuario.IdTipoUsuario = 2;
        $http.put('api/usuario', usuario).then(function (erro) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(erro.data)
                    .position('bottom right')
                    .hideDelay(3000)
            );
        }, function (result) {
            alert(result.data);
            $state.go('home');
        });
    }

    user.editarUsuario = function (usuario) {
        $http.post('api/usuario', usuario).then(function (erro) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(erro.data)
                    .position('bottom right')
                    .hideDelay(3000)
            );
            user.getUsers();
        }, function (result) {
            alert(result.data);
            $state.go('home');
        });
    }


    user.removerUsuario = function (usuario) {
        $http.delete('api/usuario', { params: { idUsuario: usuario.IdUsuario } }).then(function (erro) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(erro.data)
                    .position('bottom right')
                    .hideDelay(3000)
            );
            user.getUsers();
        }, function (result) {
            alert(result.data);
            $state.go('home');
        });
    }

    user.logar = function (login, senha,event) {
        $http.post('api/usuario/logar', { Email: login, Senha: senha, }).then(function (response) {
            
            var today = new Date();
            var expiresValue = new Date(today);

            //Set 'expires' option in 1 minute
            expiresValue.setMinutes(today.getMinutes() + 1800);

            $cookies.put('sessao', JSON.stringify(response.data), { 'expires': expiresValue });
            event(response.data);

        }, function (erro,e,c,b) {
            alert(erro.data);
        });
    }

    user.getUsuarioLogado = function () {
        var usuario = angular.fromJson($cookies.get('sessao'));
        if (usuario == null) {
            //$state.go('home');
            return null;
        }
        return usuario;
    }


    user.logout = function () {
        $cookies.remove('sessao')
        $state.go('home');
    }
    return user;

});