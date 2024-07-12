using Inicio.DB.Data;
using Inicio.DB.Data.Entity;
using Inicio.Server.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Identity.Client;

namespace Inicio.Server.Controllers
{
    [ApiController]
    [Route("api/TDocumentos")]

    public class TDocumentosControllers : ControllerBase
    {
        private readonly ITDocumentoRepositorio repositorio;

        public TDocumentosControllers(ITDocumentoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDocumento>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult<TDocumento>> Get(int id)
        {
            TDocumento? Verif = await repositorio.SelectById(id);

            if(Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        
        [HttpGet("GetByCod/{cod}")] //api/TDocumentos/DNI
        public async Task<ActionResult<TDocumento>> GetByCod(string cod)
        {
            TDocumento? Verif = await repositorio.SelectByCod(cod);

            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
           return await repositorio.Existe(id);
           
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(TDocumento entidad) 
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/TDocumentos/2
        public async Task<ActionResult> Put(int id, [FromBody]TDocumento entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var Verif = await repositorio.Update(id, entidad);

                if (!Verif)
                {
                    return BadRequest("No se pudo actualizar el tipo de documento");
                }
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
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El tipo de documento no se pudo borrar");
            }
            return Ok();
        }

    }

}
