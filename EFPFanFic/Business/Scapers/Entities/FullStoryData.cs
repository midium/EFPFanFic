using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.Business.Scapers.Entities
{
    public class FullStoryData
    {
        private string _text;
        private string _css;

        public string Text { get => _text; set => _text = value; }
        public string Css { get => _css; set => _css = value; }

        public FullStoryData(string text, string css)
        {
            _text = text;
            _css = css;
        }
    }
}
