using aspnetapp.Models.Dto;
using AutoMapper;

namespace aspnetapp.Config;

public class MapperConfig
{
    
        public static Mapper InitializePatientMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDto>();
            });
            return new Mapper(config);
        }
    
}