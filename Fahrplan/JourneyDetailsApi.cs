using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fahrplan
{
    public class JourneyDetailsApi : IApiEndpoint<TrainLocs[]>
    {
        public JourneyDetailsApi(String id, Authentication apiAuthentication)
        {
         

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("message", nameof(id));
            }

            this.ApiAuthentication = apiAuthentication ?? throw new ArgumentNullException(nameof(apiAuthentication));
            this.Id = id;
        }

        public Authentication ApiAuthentication { get; private set; }

        public String Id { get; private set; }
        public bool TestMode { get; set; }
        public bool SecureConnection { get; set; }

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
