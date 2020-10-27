using MicroRabbit.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public  async Task Transfer(TransferDTO transferDTO)
        {
            var uri = "http://localhost:5000/api/banking";

            var tranferContent = new StringContent(JsonConvert.SerializeObject(transferDTO),
                                                    System.Text.Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, tranferContent);

            response.EnsureSuccessStatusCode();

        }
    }
}
