var timeline_data = {  // save as a global variable
/*'dateTimeFormat': 'iso8601',*/

'events' : [
        {'start': '2011-10-03',
        'end': '2011-10-08',
        'title': 'Liviu - Shairs 3',
        'description': 'Upgrading Shairs 3 to ensure compatibility with Win7 x64 and Office 2010 ',
        'color' : 'red',
        'textColor' : 'green'
		},

        {'start': '2011-10-03',
        'end': '2011-10-08',
        'title': 'Conrad - ESOS',
        'description': 'ESOS Portal Poc',
        'color': 'green'
        },


        {'start': '2011-10-03',
        'end': '2011-10-08',
        'title': 'Dan - SPARS Diary',
        'description': 'CRSTORE - SPARS Diary'
        },

        {'start': '2011-10-10',
        'end': '2011-10-12 23:00',
        'title': 'Liviu - Radar',
        'description': 'Upgrading Radar to ensure compatibility with Win7 x64 and Office 2010 ',
        'color' : 'red',
        'textColor' : 'green'
		},

        {'start': '2011-10-14',
        'end': '2011-10-15',
        'title': 'Liviu - Imagic',
        'description': 'Upgrading CTWorkbench + IADCM Watcher to ensure compatibility with Win7 x64 and Office 2010 ',
        'color' : 'red',
        'textColor' : 'green'
		},

        {'start': '2011-10-10',
        'end': '2011-10-12',
        'title': 'Conrad - ESOS',
        'description': 'ESOS Portal Poc',
        'color': 'green'
        },

        {'start': '2011-10-13',
        'end': '2011-10-15',
        'title': 'Conrad - ESOS',
        'description': 'ESOS Portal Poc',
        'color': 'green'
        },

        {'start': '2011-10-10',
        'end': '2011-10-15',
        'title': 'Dan - CRStore',
        'description': 'CRSTORE - Web sites',
        }

]
}

var tl, eventSource;
function onLoad() {
    var tl_el = document.getElementById("tl");
    eventSource = new Timeline.DefaultEventSource();
            
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
            width:          "80%",
            intervalUnit:   Timeline.DateTime.WEEK, 
            intervalPixels: 550,
            eventSource:    eventSource,
            date:           d,
            theme:          theme1,
            layout:         'original'  // original, overview, detailed
        }),
				Timeline.createBandInfo({          
					width:          "20%",           
					intervalUnit:   Timeline.DateTime.MONTH,           
					intervalPixels: 100,
					eventSource:    eventSource,
					overview:		true
				})
						];
				bandInfos[1].syncWith = 0;    
				bandInfos[1].highlight = true;
                                                            
    // create the Timeline
    tl = Timeline.create(tl_el, bandInfos, Timeline.HORIZONTAL);
            
//    var url = '.'; // The base url for image, icon and background image references in the data
//    eventSource.loadJSON(timeline_data, url); // The data was stored into the timeline_data variable.
//    tl.layout(); // display the Timeline
//		tl.loadXML("events.xml", function(xml, url) {eventSource.loadXML(xml, url);});

		// load timeline data
		loadTimeline();
}
        
function loadTimeline() {

	$.ajax({ 
          url: "/WorkLoad/GetTimelineData", 
          type: "GET", 
          dataType: "json", 
          data: ({ }), 
          success: function (workloads) { 
							eventSource.loadJSON(workloads, '.'); 
							tl.layout(); // display the Timeline
          } 
      }); 

}

var resizeTimerID = null;
function onResize() {
    if (resizeTimerID == null) {
        resizeTimerID = window.setTimeout(function() {
            resizeTimerID = null;
            tl.layout();
        }, 500);
    }
}



