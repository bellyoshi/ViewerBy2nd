using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ViewerBy2ndLib
{
    public   class ImageDisposer
    {

        private List<Image> images = new List<Image>();

        private void AddImage(Image image)
        {
            images.Add(image);
            DisposeImages();
        }
        private void DisposeImages()
        {
            var list = images.ToList();
            foreach(Image image in list)
            {
                DisposeImage(image);
            }
        }
        private void DisposeImage(Image image)
        {
            if (image == null) return;
            if (image == PrevieImage) return;
            if (image == DisplayImage) return;
            if (image == OutputImage) return;
            if (image == RotatedImage) return;
            images.Remove(image);
            image.Dispose();
            
        }
        public  static Image? PrevieImage { get; set; }

        public static Image? DisplayImage { get; set; }
        
        private  Image? _rotatedImage;
        internal Image RotatedImage { 
            get => _rotatedImage ; 
            set => SetRotateImage(value); 
        }
        private void SetRotateImage(Image image)
        {
            _rotatedImage = image;
            AddImage(image);
        }

        private  Image _outputImage;
        internal Image OutputImage
        {
            get => _outputImage;
            set => SetOutputImage(value);
        }
        private void SetOutputImage(Image image)
        {
            _outputImage = image;
            AddImage(image);
        }
    }
}
