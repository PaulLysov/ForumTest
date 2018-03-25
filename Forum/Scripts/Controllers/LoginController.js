var LoginController = function ($scope, $window, LoginFactory) {
	$scope.loginForm = {
		email: '',
		password: '',
		rememberMe: false,
		loginFailure: false
	};

	$scope.login = function () {
		var result = LoginFactory($scope.loginForm.email, $scope.loginForm.password, $scope.loginForm.rememberMe);
		result.then(function (result) {
			if (result.success) {
				$window.location.pathname = '';
			} else {
				$scope.loginForm.loginFailure = true;
			}
		});
	}
}

LoginController.$inject = ['$scope', '$window', 'LoginFactory'];