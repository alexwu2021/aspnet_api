using System;
using System.ComponentModel.DataAnnotations;

namespace aspnetapp.Models;

public class Patient_Lab_Visit
{
    public int Id { get; set; }
    public int Patient_id { get; set; }
    
    public string Lab_name { get; set; }
    public string Lab_test_request { get; set; }
    public string Result_date { get; set; }
    
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}