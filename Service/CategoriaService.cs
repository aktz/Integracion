using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service;

internal sealed class CategoriaService : ICategoriaService
{
  private readonly IRepositoryManager _repository;
  private readonly ILoggerManager _logger;
  public CategoriaService(IRepositoryManager repository, ILoggerManager logger)
  {
    _repository = repository;
    _logger = logger;
  }
  
  public IEnumerable<Categoria> GetAllCategorias(bool trackChanges)
  {
    var categorias = _repository.Categoria.GetAllCategorias(trackChanges);
    return categorias;
  }
  
  public Categoria GetCategoria(int id, bool trackChanges)
  {
    var categoria = _repository.Categoria.GetCategoria(id, trackChanges);
    return categoria;
  }
  
  public Categoria CreateCategoria(Categoria categoria)
  {
    _repository.Categoria.CreateCategoria(categoria);
    _repository.Save();
    return categoria;
  }
}