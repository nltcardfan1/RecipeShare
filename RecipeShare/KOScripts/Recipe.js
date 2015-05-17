/// <reference path="~/Scripts/jquery-2.1.3.js" />
/// <reference path="~/Scripts/knockout-3.3.0.js" />

var recipe = function () {
	var self = this;
	self.name = ko.observable();
	self.serves = ko.observable();
	self.prepTime = ko.observable();
	self.cookTime = ko.observable();
	self.RecipeCategory = ko.observable();
}

var Ingredient = function(food, amount) {
	var self = this;
	self.food = ko.observable(food);
	self.amount = ko.observable(amount);
}


var recipeVm = function() {
	var self = this;
	self.name = ko.observable();
	self.foodGroups = ko.observableArray();
	self.recipeCategories = ko.observableArray();
	self.serves = ko.observable();
	self.prepTime = ko.observable();
	self.cookTime = ko.observable();
	self.food = ko.observable();
	self.amount = ko.observable();
	self.ingredient = ko.observable(function(food, amount) {
		this.food = ko.observable(food);
		this.amount = ko.observable(amount);
	});
	self.ingredients =  ko.observableArray(
	//	ko.utils.arrayMap(self.ingredient, function (ingredient) {
	//		return ko.observable(ingredient);
	//	})
	);

	//self.currentIngredient = ko.observable(ko.utils.Map(Ingredient, function(ingredient) {
	//	return ko.observable(ingredient);
	//}));
	self.getFoodGroups = function() {
		$.ajax({
			type: "POST",
			url: '/Recipe/GetFoodGroups',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function(data) {

				$.each(data, function(index, value) {
					self.foodGroups.push(value);
				});

			},

			error: function(err) {
				//alert(err.status + " - " + err.statusText);
			}
		});
	}

	self.getRecipeCategories = function() {
		$.ajax({
			type: "POST",
			url: '/Recipe/GetRecipeCategories',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function(data) {

				$.each(data, function(index, value) {
					self.recipeCategories.push(value);
				});

			},

			error: function(err) {
				//alert(err.status + " - " + err.statusText);
			}
		});
	}
	self.addIngredient = function() {

		self.ingredients.push(new Ingredient(self.food(), self.amount()));
		self.food("");
		self.amount("");
	};
	self.foodGroupId = ko.observable();
	self.getRecipeCategories();
}



//	},
//	alert : function() {
//		alert(foodVm.test.value);
//	}
//}



$(document).ready(function () {
	ko.applyBindings(new recipeVm());
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
