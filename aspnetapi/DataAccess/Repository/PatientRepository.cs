using aspnetapp.DataAccessLayer.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetapp.Model;
using aspnetapp.Model.Dto;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> IsPatientExistingAsync(int patientId)
        {
            if (patientId <= 0)
            {
                // for debugging, we will return a dummy object for non dev envs
                throw new ArgumentNullException(nameof(patientId));
            }

            return await _dbContext.Patients.AnyAsync(x => x.Id == patientId);
        }

        public async Task<Patient> GetPatientAsync(int patientId)
        {
            if (patientId <= 0)
            {
                throw new ArgumentNullException(nameof(patientId));
            }
            return await _dbContext.Patients.FirstOrDefaultAsync(x => x.Id == patientId);
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
        
        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() >= 0;
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


