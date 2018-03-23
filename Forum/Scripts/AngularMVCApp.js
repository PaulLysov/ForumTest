var AngularMVCApp = angular.module('AngularMVCApp', ['ngRoute']);

/////////////////////////////////////
//controllers
AngularMVCApp.controller('LoginController', LoginController);
AngularMVCApp.controller('RegistrationController', RegistrationController);

AngularMVCApp.controller('TopicsListController', TopicsListController);
AngularMVCApp.controller('AddTopicController', AddTopicController);

AngularMVCApp.controller('UsersPageController', UsersPageController);

//factories
AngularMVCApp.factory('LoginFactory', LoginFactory);
AngularMVCApp.factory('RegistrationFactory', RegistrationFactory);

AngularMVCApp.factory('AddTopicFactory', AddTopicFactory);
AngularMVCApp.factory('TopicsListFactory', AddTopicFactory);

AngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);

//configuration 
var configFunction = function ($routeProvider, $httpProvider) {
	$routeProvider.
        when('/login', {
        	templateUrl: '/Account/Login.cshtml',
        	controller: LoginController
        })
		.when('/registration', {
			templateUrl: '/Account/Registration.cshtml',
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