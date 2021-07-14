namespace Fahrplan
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="Location" />.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets the name of the location.
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets the Longitude of the location.
        /// </summary>
        public long Lon { get; private set; }

        /// <summary>
        /// Gets the Latitude of the location.
        /// </summary>
        public long Lat { get; private set; }

        /// <summary>
        /// Gets the Id of the location.
        /// </summary>
        public String Id { get; private set; }
      



        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="String"/>.</param>
       
        [JsonConstructor]
        public Location(string name, long lon, long lat, string id)
        {
            Lon = lon;
            Lat = lat;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

    }
}
