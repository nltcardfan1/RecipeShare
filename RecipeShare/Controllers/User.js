/// <reference path="~/Scripts/jquery-2.1.3.js" />
/// <reference path="~/Scripts/knockout-3.3.0.js" />

function User(data) {
	this.userId = ko.observable(data.Id);
	this.firstName = ko.observable(data.FirstName);
	this.lastName = ko.observable(data.LastName);
	//self.UserName = ko.observable();
}

var ProfileVM = {
	user: ko.observable()
}

$(document).ready(function () {
	$.ajax({
		type: "POST",
		url: '/Profile/GetProfileForUser',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (results) {
			ProfileVM.User(User(results));
			debugger;
			console.log(results);
		},
		error: function (err) {
			//alert(err.status + " - " + err.statusText);
		}
	});
	ko.applyBindings(ProfileVM);
});

