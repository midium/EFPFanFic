using EFPFanFic.Business.Scapers.Entities;
using EFPFanFic.UI.Search.Commands;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EFPFanFic.UI.Search.ViewModels
{
    public class FanFicSearcherViewModel : ObservableObject
    {

        public event Action SearchFanFics;

        private readonly FanFicsSearchCommand _searchCommand;

        private readonly CollectionView _ratingEntries;
        private EntityBase _ratingEntry;
        private readonly CollectionView _genreEntries;
        private EntityBase _genreEntry;
        private readonly CollectionView _storyLengthEntries;
        private EntityBase _storyLengthEntry;
        private readonly CollectionView _storyStatusEntries;
        private EntityBase _storyStatusEntry;
        private readonly CollectionView _coupleTypeEntries;
        private EntityBase _coupleTypeEntry;
        private readonly CollectionView _characterEntries;
        private EntityBase _character1Entry;
        private readonly CollectionView _characterEntries2;
        private EntityBase _character2Entry;
        private readonly CollectionView _coupleEntries;
        private EntityBase _coupleEntry;
        private readonly CollectionView _contextEntries;
        private EntityBase _contextEntry;
        private readonly CollectionView _notesEntries;
        private EntityBase _noteEntry;
        private readonly CollectionView _excludeNotesEntries;
        private EntityBase _excludeNoteEntry;
        private readonly CollectionView _warnsEntries;
        private EntityBase _warnsEntry;
        private readonly CollectionView _excludeWarnsEntries;
        private EntityBase _excludeWarnsEntry;

        public FanFicsSearchCommand SearchCommand
        {
            get { return _searchCommand; }
        }

        public FanFicSearcherViewModel(List<EntityBase> ratingOptions, List<EntityBase> genresOptions,List<EntityBase> storyLengthOptions,
                                        List<EntityBase> storyStatusOptions, List<EntityBase> coupleTypesOptions, List<EntityBase> charactersOptions,
                                        List<EntityBase> couplesOptions,List<EntityBase> contextOptions,
                                        List<EntityBase> notesOptions,List<EntityBase> warnsOptions)
        {
            _ratingEntries = new CollectionView(ratingOptions); _ratingEntry = ratingOptions[0];
            _genreEntries = new CollectionView(genresOptions); _genreEntry = genresOptions[0];
            _storyLengthEntries = new CollectionView(storyLengthOptions); _storyLengthEntry = storyLengthOptions[0];
            _storyStatusEntries = new CollectionView(storyStatusOptions); _storyStatusEntry = storyStatusOptions[0];
            _coupleTypeEntries = new CollectionView(coupleTypesOptions); _coupleTypeEntry = coupleTypesOptions[0];
            _characterEntries = new CollectionView(charactersOptions); _character1Entry = charactersOptions[0];
            _characterEntries2 = new CollectionView(charactersOptions); _character2Entry = charactersOptions[0];
            _coupleEntries = new CollectionView(couplesOptions); _coupleEntry = couplesOptions[0];
            _contextEntries = new CollectionView(contextOptions); _contextEntry = contextOptions[0];
            _notesEntries = new CollectionView(notesOptions); _noteEntry = notesOptions[0]; _excludeNoteEntry = notesOptions[0];
            List<EntityBase> excludeNotesOptions = Clone(notesOptions, true, "None");
            _excludeNotesEntries = new CollectionView(excludeNotesOptions);  _excludeNoteEntry = excludeNotesOptions[0];
            _warnsEntries = new CollectionView(warnsOptions); _warnsEntry = warnsOptions[0];
            List<EntityBase> excludeWarnsOptions = Clone(warnsOptions, true, "None");
            _excludeWarnsEntries = new CollectionView(excludeWarnsOptions); _excludeWarnsEntry = excludeWarnsOptions[0];

            _searchCommand = new FanFicsSearchCommand();
            _searchCommand.RunCommand += _RunCommand;

        }

        private void _RunCommand()
        {
            OnSearchRequest();
        }

        private void OnSearchRequest()
        {
            if (SearchFanFics != null)
                SearchFanFics();
        }

        private List<EntityBase> Clone(List<EntityBase> options, bool isOverrideDefault, string defaultValueName)
        {
            List<EntityBase> result = new List<EntityBase>();
            foreach(EntityBase option in options)
            {
                if (option.Value == string.Empty && isOverrideDefault)
                    result.Add(new EntityBase(option.Value, defaultValueName));
                else
                    result.Add(option);
            }

            return result;
        }

        public CollectionView RatingEntries => _ratingEntries;

        public EntityBase RatingEntry
        {
            get => _ratingEntry;
            set
            {
                if (_ratingEntry == value) return;
                _ratingEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView GenreEntries => _genreEntries;

        public EntityBase GenreEntry
        {
            get => _genreEntry;
            set
            {
                if (_genreEntry == value) return;
                _genreEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView StoryLengthEntries => _storyLengthEntries;

        public EntityBase StoryLengthEntry
        {
            get => _storyLengthEntry;
            set
            {
                if (_storyLengthEntry == value) return;
                _storyLengthEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView StoryStatusEntries => _storyStatusEntries;

        public EntityBase StoryStatusEntry
        {
            get => _storyStatusEntry;
            set
            {
                if (_storyStatusEntry == value) return;
                _storyStatusEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView CoupleTypeEntries => _coupleTypeEntries;

        public EntityBase CoupleTypeEntry
        {
            get => _coupleTypeEntry;
            set
            {
                if (_coupleTypeEntry == value) return;
                _coupleTypeEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView CharacterEntries => _characterEntries;

        public EntityBase Character1Entry
        {
            get => _character1Entry;
            set
            {
                if (_character1Entry == value) return;
                _character1Entry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView CharacterEntries2 => _characterEntries2;

        public EntityBase Character2Entry
        {
            get => _character2Entry;
            set
            {
                if (_character2Entry == value) return;
                _character2Entry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView CoupleEntries => _coupleEntries;

        public EntityBase CoupleEntry
        {
            get => _coupleEntry;
            set
            {
                if (_coupleEntry == value) return;
                _coupleEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView ContextEntries => _contextEntries;

        public EntityBase ContextEntry
        {
            get => _contextEntry;
            set
            {
                if (_contextEntry == value) return;
                _contextEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView NotesEntries => _notesEntries;

        public EntityBase NoteEntry
        {
            get => _noteEntry;
            set
            {
                if (_noteEntry == value) return;
                _noteEntry = value;
                OnPropertyChanged();
            }
        }

        public EntityBase ExcludeNoteEntry
        {
            get => _excludeNoteEntry;
            set
            {
                if (_excludeNoteEntry == value) return;
                _excludeNoteEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView WarnsEntries => _warnsEntries;

        public EntityBase WarnsEntry
        {
            get => _warnsEntry;
            set
            {
                if (_warnsEntry == value) return;
                _warnsEntry = value;
                OnPropertyChanged();
            }
        }

        public EntityBase ExcludeWarnsEntry
        {
            get => _excludeWarnsEntry;
            set
            {
                if (_excludeWarnsEntry == value) return;
                _excludeWarnsEntry = value;
                OnPropertyChanged();
            }
        }

        public CollectionView ExcludeNotesEntries => _excludeNotesEntries;

        public CollectionView ExcludeWarnsEntries => _excludeWarnsEntries;
    }
}
