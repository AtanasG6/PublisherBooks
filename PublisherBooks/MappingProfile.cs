using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace PublisherBooks;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Publisher, PublisherDto>()
            .ForCtorParam(nameof(PublisherDto.Location),
                options => options.MapFrom(publisher => publisher.City + ", " + publisher.Country));

        CreateMap<Book, BookDto>();
    }
}
