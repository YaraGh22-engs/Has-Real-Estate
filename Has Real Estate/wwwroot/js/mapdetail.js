function GetMap() {


    ///////////////Converting the C# Model to JS model
    // convsert the data base table to Array in json type
    var home = @Html.Raw(Json.Serialize(Model));


    //You can customize the map as you load it.
    // Use the following code to update how the map is loaded in the GetMap function such that it sets the type to aerial,
    // the zoom level to 10, and the map center over London, UK (51.50632, -0.12714).
    var map = new Microsoft.Maps.Map('#myMap', {
        credentials: 'ArTYnXAo5ajG1e4ZyFIV-LT3sW_IU0Uy2YETN7N-u5EdkJOaOwaft6BOA1SPlVfA',
        center: new Microsoft.Maps.Location(home.longitude, home.latitude),
        mapTypeId: Microsoft.Maps.MapTypeId.aerial,
        zoom: 10
    });

    var location = new Microsoft.Maps.Location(home.longitude, home.latitude);
    var pin = new Microsoft.Maps.Pushpin(location, {
        color: 'green',
        title: home.name,
    });
    map.entities.push(pin);

    //////////////////Pushpins, sometimes known as MapIcons or Markers,
    // are the primary method in the Bing Maps V8 Map Control to add a graphical image and text at a location within the map.
    //Create custom Pushpin
    // هنا يمكننا وضع الاحداثيات بدل سينتر لتثبيت ماركر

    var myloc = new Microsoft.Maps.Location(35.340192118895025, 35.93475407561252);
    var pin = new Microsoft.Maps.Pushpin(myloc, {
        color: 'red',
        title: 'Jableh',
        subTitle: 'City Center',

    });
    map.entities.push(pin);
} // end of Getmap()