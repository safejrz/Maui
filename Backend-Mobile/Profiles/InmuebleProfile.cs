using AutoMapper;
using NetKubernetes.Dtos.InmuebleDtos;
using NetKubernetes.Dtos.CategoryDtos;
using NetKubernetes.Models;
using NetKubernetes.Dtos.BookmarkDtos;
using NetKubernetes.Dtos.CompraDtos;

namespace NetKubernetes.Profiles;

public class InmuebleProfile : Profile {

    public InmuebleProfile()
    {
        CreateMap<Inmueble, InmuebleResponseDto>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<InmuebleRequestDto, Inmueble>();
        CreateMap<CompraItemRequestDto, Compra>();
        CreateMap<Bookmark, BookmarkResponseDto>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Inmueble!.Nombre))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Inmueble!.Precio))
                .ForMember(dest => dest.imagenUrl, opt => opt.MapFrom(src => src.Inmueble!.ImagenUrl))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Inmueble!.Direccion))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Inmueble!.IsTrending));

    }
    
}