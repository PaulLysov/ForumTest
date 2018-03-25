var AngularMVCApp = angular.module('AngularMVCApp', ['ngRoute']);

//controllers
AngularMVCApp.controller('LoginController', LoginController);
AngularMVCApp.controller('RegistrationController', RegistrationController);
AngularMVCApp.controller('TopicsController', TopicsController);
AngularMVCApp.controller('TopicMessagesController', TopicMessagesController);
AngularMVCApp.controller('UsersController', UsersController);

//factories
AngularMVCApp.factory('LoginFactory', LoginFactory);
AngularMVCApp.factory('RegistrationFactory', RegistrationFactory);
AngularMVCApp.factory('TopicsService', TopicsService);
AngularMVCApp.factory('UserFactory', UserService);

AngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

//configuration 
var configFunction = function ($routeProvider, $httpProvider) {
	$routeProvider.
		when('/login', {
			templateUrl: '/account/login',
			controller: LoginController
		})
		.when('/registration', {
			templateUrl: '/account/registration',
			controller: RegistrationController
		})
		.when('/topics', {
			templateUrl: '/Topic/Index',
			controller: TopicsController
		})
		.when('/showTopic/:id', {
		templateUrl: '/TopicMessages/Index',
		controller: TopicMessagesController
		})
		.when('/users', {
			templateUrl: '/users/list'
		});
	//$routeProvider.otherwise({ redirectTo: '/topics' });
	$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

AngularMVCApp.config(configFunction);