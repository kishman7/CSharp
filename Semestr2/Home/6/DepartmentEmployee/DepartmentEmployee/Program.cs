using System;

namespace DepartmentEmployee
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department();

            int c = 1;
            while (c > 0)
            {
                Console.WriteLine(
                    "1. Add Employee\n" +
                    "2. Show Employee\n" +
                    "3. Add Salary\n" +
                    "4. IEnumerable Enumerator (Show All)\n" +
                    "5. IEnumerable ReverseEnumerator (Show All)\n" +
                    "6. IEnumerable SalaryEnumerator\n" +
                    "7. Remove Employee (number)\n" +
                    "8. Remove Employee (name, lastname)\n" +
                    "9. Clone\n"
                    );

                c = Int32.Parse(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        {
                            AddEmployee(department);
                            break; 
                        }
                    case 2:
                        {
                            department.Print();
                            break;
                        }
                    case 3:
                        {
                            AddSalary(department);
                            break;
                        }
                    case 4:
                        {
                            foreach (Employee employee in department)
                                Console.WriteLine(employee);
                            break;
                        }
                    case 5:
                        {
                            foreach (Employee employee in department.GetReverseEnumerator())
                                Console.WriteLine(employee);
                            break;
                        }
                    case 6:
                        {
                            foreach (Employee employee in department.GetSalaryEnumerator())
                                Console.WriteLine(employee);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter Number Contract");
                            department.Print();
                            int id = Int32.Parse(Console.ReadLine());
                            department.RemoveEmployee(id);
                            break;
                        }
                    case 8:
                        {
                            department.RemoveEmployee();
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Select Number Contract");
                            department.Print();
                            int id = Int32.Parse(Console.ReadLine());
                          
                            foreach (Employee em in department)
                                if (em.NumberContract == id)
                                {
                                    department.AddEmployee(em.Clone() as Employee);
                                    break;
                                }
                            break;
                        }
                }
            }
        }
        static void AddEmployee(Department department)
        {
            Employee employee = new Employee();
            employee.InputName();
            employee.InputLastName();
            employee.InputSalary();
            department.AddEmployee(employee);
        }
        static void AddSalary(Department department)
        {
            Console.WriteLine("Select Number Contract");
            department.Print();
            int id = Int32.Parse(Console.ReadLine());

            Employee employee = null;
            foreach (Employee employee1 in department)
                if (employee1.NumberContract == id)
                {
                    employee = employee1;
                    break;
                }

            if (employee is null)
                AddSalary(department);
            else
            {
                Console.WriteLine("Enter the amount-> ");
                ushort sum = ushort.Parse(Console.ReadLine());
                employee.AddSalary(sum);
            }
        }

    }
}
