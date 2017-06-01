using System.Windows.Media.Imaging;
using UserModule;

namespace SystemModule
{
    public class SecuritySystem : MediatorMessage
    {
        public CognitiveServiceProxy proxy = new CognitiveServiceProxy();
        /// <summary>
        /// Get picture from camera
        /// </summary>
        public override void GetPicture(string path)
        {
           // base.GetPicture(path);
            if (!string.IsNullOrWhiteSpace(path))
            {
              proxy.getPicture(path);
            }
        }

        /// <summary>
        /// Method to send message to other components
        /// </summary>
        /// <param name="message"></param>
        public override void SendMessage(string message)
        {
            base.SendMessage(message);
        }

    }
}
