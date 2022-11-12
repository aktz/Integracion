using Contracts;
using Entities.Models;

namespace Repository;

public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
{
  public CategoriaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
  { }
  
  public IEnumerable<Categoria> GetAllCategorias(bool trackChanges) =>
    FindAll(trackChanges)
      .OrderBy(c => c.Descripcion)
      .ToList();
  
  public Categoria GetCategoria(int categoriaId, bool trackChanges) =>
    FindByCondition(c => c.Id.Equals(categoriaId), trackChanges).SingleOrDefault();
  
  public void CreateCategoria(Categoria categoria) => Create(categoria);
  public void DeleteCategoria(Categoria categoria) => Delete(categoria);
}