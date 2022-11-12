namespace Contracts;

public interface IRepositoryManager
{
  ICategoriaRepository Categoria { get; }
  Task SaveAsync();
}