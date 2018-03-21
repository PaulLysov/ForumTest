﻿var TopicsPageController = function ($scope) {
	$.get("api/Topic/GetTopicByFilter").done(function(result) {
		$scope.models = result;
	});
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
TopicsPageController.$inject = ['$scope'];