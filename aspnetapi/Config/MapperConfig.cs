using aspnetapp.Model.Dto;
using aspnetapp.Model;

using AutoMapper;

namespace aspnetapp.Config;

public class MapperConfig
{
    
        public static Mapper InitializePatientMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDto>();
                cfg.CreateMap<PatientLabResult, PatientLabResultDto>();
                cfg.CreateMap<PatientLabVisit, PatientLabVisitDto>();
                cfg.CreateMap<PatientMedication, PatientMedicationDto>();
                cfg.CreateMap<PatientVaccinationData, PatientVaccinationDataDto>();
                cfg.CreateMap<PatientVisitHistory, PatientVisitHistoryDto>();
            });
            return new Mapper(config);
        }
    
}