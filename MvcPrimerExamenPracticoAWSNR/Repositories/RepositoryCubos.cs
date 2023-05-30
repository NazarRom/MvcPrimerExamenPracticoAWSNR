using Microsoft.EntityFrameworkCore;
using MvcPrimerExamenPracticoAWSNR.Data;
using MvcPrimerExamenPracticoAWSNR.Models;

namespace MvcPrimerExamenPracticoAWSNR.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        //get
        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        //details

        public async Task<Cubo> FindCuboAsync(int id)
        {
            return await this.context.Cubos.FirstOrDefaultAsync(x => x.IdCubo == id);
        }

        //max id
        private int MaxIdCubo()
        {
            return this.context.Cubos.Max(x => x.IdCubo) + 1;
        }

        //insert
        public async Task InsertCuboAsync(string nombre, string marca, string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            cubo.IdCubo = this.MaxIdCubo();
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            await this.context.Cubos.AddAsync(cubo);
            await this.context.SaveChangesAsync();
        }

        //update
        public async Task UpdateCuboAsync(int id, string nombre, string marca, string imagen, int precio)
        {
            Cubo cubo = await this.FindCuboAsync(id);
            cubo.Nombre = nombre;
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            await this.context.SaveChangesAsync();
        }

        //delete

        public async Task DeleteCuboAsync(int id)
        {
            Cubo cubo = await this.FindCuboAsync(id);
            this.context.Cubos.Remove(cubo);
            await this.context.SaveChangesAsync();

        }
    }
}
