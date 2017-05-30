using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule
{
    public interface IPerson
    {
        /// <summary>
        /// Get / set user id
        /// </summary>
        int UserId { get; set; }
        /// <summary>
        /// get / set first name
        /// </summary>
        string FirstName { get; set; }
        /// <summary>
        /// get / set last name
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// get / set user's age
        /// </summary>
        int age { get; set; }

        /// <summary>
        /// get /set the user's location
        /// </summary>
        Location PersonLocation { get; set; }

        /// <summary>
        /// method to send message between classes
        /// </summary>
        void SendMessage();
    }
}
