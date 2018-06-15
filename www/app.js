var app = angular.module("ecommerce", 
[
    'ui.router',
    'ngCookies',
    'ui.bootstrap',
    'ngMaterial',
    'ngMessages'
]
);
app.filter('to_trusted', ['$sce', function ($sce) {
    return function (text) {
        return $sce.trustAsHtml(text);
    };
}]);