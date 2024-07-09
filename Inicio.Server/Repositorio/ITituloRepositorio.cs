using Inicio.DB.Data.Entity;

namespace Inicio.Server.Repositorio
{
    public interface ITituloRepositorio : IRepositorio<Titulo>
    {
        Task<Titulo> SelectByCod(string cod);
    }
}
