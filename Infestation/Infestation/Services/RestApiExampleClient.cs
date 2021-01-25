﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Services
{
    public class RestApiExampleClient : IRestApiExampleClient
    {
        public byte[] GetFileBytes()
        {
            var client = new RestClient("http://localhost:56090");
            var request = new RestRequest("File", Method.GET);
            byte[] content = client.Execute(request).RawBytes;
            return content;
        }
    }
}
