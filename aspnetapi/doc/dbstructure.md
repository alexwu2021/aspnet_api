DB Structure:



Table 1: Patient_Details

id Number

first_name String

middle_name String

last_name String

dob Date

ssn String

address String

city String

zip String

state String

created_at Datetime

updated_at Datetime



Table 2: Patient_Visit_History

Id Number

Patient_id Number

Visit_date Datetime

Doctor_name String

Nurse_name_1 String

Nurse_name_2 String

created_at Datetime

updated_at Datetime



Table 3: Patient_Medication

Patient_id Number

Visit_id Number

Medicine_name String

Dosage String

Frequency String

Prescribed_by String

Prescription_date Date

Prescription_period String

created_at Datetime

updated_at Datetime



Table 4: Patient_Lab_Visit

Id Number

Patient_id Number

Lab_name String

Lab_test_request String

Result_date String

created_at Datetime

updated_at Datetime



Table 5: Patient_Lab_Result

Id Number

Lab_visit_id Number

Test_name String

Test _result String

Test_observation String

Attachments String

created_at Datetime

updated_at Datetime



Table 6: Patient_Vaccination_Data

Id Number

Patient_id Number

Vaccine_name String

Vaccine_date Date

Vaccine_validity String

Administered_by String

created_at Datetime

updated_at Datetime



Also that return value can just be Task<IEnumerable<Restaurant>>. Don't need to use ActionResult unless you need more fine-grained control over the output to the browser (such as directing ASP.NET Core to serve a physical file or something).

You don't need to convert .ToList() when returning an IEnumerable. In fact if you don't it'll do Just-In-Time evaluation when ASP.NET Core goes to serialize it to JSON. Just be careful that there are no disposed objects like databases it would need to enumerate.