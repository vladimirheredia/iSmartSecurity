using System.Windows.Media.Imaging;

namespace SystemModule
{
    public interface CognitiveServicesManager
    {
        RenderTargetBitmap FaceImage { get; set; }

        int ImageCount { get; set; }
    }
}
