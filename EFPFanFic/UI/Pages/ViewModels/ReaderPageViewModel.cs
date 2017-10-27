using EFPFanFic.UI.Pages.Commands;
using Midium.Helpers.Observable;
using Midium.Helpers.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Pages.ViewModels
{
    public class ReaderPageViewModel : ObservableObject
    {
        private string _fanFicStory;
        private readonly HtmlToText _htmlToText;
        private int _defaultFontSize;
        private readonly ClosePanel _closePanel;

        public event Action CloseReaderPage;

        public ReaderPageViewModel(string fanFicStory)
        {
            _fanFicStory = fanFicStory;
            _defaultFontSize = 20;
            _htmlToText = new HtmlToText();

            _closePanel = new ClosePanel();
            _closePanel.RunClosePanel += _RunClosePanel;
        }

        private void _RunClosePanel()
        {
            CloseReaderPage?.Invoke();
        }

        public string FanFicStory
        {
            get => _htmlToText.ConvertHtml(_fanFicStory);
            set
            {
                _fanFicStory = value;
                OnPropertyChanged();
            }
        }

        public int DefaultFontSize
        {
            get => _defaultFontSize;
            set
            {
                _defaultFontSize = value;
                OnPropertyChanged();
            }
        }

        public ClosePanel ClosePanel { get => _closePanel; }
    }
}
