using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

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
  
  public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync(bool trackChanges)
  {
    var categorias = await _repository.Categoria.GetAllCategoriasAsync(trackChanges);
    return categorias;
  }
  
  public async Task<Categoria> GetCategoriaAsync(int id, bool trackChanges)
  {
    var categoria =  await _repository.Categoria.GetCategoriaAsync(id, trackChanges);
    return categoria;
  }
  
  public async Task<Categoria> CreateCategoriaAsync(Categoria categoria)
  {
    _repository.Categoria.CreateCategoria(categoria);
    await _repository.SaveAsync();
    return categoria;
  }
  
  public async Task UpdateCategoriaAsync(int id, Categoria categoria, bool trackChanges)
  {
    var categoriaDb = await _repository.Categoria.GetCategoriaAsync(id, trackChanges);
    if (categoriaDb is null) throw new CategoriaNotFoundException(id);
    categoriaDb.Codigo = categoria.Codigo;
    categoriaDb.Descripcion = categoria.Descripcion;
    categoriaDb.Activo = categoria.Activo;
    await _repository.SaveAsync();
  }
  
  public async Task DeleteCategoriaAsync(int id, bool trackChanges)
  {
    var categoria = await _repository.Categoria.GetCategoriaAsync(id, trackChanges);
    if (categoria is null) throw new CategoriaNotFoundException(id);
    _repository.Categoria.DeleteCategoria(categoria);
    await _repository.SaveAsync();
  }
}