using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule
{
    public abstract class Person
    {
        /// <summary>
        /// Get / set user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// get / set first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// get / set last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// get / set user's age
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// get /set the user's location
        /// </summary>
        public Location PersonLocation { get; set; }

        /// <summary>
        /// method to send message between classes
        /// </summary>
        public virtual void SendMessage() { }
    }
}
