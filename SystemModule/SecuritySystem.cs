using System.Threading.Tasks;
using SystemModule;

namespace SystemModule
{
    public class SecuritySystem : MediatorMessage
    {
        public CognitiveServiceProxy proxy = new CognitiveServiceProxy();

        public bool getMatch()
        {
            return proxy.IsMatched;
        }
        /// <summary>
        /// Get picture from camera
        /// </summary>
        public override async Task<bool> GetPicture(string path)
        {
            bool foundMatch = false;
           // base.GetPicture(path);
            if (!string.IsNullOrWhiteSpace(path))
            {
             foundMatch = await proxy.getPicture(path);
            }
            return foundMatch;
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
