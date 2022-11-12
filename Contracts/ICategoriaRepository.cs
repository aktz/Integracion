using Entities.Models;

namespace Contracts;

public interface ICategoriaRepository
{
  Task<IEnumerable<Categoria>> GetAllCategoriasAsync(bool trackChanges);
  Task<Categoria> GetCategoriaAsync(int categoriaId, bool trackChanges);
  void CreateCategoria(Categoria categoria);
  void DeleteCategoria(Categoria categoria);
}