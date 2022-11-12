using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Presentation.Controllers;

[Route("api/categorias")]
[ApiController]
public class CategoriasController : ControllerBase
{
  private readonly IServiceManager _service;
  public CategoriasController(IServiceManager service) => _service = service;
  [HttpGet]
  public IActionResult GetCompanies()
  {
    var categorias = _service.CategoriaService.GetAllCategorias(trackChanges: false);
    return Ok(categorias);
  }
  
  [HttpGet("{id:int}", Name = "CategoriaById")]
  public IActionResult GetCompany(int id)
  {
    var categoria = _service.CategoriaService.GetCategoria(id, trackChanges: false);
    if (categoria is null)
      throw new CategoriaNotFoundException(id);
    return Ok(categoria);
  }
  
  [HttpPost]
  public IActionResult CreateCategoria([FromBody] Categoria categoria)
  {
    if (categoria is null)
      return BadRequest("Objeto nulo.");
    var createdCategoria = _service.CategoriaService.CreateCategoria(categoria);
    return CreatedAtRoute("CategoriaById", new { id = createdCategoria.Id },
      createdCategoria);
  }
}