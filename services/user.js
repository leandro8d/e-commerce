app.factory("userService",function($cookies){
user = {};
user.list = [];
user.adicionarUsuario = function(usuario){
    user.list.push(usuario);
}
user.logar = function(login,senha){

    for(var i=0 in user.list){
        if(user.list[i].Login==login){
            if(user.list[i].Senha==senha){
                $cookies.put('sessao', JSON.stringify(user.list[i]));
                return user.list[i];
            }
            else
            {
                alert("senha ou usuario inválido!");
                return false;
            }
        }
    }
    alert("usuario nao existe");
    return false;
}

user.getUsuarioLogado = function(){
    var usuario = angular.fromJson($cookies.get('sessao'));
    if(usuario=null){
    return null;
    }
    return usuario;
}
return user;

});