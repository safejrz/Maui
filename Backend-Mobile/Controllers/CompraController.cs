using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetKubernetes.Data.Compras;
using NetKubernetes.Dtos.CompraDtos;
using NetKubernetes.Models;

namespace NetKubernetes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompraController : ControllerBase
{
    private readonly ICompraRepository _repository;
    private IMapper _mapper;

    public CompraController(
        ICompraRepository repository,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _repository = repository;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CompraRequestDto request)
    {
        var compraDtos = request.Data;
        var compras = _mapper.Map<IEnumerable<Compra>>(compraDtos);
        await _repository.SaveCompras(compras);
        
        return  Ok();
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Compra>>> Get()
    {
        
        var compras = await _repository.GetAll();
        return Ok(compras);
    }


}