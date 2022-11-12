using Entities.Models;

namespace Service.Contracts;

public interface ICategoriaService
{
  IEnumerable<Categoria> GetAllCategorias(bool trackChanges);
  Categoria GetCategoria(int categoriaId, bool trackChanges);
  Categoria CreateCategoria(Categoria categoria);
}