using ApiCoreCrudPersonajesCMA.Models;
using ApiCoreCrudPersonajesCMA.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudPersonajesCMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonaje repo;

        public PersonajesController(RepositoryPersonaje repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> Get()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> InsertarPersonaje(Personaje per)
        {
            await this.repo.InsertarPersonajeAsync
                (per.Nombre, per.Imagen, per.IdSerie);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonaje(Personaje per)
        {
            await this.repo.UpdatePersonajeAsync
                (per.IdPersonaje, per.Nombre, per.Imagen, per.IdSerie);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonajeAsync(id);
            return Ok();
        }
    }
}
