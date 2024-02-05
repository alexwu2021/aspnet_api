using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.EntityFrameworkCore.SqlServer;

namespace aspnetapp.Model
{
    
   
    public class Patient 
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
     
        public DateTime Dob { get; set; }
        public string Ssn { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
        
        
        
        public ICollection<PatientLabVisit> PatientLabVisits { get; } = new List<PatientLabVisit>();
        public ICollection<PatientLabResult> PatientLabResults { get; } = new List<PatientLabResult>();
        public ICollection<PatientMedication> PatientMedications { get; } = new List<PatientMedication>();
        public ICollection<PatientVaccinationData> PatientVaccinationDatas { get; } = new List<PatientVaccinationData>();
        
        public ICollection<PatientVisitHistory> PatientVisitHistories { get; } = new List<PatientVisitHistory>();
        
    }
}
