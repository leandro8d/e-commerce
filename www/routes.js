

app.config(['$stateProvider', '$urlRouterProvider',
function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('root', {
         abstract: true,
         templateUrl: 'index.html' ,           
        })

        .state('home', {
            //parent: 'root',
            url: '/',
            templateUrl: 'views/home/home.html',
            controller: 'homeController',
        })

        .state('registrar', {
           // parent: 'root',
            url: '/registrar',
            templateUrl: 'views/registrar/registrar.html',
            controller: 'registrarController',
        })
        .state('gerenciaprodutos', {
            // parent: 'root',
             url: '/gerenciaprodutos',
             templateUrl: 'views/gerenciaprodutos/gerenciaprodutos.html',
             controller: 'gerenciaProdutosController',
        })
        .state('produto', {
            // parent: 'root',
            url: '/produto/{id:int}',
            templateUrl: 'views/produto/produto.html',
            controller: 'produtoController',
        })
        .state('carrinho', {
            // parent: 'root',
            url: '/carrinho',
            templateUrl: 'views/carrinho/carrinho.html',
            controller: 'carrinhoController',
        })
        .state('gerenciausuarios', {
            // parent: 'root',
            url: '/gerenciausuarios',
            templateUrl: 'views/gerenciausuarios/gerenciausuarios.html',
            controller: 'gerenciaUsuariosController',
        })

       

    ;
}]);
