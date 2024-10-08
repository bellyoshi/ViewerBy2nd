﻿using ViewerBy2nd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ViewerBy2nd.FileViewParams
{
    abstract public class DocuGraphFileViewParam(string filename) : FileViewParam(filename), ImageSetter
    {

        private IDisplay? _display;
        public void SetDisplay(IDisplay display)
        {
            _display = display;
            ExecuteDisplay();
        }

        public void ExecuteDisplay()
        {
            if (_display == null) return;
            var image = GetImageFromFile();
            // 回転変換を作成する
            RotateTransform rotateTransform = new RotateTransform(_angle);

            // 回転させた画像を表示するためにTransformedBitmapを作成する
            TransformedBitmap transformedBitmap = new TransformedBitmap(image, rotateTransform);

            // ImageコントロールのSourceプロパティに設定する

            _display.SetImageSource(transformedBitmap);
        }

        private double _angle = 0;

        /// <summary>
        /// 回転角度
        /// </summary>
        public double Angle
        {
            get => _angle; 
            set
            {
                _angle = value;
                ExecuteDisplay();
            }
        }

        public double _scale = 100;
        public double Scale
        {
            get => _scale;
            set
            {
                _scale = value; 
                ExecuteDisplay();
            }
        }
               


        public abstract BitmapSource GetImageFromFile();
        
    }
}
