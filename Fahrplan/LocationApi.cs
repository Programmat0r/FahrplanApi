namespace Fahrplan
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="LocationApi" />.
    /// </summary>
    public class LocationApi : IApiEndpoint<Location[]>
    {
        /// <summary>
        /// Gets the Name.
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets the ApiAuthentication.
        /// </summary>
        public Authentication ApiAuthentication { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether TestMode.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SecureConnection.
        /// </summary>
        public bool SecureConnection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationApi"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="String"/>.</param>
        /// <param name="apiAuthentication">The apiAuthentication<see cref="Authentication"/>.</param>
        public LocationApi(String name, Authentication apiAuthentication)
        {

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            this.Name = name;
            this.ApiAuthentication = apiAuthentication ?? throw new ArgumentNullException(nameof(apiAuthentication));
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <returns>The <see cref="Location[]"/>.</returns>
        public Location[] Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Api.GetEndpoint(this.TestMode, this.SecureConnection) + "location/" + this.Name);

            request.PreAuthenticate = true;
            request.Accept = "application/json";
            request.Method = "GET";

            request.Headers.Add("Authorization", "Bearer " + this.ApiAuthentication.TokenBearer);

            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            String content = streamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<Location[]>(content);
        }
    }
}
