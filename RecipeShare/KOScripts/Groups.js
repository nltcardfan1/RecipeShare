var member = function(userEmail) {
	var self = this;
	self.userEmail = ko.observable(userEmail);
}

var groupVm = function (data) {
	var self = this;
	self.id = ko.observable(); 
	self.name = ko.observable();
	self.userEmails = ko.observableArray();
	self.memberToAdd = ko.observable("");
	self.selectedItems = ko.observableArray();
	//self.recipes = ko.observableArray();
	self.addMember = function () {
		if (self.memberToAdd()) {
			self.userEmails.push(self.memberToAdd());
			self.memberToAdd("");
			//console.log(self.members());
		} else {
			toastrError();
		}
	}
	self.removeSelected = function () {
		this.userEmails.removeAll(self.selectedItems());
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
	self.getGroupInfo = function (data) {
		$.ajax({
			type: "POST",
			url: '/Group/GetGroupInfo',
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

	if (data === parseInt(data, 10)) {
		self.getGroupInfo(data);
	}
}

groupVm.prototype.update = function (data) {
	var self = this;
	self.name(data.Name || "");
	self.id(data.Id || "");
	if (typeof data.UserEmails != "undefined") {
		ko.utils.arrayForEach(data.UserEmails, function (item) {
			self.memberToAdd(item);
			self.addMember();
		});
	}
	
}
