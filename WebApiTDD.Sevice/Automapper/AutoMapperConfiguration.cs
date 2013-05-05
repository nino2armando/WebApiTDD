using AutoMapper;
using WebApiTDD.DataContract;
using WebApiTDD.Domain.Models;

namespace WebApiTDD.Sevice.Automapper
{
    public static class AutoMapperConfiguration 
    {
        public static void LoadConfiguration()
        {
            ConfigureDataContract();
        }

        public static void ConfigureDataContract()
        {
            Mapper.CreateMap<Manager,Employee>()
                .ForMember(src => src.Id , trg => trg.MapFrom(a => a.Id))
                .ForMember(src => src.Name, trg => trg.MapFrom(a => a.Name));
        }

    }
}