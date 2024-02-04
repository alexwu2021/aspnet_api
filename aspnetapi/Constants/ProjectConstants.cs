namespace aspnetapp.Constants;

public class ProjectConstants
{

    public static readonly string RemoteServiceAuthEndPoint = "https://testapi.mindware.us/auth/local";

    public static readonly string RemoteServiceAuthCredential =
        "{\"identifier\": \"user1@test.com\",   \"password\": \"Test123!\" }"; 
    
    
    public static readonly string LabVisitEndPoint_DocLink =
        "https://testapi.mindware.us/documentation/v1.0.0#/Patient-lab-visit";
    public static readonly string LabVisitEndPoint =
        "Endpoint: https://testapi.mindware.us/Patient-lab-visit";
    
    
    public static readonly string LabResultEndPoint_DocLink =
        "https://testapi.mindware.us/documentation/v1.0.0#/Patient-lab-results"; 
    public static readonly string LabResultEndPoint =
        "https://testapi.mindware.us/Patient-lab-results"; 

    
    public static readonly string PatientMedicationEndPoint_DocLink =
        "https://testapi.mindware.us/documentation/v1.0.0#/Patient-medication";
    public static readonly string PatientMedicationEndPoint =
        "https://testapi.mindware.us/patient-medications";

     
    public static readonly string PatientVaccinationEndPoint_DocLink
        = "https://testapi.mindware.us/documentation/v1.0.0#/Patient-vaccination";
    public static readonly string PatientVaccinationEndPoint
        = "https://testapi.mindware.us/Patient-vaccination";

}