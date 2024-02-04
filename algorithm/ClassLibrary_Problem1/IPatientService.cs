namespace ClassLibraryProb1;

public interface IPatientService
{
    // The patient is already registered -
    // This API will be used to check if the patient is already registered or not
    // and returns the patient’s id for the existing patient
    bool isExistingPatient();


    //  Get Patient Data for the existing patients - 
    // Return patient information to the consumer/frontend based on the patient id
    PatientData getPatientData(long patientId);




    // Register New Patient - registerNewPatient
    // If the patient is not found in the system then this API will register
    // the new patient and return the newly generated patient id to the consumer/frontend.
    // This API should also trigger another process to perform the following actions in the background
    // Connect to remote API to pull patient's medicines, lab, and vaccination data

    void registerNewPatient();

    /*
    All these APIs should be executed in parallel 
    Each API will require separate authentication
    Once the data is retrieved, it should be stored in the corresponding tables
    */
}