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

namespace SystemModule
{
    /// <summary>
    /// Proxy to get picture information from service in the cloud
    /// </summary>
    public class CognitiveServiceProxy : CognitiveServicesManager
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
            }
        }

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
            }
        }



        /// <summary>
        /// gets the face detection from picture
        /// </summary>
        public async void getPicture(string path)
        {

            string filePath = path;

            Uri fileUri = new Uri(filePath);
            BitmapImage bitmapSource = new BitmapImage();
            bitmapSource.BeginInit();
            bitmapSource.CacheOption = BitmapCacheOption.None;
            bitmapSource.UriSource = fileUri;
            bitmapSource.EndInit();

            //calls method to upload and detect face
            FaceRectangle[] faceRects = await UploadAndDetectFaces(filePath);



            if (faceRects.Length > 0)
            {
                DrawingVisual visual = new DrawingVisual();
                DrawingContext drawingContext = visual.RenderOpen();
                drawingContext.DrawImage(bitmapSource,
                    new Rect(0, 0, bitmapSource.Width, bitmapSource.Height));
                double dpi = bitmapSource.DpiX;
                double resizeFactor = 96 / dpi;

                foreach (var faceRect in faceRects)
                {
                    drawingContext.DrawRectangle(
                        Brushes.Transparent,
                        new Pen(Brushes.Red, 2),
                        new Rect(
                            faceRect.Left * resizeFactor,
                            faceRect.Top * resizeFactor,
                            faceRect.Width * resizeFactor,
                            faceRect.Height * resizeFactor
                            )
                    );
                }

                drawingContext.Close();
                RenderTargetBitmap faceWithRectBitmap = new RenderTargetBitmap(
                    (int)(bitmapSource.PixelWidth * resizeFactor),
                    (int)(bitmapSource.PixelHeight * resizeFactor),
                    96,
                    96,
                    PixelFormats.Pbgra32);

                faceWithRectBitmap.Render(visual);
                FaceImage = faceWithRectBitmap;
            }
        }

        /// <summary>
        /// Method uses Cognitive services API to detect the face information.
        /// </summary>
        /// <param name="imageFilePath"></param>
        /// <returns></returns>
        private async Task<FaceRectangle[]> UploadAndDetectFaces(string imageFilePath)
        {
            try
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    var faces = await faceServiceClient.DetectAsync(imageFileStream);
                    var faceRects = faces.Select(face => face.FaceRectangle);
                    imageCount = faceRects.Count();
                    return faceRects.ToArray();
                }
            }
            catch (Exception)
            {
                return new FaceRectangle[0];
            }
        }
    }
}
