var LoginFactory = function ($http, $q) {
	return function (email, password, rememberMe) {

		var deferredObject = $q.defer();

		var successFunc = function (data) {
			if (data.status == 200) {
				deferredObject.resolve({ success: true });
			} else {
				deferredObject.resolve({ success: false });
			}
		};

		var errorFunc = function () {
			deferredObject.resolve({ success: false });
		};

		$http.post(
			'/api/Account/Login', {
				Email: email,
				Password: password,
				RememberMe: rememberMe
			}
		).then(successFunc, errorFunc);

		return deferredObject.promise;
	}
}

LoginFactory.$inject = ['$http', '$q'];