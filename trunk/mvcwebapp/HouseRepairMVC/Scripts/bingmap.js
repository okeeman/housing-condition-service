 var map = null;
          var query;
          var address;
          function getMap() {
              map = new Microsoft.Maps.Map(document.getElementById('myMap'), { credentials: 'AljxZmh_XCLVHZRtCXA8uMJhe_zN3VDnd17sbgZQ4wnhC3aAWJNWOE5boR074yv9' });
          }

          function findLocation(address) {
              query = address;
              map.getCredentials(callSearchService);
          }

          function callSearchService(credentials) {
              var searchRequest = 'http://dev.virtualearth.net/REST/v1/Locations/' + query + '?output=json&jsonp=searchServiceCallback&key=' + credentials;
              var mapscript = document.createElement('script');
              mapscript.type = 'text/javascript';
              mapscript.src = searchRequest;
              document.getElementById('myMap').appendChild(mapscript)
          }

          function searchServiceCallback(result) {
              var output = document.getElementById("output");
              if (output) {
                  while (output.hasChildNodes()) {
                      output.removeChild(output.lastChild);
                  }
              }
              var resultsHeader = document.createElement("h5");
              output.appendChild(resultsHeader);

              if (result &&
          result.resourceSets &&
          result.resourceSets.length > 0 &&
          result.resourceSets[0].resources &&
          result.resourceSets[0].resources.length > 0) {
                  resultsHeader.innerHTML = "Bing Maps<br/>Found location " + result.resourceSets[0].resources[0].name;
                  var bbox = result.resourceSets[0].resources[0].bbox;
                  var viewBoundaries = Microsoft.Maps.LocationRect.fromLocations(new Microsoft.Maps.Location(bbox[0], bbox[1]), new Microsoft.Maps.Location(bbox[2], bbox[3]));
                  map.setView({ bounds: viewBoundaries });
                  var location = new Microsoft.Maps.Location(result.resourceSets[0].resources[0].point.coordinates[0], result.resourceSets[0].resources[0].point.coordinates[1]);
                  var pushpin = new Microsoft.Maps.Pushpin(location);
                  map.entities.push(pushpin);
              }
              else {
                  if (typeof (response) == 'undefined' || response == null) {
                      alert("Invalid credentials or no response");
                  }
                  else {
                      if (typeof (response) != 'undefined' && response && result && result.errorDetails) {
                          resultsHeader.innerHTML = "Message :" + response.errorDetails[0];
                      }
                      alert("No results for the query");

                  }
              }
          } 