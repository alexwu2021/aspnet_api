using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Models;

public class Patient_Lab_Result
{
    
    public int Id { get; set; }
    public int Lab_visit_id { get; set; }
    
    public string Test_name { get; set; }
    public string Test_result { get; set; }
    public string Test_observation { get; set; }
    public string Attachments { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}