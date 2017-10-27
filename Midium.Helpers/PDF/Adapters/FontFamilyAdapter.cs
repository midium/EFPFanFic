using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace Midium.Helpers.PDF.Adapters
{
    public class FontFamilyAdapter: RFontFamily
    {
        /// <summary>
        /// the underline win-forms font.
        /// </summary>
        private readonly XFontFamily _fontFamily;

        /// <summary>
        /// Init.
        /// </summary>
        public FontFamilyAdapter(XFontFamily fontFamily)
        {
            _fontFamily = fontFamily;
        }

        /// <summary>
        /// the underline win-forms font family.
        /// </summary>
        public XFontFamily FontFamily
        {
            get { return _fontFamily; }
        }

        public override string Name
        {
            get { return _fontFamily.Name; }
        }
    }
}