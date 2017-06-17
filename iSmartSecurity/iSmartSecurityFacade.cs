using BehaviorModule;
using System.Threading.Tasks;
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

        public bool IsMatched;

        public iSmartSecurityFacade()
        {
            Cam = new Camera();
            securitySystem = new SecuritySystem();
        }


        public bool GetMatch()
        {
            return securitySystem.getMatch();
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
        public async Task<bool> getPicture(string path)
        {
            bool IsMatchFound = false;
            ICommand cmd = Cam.CaptureImageCommand();
           // cmd.Execute();
           IsMatchFound = await securitySystem.GetPicture(path);

            return IsMatchFound;
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
