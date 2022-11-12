using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers;

[Route("api/categorias")]
[ApiController]
public class CategoriasController : ControllerBase
{
  private readonly IServiceManager _service;
  public CategoriasController(IServiceManager service) => _service = service;
  [HttpGet]
  public async Task<IActionResult> GetCompanies()
  {
    var categorias = await _service.CategoriaService.GetAllCategoriasAsync(trackChanges: false);
    return Ok(categorias);
  }
  
  [HttpGet("{id:int}", Name = "CategoriaById")]
  public async Task<IActionResult> GetCompany(int id)
  {
    var categoria = await _service.CategoriaService.GetCategoriaAsync(id, trackChanges: false);
    if (categoria is null)
      throw new CategoriaNotFoundException(id);
    return Ok(categoria);
  }
  
  [HttpPost]
  public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
  {
    if (categoria is null) return BadRequest("Objeto nulo.");
    var createdCategoria = await _service.CategoriaService.CreateCategoriaAsync(categoria);
    return CreatedAtRoute("CategoriaById", new { id = createdCategoria.Id },
      createdCategoria);
  }
  
  [HttpPut("{id:int}")]
  public async Task<ActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
  {
    if (categoria is null) return BadRequest("Objeto nulo.");
    await _service.CategoriaService.UpdateCategoriaAsync(id, categoria, trackChanges: true);
    var categoriaUpdated = await _service.CategoriaService.GetCategoriaAsync(id, trackChanges: false);
    return Ok(categoriaUpdated);
  }
  
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteCategoria(int id)
  {
    await _service.CategoriaService.DeleteCategoriaAsync(id, trackChanges: false);
    return NoContent();
  }
}