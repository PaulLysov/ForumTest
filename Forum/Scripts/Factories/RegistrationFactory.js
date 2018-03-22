var RegistrationFactory = function ($http, $q) {
	return function (email, password, confirmPassword) {

		var deferredObject = $q.defer();

		var success = function (data) {
			if (data.status == 200) {
				deferredObject.resolve({ success: true });
			} else {
				deferredObject.resolve({ success: false });
			}
		};

		var error = function () {
			deferredObject.resolve({ success: false });
		};

		$http.post(
			'/api/Account/Register', {
				Email: email,
				Password: password,
				ConfirmPassword: confirmPassword
			}
		).then(success, error);

		return deferredObject.promise;
	}
}

RegistrationFactory.$inject = ['$http', '$q'];