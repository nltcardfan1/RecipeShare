/// <reference path="~/Scripts/jquery-2.1.3.js" />
/// <reference path="~/Scripts/knockout-3.3.0.js" />
/// <reference path="~/Scripts/toastr.js" />
/// <reference path="~/Scripts/knockout.validation.js" />
/// <reference path="~/Scripts/setup.js" />


var Ingredient = function(food, amount) {
	var self = this;
	self.food = ko.observable(food);
	self.amount = ko.observable(amount);
	self.formated = ko.computed(function() {
		return self.amount() + " " + self.food();
	});
}

var Step = function(narrative) {
	var self = this;
	self.narrative = ko.observable(narrative);
}



var recipeVm = function(data) {
	var self = this;
	self.Id = ko.observable();
	self.name = ko.observable().extend({ required: true });
	self.foodGroups = ko.observableArray();
	self.groups = ko.observableArray();
	self.groups.forRecipe = ko.observableArray();
	self.chosenGroups = ko.observableArray();
	self.recipeCategories = ko.observableArray();
	self.serves = ko.observable().extend({ required: true});
	self.prepTime = ko.observable().extend({ number: true });
	self.cookTime = ko.observable().extend({ number: true });
	self.food = ko.observable();
	self.amount = ko.observable();
	self.ingredients = ko.observableArray();
	self.step = ko.observable();
	self.instructions = ko.observableArray();
	self.errors = ko.validation.group(self);
	self.getRecipe = function (data) {
		$.ajax({
			type: "POST",
			url: '/Recipe/GetRecipe',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			data: "{'id':" + data + "}",
			success: function (data) {
				self.update(data);

			},

			error: function (err) {
				//alert(err.status + " - " + err.statusText);
			}
		});
	}

	//coming from edit, data is ID of recipe
	if (data === parseInt(data, 10)) {
		self.getRecipe(data);
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
				alert(err.status + " - " + err.statusText);
			}
		});
	}
	self.addIngredient = function() {
		if (self.food() && self.amount()) {
			self.ingredients.push(new Ingredient(self.food(), self.amount()));
			self.food("");
			self.amount("");
		} else {
			toastrError();
		}
	};
	self.removeIngredient = function() {
		self.ingredients.remove(this);
	};
	self.addStep = function () {
		if (self.step()) {
			self.instructions.push(new Step(self.step()));
			self.step("");
		} else {
			toastrError();
		}
	};
	self.removeStep = function () {
		self.instructions.remove(this);
	}
	self.addGroup = function () {
		$.each(self.chosenGroups(), function (key, value) {
			//alert(key + " : " + value);
			self.groups.forRecipe.push(value);
			self.groups.remove(value);
		});
	}
	self.saveRecipe = function () {
		//console.log(ko.toJSON(self));
		if (self.errors().length === 0) {
		$.ajax({
			type: "POST",
			url: '/Recipe/SaveRecipe',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			data: ko.toJSON(self),
			success: function (data) {

				$.each(data, function (index, value) {
					self.foodGroups.push(value);
				});

			},

			error: function (err) {
				//alert(err.status + " - " + err.statusText);
			}
		});
		} else {
			toastrError();
		}
	}
	self.getGroupsForUser = function() {
		$.ajax({
			type: "POST",
			url: '/Group/GetGroupsForUser',
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function (data) {
				$.each(data, function(index, value) {
					self.groups.push(value);
				});
			}
		});
	}
	self.getGroupsForUser();
	self.getRecipeCategories();
}


recipeVm.prototype.update = function (data) {
	var self = this;
	self.Id(data.Id || "");
	self.name(data.Name || "");
	self.serves(data.Serves || "");
	self.prepTime(data.PrepTime || "");
	self.cookTime(data.CookTime || "");
	if (typeof data.Ingredients != "undefined") {
		ko.utils.arrayForEach(data.Ingredients, function (item) {
			self.food(item.Food);
			self.amount(item.Amount);
			self.addIngredient();
		});
	}
	if (typeof data.Instructions != "undefined") {
		ko.utils.arrayForEach(data.Instructions, function (item) {
			self.step(item.Narrative);
			self.addStep();
		});
	}

};

