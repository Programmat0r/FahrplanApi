namespace Fahrplan
{
    using System;
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
        public Location(String name)
        {
            if (name is null || name == "")
                throw new ArgumentNullException("Location name can't be empty");

            this.Name = name;
        }

        public void Get()
        {
            WebRequest request = WebRequest.Create("https://api.deutschebahn.com/freeplan/v1/location/" + this.Name);
          
            WebResponse response = request.GetResponse();
        }
    }
}
