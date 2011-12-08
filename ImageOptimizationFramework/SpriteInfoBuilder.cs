using System.Collections.Generic;
using System.Drawing;

namespace Microsoft.Web.Samples
{
    public class SpriteInfoBuilder
    {
        private SpriteInfo _spriteInfo;
        private ImageSettings _settings;
        private int _xOffset;
        private int _yOffset;

        public SpriteInfo Build(ImageSettings settings, List<string> imageLocations)
        {
            _spriteInfo = new SpriteInfo();
            _settings = settings;
            var imagePairs = new HoverGenerator().Generate(imageLocations);

            int totalImages = 0;
            foreach (var imagePath in imagePairs)
            {
                var imageInfo = new ImageInfo
                {
                    FileName = imagePath.Key,
                    Bitmap = new Bitmap(imagePath.Key),
                };
                UpdateSizes(imageInfo);
                totalImages++;

                var hoverPath = imagePath.Value;
                if (hoverPath != null)
                {
                    var hoverInfo = new ImageInfo
                    {
                        FileName = hoverPath,
                        Bitmap = new Bitmap(hoverPath)
                    };

                    UpdateSizes(hoverInfo);
                    totalImages++;
                    imageInfo.HoverImage = hoverInfo;
                }
                
                _spriteInfo.Images.Add(imageInfo);
            }

            // Create a drawing surface and add the images to it
            // Since we'll be padding each image by 1px later on, we need to increase the sprites's size correspondingly.
            if (settings.TileInXAxis)
            {
                _spriteInfo.Width += totalImages;
            }
            else
            {
                _spriteInfo.Height += totalImages;                
            }

            return _spriteInfo;
        }

        private void UpdateSizes(ImageInfo imageInfo)
        {
            var bitmap = imageInfo.Bitmap;
            imageInfo.Position = new Position(_xOffset, _yOffset);
            // Find the total pixel size of the sprite based on the tiling direction
            if (_settings.TileInXAxis)
            {
                _spriteInfo.Width += bitmap.Width;
                if (_spriteInfo.Height < bitmap.Height)
                {
                    _spriteInfo.Height = bitmap.Height;
                }
                _xOffset += bitmap.Width + 1;
            }
            else
            {
                _spriteInfo.Height += bitmap.Height;
                if (_spriteInfo.Width < bitmap.Width)
                {
                    _spriteInfo.Width = bitmap.Width;
                }
                _yOffset += bitmap.Height + 1;                
            }
        }
    }
}