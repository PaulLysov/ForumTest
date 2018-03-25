var UsersController = function ($scope, UserFactory ) {

	$scope.usersList = UserFactory.getUserList();

	$scope.userInfo = function() {
		$scope.userForm = UserFactory.getUser();
	}

	$scope.userForm = {
		email: '',
		login: '',
		firstName: '',
		lastName: '',
		errMsg: ''
	};

	$scope.editUserInfo = function() {
		UserFactory.editUserInfo($scope.userForm);
	};

	$scope.blockUser = function (id) {
		UserFactory.lockoutUser(id, true);
	};

	$scope.unblockUser = function (id) {
		UserFactory.lockoutUser(id, false);
	};
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
UsersController.$inject = ['$scope', 'UserFactory'];