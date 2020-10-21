using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Linq
{
    class Employee
    {
        public int Employee_ID;

        public string Surname;

        public int Department_ID;
        public Employee() { }
        public Employee(int Employee_ID, string Surname, int Department_ID)
        {
            this.Employee_ID = Employee_ID;
            this.Surname = Surname;
            this.Department_ID = Department_ID;
        }

        public override string ToString()
        {
            return ( "Department_ID= " +  Department_ID.ToString() + 
                " ID= " + Employee_ID.ToString() + " " + Surname);
        }

    }
    class Department
    {
        public int Department_ID;

        public string Department_name;

        public Department(int Department_ID, string Department_name)
        {
            this.Department_ID = Department_ID;
            this.Department_name = Department_name;
        }

        public override string ToString()
        {
            return ("ID= " + Department_ID.ToString() +
                " name= " + Department_name);
        }
    }
    //5
    class Department_employees
    {
        public int Employee_ID;

        public int Department_ID;

        public Department_employees(int Employee_ID, int Department_ID)
        {
            this.Employee_ID = Employee_ID;
            this.Department_ID = Department_ID;
        }
    }
    class Program
    {
        static void print_query_result<T>(IEnumerable<T> employees, string query_type)
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++\n" + query_type);
            foreach (var x in employees)
            {
                Console.WriteLine(x.ToString());
            }
        }
        static void Main(string[] args)
        {
            //data
            List<Employee> employees = new List<Employee>
            {
                new Employee(1,"Antonov",5),
                new Employee(2,"Lebedev",4),
                new Employee(3,"Abramovich",5),
                new Employee(4,"Viktorovich",4),
                new Employee(5,"Robertovich",4),
                new Employee(6,"Alibasov",5),
                new Employee(7,"Alexeev",5),
                new Employee(8,"Nikitina",4),
                new Employee(9,"Lapenko",4),
                new Employee(10,"Albertov",4),
                new Employee(11,"Leonov", 3),
                new Employee(12,"Radionov", 3),
                new Employee(13,"Nixon", 3)
            };
            List<Department> departments = new List<Department>
            {
                new Department(5, "Human resourses"),
                new Department(4, "IT development"),
                new Department(3, "IT testing")
            };   
            //4
            var departments_employees = from x in employees
                                        orderby x.Department_ID
                                        select x;
            print_query_result(departments_employees, nameof(departments_employees));
            var begin_with_a = from x in employees
                               where x.Surname.StartsWith("A")
                               select x;
            print_query_result(begin_with_a, nameof(begin_with_a));
            var deps_emp_cnt = from x in departments
                               select new { dep_name = x.Department_name, 
                                   value = employees.Count(p => p.Department_ID == x.Department_ID) };
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++\ndeps_emp_cnt");
            foreach(var item in deps_emp_cnt)
            {
                Console.WriteLine(item.dep_name + " has " + item.value + " employees");
            }

            var deps_with_All_A_employees = from x in departments
                                        where employees.Count(p => p.Department_ID == x.Department_ID) == 
                                        employees.Count(p => p.Surname.StartsWith("A") && p.Department_ID == x.Department_ID)
                                        select x;
            print_query_result(deps_with_All_A_employees, nameof(deps_with_All_A_employees));

            var deps_with_A_employees = from x in departments
                                        where employees.Count(p => p.Surname.StartsWith("A") &&
                                        p.Department_ID == x.Department_ID) > 0
                                        select x;
            print_query_result(deps_with_A_employees, nameof(deps_with_A_employees));

            //6
            List<Department_employees> dep_employees = new List<Department_employees>();
            foreach(var x in employees)
            {
                Department_employees tmp = new Department_employees(x.Employee_ID, x.Department_ID);
                dep_employees.Add(tmp);
                if (tmp.Department_ID == 4)
                {
                    Department_employees tmp2 = new Department_employees(x.Employee_ID, 3);
                    dep_employees.Add(tmp2);
                }
            }
            var query_empl_in_deps = from d in dep_employees
                                     join e in employees on d.Employee_ID equals e.Employee_ID
                                     orderby d.Department_ID
                                     select new { Department_ID = d.Department_ID, Surname = e.Surname };
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++\nquery_empl_in_deps");
            foreach (var item in query_empl_in_deps)
            {
                Console.WriteLine("Dep_ID = " + item.Department_ID + "  " + item.Surname);
            }
            var query_empl_in_deps_cnt = from x in departments
                                         select new { dep_name = x.Department_name,
                                             empl_count = dep_employees.Count(p => p.Department_ID == x.Department_ID) };
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++\nquery_empl_in_deps_cnt");
            foreach (var item in query_empl_in_deps_cnt)
            {
                Console.WriteLine(item.dep_name + " has " + item.empl_count + " employees");
            }
        }
    }
}
