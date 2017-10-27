using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace Midium.Helpers.PDF.Adapters
{
    public class BrushAdapter: RBrush
    {
        /// <summary>
        /// The actual PdfSharp brush instance.<br/>
        /// Should be <see cref="XBrush"/> but there is some fucking issue inheriting from it =/
        /// </summary>
        private readonly Object _brush;

        /// <summary>
        /// Init.
        /// </summary>
        public BrushAdapter(Object brush)
        {
            _brush = brush;
        }

        /// <summary>
        /// The actual WinForms brush instance.
        /// </summary>
        public Object Brush
        {
            get { return _brush; }
        }

        public override void Dispose()
        { }
    }
}