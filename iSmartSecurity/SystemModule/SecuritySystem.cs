using UserModule;

namespace SystemModule
{
    public class SecuritySystem : MediatorMessage
    {
       private IPerson person;

        /// <summary>
        /// Get image to serialize and send to API
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public override byte[] GetImageAsByteArray(string img)
        {
            return base.GetImageAsByteArray(img);
        }


        /// <summary>
        /// Get picture from camera
        /// </summary>
        public override void GetPicture()
        {
            base.GetPicture();
        }

        /// <summary>
        /// Method to send message to other components
        /// </summary>
        /// <param name="message"></param>
        public override void SendMessage(string message)
        {
            base.SendMessage(message);
        }


        /// <summary>
        /// Method to make detect request.
        /// </summary>
        public override void MakeDetectRequest()
        {
            base.MakeDetectRequest();
        }

        //private async Task<FaceRectangle[]> UploadAndDetectFaces(string imageFilePath)
        //{
        //    try
        //    {
        //        using (Stream imageFileStream = File.OpenRead(imageFilePath))
        //        {
        //            var faces = await faceServiceClient.DetectAsync(imageFileStream);
        //            var faceRects = faces.Select(face => face.FaceRectangle);
        //            return faceRects.ToArray();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return new FaceRectangle[0];
        //    }
        //}
    }
}
