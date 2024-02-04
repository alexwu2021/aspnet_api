using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Model.Dto;

public class PatientMedicationDto
{
    public int Id { get; set; }
    public int Patient_id { get; set; }
    public int Visit_id { get; set; }
    
    public string Medicine_name { get; set; }
    public string Dosage { get; set; }
    public string Frequency { get; set; }
    public string Prescribed_by { get; set; }
    public DateTime? Prescription_date { get; set; } 
    
    public string Prescription_period { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}