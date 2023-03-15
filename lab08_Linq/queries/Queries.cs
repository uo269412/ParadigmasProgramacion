using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPP.Laboratory.Functional.Lab08 {

    class Query {

        private Model model = new Model();

        private static void Show<T>(IEnumerable<T> collection) {
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Number of items in the collection: {0}.", collection.Count());
        }

        static void Main(string[] args) {
            Query query = new Query();
            query.Query1();
            query.Query2();
            query.Query3();
            query.Query4();
            query.Query5();
            query.Homework1();
            query.Homework2();
            query.Homework3();
            query.Homework4();
            query.Homework5();
        }

        private void Query1() {
            // Modify this query to show the names of the employees older than 50 years
            var employees = model.Employees;
            Console.WriteLine("Employees:");
            var query1 =
            from e in employees
            where e.Age > 50
            select e.Name;
            Show(query1);
            Show(employees.Where(e => e.Age > 50).Select(e => e.Name)); 
        }

        private void Query2() {
            // Show the name and email of the employees who work in Asturias
            var employees = model.Employees;
            Console.WriteLine("Employees from Asturias:");
            var query2 =
            from e in employees
            where e.Province.Equals("Asturias")
            select new { Name = e.Name, Email = e.Email };
            Show(query2);
            Show(employees.Where(e => e.Province.Equals("Asturias")).Select(e => new { Name = e.Name, Email = e.Email }));
            var temp = employees.Where(e => e.Province.Equals("Asturias")).Select(e => new { Name = e.Name, Email = e.Email });
            Show(temp);
            Console.WriteLine(temp.ElementAt(0));
        }

        // Notice: from now on, check out http://msdn.microsoft.com/en-us/library/9eekhta0.aspx

        private void Query3() {
            // Show the names of the departments with more than one employee 18 years old and beyond; 
            // the department should also have any office number starting with "2.1"
            var employees = model.Employees;
            Console.WriteLine("Name of departments with more than one employee with more than 18 years and which office number starts with 2.1:");
            var dep1 = employees.Where(e => e.Department.Employees.Any(l => l.Age >= 18)).Select(e => e.Department.Name);
            var dep2 = employees.Where(e => e.Department.Employees.Any(l => l.Office.Number.StartsWith("2.1"))).Select(e => e.Department.Name);
            var finalDep = dep1.Where(x => dep2.Contains(x));
            Show(finalDep);
        }

        private void Query4() {
            // Show the phone calls of each employee. 
            // Each line should show the name of the employee and the phone call duration in seconds.
            var employees = model.Employees;
            var phoneCalls = model.PhoneCalls;
            Console.WriteLine("Phone calls of each employee:");
            Show(employees.Join(phoneCalls, employee => employee.TelephoneNumber, call => call.SourceNumber, (employee, call) => new { employee = employee.Name, call = call.Seconds }));
        }

        private void Query5() {
            // Show, grouped by each province, the name of the employees 
            // (both province and employees must be lexicographically ordered)
            var employees = model.Employees;
            var query =
                 from e in employees
                 orderby e.Province
                 group e by e.Province;
            foreach(var element in query)
            {
                Console.WriteLine("Group by Province: " + element.Key);
                    foreach (var e in element)
                {
                    Console.WriteLine(e.Name);
                }
            }
        }

        /************ Homework **********************************/

        private void Homework1() {
            // Show, ordered by age, the names of the employees in the Computer Science department, 
            // who have an office in the Faculty of Science, 
            // and who have done phone calls longer than one minute
            var employees = model.Employees;
            var phoneCalls = model.PhoneCalls;
            var query =
                from c in phoneCalls
                from e in employees
                where c.Seconds > 60 && e.Department.Name.Equals("Computer Science") && e.Office.Building.Equals("Faculty of Science") && c.SourceNumber == e.TelephoneNumber
                orderby e.Age
                select e.Name;

            Console.WriteLine("Name of employees working in the Computer Science department, have an office in the Faculty of Science and have done phone calls longer than a minute, sorted by age");
            Show(query);

            Console.WriteLine("No syntax sugar");
            var query1 = phoneCalls.Where(p => p.Seconds > 60).Select(p => p);
            var query2 = employees.Where(p => p.Department.Name.Equals("Computer Science") && p.Office.Building.Equals("Faculty of Science")).Select(p => p);
            Show(query2.Join(query1, employee => employee.TelephoneNumber, call => call.SourceNumber, (employee, call) => employee.Name));


        }

        private void Homework2() {
            // Show the summation, in seconds, of the phone calls done by the employees of the Computer Science department
            var phoneCalls = model.PhoneCalls;
            var employees = model.Employees;
            var query =
                (from c in phoneCalls
                 from e in employees
                 where e.Department.Name.Equals("Computer Science") && c.SourceNumber == e.TelephoneNumber
                 select c.Seconds).Sum();
            Console.WriteLine("Sum of the seconds of the phone calls done by the employees of the computer Science department");
            Console.WriteLine(query);
        }

        private void Homework3() {
            // Show the phone calls done by each department, ordered by department names. 
            // Each line must show “Department = <Name>, Duration = <Seconds>”
            var phoneCalls = model.PhoneCalls;
            var employees = model.Employees;
            var query =
                from c in phoneCalls
                from e in employees
                orderby e.Department.Name
                select new { Department = e.Department.Name, Duration = c.Seconds };
            Console.WriteLine("Phone calls done by each department");
            Show(query);
        }

        private void Homework4() {
            // Show the departments with the youngest employee, 
            // together with the name of the youngest employee and his/her age 
            // (more than one youngest employee may exist)
            var employees = model.Employees;
            var query =
            from e in employees
            where e.DateOfBirth == (from y in employees select y.DateOfBirth).Max()
            orderby e.Department.Name
            select new { Department = e.Department.Name, Name = e.Name, Age = e.Age };
            Console.WriteLine("Youngest employees of each department alongside the age");
            Show(query);
        }

        private void Homework5() {
            // Show the greatest summation of phone call durations, in seconds, 
            // of the employees in the same department, together with the name of the department 
            // (it can be assumed that there is only one department fulfilling that condition)
            var phoneCalls = model.PhoneCalls;
            var employees = model.Employees;
            var departments = model.Departments;
            var query = departments.Select(dep => new
            { dep.Name, duration = dep.Employees.Join(phoneCalls, emp => emp.TelephoneNumber, pc => pc.SourceNumber, (emp, pc) => new { emp, pc }).Sum(x => x.pc.Seconds) }
            ).OrderBy(y => -y.duration).ElementAt(0);
            Console.WriteLine("Youngest employees of each department alongside the age");
            Console.WriteLine(query.Name);
            Console.WriteLine(query.duration);
        }


    }

}
