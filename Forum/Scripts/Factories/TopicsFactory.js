//get topic list 
var TopicsService = function ($http, $q) {

	return {
		getTopicsList: function (filter) {

			var deferredObject = $q.defer();

			$http.get('/api/Topic/GetTopicsByFilter', {filter: filter}).then(
			function success(response) {
				deferredObject.resolve(response.data);
			},
			function error() {
				deferredObject.resolve(response.status);
			});

			return deferredObject.promise;
		},
		addNewTopic: function (name, message) {
			var deferredObject = $q.defer();
			$http.post(
				'/Topics/AddTopic',
				{
					name: name,
					message: message
				}
			).then(
			function success(response) {
				deferredObject.resolve(response.data);
			},
			function error(ex) {
				deferredObject.resolve(response.status);
			});

			return deferredObject.promise;
		}
	}
}
TopicsService.$inject = ['$http', '$q'];


