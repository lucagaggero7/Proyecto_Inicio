using Inicio.DB.Data;
using Inicio.DB.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inicio.Server.Repositorio
{
    public class TituloRepositorio : Repositorio<Titulo>, ITituloRepositorio
    {
        private readonly Context context;

        public TituloRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Titulo> SelectByCod(string cod)
        {
            Titulo? pepe = await context.Titulos
                             .FirstOrDefaultAsync(x => x.Codigo == cod);
            return pepe;
        }

    }
}
