var RegistrationController = function ($scope, $routeParams) {
	$scope.registerForm = {
		email: '',
		password: '',
		confirmPassword: '',
		returnUrl: $routeParams.returnUrl
	};

	$scope.register = function () {
		//todo
	}
}

RegistrationController.$inject = ['$scope', '$routeParams'];