using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Models;

public class Patient_Medication
{
    [Key] public long Id { get; set; }
    public long Patient_id { get; set; }
    public long Visit_id { get; set; }
    
    public string Medicine_name { get; set; }
    public string Dosage { get; set; }
    public string Frequency { get; set; }
    public string Prescribed_by { get; set; }
    public DateTime? Prescription_date { get; set; } 
    
    public string Prescription_period { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}