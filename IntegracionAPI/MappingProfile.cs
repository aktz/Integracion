using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace IntegracionAPI;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Categoria, CategoriaDto>();
    CreateMap<CategoriaDto, Categoria>();
  }
}