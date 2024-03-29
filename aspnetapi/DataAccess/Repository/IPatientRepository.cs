﻿using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetapp.Model;
using aspnetapp.Model.Dto;


namespace aspnetapp.DataAccessLayer.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int patientId);
        void AddPatient(Patient patient);
        
        
        
        
        Task<Patient> GetPatientAsync(int patientId);
        
        Task<bool> IsPatientExistingAsync(int patientId);
        
        Task<bool> SaveAsync();
        
        bool Save();
    }
}
