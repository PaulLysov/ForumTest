var TopicsListController = function ($scope, TopicsListFactory) {
	$scope.models = {
		Topics: [
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' },
			{ Name: 'Test1', CountMessage: 20, LastUser: 'User1' }
		]
	};

}
TopicsListController.$inject = ['$scope', 'TopicsListFactory'];

//add new topic
var AddTopicController = function ($scope,  AddTopicFactory) {
	$scope.topicForm = {
		name: '',
		type: 1,
		isFailure: false
	};

	$scope.addTopic = function () {
		var result = AddTopicFactory($scope.topicForm.name, $scope.topicForm.type);
		result.then(function (result) {
			if (result.success) {
				$location.path('/topics');
			} else {
				$scope.topicForm.isFailure = true;
			}
		});
	}
}
AddTopicController.$inject = ['$scope', 'AddTopicFactory'];