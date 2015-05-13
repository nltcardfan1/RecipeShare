/// <reference path="~/Scripts/jquery-2.1.3.js" />
/// <reference path="~/Scripts/knockout-3.3.0.js" />

//var RecipeVm = {
//	ingredients: ko.observableArray()
//}

//var Ingredient = {
//	food: ko.observable(),
//	amount: ko.observable(),
//	foodGroup: ko.observable()
//}
var foodVm = function(foods) {
		var self = this;
		self.foods = ko.observableArray(foods),
		self.test = ko.observable();
};
$.ajax({
				type: "POST",
				url: '/Recipe/GetFoods',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (data) {
					

					ko.applyBindings(new foodVm(data));
				},

				error: function(err) {
					//alert(err.status + " - " + err.statusText);
				}
			});
//var foodVm = {
//	foods: ko.observableArray([]),
//	test : ko.observable(),

//	getFoods : function() {
//		$.ajax({
//			type: "POST",
//			url: '/Recipe/GetFoods',
//			contentType: "application/json; charset=utf-8",
//			dataType: "json",
//			success: function (data) {
				
//				$.each(data, function(index, value) {
//					foodVm.foods.push(value);
//				});

//				ko.applyBindings(foodVm);
//			},

//			error: function(err) {
//				//alert(err.status + " - " + err.statusText);
//			}
//		});
//	},
//	alert : function() {
//		alert(foodVm.test.value);
//	}
//}



//$().ready(function() {
//	foodVm.getFoods();
//});
