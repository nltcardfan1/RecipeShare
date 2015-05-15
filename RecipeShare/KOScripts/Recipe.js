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
		self.foods = ko.observableArray(foods)
};

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



$(document).ready(function () {
	$("#foodSearch").autocomplete({
		delay: 500,
		minLength: 3,
		source: function(request, response) {
			$.ajax({
				dataType: "json",
				data: { "search": request.term },
				url: '/Recipe/GetFoods',
				success: function (data) {
					var items = $.map(data, function (item) {
						return {
							label: item.name,
							value: item.id
						};
					});
					response(items);
				}
				
			});
		},
		select: function (event, ui) {
			$("#foodSearch").val(ui.item.label);
			//cityID = ui.item.id;
			return false;
		}
	});

//	foodVm.getFoods();
});
