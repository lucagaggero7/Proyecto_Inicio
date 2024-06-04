using Inicio.DB.Data;
using Inicio.DB.Data.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inicio.Server.Controllers
{
    [ApiController]
    [Route("api/TDocumentos")]

    public class TDocumentosControllers : ControllerBase
    {

        private readonly Context context;
        public TDocumentosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDocumento>>> Get()
        {
            return await context.TDocumentos.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult<TDocumento>> Get(int id)
        {
            TDocumento? Verif = await context.TDocumentos.FirstOrDefaultAsync(x=> x.Id == id);

            if(Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.TDocumentos.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpGet("GetByCod/{cod}")] //api/TDocumentos/DNI
        public async Task<ActionResult<TDocumento>> GetByCod(string cod)
        {
            TDocumento? Verif = await context.TDocumentos.FirstOrDefaultAsync(x => x.Codigo == cod);

            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad) 
        {
            try
            {
                context.TDocumentos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Put(int id, [FromBody]TDocumento entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.TDocumentos.Where(e=> e.Id == id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el Tipo de Documento Buscado");
            }

            Verif.Codigo = entidad.Codigo;
            Verif.Nombre = entidad.Nombre;
            Verif.Activo = entidad.Activo;

            try
            {
                context.TDocumentos.Update(Verif);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.TDocumentos.AnyAsync(x => x.Id == id);

            if(!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }
            TDocumento EntidadABorrar = new TDocumento();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}
