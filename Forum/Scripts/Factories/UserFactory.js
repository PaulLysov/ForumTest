var UserService = function ($http, $q) {
	return {
		getUserList: function () {
			var deferred = $q.defer();

			$http.get('/api/users/getUserList')
				.then(function success(response) {
					deferred.resolve(response.data);
				}, function error(response) {
					deferred.reject(response.status);
				}
			);

			return deferred.promise;
		},
		editUserInfo: function(user) {
			var deferred = $q.defer();

			$http.post('/api/users/editUserInfo', { user : user })
				.then(function success(response) {
					deferred.resolve(response.data);
				}, function error(response) {
					deferred.reject(response.status);
				}
			);

			return deferred.promise;
		},

		lockoutUser: function (id, block) {
			var deferred = $q.defer();

			$http.post('/api/users/LockoutUser', { id: id, block: block })
				.then(function success(response) {
					deferred.resolve(response.data);
				}, function error(response) {
					deferred.reject(response.status);
				}
			);

			return deferred.promise;
		},
		unblockUser: function (id) {
			var deferred = $q.defer();

			$http.post('/api/users/unblockUser', { id: id })
				.then(function success(response) {
					deferred.resolve(response.data);
				}, function error(response) {
					deferred.reject(response.status);
				}
			);

			return deferred.promise;
		}
	}
}

UserService.$inject = ['$http', '$q'];