using BehaviorModule;
using System.Windows.Media.Imaging;
using SystemModule;
using UserModule;

namespace iSmartSecurityView
{
    /// <summary>
    /// Facade to serve as an interface between modules 
    /// and to abstract out module's implementations
    /// </summary>
    public class iSmartSecurityFacade
    {
        public Camera Cam = null;
        public Person person = null;
        public SecuritySystem securitySystem = null;

        public iSmartSecurityFacade()
        {
            Cam = new Camera();
            securitySystem = new SecuritySystem();
            
        }

        /// <summary>
        /// Returns Image
        /// </summary>
        public RenderTargetBitmap Image
        {
            get
            {
                return securitySystem.proxy.FaceImage;
            }
        }

        /// <summary>
        /// Gets's Image from Cam
        /// </summary>
        /// <param name="path"></param>
        public void getPicture(string path)
        {
            ICommand cmd = Cam.CaptureImageCommand();
            cmd.Execute();
            securitySystem.GetPicture(path);
        }

        /// <summary>
        /// Returns either employee or visitor object
        /// </summary>
        /// <param name="isEmp"></param>
        /// <returns></returns>
        public Person getPerson(bool isEmp)
        {
            return  PersonFactory.CreatePerson(isEmp);
        }

        
    }
}
