using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
{
  public CategoriaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  { }
  
  public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync(bool trackChanges) =>
    await FindAll(trackChanges)
      .OrderBy(c => c.Descripcion)
      .ToListAsync();
  
  public async Task<Categoria> GetCategoriaAsync(int categoriaId, bool trackChanges) =>
    await FindByCondition(c => c.Id.Equals(categoriaId), trackChanges).SingleOrDefaultAsync();
  
  public void CreateCategoria(Categoria categoria) => Create(categoria);
  public void UpdateCategoria(Categoria categoria) => Update(categoria);
  public void DeleteCategoria(Categoria categoria) => Delete(categoria);
}