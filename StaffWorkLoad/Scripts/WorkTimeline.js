$(document).ready(function () {
	
	$('.date-pick').datepicker({
		dateFormat: "dd/mm/yy",
		showStatus: true,
		showWeeks: true,
		currentText: 'Now',
		autoSize: true,
		gotoCurrent: true,
		showAnim: 'blind',
		highlightWeek: true
	});

});

var tl = null;
$(document).ready(function () {

	var tl_el = document.getElementById("tl");
	if (tl_el == null)
		return;

	var eventSource = new Timeline.DefaultEventSource();

	var theme1 = Timeline.ClassicTheme.create();
	theme1.event.bubble.width = 350;
	theme1.event.bubble.height = 300;
	//theme1.autoWidth = true; // Set the Timeline's "width" automatically.
	//theme1.timeline_start = new Date(Date.UTC(2000, 0, 1));
	//theme1.timeline_stop  = new Date(Date.UTC(2050, 0, 1));

	var cDate = new Date();
	var prevSunday = new Date(cDate.setDate(cDate.getDate() - cDate.getDay()));
	var d = Timeline.DateTime.parseGregorianDateTime(prevSunday);
	//var d = Timeline.DateTime.parseGregorianDateTime("2010-01-01");

	var bandInfos = [
        Timeline.createBandInfo({
        	width: "80%",
        	intervalUnit: Timeline.DateTime.WEEK,
        	intervalPixels: 550,
        	eventSource: eventSource,
        	date: d,
        	theme: theme1,
        	layout: 'original'  // original, overview, detailed
        }),
				Timeline.createBandInfo({
					width: "20%",
					intervalUnit: Timeline.DateTime.MONTH,
					intervalPixels: 100,
					eventSource: eventSource,
					overview: true
				})
						];
	bandInfos[1].syncWith = 0;
	bandInfos[1].highlight = true;

	// create the Timeline
	tl = Timeline.create(tl_el, bandInfos, Timeline.HORIZONTAL);

	// load timeline data
	$.ajax({
		url: window.location.pathname + "/GetTimelineData",
		type: "GET",
		dataType: "json",
		data: ({}),
		success: function (workloads) {
			eventSource.loadJSON(workloads, '.');
			tl.layout(); // display the Timeline
		}
	});
});

var resizeTimerID = null;
$(window).resize(function () {

	if (resizeTimerID == null) {
		resizeTimerID = window.setTimeout(function () {
			resizeTimerID = null;
			tl.layout();
		}, 500);
	}
});

var timeline_data = {  // save as a global variable
	'dateTimeFormat': 'iso8601',

	"events": [
		{ "start": "Mon, 10 Oct 2011 00:00:00", "end": "Tue, 11 Oct 2011 23:00:00", "title": "Liviu - MVC3", "description": "Introduction to ASP.NET MVC3 Framework", "color": "Green" },
	]
}

