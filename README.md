# Deutsche Bahn Fahrplan API Library
<p>An unofficial .Net library to connect to the Deutsche Bahn Fahrplan API.</p>

<p>I am an independet developer and i am not business related (or in any other way) to the Deutsche Bahn AG.</p>

<p>This is just a library to help other programmers to develop applications using the Deutsche Bahn API.</p>

<h2>Requirements</h2>
<p><b>.Net Framework 4.7.2</b></p>
<p>This library was programmed in .Net Framework 4.7.2. You can download it and decrease the .Net version as much as you need it. I didn't tested it below the mentioned version and don't know if it will work.</p>
<p><b>To use this library you need to add Newtonsoft.JSON. It's explained <a href="https://www.nuget.org/packages/Newtonsoft.Json/">here</a> how to get it.</p></b>
<p>You also need an API Token or an developer Account. You can create register <a href="https://developer.deutschebahn.com/store/site/pages/sign-up.jag">here</a>

<h2>Endpoints</h2>

Endpoint | Class | Version
------------- | ------------- | -------------
`location` | LocationApi | `v1`
`arrivalBoard` | ArrivalBoardApi | `v1`
`departureBoard` | DepartureBoardApi | `v1`
`journeyDetails` | JourneyDetailsApi | `v1`


<h2>Examples</h2>
<p><a href="https://github.com/Programmat0r/FahrplanApi/blob/main/FahrplanClient/Program.cs">Here</a> is a reference implementation.</a>
<p>Get all locations containing "Frankfurt"</p>

```csharp
var locationApi = new LocationApi("Frankfurt", new Authentication(token));
locationApi.TestMode = true;
locationApi.SecureConnection = true;
var locations = locationApi.Get();
```

<p>Pass the id of a location to get the arrival board of the given location</p>

```csharp
var arrivalBoardApi = new ArrivalBoardApi(locations[0].Id, new Authentication(token), DateTime.Now);
arrivalBoardApi.TestMode = true;
arrivalBoardApi.SecureConnection = true;
var arrivals = arrivalBoardApi.Get();
```

<p>Pass the id of a location to get the departure board of the given location</p>

```csharp
var departureBoardApi = new DepartureBoardApi(locations[0].Id, new Authentication(token), DateTime.Now);
departureBoardApi.TestMode = true;
departureBoardApi.SecureConnection = true;
var departures = departureBoardApi.Get();
```         
          
<p>Pass the DetailsId of an arrival board or departure board entry to get the details of the given journey</p>

```csharp
var journeyDetailsApi = new JourneyDetailsApi(arrivals[0].DetailsId, new Authentication(token));
journeyDetailsApi.TestMode = true;
journeyDetailsApi.SecureConnection = true;
var journeyDetails = journeyDetailsApi.Get();
```

<h2>License</h2>

<p>Code - <a href="http://www.apache.org/licenses/LICENSE-2.0">APACHE LICENSE, VERSION 2.0</a></p>

