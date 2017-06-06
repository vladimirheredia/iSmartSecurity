using BehaviorModule;
using UserModule;

namespace SystemModule
{
    public class Camera
    {


        ICommand cmd = null;
        public ICommand CaptureImageCommand()
        {
            cmd = new CaptureCommand();
            return cmd;
        }


        /// <summary>
        /// get/set the camera's IP address
        /// </summary>
        public string CameraIP { get; set; }

        /// <summary>
        /// get / set the camera's location
        /// </summary>
        public Location CameraLocation { get; set; }

        /// <summary>
        /// get person's picture
        /// </summary>
        public string GetPicture(string path)
        {
            return path;
        }
    }
}
