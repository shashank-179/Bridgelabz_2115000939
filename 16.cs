
using System;
using System.Collections.Generic;
using System.Linq;

class InsurancePolicy
{
    public int PolicyNumber { get; set; }
    public string CoverageType { get; set; }
    public DateTime ExpiryDate { get; set; }

    public InsurancePolicy(int policyNumber, string coverageType, DateTime expiryDate)
    {
        PolicyNumber = policyNumber;
        CoverageType = coverageType;
        ExpiryDate = expiryDate;
    }
}

class Program
{
    static void Main()
    {
        HashSet<int> uniquePolicies = new HashSet<int>();
        SortedSet<InsurancePolicy> sortedPolicies = new SortedSet<InsurancePolicy>(
            Comparer<InsurancePolicy>.Create((p1, p2) => p1.ExpiryDate.CompareTo(p2.ExpiryDate))
        );

        uniquePolicies.Add(101);
        uniquePolicies.Add(102);
        uniquePolicies.Add(103);

        sortedPolicies.Add(new InsurancePolicy(101, "Health", DateTime.Now.AddDays(20)));
        sortedPolicies.Add(new InsurancePolicy(102, "Auto", DateTime.Now.AddDays(40)));
        sortedPolicies.Add(new InsurancePolicy(103, "Home", DateTime.Now.AddDays(10)));

        Console.WriteLine("Policies expiring soon:");
        foreach (var policy in sortedPolicies.Where(p => (p.ExpiryDate - DateTime.Now).Days <= 30))
        {
            Console.WriteLine($"Policy {policy.PolicyNumber} - Expires on {policy.ExpiryDate}");
        }
    }
}

