namespace Fahrplan
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="ArrivalBoardApi" />.
    /// </summary>
    public class ArrivalBoardApi : IApiEndpoint<Board[]>
    {
        /// <summary>
        /// Gets the ApiAuthentication.
        /// </summary>
        public Authentication ApiAuthentication { get; private set; }

        /// <summary>
        /// Gets the Id.
        /// </summary>
        public String Id { get; private set; }

        /// <summary>
        /// Gets the Date.
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether TestMode.
        /// </summary>
        public bool TestMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether SecureConnection.
        /// </summary>
        public bool SecureConnection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrivalBoardApi"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="String"/>.</param>
        /// <param name="apiAuthentication">The apiAuthentication<see cref="Authentication"/>.</param>
        /// <param name="date">The date<see cref="DateTime"/>.</param>
        public ArrivalBoardApi(String id, Authentication apiAuthentication, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("message", nameof(id));
            }

            if (apiAuthentication is null)
            {
                throw new ArgumentNullException(nameof(apiAuthentication));
            }


            this.Id = id;
            this.ApiAuthentication = apiAuthentication;
            this.Date = date;
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <returns>The <see cref="Board[]"/>.</returns>
        public Board[] Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Api.GetEndpoint(this.TestMode, this.SecureConnection) + "arrivalBoard/" + this.Id + "?date=" + this.Date.ToString("yyyy-MM-ddThh:mm:ss"));

            request.PreAuthenticate = true;
            request.Accept = "application/json";
            request.Method = "GET";


            request.Headers.Add("Authorization", "Bearer " + this.ApiAuthentication.TokenBearer);


            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            String content = streamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<Board[]>(content);
        }
    }
}
