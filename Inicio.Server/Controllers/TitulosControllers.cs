using Inicio.DB.Data.Entity;
using Inicio.DB.Data;
using Inicio.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inicio.Shared.DTO;
using AutoMapper;
using Inicio.Server.Repositorio;

namespace Inicio.Server.Controllers
{

    [ApiController]
    [Route("api/Titulos")]
    public class TitulosControllers : ControllerBase
    {
        private readonly ITituloRepositorio repositorio;
        private readonly IMapper mapper;

        public TitulosControllers(ITituloRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Titulo>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Titulos/2
        public async Task<ActionResult<Titulo>> Get(int id)
        {

            Titulo? Verif = await repositorio.SelectById(id);

            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }
        
        [HttpGet("GetByCod/{cod}")] //api/Titulos/GetByCod/DNI
        public async Task<ActionResult<Titulo>> GetByCod(string cod)
        {
            Titulo? pepe = await repositorio.SelectByCod(cod);
            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTituloDTO entidadDTO)
        {
            try
            {
                Titulo entidad = mapper.Map<Titulo>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {

                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Titulos/2
        public async Task<ActionResult> Put(int id, [FromBody] Titulo entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await repositorio.SelectById(id);

            if (Verif == null)
            {
                return NotFound("No existe el Tipo de Documento Buscado");
            }

            Verif.Codigo = entidad.Codigo;
            Verif.Nombre = entidad.Nombre;
            Verif.Activo = entidad.Activo;

            try
            {
                await repositorio.Update(id, Verif);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/Titulos/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }

            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

    
    }
}
