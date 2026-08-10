using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace PublisherBooks;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Publisher, PublisherDto>()
            .ForMember(dto => dto.Location,
                options => options.MapFrom(publisher => publisher.City + ", " + publisher.Country));

        CreateMap<Book, BookDto>();

        CreateMap<PublisherForCreationDto, Publisher>();
    }
}
