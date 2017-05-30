using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModule
{
    public abstract class MediatorMessage
    {

        /// <summary>
        /// Method to send message 
        /// </summary>
        /// <param name="message"></param>
        public virtual void SendMessage(string message)
        {

        }

        /// <summary>
        /// Method to get picture from camera
        /// </summary>
        public virtual void GetPicture()
        {

        }

        /// <summary>
        /// Method to serialize image
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public virtual byte[] GetImageAsByteArray(string img)
        {
            return null;
        }

        /// <summary>
        /// Make the detect request to AI API
        /// </summary>
        public virtual void MakeDetectRequest()
        {

        }
    }
}
