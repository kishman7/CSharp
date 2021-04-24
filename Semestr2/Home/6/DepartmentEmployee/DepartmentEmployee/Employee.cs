using System;
using System.Collections.Generic;
using System.Text;

namespace DepartmentEmployee
{
    class Employee : ICloneable
    {
        string name;
        public string Name { get => name; }
        string lastName;
        public string LastName { get => lastName; }
        ushort salary;
        public ushort Salary { get => salary; }
        int numberContract;
        public int NumberContract { get => numberContract; }
        public static int id = 0;

        public Employee() => numberContract = id++;
         public Employee(Employee clone)
        {
            this.name = clone.Name;
            this.lastName = clone.LastName;
            this.salary = clone.Salary;
            this.numberContract = id++;
        }

        public void InputName()
        {
            try
            {
                Console.WriteLine("Enter Name");
                string nam = Console.ReadLine();
                if (!Valid(nam))
                    throw new Exception("Not Corect Name");
                else
                    this.name = nam;
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
                InputName();
            }
        }
        public void InputLastName()
        {
            try
            {
                Console.WriteLine("Enter Last Name");
                string nam = Console.ReadLine();
                if (!Valid(nam))
                    throw new Exception("Not Corect LastName");
                else
                    this.lastName = nam;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                InputLastName();
            }
        }
        public void InputSalary()
        {
            try
            {
                Console.WriteLine("Enter Salary");
                salary = ushort.Parse(Console.ReadLine());
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                InputSalary();
            }
        }
        public void AddSalary(ushort add)
        {
            try
            {
                checked
                {
                    salary += add;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        bool Valid(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        public override string ToString()
        {
            return ($"Name: {Name} {LastName} Contract#: {NumberContract} Salary: {Salary}");
        }

        public object Clone()
        {
            return new Employee(this);
        }
    }
}
