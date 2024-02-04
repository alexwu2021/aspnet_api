

using System;
using System.Collections.Generic;
using aspnetapp.Model;

namespace aspnetapp.Provider.Contracts
{
    public interface IPatientProvider
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int patientId);
        void AddPatient(Patient patient);
    }
}


