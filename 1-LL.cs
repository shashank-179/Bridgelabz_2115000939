/*Problem Statement: Create a program to manage student records using a singly linked list. Each node will store information about a student, including their Roll Number, Name, Age, and Grade. Implement the following operations:
Add a new student record at the beginning, end, or at a specific position.
Delete a student record by Roll Number.
Search for a student record by Roll Number.
Display all student records.
Update a student's grade based on their Roll Number.
*/

using System;


class Student {
    public int RollNumber;
    public string Name;
    public int Age;
    public char Grade;
    public Student Next;
}


class StudentLinkedList {
    private Student head;  // Declare head pointer


    // Add a student at the beginning
    public void AddAtBeginning(int rollNumber, string name, int age, char grade) {
        Student newStudent = new Student();
        newStudent.RollNumber = rollNumber;
        newStudent.Name = name;
        newStudent.Age = age;
        newStudent.Grade = grade;
        newStudent.Next = head;


        head = newStudent;
    }


    // Add a student at the end
    public void AddAtEnd(int rollNumber, string name, int age, char grade) {
        Student newStudent = new Student();
        newStudent.RollNumber = rollNumber;
        newStudent.Name = name;
        newStudent.Age = age;
        newStudent.Grade = grade;
        newStudent.Next = null; // New student will be the last one


        if (head == null) {
            head = newStudent;  // If the list is empty, the new student becomes the head
        } else {
            Student current = head;
            while (current.Next != null) {
                current = current.Next;  // Traverse to the last node
            }
            current.Next = newStudent;  // Add the new student at the end
        }
    }


    // Add a student at a specific position
    public void AddAtPosition(int position, int rollNumber, string name, int age, char grade) {
        if (position < 0) {
            Console.WriteLine("Invalid position.");
            return;
        }


        Student newStudent = new Student();
        newStudent.RollNumber = rollNumber;
        newStudent.Name = name;
        newStudent.Age = age;
        newStudent.Grade = grade;


        // If position is 0, add at the beginning
        if (position == 0) {
            newStudent.Next = head;
            head = newStudent;
            return;
        }


        Student current = head;
        int currentPosition = 0;


        // Traverse to the position before the desired position
        while (current != null && currentPosition < position - 1) {
            current = current.Next;
            currentPosition++;
        }


        // If the current node is null, the position is out of bounds
        if (current == null) {
            Console.WriteLine("Position is out of bounds.");
            return;
        }


        // Insert the new student at the specified position
        newStudent.Next = current.Next;
        current.Next = newStudent;
    }


    // Delete a student record by Roll Number
    public void DeleteByRollNumber(int rollNumber) {
        if (head == null) {
            Console.WriteLine("The list is empty.");
            return;
        }


        // If the head is the student to delete
        if (head.RollNumber == rollNumber) {
            head = head.Next;
            Console.WriteLine("Student with Roll Number " + rollNumber + " has been deleted.");
            return;
        }


        Student current = head;
        while (current.Next != null && current.Next.RollNumber != rollNumber) {
            current = current.Next;
        }


        if (current.Next == null) {
            Console.WriteLine("Student with Roll Number " + rollNumber + " not found.");
        } else {
            current.Next = current.Next.Next;
            Console.WriteLine("Student with Roll Number " + rollNumber + " has been deleted.");
        }
    }


    // Search for a student record by Roll Number
    public void SearchByRollNumber(int rollNumber) {
        Student current = head;
        while (current != null) {
            if (current.RollNumber == rollNumber) {
                Console.WriteLine("Student found: Roll Number: " + current.RollNumber + ", Name: " + current.Name + ", Age: " + current.Age + ", Grade: " + current.Grade);
                return;
            }
            current = current.Next;
        }


        Console.WriteLine("Student with Roll Number " + rollNumber + " not found.");
    }


    // Update a student's grade based on Roll Number
    public void UpdateGrade(int rollNumber, char newGrade) {
        Student current = head;
        while (current != null) {
            if (current.RollNumber == rollNumber) {
                current.Grade = newGrade;
                Console.WriteLine("Grade of student with Roll Number " + rollNumber + " has been updated to " + newGrade);
                return;
            }
            current = current.Next;
        }


        Console.WriteLine("Student with Roll Number " + rollNumber + " not found.");
    }


    // Display all student records
    public void DisplayList() {
        Student current = head;
        if (current == null) {
            Console.WriteLine("The list is empty.");
            return;
        }
       
        while (current != null) {
            Console.WriteLine("Roll Number: " + current.RollNumber + ", Name: " + current.Name + ", Age: " + current.Age + ", Grade: " + current.Grade);
            current = current.Next;
        }
    }
}


class Program {
    static void Main(string[] args) {
        StudentLinkedList studentList = new StudentLinkedList();


        // Adding students to the list
        studentList.AddAtBeginning(1, "Shashank", 20, 'A');
        studentList.AddAtEnd(2, "Akshay", 40, 'B');
        studentList.AddAtEnd(3, "Ramesh", 22, 'A');
        studentList.AddAtPosition(1, 4, "Suresh", 25, 'A');  // Adding at position 1


        // Displaying student records
        Console.WriteLine("Student Records:");
        studentList.DisplayList();


        // Searching for a student by Roll Number
        studentList.SearchByRollNumber(2);


        // Updating a student's grade
        studentList.UpdateGrade(2, 'A');


        // Deleting a student by Roll Number
        studentList.DeleteByRollNumber(3);


        // Displaying student records after deletion and grade update
        Console.WriteLine("\nUpdated Student Records:");
        studentList.DisplayList();
    }
}
