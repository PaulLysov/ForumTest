var RegistrationController = function ($scope, $routeParams, RegistrationFactory) {
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
				$location.path('/topics');
			} else {
				$scope.registerForm.registrationFailure = true;
			}
		});
	}
}

RegistrationController.$inject = ['$scope', '$routeParams', 'RegistrationFactory'];