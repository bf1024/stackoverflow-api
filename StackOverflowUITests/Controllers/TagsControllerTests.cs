using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackOverflowUI.Controllers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using StackOverflowAPI.Dtos;

namespace StackOverflowUI.Controllers.Tests
{
    [TestClass()]
    public class TagsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public TagsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod()]
        public async Task GetTest()
        {
            var response = await _client.GetAsync("/api/tags");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            List<TagDTO> list = JsonConvert.DeserializeObject<List<TagDTO>>(responseString);
            Assert.AreEqual(1000, list.Count);
        }

        [TestMethod()]
        public async Task GetTest200()
        {
            var response = await _client.GetAsync("/api/tags");
            response.EnsureSuccessStatusCode();
        }
    }
}