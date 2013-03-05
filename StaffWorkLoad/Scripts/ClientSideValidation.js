
$.validator.unobtrusive.adapters.add(
	'dategreaterthan',
	['refdate'],
	function (options) {
		var element = $(options.form).find(':input[name=' + options.params.refdate + ']')[0];
		options.rules['dategreaterthan'] = {element: element};
		options.messages['dategreaterthan'] = options.message;
	}
);

$.validator.addMethod(
	'dategreaterthan',
	function (value, element, params) {

		var sCurDate = value.split('/');
		var curDate = new Date(sCurDate[2], sCurDate[1], sCurDate[0]);

		var refDateValue = $(params.element).val();
		var sRefDate = refDateValue.split('/');
		var refDate = new Date(sRefDate[2], sRefDate[1], sRefDate[0]);

		return curDate > refDate;
	}
);

