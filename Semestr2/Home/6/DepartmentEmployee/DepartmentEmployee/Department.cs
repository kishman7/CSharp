using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DepartmentEmployee
{
    class Department : IEnumerable
    {
        List<Employee> ListEmployee = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            ListEmployee.Add(employee);
        }

        public void RemoveEmployee(int number)
        {
            foreach (Employee em in ListEmployee)
                if (em.NumberContract == number)
                { 
                    ListEmployee.Remove(em);
                    break;
                }
        }
        public void RemoveEmployee()
        {
            Console.WriteLine("Enter name->");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Lastname->");
            string lastName = Console.ReadLine();
            
            foreach (Employee em in ListEmployee)
                if (string.Compare(em.Name, name) == 0 && string.Compare(em.LastName, lastName) == 0)
                {
                    ListEmployee.Remove(em);
                    break;
                }
        }

        public void Print()
        {
            foreach (Employee em in ListEmployee)
                Console.WriteLine(em);
        }

        public IEnumerator GetEnumerator()
        {
            return ListEmployee.GetEnumerator();
        }
        public IEnumerable GetReverseEnumerator()
        {
            for (int i = ListEmployee.Count - 1; i >= 0; i--)
                yield return ListEmployee[i];
        }
        public IEnumerable GetSalaryEnumerator()
        {
            int sal = 0;
            foreach (Employee em in ListEmployee)
                sal += em.Salary;
            sal /= ListEmployee.Count;

            foreach (Employee em in ListEmployee)
                if (em.Salary < sal)
                    yield return em;
        }


    }
}
