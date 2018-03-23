var RegistrationController = function ($scope, $location, $routeParams, RegistrationFactory) {
	$scope.registerForm = {
		email: '',
		password: '',
		confirmPassword: '',
		returnUrl: $routeParams.returnUrl,
		registrationFailure: false
	};

	$scope.register = function () {
		var result = RegistrationFactory($scope.registerForm.email, $scope.registerForm.password, $scope.registerForm.confirmPassword);
		result.then(function (result) {
			if (result.success) {
				$location.url('/Account/Login');
				//$location.path('/login');
			} else {
				$scope.registerForm.registrationFailure = true;
			}
		});
	}
}

RegistrationController.$inject = ['$scope', '$location', '$routeParams', 'RegistrationFactory'];