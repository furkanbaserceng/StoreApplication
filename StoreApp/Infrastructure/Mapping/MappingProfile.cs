using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapping
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>().ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
        }



    }
}
