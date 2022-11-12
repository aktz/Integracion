using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
  private readonly Lazy<ICategoriaService> _categoriaService;
  public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
  {
    _categoriaService = new Lazy<ICategoriaService>(() => new
      CategoriaService(repositoryManager, logger));
  }
  public ICategoriaService CategoriaService => _categoriaService.Value;
}