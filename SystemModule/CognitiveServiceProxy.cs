using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.ProjectOxford.Face.Contract;
using System.IO;
using Microsoft.ProjectOxford.Face;
using System.Windows.Media;
using System.Windows;
using System.Diagnostics;
using BehaviorModule;

namespace SystemModule
{
    /// <summary>
    /// Proxy to get picture information from service in the cloud
    /// </summary>
    public class CognitiveServiceProxy : WpfBase, CognitiveServicesManager
    {
        //key to to use Microsoft Cognitive Services API
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("676f67d50e7749f4bc88bd9d6aabb7b5", "https://westcentralus.api.cognitive.microsoft.com/face/v1.0");
        /// <summary>
        /// gets face from an image.
        /// </summary>
        private RenderTargetBitmap faceImage;
        public RenderTargetBitmap FaceImage
        {
            get
            {
                return faceImage;
            }

            set
            {
                faceImage = value;
                NotifyPropertyChanged("FaceImage");
            }
        }

        public bool IsMatched { get; set; }

        public Guid PersistedId { get; set; }

        /// <summary>
        /// Gets's face count in a give image
        /// </summary>
        private int imageCount;
        public int ImageCount
        {
            get
            {
                return imageCount;
            }

            set
            {
                imageCount = value;
                NotifyPropertyChanged("ImageCount");
            }
        }



        /// <summary>
        /// gets the face detection from picture
        /// </summary>
        public async Task<bool> getPicture(string path)
        {

            string filePath = path;

            Uri fileUri = new Uri(filePath);
            BitmapImage bitmapSource = new BitmapImage();
            bitmapSource.BeginInit();
            bitmapSource.CacheOption = BitmapCacheOption.None;
            bitmapSource.UriSource = fileUri;
            bitmapSource.EndInit();

            //calls method to upload and detect face
            var isMatchFound = await UploadAndDetectFaces(filePath);
            return isMatchFound;
        }

        /// <summary>
        /// Method uses Cognitive services API to detect the face information.
        /// </summary>
        /// <param name="imageFilePath"></param>
        /// <returns></returns>
        private async Task<bool> UploadAndDetectFaces(string imageFilePath)
        {
            bool isMatched = false;
            try
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    var faces = await faceServiceClient.DetectAsync(imageFileStream);
                    var faceRects = faces.Select(face => face.FaceRectangle);
                    var faceId = faces.FirstOrDefault().FaceId;
                    isMatched = await MatchPersonFace(faceId);
                   
                }
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
            return isMatched;
        }


        /// <summary>
        /// Try to match faces with the system.
        /// </summary>
        /// <param name="faceid1"></param>
        /// <param name="faceid2"></param>
        /// <returns></returns>
        private async Task<bool> MatchPersonFace(Guid faceid1)
        {
            try
            {
                var faceList = await faceServiceClient.GetFaceListAsync("1");
                var faces = await faceServiceClient.FindSimilarAsync(faceid1,faceList.FaceListId);
                if(faces.Count() > 0)
                {
                    var confidence = faces.FirstOrDefault().Confidence;
                    PersistedId = faces.FirstOrDefault().PersistedFaceId;


                    if (confidence > 0.5)
                    {
                        IsMatched = true;
                    }
                    else
                    {
                        IsMatched = false;
                    }

                }
                
                
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.WriteEntry(ex.Message,EventLogEntryType.Error);
            }


            return IsMatched;
        }
    }
}
