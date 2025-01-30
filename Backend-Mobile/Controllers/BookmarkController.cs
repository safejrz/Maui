using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetKubernetes.Data.Bookmarks;
using NetKubernetes.Dtos.BookmarkDtos;
using NetKubernetes.Middleware;
using NetKubernetes.Models;

namespace NetKubernetes.Controllers;
 
[Route("api/[controller]")]
[ApiController]
public class BookmarkController : ControllerBase
{
    private readonly IBookmarkRepository _repository;
    private IMapper _mapper;

    public BookmarkController(
        IBookmarkRepository repository,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _repository = repository;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookmarkResponseDto>>> Get()
    {
        var bookmarks = await _repository.GetByUsuarioId();
        return Ok(_mapper.Map<IEnumerable<BookmarkResponseDto>>(bookmarks));
    }


    [HttpPost]
    public async Task<ActionResult<BookmarkResponseDto>> Create( 
        [FromBody] BookmarkRequestDto request)
    {
        return  await _repository.Create(request);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.Delete(id);
        return Ok();
    }




    // [HttpGet("{id}", Name = "GetInmuebleById")]
    // public async Task<ActionResult<InmuebleResponseDto>> GetInmuebleById(int id)
    // {
    //     var inmueble = await  _repository.GetInmuebleById(id);

    //     if(inmueble is null)
    //     {
    //         throw new MiddlewareException(
    //             HttpStatusCode.NotFound,
    //             new {mensaje = $"No se encontro el inmueble por este id {id}"}
    //         );

    //     }


    //     return Ok(_mapper.Map<InmuebleResponseDto>(inmueble));

    // }





}