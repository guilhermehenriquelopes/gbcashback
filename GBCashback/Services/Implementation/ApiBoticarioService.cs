using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using GBCashback.DTO;
using GBCashback.Services.Interface;
using GBCashback.Util;

namespace GBCashback.Services.Implementation
{
    public class ApiBoticarioService : IApiBoticarioService
    {
        private readonly HttpClient _httpClient;

        public ApiBoticarioService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<AcumuladoDTO> Acumulado(string cpf)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Token", "ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm");

            _httpClient.BaseAddress = new Uri("https://mdaqk8ek5j.execute-api.us-east-1.amazonaws.com/v1/");

            var streamTask = _httpClient.GetStreamAsync("cashback?cpf=" + Geral.ApenasNumeros(cpf));
            var response = await JsonSerializer.DeserializeAsync<AcumuladoResponse>(await streamTask);

            return new AcumuladoDTO(){
                CPF = cpf,
                Credit = response.body.credit
            };
        }
    }
}