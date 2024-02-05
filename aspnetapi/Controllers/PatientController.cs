//using AutoMapper;
//using Marvin.Cache.Headers;
//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Resources;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using aspnetapp.Config;
using aspnetapp.Constants;
using aspnetapp.DataAccessLayer.Repositories;
using aspnetapp.Model;
using aspnetapp.Model.Dto;
using AutoMapper;
using IdentityModel;
using IdentityModel.Client;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authentication;

using Newtonsoft.Json.Linq;


namespace aspnetapp.Controllers
{
    [ApiController]
    [Route("api/v1/patient/")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private Mapper _mapper;
        
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            var mapperConfig = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Patient, PatientDto>();});
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDto>();
                cfg.CreateMap<PatientAddDto, Patient>();
                cfg.CreateMap<PatientUpdateDto, Patient>();
            });
            _mapper = new Mapper(config);
        }


        #region HttpGet

        [HttpGet("{patientId}", Name = nameof(GetPatientByPatientId))]
        public async Task<IActionResult> GetPatientByPatientId(int patientId) {
            if (await _patientRepository.IsPatientExistingAsync(patientId))
            {
                var pa = await _patientRepository.GetPatientAsync(patientId);
                var patientDto = _mapper.Map<PatientDto>(pa);
                return Ok(patientDto);
            }
            return NotFound();
        }
            
        

        private async  void GetAuthorToken()
        {
            string url = Constants.ProjectConstants.RemoteServiceAuthEndPoint;
            string body = ProjectConstants.RemoteServiceAuthCredential;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            request.Content = new StringContent(body,Encoding.UTF8, "application/json");
            string tokenRetrieved = string.Empty;
            HttpResponseMessage response =  await client.PostAsync(url, request.Content);
            try
            {
                var sa = response.Content.ReadAsStringAsync().Result.Split(" ,:".ToCharArray());
                tokenRetrieved = sa[1];
                Console.Write("token retrieved: " + tokenRetrieved);
            } catch (Exception ex) {
               Console.Write(ex);
            }
        }
     
        
        [HttpGet(Name = nameof(GetAllPatients))]
        public  ActionResult GetAllPatients()
        {
            var patients = _patientRepository.GetPatients();
            if (patients.Any())
            {
                var patientDtos = new List<PatientDto>();
                foreach (var patient in patients)
                {
                    patientDtos.Add(_mapper.Map<PatientDto>(patient));
                }
                return Ok(patientDtos);
            }
            return NotFound();
            
        }
        #endregion HttpGet
        
        
        #region HttpPost
        
        
        [HttpPost()]
        public async Task<IActionResult> CreatePatient([FromBody]PatientAddDto patientAddDto)
        {
            var patientToAddEntity = _mapper.Map<Patient>(patientAddDto);
            _patientRepository.AddPatient(patientToAddEntity);
            await _patientRepository.SaveAsync();
            var returnDto = _mapper.Map<PatientDto>(patientToAddEntity);
            return CreatedAtAction(nameof(GetPatientByPatientId),
                new { patientId = returnDto.Id},
                returnDto);
            
        }
        #endregion
    }
}