using System.Collections.Generic;
using UserModule;

namespace BehaviorModule
{
    /// <summary>
    /// Employee Iterator class
    /// </summary>
    public class EmployeeIterator : PersonIterator
    {
        private int position;
        IList<Employee> Employees;

        public EmployeeIterator()
        {
            position = 0;
            Employees = new List<Employee>();
        }


        /// <summary>
        /// Gets current item in the list
        /// </summary>
        public Person currentItem()
        {
            return Employees[position];
        }

        /// <summary>
        /// Gets first item in the list
        /// </summary>
        public Person first()
        {
           return Employees[0];
        }

        /// <summary>
        /// Is iterator Done 
        /// </summary>
        /// <returns></returns>
        public bool isDone()
        {
            if (Employees.Count <= position)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get's next item in the list
        /// </summary>
        public Person next()
        {
            return Employees[position++];
        }
    }
}
