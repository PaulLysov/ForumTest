var LoginController = function ($scope, $routeParams) {
	$scope.loginForm = {
		email: '',
		password: '',
		rememberMe: false,
		returnUrl: $routeParams.returnUrl
	};

	$scope.login = function () {
		//todo
	}
}

LoginController.$inject = ['$scope', '$routeParams'];