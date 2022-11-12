using Entities.Models;

namespace Contracts;

public interface ICategoriaRepository
{
  IEnumerable<Categoria> GetAllCategorias(bool trackChanges);
  Categoria GetCategoria(int categoriaId, bool trackChanges);
  void CreateCategoria(Categoria categoria);
  void DeleteCategoria(Categoria categoria);
}