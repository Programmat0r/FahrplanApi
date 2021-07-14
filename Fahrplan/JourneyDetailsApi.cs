﻿using Newtonsoft.Json;
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

        public TrainLocs[] Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Api.GetEndpoint(this.TestMode) + "journeyDetails/" + this.Id);

            request.PreAuthenticate = true;
            request.Accept = "application/json";
            request.Method = "GET";

            switch (this.ApiAuthentication.Type)
            {
                case Authentication.AuthenticationType.Bearer:

                    request.Headers.Add("Authorization", "Bearer " + this.ApiAuthentication.TokenBearer);
                    break;
                case Authentication.AuthenticationType.UsernamePassword:
                    NetworkCredential networkCredentials = new NetworkCredential(this.ApiAuthentication.Username, this.ApiAuthentication.Password);

                    CredentialCache credentialCache = new CredentialCache
                    {
                        { request.RequestUri, "Basic", networkCredentials }
                    };
                    break;
            }

            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
            String content = streamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<TrainLocs[]>(content);
        }
    }
}