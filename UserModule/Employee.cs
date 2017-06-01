using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule
{
    public class Employee : Person
    {
        /// <summary>
        /// get/set age
        /// </summary>
        public int age { get;set; }

        /// <summary>
        /// get /set first name of employee
        /// </summary>
        public string FirstName { get;set; }

        /// <summary>
        /// get/set last name of employee
        /// </summary>
        public string LastName { get;set; }

        /// <summary>
        /// get / set the location of employee
        /// </summary>
        public Location PersonLocation { get;set; }

        /// <summary>
        /// get /set the user id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// This method is used to send message to other classes.
        /// </summary>
        public void SendMessage()
        {
            throw new NotImplementedException();
        }
    }
}
