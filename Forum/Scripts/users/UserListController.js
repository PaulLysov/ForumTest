(function (app) {
	var UserListController = function ($scope) {
		$scope.message = "Manish Kumar";
	};
	app.controller("UserListController", UserListController);
}
(Angular.module("users")));