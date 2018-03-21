var AngularMVCApp = angular.module('AngularMVCApp', []);

AngularMVCApp.controller('LoginController', TopicsPageController);
AngularMVCApp.controller('RegistrationController', TopicsPageController);
AngularMVCApp.controller('TopicsPageController', TopicsPageController);
AngularMVCApp.controller('UsersPageController', TopicsPageController);

var configFunction = function ($routeProvider) {
	$routeProvider.
        when('/login', {
        	templateUrl: 'routesDemo/one'
        })
		.when('/registration', {
			templateUrl: 'routesDemo/one'
		})
        .when('/topics', {
        	templateUrl: 'routesDemo/two'
        })
        .when('/users', {
        	templateUrl: 'routesDemo/three'
        });
}
configFunction.$inject = ['$routeProvider'];

AwesomeAngularMVCApp.config(configFunction);