var AngularMVCApp = angular.module('AngularMVCApp', ['ngRoute']);

/////////////////////////////////////
//controllers
AngularMVCApp.controller('LoginController', LoginController);
AngularMVCApp.controller('RegistrationController', RegistrationController);

//topics
AngularMVCApp.controller('TopicsListController', TopicsListController);
AngularMVCApp.controller('AddTopicController', AddTopicController);

//users
AngularMVCApp.controller('UsersPageController', UsersPageController);

//factories
AngularMVCApp.factory('LoginFactory', LoginFactory);
AngularMVCApp.factory('RegistrationFactory', RegistrationFactory);
AngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

//configuration 
var configFunction = function ($routeProvider, $httpProvider) {
	$routeProvider.
        when('/login', {
        	templateUrl: '/Account/Login',
        	controller: LoginController
        })
		.when('/registration', {
			templateUrl: '/Account/Registration',
			controller: RegistrationController
		})
        .when('/topics', {
        	templateUrl: '/Topics/Index',
        	controller: TopicsListController
        })
        .when('/users', {
        	templateUrl: '/Users/List'
        });

	$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

AngularMVCApp.config(configFunction);