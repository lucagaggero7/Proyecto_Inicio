using Inicio.DB.Data.Entity;
using Inicio.DB.Data;
using Inicio.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inicio.Shared.DTO;
using AutoMapper;

namespace Inicio.Server.Controllers
{

    [ApiController]
    [Route("api/Titulos")]
    public class TitulosControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public TitulosControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Titulo>>> Get()
        {
            return await context.Titulos.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/Titulos/2
        public async Task<ActionResult<Titulo>> Get(int id)
        {
            Titulo? Verif = await context.Titulos.FirstOrDefaultAsync(x => x.Id == id);

            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Titulos.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpGet("GetByCod/{cod}")] //api/Titulos/DNI
        public async Task<ActionResult<Titulo>> GetByCod(string cod)
        {
            Titulo? Verif = await context.Titulos.FirstOrDefaultAsync(x => x.Codigo == cod);

            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTituloDTO entidadDTO)
        {
            try
            {
                //Titulo entidad = new Titulo();
                //entidad.Codigo = entidadDTO.Codigo;
                //entidad.Nombre = entidadDTO.Nombre;

                Titulo entidad = mapper.Map<Titulo>(entidadDTO);


                context.Titulos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
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
            var Verif = await context.Titulos.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el Tipo de Documento Buscado");
            }

            Verif.Codigo = entidad.Codigo;
            Verif.Nombre = entidad.Nombre;
            Verif.Activo = entidad.Activo;

            try
            {
                context.Titulos.Update(Verif);
                await context.SaveChangesAsync();
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
            var existe = await context.Titulos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El tipo de documento {id} no existe.");
            }
            Titulo EntidadABorrar = new Titulo();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    
    }
}
