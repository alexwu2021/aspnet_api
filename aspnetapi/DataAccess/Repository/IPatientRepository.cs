﻿using System.Collections.Generic;
using aspnetapp.Model;
using aspnetapp.Model.Dto;


namespace aspnetapp.DataAccessLayer.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int patientId);
        void AddPatient(Patient patient);
        //bool Save();
        
        bool IsPatientRegistered(long patientId);
    }
}
