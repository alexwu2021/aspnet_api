using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Models;

public class Patient_Visit_History
{
   
    [Key] public long Id { get; set; }
    public long Patient_id { get; set; }
    public DateTime Visit_date { get; set; }
    
    
    public string Doctor_name { get; set; }
    public string Nurse_name_1 { get; set; }
    public string Nurse_name_2 { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}