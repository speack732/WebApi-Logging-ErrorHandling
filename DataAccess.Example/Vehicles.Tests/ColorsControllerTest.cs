using DataAccess.Example.Core;
using DataAccess.Example.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace Vehicles.Tests
{
    [TestFixture]
    public class ColorsControllerTest
    {

        private WebFactory _factory;
        private HttpClient _client;
        private string colorCode;
        private int colorId;


        [OneTimeSetUp]
        public void Setup()
        {
            _factory = new WebFactory();
            _client = _factory.CreateClient();

            colorCode = (new System.Random().Next(1, 9999)).ToString().PadLeft(5,'0');

        }

        [Order(0)]
        [Test]
        public async Task Insert_Test()
        {
            Color newColor = new Color
            {
                Code = colorCode,
                Name = "Rosa Mexicano"
            };

            string json = JsonConvert.SerializeObject(newColor);

            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PostAsync("/api/colors", byteContent);
            string resultContent = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }



        [Order(1)]
        [Test]
        public async Task GetAll_Test()
        {
            var colors = await _client.GetFromJsonAsync<List<Color>>("/api/colors");

            var colorAdded = colors.FirstOrDefault(x => x.Code == colorCode);
            
            Assert.IsNotNull(colorAdded);

            colorId = colorAdded.Id;

            Assert.IsNotNull(colors);
            Assert.IsTrue(colors.Count > 0);
            
        }


        [Order(2)]
        [Test]
        public async Task Get_Test()
        {
            var color = await _client.GetFromJsonAsync<Color>("/api/colors/" + colorId);
            Assert.IsNotNull(color);
        }


        [Order(3)]
        [Test]
        public async Task Update_Test()
        {
            Color newColor = new Color
            {
                Code = "UPDT",
                Name = "Purple"
            };

            string json = JsonConvert.SerializeObject(newColor);

            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _client.PutAsync("/api/colors/" + colorId, byteContent);
            string resultContent = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Order(4)]
        [Test]
        public async Task Delete_Test()
        {
            var response = await _client.DeleteAsync("/api/colors/" + colorId);
            string resultContent = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }



        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}