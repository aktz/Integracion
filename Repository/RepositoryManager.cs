using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
  private readonly RepositoryContext _repositoryContext;
  private readonly Lazy<ICategoriaRepository> _companyRepository;
  public RepositoryManager(RepositoryContext repositoryContext)
  {
    _repositoryContext = repositoryContext;
    _companyRepository = new Lazy<ICategoriaRepository>(() => new
      CategoriaRepository(repositoryContext));
  }
  public ICategoriaRepository Categoria => _companyRepository.Value;
  public void Save() => _repositoryContext.SaveChanges();
}