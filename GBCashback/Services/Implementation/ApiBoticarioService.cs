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
        public AcumuladoDTO Acumulado(string cpf)
        {
            var acumulado = new AcumuladoDTO()
            {
                CPF = cpf,
                Credit = 0
            };

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Token", "ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm");

                client.BaseAddress = new Uri("https://mdaqk8ek5j.execute-api.us-east-1.amazonaws.com/v1/");

                HttpResponseMessage response = client.GetAsync("cashback?cpf=" + Geral.ApenasNumeros(cpf)).Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var content = JsonSerializer.Deserialize<AcumuladoResponse>(json);

                    acumulado.Credit = content.body.credit;                    
                }
            }

            return acumulado;
        }
    }
}