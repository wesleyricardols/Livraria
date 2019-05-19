using Livraria.Web.Models.Base;
using Livraria.Web.Models.Livros.Requests;
using Livraria.Web.Models.Livros.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Livraria.Web.Controllers
{
    public class LivroController : Controller
    {
        private HttpClient _client;
        private IConfiguration _configuration;

        public LivroController(IConfiguration configuration)
        {
            _client = new HttpClient();
            _configuration = configuration;
        }

        #region View

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        [HttpGet]
        public List<LivroResponse> GetBooks()
        {
            List<LivroResponse> livroResponses = null;
            string url = string.Concat(_configuration["ApiBase:Base"], "api/Livro");
            _client.BaseAddress = new Uri(url);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                livroResponses = JsonConvert.DeserializeObject<List<LivroResponse>>(json);
            }

            return livroResponses;
        }

        [HttpPost]
        public LivroResponse PostBook(LivroRequest request)
        {
            LivroResponse livroResponse = null;

            if (FieldsAreNotValid(request))
                return new LivroResponse(false, "Informações incorretas. Verifique os campos e tente novamente");

            string url = string.Concat(_configuration["ApiBase:Base"], "api/Livro");
            _client.BaseAddress = new Uri(url);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = _client.PostAsJsonAsync(_client.BaseAddress, request).Result;

            string json = response.Content.ReadAsStringAsync().Result;
            livroResponse = JsonConvert.DeserializeObject<LivroResponse>(json);

            return livroResponse;
        }

        [HttpDelete]
        public BaseResponse DeleteBook(LivroRequest request)
        {
            BaseResponse baseResponse = null;

            string url = string.Format(string.Concat(_configuration["ApiBase:Base"], "api/Livro/{0}"), request.Id);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = _client.SendAsync(httpRequest).Result;

            string json = response.Content.ReadAsStringAsync().Result;
            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(json);

            return baseResponse;
        }

        [HttpPut]
        public LivroResponse PutBook(LivroRequest request)
        {
            LivroResponse livroResponse = null;

            if (FieldsAreNotValid(request))
                return new LivroResponse(false, "Informações incorretas. Verifique os campos e tente novamente");

            string url = string.Format(string.Concat(_configuration["ApiBase:Base"], "api/Livro/{0}"), request.Id);

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
            };

            HttpResponseMessage response = _client.SendAsync(httpRequest).Result;

            string json = response.Content.ReadAsStringAsync().Result;
            livroResponse = JsonConvert.DeserializeObject<LivroResponse>(json);

            return livroResponse;
        }

        private bool FieldsAreNotValid(LivroRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Editora) || request.AnoPublicacao <= 0 || string.IsNullOrWhiteSpace(request.Autor) || request.QtdeExemplares <= 0)
                return true;

            return false;
        }
    }
}