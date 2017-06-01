using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule
{
    public class Visitor : Person
    {
        /// <summary>
        /// get/set age
        /// </summary>
        public int age { get; set; }

        /// <summary>
        /// get /set first name of visitor
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// get/set last name of visitor
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// get / set the location of visitor
        /// </summary>
        public Location PersonLocation { get; set; }

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
