namespace Contracts;

public interface IRepositoryManager
{
  ICategoriaRepository Categoria { get; }
  void Save();
}