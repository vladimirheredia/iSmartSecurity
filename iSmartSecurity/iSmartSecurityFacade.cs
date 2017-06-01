using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using SystemModule;
using UserModule;

namespace iSmartSecurity
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


        public void getPicture(string path)
        {
            Cam.GetPicture(path);
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
