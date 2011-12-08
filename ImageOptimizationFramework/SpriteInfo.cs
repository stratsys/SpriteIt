using System.Collections.Generic;
using System.Drawing;

namespace Microsoft.Web.Samples
{
    public class SpriteInfo
    {
        public SpriteInfo()
        {
            Images = new List<ImageInfo>();
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public List<ImageInfo> Images{ get; set; }
    }

    public class ImageInfo
    {
        public Position Position { get; set; }
        public string FileName { get; set; }
        public Bitmap Bitmap { get; set; }
        public ImageInfo HoverImage { get; set; }
    }

    public struct Position
    {
        public Position(int xOffset, int yOffset)
        {
            XOffset = xOffset;
            YOffset = yOffset;
        }
        public int XOffset;
        public int YOffset;
    }
}