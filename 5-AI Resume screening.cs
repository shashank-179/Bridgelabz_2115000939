/*AI-Driven Resume Screening System
Concepts: Generic Classes, Generic Methods, Constraints
Problem Statement: Develop a resume screening system that can process resumes for different job roles while ensuring type safety.
Hints: 
Create an abstract class JobRole (SoftwareEngineer, DataScientist).
Implement a generic class Resume<T> where T : JobRole to process resumes dynamically.
Use List<T> to handle multiple job roles in the screening pipeline.
*/


using System;
using System.Collections.Generic;


// Abstract class for job roles
abstract class JobRole { }


class SoftwareEngineer : JobRole { }
class DataScientist : JobRole { }


// Base class for Resume
abstract class ResumeBase
{
    public string CandidateName { get; set; }
    public abstract string GetRoleName();
}


// Generic Resume class inheriting from ResumeBase
class Resume<T> : ResumeBase where T : JobRole, new()
{
    public T Role { get; set; } = new T();
    public override string GetRoleName() => Role.GetType().Name;
}


// Resume screening system
class ResumeScreening
{
    private List<ResumeBase> Resumes = new List<ResumeBase>();


    public void AddResume(ResumeBase resume) => Resumes.Add(resume);


    public void ProcessResumes()
    {
        foreach (var resume in Resumes)
        {
            Console.WriteLine($"Processing Resume for {resume.CandidateName} - Role: {resume.GetRoleName()}");
        }
    }
}


// Main execution
class Program
{
    static void Main()
    {
        ResumeScreening system = new ResumeScreening();


        Resume<SoftwareEngineer> seResume = new Resume<SoftwareEngineer> { CandidateName = "Alice" };
        Resume<DataScientist> dsResume = new Resume<DataScientist> { CandidateName = "Bob" };


        system.AddResume(seResume);
        system.AddResume(dsResume);


        system.ProcessResumes();
    }
}


