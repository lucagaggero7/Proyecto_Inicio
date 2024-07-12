using Inicio.DB.Data.Entity;

namespace Inicio.Server.Repositorio
{
    public interface ITDocumentoRepositorio : IRepositorio<TDocumento>
    {
        Task<TDocumento> SelectByCod(string cod);
    }
}
