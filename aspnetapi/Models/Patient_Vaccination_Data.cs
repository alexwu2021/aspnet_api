using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Models;

public class Patient_Vaccination_Data
{
    [Key] public long Id { get; set; }
    public long Patient_id { get; set; }
    public string Vaccine_name { get; set; }
    public DateTime Vaccine_date { get; set; }
    public string Vaccine_validity { get; set; }
    public string Administered_by { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}