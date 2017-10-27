using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace Midium.Helpers.PDF.Adapters
{
    public class ImageAdapter: RImage
    {
        /// <summary>
        /// the underline win-forms image.
        /// </summary>
        private readonly XImage _image;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ImageAdapter(XImage image)
        {
            _image = image;
        }

        /// <summary>
        /// the underline win-forms image.
        /// </summary>
        public XImage Image
        {
            get { return _image; }
        }

        public override double Width
        {
            get { return _image.PixelWidth; }
        }

        public override double Height
        {
            get { return _image.PixelHeight; }
        }

        public override void Dispose()
        {
            _image.Dispose();
        }
    }
}