﻿
namespace Inicio.Client.Servicios
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<object>> Delete<T>(string url, T entidad);
        Task<HttpRespuesta<T>> Get<T>(string url);
        Task<HttpRespuesta<object>> Post<T>(string url, T entidad);
        Task<HttpRespuesta<object>> Put<T>(string url, T entidad);
    }
}