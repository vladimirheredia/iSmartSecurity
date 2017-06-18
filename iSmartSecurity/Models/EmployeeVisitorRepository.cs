using System;
using System.Collections.Generic;
using UserModule;

namespace iSmartSecurity.Models
{
    public static class EmployeeVisitorRepository
    {
        public static List<Employee> Employees { get; set; }

        public static List<Visitor> Visitors { get; set; }
        static EmployeeVisitorRepository()
        {
            Employees = new List<Employee>();
            Employees.Add(new Employee()
            {
                UserId = new Guid("c85055e0-0258-46b3-86bc-d1623aaef2fd"),
                FirstName = "Vladimir",
                LastName = "Heredia",
                age = 38,
                PersonLocation = new Location()
                {
                    Building = "4",
                    Department = "Engineering",
                    Floor = "3",
                    IsCamActive = true
                }
               
            });

            Employees.Add(new Employee()
            {
                UserId = new Guid("09346c57-4aaf-47d6-b9f3-ccfa5366769c"),
                FirstName = "Roman",
                LastName = "Jaquez",
                age = 36,
                PersonLocation = new Location()
                {
                    Building = "4",
                    Department = "Engineering",
                    Floor = "3",
                    IsCamActive = true
                }

            });


            Visitors = new List<Visitor>();
            Visitors.Add(new Visitor()
            {
                FirstName = "Jane",
                LastName = "Doe",
                age = 34,
                
            });

            Visitors.Add(new Visitor()
            {
                FirstName = "John",
                LastName = "Doe",
                age = 36,

            });
        }
    }
}
