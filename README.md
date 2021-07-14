# FahrplanApi
An unofficial library to connect to the Deutsche Bahn Fahrplan API.
<h1>Endpoints</h1>
<table>
<thead>
<tr>
<th>Endpoint</th>
<th>Class</th>
</tr>
</thead>
<tbody>
<tr>
<td>location</td>
<td>LocationApi</td>
</tr>
<tr>
<td>arrivalBoard</td>
<td>ArrivalBoardApi</td>
</tr>
<tr>
<td>departureBoard</td>
<td>DepartureBoardApi</td>
</tr>
<tr>
<td>journeyDetails</td>
<td>JourneyDetailsApi</td>
</tr>
</tr>
</tbody>
</table>

<h2>Examples</h2>
<p>Get all locations containing "Frankfurt"</p>

```csharp
var locationApi = new LocationApi("Frankfurt", new Authentication(token));
locationApi.TestMode = true;
var locations = locationApi.Get();
```

<p>Pass the id of a location to get the arrival board of the given location</p>

```csharp
var arrivalBoardApi = new ArrivalBoardApi(locations[0].Id, new Authentication(token), DateTime.Now);
arrivalBoardApi.TestMode = true;
var arrivals = arrivalBoardApi.Get();
```

<p>Pass the id of a location to get the departure board of the given location</p>

```csharp
var departureBoardApi = new DepartureBoardApi(locations[0].Id, new Authentication(token), DateTime.Now);
departureBoardApi.TestMode = true;
var departures = departureBoardApi.Get();
```         
          
<p>Pass the DetailsId of an arrival board or departure board entry to get the details of the given journey</p>

```csharp
var journeyDetailsApi = new JourneyDetailsApi(arrivals[0].DetailsId, new Authentication(token));
journeyDetailsApi.TestMode = true;
var journeyDetails = journeyDetailsApi.Get();
```
