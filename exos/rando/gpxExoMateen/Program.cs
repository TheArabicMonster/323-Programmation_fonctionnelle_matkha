using Aspose.Gis;
using Aspose.Gis.Geometries;
using gpxExo;
using System;

var layer = Drivers.Gpx.OpenLayer(".\\Ballade_châtaignère_🌰.gpx");

List<Trackpoint> trackpoints = new List<Trackpoint>();

var srs

foreach (var feature in layer)
{

    if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
    {

        var lines = (MultiLineString)feature.Geometry;
        for (int i = 0; i < lines.Count; i++)
        {
            var segment = (LineString)lines[i];


            for (int j = 0; j < segment.Count; j++)
            {

                var point = segment[j];

                double elevation = point.HasZ ? point.Z : 0.0;


                Trackpoint trackpoint = new Trackpoint
                {
                    _latitude = point.Y,
                    _longitude = point.X,
                    _elevation = elevation
                };
                trackpoints.Add(trackpoint);
            }
        }
    }
}

var reducedTrackpoints = trackpoints
    .Where((trackpoint, index) => index % 5 == 0)
    .ToList();


foreach (var trackpoint in reducedTrackpoints)
{
    Console.WriteLine($"Latitude: {trackpoint._latitude}, Longitude: {trackpoint._longitude}, Elevation: {trackpoint._elevation}");
}


var distTrackpoint = trackpoints
    .SelectMany((p1, i1) => trackpoints
    .Skip(i1 + 1)
    .Select(p2 => new
    {
        P1 = p1,
        P2 = p2,
        Dist = 
    }
    ).ToList();
Console.ReadLine();