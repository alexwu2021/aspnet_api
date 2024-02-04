using aspnetapp.DataAccessLayer.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using aspnetapp.Models.Dto;

namespace aspnetapp.DataAccessLayer.Repositories
{
    public class PatientRepository : IPatientRepository, IDisposable
    {
        private readonly PatientDbContext _dbContext;

        public PatientRepository(PatientDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Patient> GetPatients()
        {
            Console.WriteLine("GetPatients invoked inside PatientRepository");
            return _dbContext.Patients;
        }

        public Patient GetPatient(int patientId)
        {
            return _dbContext.Patients.SingleOrDefault(a => a.Id == patientId);
        }



        public void AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _dbContext.Patients.Add(patient);
            Save();
        }

        public bool IsPatientRegistered(long patientId)
        {
            return true;
        }

        public bool Save()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
        
    }
}


