var AddTopicFactory = function ($http, $q) {

	return function (name, type) {

		var deferredObject = $q.defer();

		var successFunc = function (data) {
			if (data == "True") {
				deferredObject.resolve({ success: true });
			} else {
				deferredObject.resolve({ success: false });
			}
		};

		var errorFunc = function () {
			deferredObject.resolve({ success: false });
		};

		$http.post(
            '/api/Topic/Login', {
            	Email: email,
            	Password: password,
            	RememberMe: rememberMe
            }
        ).then(successFunc, errorFunc);

		return deferredObject.promise;
	}
}

LoginFactory.$inject = ['$http', '$q'];