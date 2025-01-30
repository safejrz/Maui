using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetKubernetes.Data.Categories;
using NetKubernetes.Dtos.CategoryDtos;

namespace NetKubernetes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase{

    private readonly ICategoryRepository _repository;
    private IMapper _mapper;
    
    public CategoryController(
        ICategoryRepository repository,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryResponseDto>>> GetCategories()
    {
        var categories = await _repository.GetAllCategories();
        return Ok(_mapper.Map<IEnumerable<CategoryResponseDto>>(categories));
    }




}