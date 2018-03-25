var TopicMessageController = function ($scope, TopicsService) {

	$scote.topicId = null;


	$scope.messageForm = {

		message: '',
		errMsg: ''
	};

	$scope.topicList = null;

	var promiseList = TopicsService.getTopicsList($scope.filter);
	promiseList.then(function(list) {
		$scope.topicList = list;
	});

	$scope.showTopic = function (id) {
		$location.path('/showTopic?id=' + id);
	};

	$scope.addTopic = function () {

		var promiseNewTopic = TopicsService.addNewTopic($scope.topicForm.name, $scope.topicForm.message);
		promiseNewTopic.then(function(value) {
			$scope.topicList.push(value);
		});
	}
}
TopicMessageController.$inject = ['$scope', '$http', 'TopicsService'];
