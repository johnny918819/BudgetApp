namespace BudgetApp {

    angular.module('BudgetApp', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: BudgetApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('details', {
                url: '/details/:id',
                templateUrl: '/ngApp/views/details.html',
                controller: BudgetApp.Controllers.DetailsController,
                controllerAs: 'controller'
            })
            .state('addBudget', {
                url: '/addBudget',
                templateUrl: '/ngApp/views/addBudget.html',
                controller: BudgetApp.Controllers.AddBudgetController,
                controllerAs: 'controller'
            })
            .state('addBill', {
                url: '/addBill',
                templateUrl: '/ngApp/views/addBill.html',
                controller: BudgetApp.Controllers.AddBillController,
                controllerAs: 'controller'
            })
            .state('addIncome', {
                url: '/addIncome',
                templateUrl: '/ngApp/views/addIncome.html',
                controller: BudgetApp.Controllers.AddIncomeController,
                controllerAs: 'controller'
            })
            .state('editIncome', {
                url: '/editIncome',
                templateUrl: '/ngApp/views/editIncome.html',
                controller: BudgetApp.Controllers.EditIncomeController,
                controllerAs: 'controller'
            })
            .state('addGoal', {
                url: '/addGoal',
                templateUrl: '/ngApp/views/addGoal.html',
                controller: BudgetApp.Controllers.AddGoalController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: BudgetApp.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: BudgetApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: BudgetApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: BudgetApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: BudgetApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('BudgetApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('BudgetApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
