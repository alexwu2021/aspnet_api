//using AutoMapper;
//using Marvin.Cache.Headers;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetapp.Config;
using aspnetapp.DataAccessLayer.Repositories;
using aspnetapp.Models.Dto;
using AutoMapper;
using Marvin.Cache.Headers;


namespace aspnetapp.Controllers
{
    [ApiController]
    [Route("api/v1/patient/")]
    //[ResponseCache(CacheProfileName = "120sCacheProfile")]  //允许被缓存120秒（视频P46）

    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        //private readonly IMapper _mapper;
        private Mapper _mapper;
        
        public PatientsController(IPatientRepository patientRepository
            //, IMapper mapper
            )
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            var mapperConfig = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Patient, PatientDto>();});
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            //_mapper = MapperConfig.InitializePatientMapper();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDto>();
            });
            _mapper = new Mapper(config);
        }


        #region HttpGet

        [HttpGet("{patientId}", Name = nameof(GetPatientByPatientId))]
        
        //[ResponseCache(Duration = 60)]                                        
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 1800)] 
        //[HttpCacheValidation(MustRevalidate = false)]                              
        public ActionResult GetPatientByPatientId(int patientId
            //,
              //                                                  [FromQuery]PatientDtoParameters parameters
            )
        {
           
            
            // use await should
            if (_patientRepository.IsPatientRegistered(patientId))
            {
                var patient = //await 
                    _patientRepository.GetPatient(patientId);
                    //GetPatientsAsync(patientId, parameters);

                    
                var patientDto = _mapper.Map<PatientDto>(patient);
                return Ok(patientDto);
            }
            else
            {
                return NotFound();
            }
        }

        
        [HttpGet(Name = nameof(GetAllPatients))]
        public ActionResult GetAllPatients()
        {
            
            var patients = _patientRepository.GetPatients();
            if (patients == null)
            {
                return NotFound();
            }
            var patientDtos = _mapper.Map<IEnumerable<PatientDto>>(patients);
            if(patientDtos != null && patientDtos.Any())
            {
                return Ok(patientDtos);
            }

            return NotFound();
            
        }


        #endregion HttpGet
        
    }
}