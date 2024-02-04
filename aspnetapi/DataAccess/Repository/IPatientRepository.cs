using System.Collections.Generic;
using aspnetapp.Models.Dto;


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
