/// <reference path="~/Scripts/jquery-2.1.3.js" />
/// <reference path="~/Scripts/knockout-3.3.0.js" />

function User(data) {
	self.userId = ko.observable(data.Id);
	self.firstName = ko.observable(data.FirstName);
	self.lastName = ko.observable(data.LastName);
	//self.UserName = ko.observable();
}

$.ajax({
	type: "POST",
	url: '/Profile/GetProfileForUser',
	contentType: "application/json; charset=utf-8",
	dataType: "json",
	success: function (results) {
		//self.Students(students);
		debugger;
		console.log(results);
	},
	error: function (err) {
		//alert(err.status + " - " + err.statusText);
	}
})