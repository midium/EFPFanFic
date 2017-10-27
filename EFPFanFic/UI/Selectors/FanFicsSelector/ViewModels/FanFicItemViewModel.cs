using EFPFanFic.UI.Selectors.FanFicsSelector.Commands;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels
{
    public class FanFicItemViewModel: ObservableObject
    {
        public event Action<FanFicItemViewModel> SaveAsPDF;
        public event Action<FanFicItemViewModel> ReadFanFic;
        private SaveAsPdfCommand _saveAsPdfCommand;
        private ReadFanFicCommand _readFanFicCommand;

        public SaveAsPdfCommand SaveAsPdf { get => _saveAsPdfCommand; }
        public ReadFanFicCommand ReadFanFicCommand { get => _readFanFicCommand; }

        private SolidColorBrush _ratingColor;
        private string _title;
        private string _description;
        private string _author;
        private string _started;
        private string _updated;
        private string _genre;
        private int _caps;
        private string _status;
        private string _notes;
        private string _warnings;
        private string _characters;
        private string _couples;
        private string _coupleType;
        private string _context;
        private string _uri;

        public SolidColorBrush RatingColor { get => _ratingColor; set { _ratingColor = value; OnPropertyChanged(); } }
        public string Title { get => _title; set { _title = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string Author { get => _author; set { _author = value; OnPropertyChanged(); } }
        public string Started { get => _started; set { _started = value; OnPropertyChanged(); } }
        public string Updated { get => _updated; set { _updated = value; OnPropertyChanged(); } }
        public string Genre { get => _genre; set { _genre = value; OnPropertyChanged(); } }
        public int Caps { get => _caps; set { _caps = value; OnPropertyChanged(); } }
        public string Status { get => _status; set { _status = value; OnPropertyChanged(); } }
        public string Notes { get => _notes; set { _notes = value; OnPropertyChanged(); } }
        public string Warnings { get => _warnings; set { _warnings = value; OnPropertyChanged(); } }
        public string Characters { get => _characters; set { _characters = value; OnPropertyChanged(); } }
        public string Couples { get => _couples; set { _couples = value; OnPropertyChanged(); } }
        public string CoupleType { get => _coupleType; set { _coupleType = value; OnPropertyChanged(); } }
        public string Context { get => _context; set { _context = value; OnPropertyChanged(); } }
        public string Uri { get => _uri; set { _uri = value; OnPropertyChanged(); } }

        public FanFicItemViewModel(SolidColorBrush ratingColor, string title, string description, string author, string started, string updated, 
                                    string genre, int caps, string status, string notes, string warnings, string characters, string couples, 
                                    string coupleType, string context, string uri)
        {
            _ratingColor = ratingColor;
            _title = title;
            _description = description;
            _author = author;
            _started = started;
            _updated = updated;
            _genre = genre;
            _caps = caps;
            _status = status;
            _notes = notes;
            _warnings = warnings;
            _characters = characters;
            _couples = couples;
            _coupleType = coupleType;
            _context = context;
            _uri = uri;

            _saveAsPdfCommand = new SaveAsPdfCommand();
            _saveAsPdfCommand.SaveAsPdf += _SaveAsPdf;

            _readFanFicCommand = new ReadFanFicCommand();
            _readFanFicCommand.ReadFanFic += _ReadFanFic;

        }

        private void _ReadFanFic(FanFicItemViewModel fanFicData)
        {
            if (fanFicData != null && ReadFanFic != null)
                ReadFanFic(fanFicData);
        }

        private void _SaveAsPdf(FanFicItemViewModel fanFicData)
        {
            if (fanFicData != null && SaveAsPDF != null)
                SaveAsPDF(fanFicData);
        }

    }
}
