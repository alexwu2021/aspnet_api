using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Models;

public class Patient_Lab_Visit
{
    [Key] public long Id { get; set; }
    public long Patient_id { get; set; }
    
    public string Lab_name { get; set; }
    public string Lab_test_request { get; set; }
    public string Result_date { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}