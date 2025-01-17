﻿using AutoMapper;
using Odonto.Data.Dtos;
using Odonto.Models;

namespace Odonto.Profiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile() 
        {
            CreateMap<CreatePacienteDto, Paciente>();
            CreateMap<UpdatePacienteDto, Paciente>();
            CreateMap<Paciente, UpdatePacienteDto>();
            CreateMap<Paciente, ReadPacienteDto>();
        }
    }
}
