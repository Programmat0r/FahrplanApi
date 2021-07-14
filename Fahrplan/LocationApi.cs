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
   public class LocationApi : IApiEndpoint<Location[]>
    {
        public String Name { get; private set; }
        public Authentication ApiAuthentication { get; private set; }
        public bool TestMode { get; set; }
        public bool SecureConnection { get; set; }

        public LocationApi(String name, Authentication apiAuthentication)
        {
          
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            this.Name = name;
            this.ApiAuthentication = apiAuthentication ?? throw new ArgumentNullException(nameof(apiAuthentication));
        }

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

