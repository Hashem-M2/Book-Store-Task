using AutoMapper;
using BookStore.Application.DTOS;
using BookStore.Infrastructure;

namespace BookStore.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookWithAuthorDto,Book >()
                .ForMember(dest => dest.BookId, obj => obj.MapFrom(src => src.BookId))
                .ForMember(dest => dest.Title, obj => obj.MapFrom(src => src.Title))
                .ForMember(dest => dest.TypeBook, obj => obj.MapFrom(src => src.TypeBook))
                .ForMember(dest => dest.Price, obj => obj.MapFrom(src => src.Price))
                .ForMember(dest => dest.PublishedDate, obj => obj.MapFrom(src => src.PublishedDate))
                .ForMember(dest => dest.AuthorId, obj => obj.MapFrom(src => src.AuthorId)).ReverseMap();
        }
    }
}
