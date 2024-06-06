using AutoMapper;
using Inicio.DB.Data.Entity;
using Inicio.Shared.DTO;

namespace Inicio.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearTituloDTO, Titulo>();
        }
    }
}
