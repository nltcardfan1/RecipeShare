var member = function(userEmail) {
	var self = this;
	self.userEmail = ko.observable(userEmail);
}

var groupVm = function () {
	var self = this;
	self.name = ko.observable();
	self.userEmails = ko.observableArray();
	self.memberToAdd = ko.observable("");
	self.selectedItems = ko.observableArray();
	//self.recipes = ko.observableArray();
	self.addMember = function () {
		if (self.memberToAdd()) {
			self.userEmails.push(self.memberToAdd());
			self.memberToAdd("");
			console.log(self.members());
		} else {
			toastrError();
		}
	}
	self.removeSelected = function () {
		this.members.removeAll(self.selectedItems());
		this.selectedItems([]); // Clear selection
	};
	self.errors = ko.validation.group(self);
	self.saveGroup = function () {
		console.log(ko.toJSON(self));
		if (self.errors().length === 0) {
			$.ajax({
				type: "POST",
				url: '/Group/SaveGroup',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				data: ko.toJSON(self),
				success: function (data) {

				},

				error: function (err) {
					//alert(err.status + " - " + err.statusText);
				}
			});
		} else {
			toastrError();
		}
	}
}
$(document).ready(function() {
	ko.applyBindings(new groupVm());
});