
using aspnetapp.DataAccessLayer.Repositories;
using System.Collections.Generic;
using aspnetapp.Provider.Contracts;
using aspnetapp.Model;

namespace aspnetapp.Provider
{
    public class PatientProvider : IPatientProvider
    {
        private readonly IPatientRepository _patientRepository;

        public PatientProvider(IPatientRepository patientRepository)
        {
            this._patientRepository = patientRepository;
        }
        public void AddPatient(Patient patient)
        {
            _patientRepository.AddPatient(patient);
        }

        public Patient GetPatient(int employeeId)
        {
            return _patientRepository.GetPatient(employeeId);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _patientRepository.GetPatients();
        }
    }
}



