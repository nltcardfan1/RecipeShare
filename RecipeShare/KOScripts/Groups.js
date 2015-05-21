//var member = function(data) {
//	var self = this;
//	self.userId = ko, observable();
//}

var groupVm = function () {
	var self = this;
	self.name = ko.observable();
	self.members = ko.observableArray();
	self.memberToAdd = ko.observable("");
	self.selectedItems = ko.observableArray();
	//self.recipes = ko.observableArray();
	self.addMember = function() {
		self.members.push(self.memberToAdd());
	}
}
$(document).ready(function() {
	ko.applyBindings(new groupVm());
});