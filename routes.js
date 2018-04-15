

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
 

       

    ;
}]);
