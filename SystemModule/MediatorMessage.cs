using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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
        public virtual void GetPicture(string path)
        {
           
        } 
    }
}
