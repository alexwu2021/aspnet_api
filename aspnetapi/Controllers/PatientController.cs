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
    //[ResponseCache(CacheProfileName = "120sCacheProfile")]  // TODO: WILL CREATE 
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        //private readonly IMapper _mapper; // TODO: WILL USE ASSEMBLY WIDE DI
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
            
            GetAuthorToken();
            
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
                //var tokenHandler = new TokenReader();// sa[1], validationParameters);
                tokenRetrieved = sa[1];
                Console.Write("token retrieved: " + tokenRetrieved);

            } catch (Exception ex) {
                // Log the reason why the token is not valid
               Console.Write(ex);
            }
            
        }
        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            /*if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }*/
        }

        /*
        static HttpClient client = new HttpClient();
        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }
        */

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