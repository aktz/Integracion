namespace Entities.Exceptions;

public sealed class CategoriaNotFoundException : NotFoundException
{
  public CategoriaNotFoundException(int categoriaId)
    :base ($"La categoría con id {categoriaId} no se encuentra la base de datos.")
  { }
}