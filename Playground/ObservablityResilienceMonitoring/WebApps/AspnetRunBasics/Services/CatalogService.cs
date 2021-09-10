using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AspnetRunBasics.Useful;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        private readonly ILogger<CatalogService> _logger;

        public CatalogService(HttpClient client, ILogger<CatalogService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            _logger.LogInformation($"Getting catalog products from url: {_client.BaseAddress}");
            var response = await _client.GetAsync("/Catalog");

            return await ResponseWithLogging.Generate<List<CatalogModel>>(response, _logger, $"Response catalog products from url: {_client.BaseAddress}");
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            _logger.LogInformation($"Getting product by Id from url: {_client.BaseAddress}/Catalog/{id}");
            var response = await _client.GetAsync($"/Catalog/{id}");
            return await response.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            _logger.LogInformation($"Getting product by category from url: {_client.BaseAddress}/Catalog/GetProductByCategory/{category}");
            var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAs<List<CatalogModel>>();
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            var response = await _client.PostAsJson($"/Catalog", model);
            if (response.IsSuccessStatusCode)
                return await ResponseWithLogging.Generate<CatalogModel>(response, _logger, "CreateCatalog");
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
