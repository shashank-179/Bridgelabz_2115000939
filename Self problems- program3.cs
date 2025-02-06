/*Problem 3: Hospital, Doctors, and Patients (Association and Communication)
Description: Model a Hospital where Doctor and Patient objects interact through consultations. A doctor can see multiple patients, and each patient can consult multiple doctors.
Tasks:
Define a Hospital class containing Doctor and Patient classes.
Create a method Consult() in the Doctor class to show communication, which would display the consultation between a doctor and a patient.
Model an association between doctors and patients to show that doctors and patients can have multiple relationships.
Goal: Practice creating an association with communication between objects by modeling doctor-patient consultations.
*/

using System;
using System.Collections.Generic;

class Hospital
{
    public string Name { get; set; }
    public List<Doctor> Doctors { get; private set; }
    public List<Patient> Patients { get; private set; }

    // Constructor to initialize hospital
    public Hospital(string name)
    {
        Name = name;
        Doctors = new List<Doctor>();
        Patients = new List<Patient>();
    }

    // Add a doctor to the hospital
    public void AddDoctor(Doctor doctor)
    {
        Doctors.Add(doctor);
    }

    // Add a patient to the hospital
    public void AddPatient(Patient patient)
    {
        Patients.Add(patient);
    }
}

class Doctor
{
    public string Name { get; set; }
    public List<Patient> Patients { get; private set; }

    // Constructor to initialize doctor
    public Doctor(string name)
    {
        Name = name;
        Patients = new List<Patient>();
    }

    // Doctor consults a patient
    public void Consult(Patient patient)
    {
        if (!Patients.Contains(patient))
        {
            Patients.Add(patient);
            patient.Doctors.Add(this);
        }
        Console.WriteLine($"Dr. {Name} is consulting Patient {patient.Name}.");
    }
}

class Patient
{
    public string Name { get; set; }
    public List<Doctor> Doctors { get; private set; }

    // Constructor to initialize patient
    public Patient(string name)
    {
        Name = name;
        Doctors = new List<Doctor>();
    }
}

class Program
{
    public static void Main()
    {
        // Create a hospital
        Hospital hospital = new Hospital("City Hospital");

        // Create doctors
        Doctor doctor1 = new Doctor("Arun");
        Doctor doctor2 = new Doctor("Varun");

        // Create patients
        Patient patient1 = new Patient("Ram");
        Patient patient2 = new Patient("Shyam");

        // Add doctors and patients to the hospital
        hospital.AddDoctor(doctor1);
        hospital.AddDoctor(doctor2);
        hospital.AddPatient(patient1);
        hospital.AddPatient(patient2);

        // Perform consultations
        doctor1.Consult(patient1);
        doctor1.Consult(patient2);
        doctor2.Consult(patient1);

        // Display doctor-patient associations
        Console.WriteLine("\nDoctor-Patient Associations:");
        foreach (var doc in hospital.Doctors)
        {
            Console.WriteLine($"Dr. {doc.Name} is consulting:");
            foreach (var pat in doc.Patients)
            {
                Console.WriteLine($"  - {pat.Name}");
            }
        }
    }
}


