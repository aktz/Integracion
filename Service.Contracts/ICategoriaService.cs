using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICategoriaService
{
  Task<IEnumerable<Categoria>> GetAllCategoriasAsync(bool trackChanges);
  Task<Categoria> GetCategoriaAsync(int categoriaId, bool trackChanges);
  Task<Categoria> CreateCategoriaAsync(Categoria categoria);
  Task UpdateCategoriaAsync(int id, Categoria categoria, bool trackChanges);
  Task DeleteCategoriaAsync(int id, bool trackChanges);
}