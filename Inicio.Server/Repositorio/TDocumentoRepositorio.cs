using Inicio.DB.Data;
using Inicio.DB.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inicio.Server.Repositorio
{
    public class TDocumentoRepositorio : Repositorio<TDocumento>, ITDocumentoRepositorio
    {
        private readonly Context context;

        public TDocumentoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<TDocumento> SelectByCod(string cod)
        {
            TDocumento? Verif = await context.TDocumentos
                             .FirstOrDefaultAsync(x => x.Codigo == cod);
            return Verif;
        }
    }
}
