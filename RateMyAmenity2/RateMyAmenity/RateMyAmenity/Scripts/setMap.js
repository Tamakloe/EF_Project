// set up document and map functions

$(document).ready(function() 
	{

		function initialize() 
		{	
					//set map centre and positions for markers
					var center_map = new google.maps.LatLng(53.468431,-6.300659); //centre Map
					var pos1 = new google.maps.LatLng(53.58611828,-6.289860078); //Seamus Ennis Cultural Centre
					var pos2 = new google.maps.LatLng(53.57811466,-6.111333221); //The Little Theatre
					var pos3 = new google.maps.LatLng(53.52189548,-6.10291556); // Millbank Theatre
					var pos4 = new google.maps.LatLng(53.39115215,-6.391692704); // Draiocht


					// set zoom and center map to co-ordinates
					var myOptions = 
					{
						zoom: 8,
						center: center_map,
						mapTypeId: google.maps.MapTypeId.ROADMAP
					}

					var map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);


			// set markers 
					var marker1 = new google.maps.Marker({
					position: pos1,
					map: map,
					title: 'Seamus Ennis Cultural Centre'
					});
                        
					var marker2 = new google.maps.Marker({
					position: pos2,
					map: map,
					title: 'The Little Theatre'
					});
                        
					var marker3 = new google.maps.Marker({
					position: pos3,
					map: map,
					title: 'Millbank Theatre'
					});
					
					var marker4 = new google.maps.Marker({
					position: pos4,
					map: map,
					title: 'Draiocht'
					});

			// add the content for the infowindows
                
					var contentString1 = '<div class="content">'+
					'<h5>Seamus Ennis<\/h5>'+
					'<p>Cultural Centre</p>'+
					'</div>'

					var contentString2 = '<div class="content">'+
					'<h5>The Little Theatre<\/h5>'+
					'<p>Arts Centre</p>'+
					'</div>'

					var contentString3 = '<div class="content">'+
					'<h5>Millbank Theatre<\/h5>'+
					'<p>Arts Centre</p>'+
					'</div>'

					var contentString4 = '<div class="content">'+
					'<h5>Draiocht<\/h5>'+
					'<p>Arts Centre</p>'+
					'</div>'					
                
                        
			// set up the infowindows
					var infowindow1 = new google.maps.InfoWindow({
					content: contentString1,
					maxWidth: 100
					});
            
					var infowindow2 = new google.maps.InfoWindow({
					content: contentString2,
					maxWidth: 100
					
					});
            
					var infowindow3 = new google.maps.InfoWindow({
					content: contentString3,
					maxWidth: 100
					});
					
					var infowindow4 = new google.maps.InfoWindow({
					content: contentString4,
					maxWidth: 100
					});					
                
			//set listeners for markers with mouseover to open, mouseout to close

					google.maps.event.addListener(marker1, 'mouseover', function() 
					{infowindow1.open(map, marker1);});
						google.maps.event.addListener(marker1, 'mouseout', function() 
						{infowindow1.close(map, marker1);});
                
					google.maps.event.addListener(marker2, 'mouseover', function() 
					{infowindow2.open(map, marker2);});
						google.maps.event.addListener(marker2, 'mouseout', function() 
						{infowindow2.close(map, marker2);});
			
					google.maps.event.addListener(marker3, 'mouseover', function() 
					{infowindow3.open(map, marker3);});             
						google.maps.event.addListener(marker3, 'mouseout', function() 
						{infowindow3.close(map, marker3);});     
						
					google.maps.event.addListener(marker4, 'mouseover', function() 
					{infowindow4.open(map, marker4);});             
						google.maps.event.addListener(marker4, 'mouseout', function() 
						{infowindow4.close(map, marker4);});     
						
		}
			// end initialize


			// Function added to help reset map and container boundaries
				$("#showMap").click(function() {
				$("#tab2").css({'display':'block'});
				$("#map_canvas").css({'width':'90%','margin':'auto','height':'500px'});
				initialize();

				//alert('showMap Clicked!');
				});

				initialize(); 

	});
//end document ready function