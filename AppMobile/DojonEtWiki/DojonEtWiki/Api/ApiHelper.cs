﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DojonEtWiki.Api
{
    public class ApiHelper
    {
        public static HttpClient apiClient { get; set; }

        public static void InitializeClient()
        {
            apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            apiClient.BaseAddress = new Uri("https://c0fnrbvj-7296.use.devtunnels.ms/");
        }
    }
}
