﻿
using Azure;
using System.Text;
using System.Text.Json;

namespace Inicio.Client.Servicios
{
    public class HttpServicio : IHttpServicio
    {
        private readonly HttpClient http;

        public HttpServicio(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSereailzar<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, response);
            }
        }

        public async Task<HttpRespuesta<object>> Post<T>(string url, T entidad)
        {
            var enviarJson = JsonSerializer.Serialize(entidad);

            var enviarContent = new StringContent(enviarJson,
                Encoding.UTF8,
                "application/json");

            var response = await http.PostAsync(url, enviarContent);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSereailzar<object>(response);
                return new HttpRespuesta<object>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<object>(default, true, response);
            }

            
        }

        public async Task<HttpRespuesta<object>> Put<T>(string url, T entidad)
        {
            var enviarJson = JsonSerializer.Serialize(entidad);
            var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");

            var response = await http.PutAsync(url, enviarContent);

                if (response.IsSuccessStatusCode)
                {
                    //var respuesta = await DesSereailzar<object>(response);
                    return new HttpRespuesta<object>(null, false, response);
                }
                else
                {
                    return new HttpRespuesta<object>(default, true, response);
                }
        }

        public async Task<HttpRespuesta<object>> Delete<T>(string url, T entidad)
        {
            var respuesta = await http.DeleteAsync(url);

            return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);
        }


        private async Task<T> DesSereailzar<T>(HttpResponseMessage response)
        {
            var respuestaStr = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuestaStr,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
