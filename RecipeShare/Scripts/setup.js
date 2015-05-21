/// <reference path="toastr.js" />


function toastrError() {
	toastr.clear();
	toastr.error("Please enter a valid value");
}

ko.validation.init({
	registerExtenders: true,
	messagesOnModified: true,
	insertMessages: true,
	parseInputAttributes: true,
	messageTemplate: null
}, true);