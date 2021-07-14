namespace Fahrplan
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="JourneyDetailsApi" />.
    /// </summary>
    public class JourneyDetailsApi : IApiEndpoint<TrainLocs[]>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JourneyDetailsApi"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="String"/>.</param>
        /// <param name="apiAuthentication">The apiAuthentication<see cref="Authentication"/>.</param>
        public JourneyDetailsApi(String id, Authentication apiAuthentication)
        {


            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("message", nameof(id));
            }

            this.ApiAuthentication = apiAuthentication ?? throw new ArgumentNullException(nameof(apiAuthentication));
            this.Id = id;
        }

        /// <summary>
        /// Gets the ApiAuthentication.
        /// </summary>
        public Authentication ApiAuthentication { get; private set; }

        /// <summary>
        /// Gets the Id.
        /// </summary>
        public String Id { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether TestMode.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SecureConnection.
        /// </summary>
        public bool SecureConnection { get; set; }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <returns>The <see cref="TrainLocs[]"/>.</returns>
        public TrainLocs[] Get()
        {
            var urlEncodedId = WebUtility.UrlEncode(this.Id);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Api.GetEndpoint(this.TestMode, this.SecureConnection) + "journeyDetails/" + urlEncodedId);

            request.PreAuthenticate = true;
            request.Accept = "application/json";
            request.Method = "GET";

            request.Headers.Add("Authorization", "Bearer " + this.ApiAuthentication.TokenBearer);

            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            String content = streamReader.ReadToEnd();



            return JsonConvert.DeserializeObject<TrainLocs[]>(content);
        }
    }
}
