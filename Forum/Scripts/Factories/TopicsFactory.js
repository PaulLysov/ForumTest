//get topic list 
var TopicsListFactory = function ($http, $q) {

	return function () {

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
            '/api/Topic/GetTopicsByFilter', {
            	TopicName: name,
            	TopicType: type
            }
        ).then(successFunc, errorFunc);

		return deferredObject.promise;
	}
}
TopicsListFactory.$inject = ['$http', '$q'];


//add new topic 
var AddTopicFactory = function ($http, $q) {
	return function () {

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
            '/api/Topic/GetTopicsByFilter', {
            	TopicName: name,
            	TopicType: type
            }
        ).then(successFunc, errorFunc);

		return deferredObject.promise;
	}
}

AddTopicFactory.$inject = ['$http', '$q'];

