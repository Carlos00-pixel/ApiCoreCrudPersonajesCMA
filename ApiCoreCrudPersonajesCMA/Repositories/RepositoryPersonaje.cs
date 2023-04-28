using ApiCoreCrudPersonajesCMA.Data;
using ApiCoreCrudPersonajesCMA.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudPersonajesCMA.Repositories
{
    public class RepositoryPersonaje
    {
        private PersonajesContext context;

        public RepositoryPersonaje(PersonajesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await
                this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
            }
        }

        public async Task InsertarPersonajeAsync
            (string nombre, string imagen, int idSerie)
        {
            Personaje per = new Personaje();
            per.IdPersonaje = GetMaxIdPersonaje();
            per.Nombre = nombre;
            per.Imagen = imagen;
            per.IdSerie = idSerie;
            this.context.Personajes.Add(per);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdatePersonajeAsync
            (int idPersonaje, string nombre, string imagen, int idSerie)


        {
            Personaje per = await this.FindPersonajeAsync(idPersonaje);
            per.IdPersonaje = idPersonaje;
            per.Nombre = nombre;
            per.Imagen = imagen;
            per.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePersonajeAsync(int id)
        {
            Personaje per = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(per);
            await this.context.SaveChangesAsync();
        }
    }
}
