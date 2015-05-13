/// <reference path="~/Scripts/jquery-2.1.3.js" />
/// <reference path="~/Scripts/knockout-3.3.0.js" />

//function User(data) {
//	this.userId = ko.observable(data.Id);
//	this.firstName = ko.observable(data.FirstName);
//	this.lastName = ko.observable(data.LastName);
//	//self.UserName = ko.observable();
//}

var ProfileVM = {
	userId: ko.observable(),
	firstName: ko.observable(),
	lastName: ko.observable(),
	recipes: ko.observableArray(),
	groups: ko.observableArray()
};
	
getUserInfo= function () {
		$.ajax({
			type: "POST",
			url: '/Profile/GetProfileForUser',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (results) {
				//self.User(results);
				ProfileVM.userId = results.Id;
				ProfileVM.firstName = results.FirstName;
				ProfileVM.lastName = results.LastName;
				ProfileVM.groups = results.RecipeGroups;
				ProfileVM.recipes = results.Recipes;
				ko.applyBindings(ProfileVM);
			},
			error: function (err) {
				//alert(err.status + " - " + err.statusText);
			}
		});
	}


$(document).ready(function () {
	getUserInfo();
});


//function AppViewModel() {
//	this.firstName = ko.observable("Bert");
//	this.lastName = ko.observable("Bertington");
//}
// Activates knockout.js


//When I click button I want the name to change
//$('input[type=button]').click(function () {
//	//var name = 'New Name';
//	//AppViewModel.firstName();

//});

//$(document).ready(function() {
//	ko.applyBindings(new AppViewModel());
//});