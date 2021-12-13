using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication.Test
{
    public class TestClientProvider
    {
        public HttpClient clientMainAPI { get; set; }
        public HttpClient clientAPI1 { get; set; }
        public HttpClient clientAPI2 { get; set; }
        public HttpClient clientAPI3 { get; set; }
        public TestClientProvider()
        {
            var serverAPI1 = new TestServer(new WebHostBuilder().UseStartup<WebApplication.API1.Startup>());
            clientAPI1 = serverAPI1.CreateClient();

            var serverManiAPI = new TestServer(new WebHostBuilder().UseStartup<WebApplication.MainAPI.Startup>());
            clientMainAPI = serverManiAPI.CreateClient();

            var serverAPI2 = new TestServer(new WebHostBuilder().UseStartup<WebApplication.API2.Startup>());
            clientAPI2 = serverAPI2.CreateClient();

            var serverAPI3 = new TestServer(new WebHostBuilder().UseStartup<WebApplication.API3.Startup>());
            clientAPI3 = serverAPI3.CreateClient();
        }
    }
}
