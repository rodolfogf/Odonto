using AutoMapper;
using Odonto.Data.Dtos;
using Odonto.Models;

namespace Odonto.Profiles
{
    public class TratamentoProfile : Profile
    {
        public TratamentoProfile()
        {
            CreateMap<CreateTratamentoDto, Tratamento>();
            CreateMap<UpdateTratamentoDto, Tratamento>();
            CreateMap<Tratamento, UpdateTratamentoDto>();
            CreateMap<Tratamento, ReadTratamentoDto>();
        }
    }
}
