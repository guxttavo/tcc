using Core.Interfaces.Repositories;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class DenunciaRepository : IDenunciaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DenunciaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Bairro>> BuscarBairros()
        {
            return _dbContext.Bairros
            .AsSingleQuery()
            .Select(x => new Bairro
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> BuscarCategorias()
        {   
            var categorias = await _dbContext.Categorias.ToListAsync();
            return categorias;
        }

        public async Task<IEnumerable<Categoria>> BuscarSubcategorias()
        {
            return await _dbContext.Categorias
                .Where(x => x.IdCategoriaPai != null && x.Id == x.IdCategoriaPai)
                .ToListAsync();
        }

        public async Task CadastrarDenuncia(Denuncia denuncia)
        {
            await _dbContext.AddAsync(denuncia);
            await _dbContext.SaveChangesAsync();
        }

        // public async Task<Denuncia> BuscarDadosGraficos()
        // {
        //     return await _dbContext.Denuncias
        //                            .Select(x => new Denuncia
        //                            {
        //                                Data = x.Data,
        //                                Bairro = new Bairro
        //                                {
        //                                    Nome = x.Bairro.Nome
        //                                },
        //                                Categoria = new Categoria
        //                                {
        //                                    Nome = x.Categoria.Nome
        //                                }
        //                            })
        //                            .FirstOrDefaultAsync();
        // }

        // public async Task<IEnumerable<Denuncia>> BuscarDenuncias()
        // {
        //     return await _dbContext.Denuncias
        //                            .Include(x => x.Bairro)
        //                            .Include(x => x.Categoria)
        //                            .ToListAsync();
        // }
    }
}