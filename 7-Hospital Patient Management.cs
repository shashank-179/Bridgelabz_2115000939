/*7. Hospital Patient Management
Description: Design a system to manage patients in a hospital.
Abstract Class:
Create an abstract class Patient with fields: patientId, name, and age.
Add an abstract method CalculateBill().
Implement a concrete method GetPatientDetails().
Subclasses:
Extend Patient into InPatient and OutPatient.
Implement CalculateBill() differently for each subclass.
Interface:
Implement an interface IMedicalRecord.
Define methods AddRecord() and ViewRecords().
Encapsulation:
Protect sensitive patient data like diagnosis and medical history.
Polymorphism:
Use a Patient reference to handle different patient types dynamically.
Display billing details based on polymorphic behavior.
*/

using System;
using System.Collections.Generic;


// Abstract Class
public abstract class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }


    public abstract double CalculateBill();
    public void GetPatientDetails()
    {
        Console.WriteLine("Patient: " + Name + ", Age: " + Age);
    }
}


// Subclasses
public class InPatient : Patient
{
    public override double CalculateBill()
    {
        return 1000;  // Example bill for in-patient
    }
}


public class OutPatient : Patient
{
    public override double CalculateBill()
    {
        return 200;  // Example bill for out-patient
    }
}


// Interface
public interface IMedicalRecord
{
    void AddRecord(string record);
    void ViewRecords();
}


// Main Program
public class Program
{
    public static void Main()
    {
        List<Patient> patients = new List<Patient>
        {
            new InPatient { PatientId = 1, Name = "Ramesh", Age = 40 },
            new OutPatient { PatientId = 2, Name = "Suresh", Age = 30 }
        };


        foreach (var patient in patients)
        {
            patient.GetPatientDetails();
            double bill = patient.CalculateBill();
            Console.WriteLine("Bill: " + bill);
        }
    }
}



