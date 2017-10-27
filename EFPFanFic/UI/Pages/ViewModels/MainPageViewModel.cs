using EFPFanFic.Business.Scapers;
using EFPFanFic.Business.Scapers.Entities;
using EFPFanFic.UI.Selectors.CategorySelector;
using EFPFanFic.UI.Selectors.CategorySelector.ViewModels;
using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels;
using EFPFanFic.UI.Selectors.SubCategorySelector.ViewModels.DTO;
using Midium.Helpers.Observable;
using Midium.Helpers.PDF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFPFanFic.UI.Pages.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly CategorySelectorViewModel _categorySelectorViewModel;
        private UserControl _currentCategoryViewModel;

        private SubCategoryViewModel _subCategorySelectorViewModel;
        private CategoryPageViewModel _categoryPageViewModel;
        private CategoryPage _categoryPage;
        private readonly ScrapersManager _scrapersManager;

        private FanFicSelectorViewModel _fanFicSelectorViewModel;
        private FanFicPageViewModel _fanFicPageViewModel;
        private FanFicsPage _fanFicsPage;

        private ReaderPageViewModel _pageReader;
        private ReaderPage _readerPage;

        private SubCategoryItemDTO _selectedSubCategory;

        private string _rating = string.Empty;
        private string _genre = string.Empty;
        private string _storyLength = string.Empty;
        private string _storyStatus = string.Empty;
        private string _coupleType = string.Empty;
        private string _character1 = string.Empty;
        private string _character2 = string.Empty;
        private string _couple = string.Empty;
        private string _context = string.Empty;
        private string _note = string.Empty;
        private string _warn = string.Empty;
        private string _excludeNote = string.Empty;
        private string _excludeWarn = string.Empty;

        public MainPageViewModel(CategorySelectorViewModel categorySelectorViewModel, ScrapersManager scrapersManager)
        {
            _scrapersManager = scrapersManager;
            _categorySelectorViewModel = categorySelectorViewModel;

            CurrentCategoryViewModel = InitiateCategoryPage();
        }

        private CategoryPage InitiateCategoryPage()
        {
            _subCategorySelectorViewModel = new SubCategoryViewModel();
            _categoryPageViewModel = new CategoryPageViewModel(_subCategorySelectorViewModel);
            _categoryPage = new CategoryPage(_categoryPageViewModel);

            _categoryPage.SubCategorySelectionChanged += _categoryPage_SubCategorySelectionChanged;

            return _categoryPage;
        }

        private FanFicsPage InitiateFanFicPage(string fanFicPageUri)
        {
           
            ObservableCollection<FanFicItemViewModel> fanFics = _scrapersManager.GetFanFicStories(fanFicPageUri, 1);

            _fanFicSelectorViewModel = new FanFicSelectorViewModel(fanFics, 1, _scrapersManager.GetFanFicPages(),
                _scrapersManager.GetRatingOptions(), _scrapersManager.GetGenresOptions(), _scrapersManager.GetStoryLengthOptions(),
                _scrapersManager.GetStoryStatusOptions(), _scrapersManager.GetCoupleTypesOptions(), _scrapersManager.GetCharactersOptions(),
                _scrapersManager.GetCouplesOptions(), _scrapersManager.GetContextOptions(), _scrapersManager.GetNotesOptions(),
                _scrapersManager.GetWarnsOptions());
            _fanFicPageViewModel = new FanFicPageViewModel(_fanFicSelectorViewModel);
            _fanFicsPage = new FanFicsPage(_fanFicPageViewModel);

            _fanFicSelectorViewModel.GotoFirstPage += _GotoFirstPage;
            _fanFicSelectorViewModel.GotoPreviousPage += _GotoPreviousPage;
            _fanFicSelectorViewModel.GotoNextPage += _GotoNextPage;
            _fanFicSelectorViewModel.GotoLastPage += _GotoLastPage;
            _fanFicSelectorViewModel.SaveAsPDF += _SaveAsPDF;
            _fanFicSelectorViewModel.ReadFanFic += _ReadFanFic;
            _fanFicSelectorViewModel.SearchFanFics += _SearchFanFics;

            return _fanFicsPage;
        }

        private void _SearchFanFics()
        {
            ReadFanFicsSearchParams();

            _fanFicSelectorViewModel.FanFics = _scrapersManager.GetFanFicStories(_selectedSubCategory.FanFicsPageUri, 1, _rating, _genre, _storyLength,
                _storyStatus, _coupleType, _character1, _character2, _couple, _context, _note, _warn, _excludeNote, _excludeWarn);
            _fanFicSelectorViewModel.PageNavigatorViewModel.MaxPages = _scrapersManager.GetFanFicPages();
        }

        private void ReadFanFicsSearchParams()
        {
            _rating = _fanFicSelectorViewModel.FanFicSearcherViewModel.RatingEntry.Value;
            _genre = _fanFicSelectorViewModel.FanFicSearcherViewModel.GenreEntry.Value;
            _storyLength = _fanFicSelectorViewModel.FanFicSearcherViewModel.StoryLengthEntry.Value;
            _storyStatus = _fanFicSelectorViewModel.FanFicSearcherViewModel.StoryStatusEntry.Value;
            _coupleType = _fanFicSelectorViewModel.FanFicSearcherViewModel.CoupleTypeEntry.Value;
            _character1 = _fanFicSelectorViewModel.FanFicSearcherViewModel.Character1Entry.Value;
            _character2 = _fanFicSelectorViewModel.FanFicSearcherViewModel.Character2Entry.Value;
            _couple = _fanFicSelectorViewModel.FanFicSearcherViewModel.CoupleEntry.Value;
            _context = _fanFicSelectorViewModel.FanFicSearcherViewModel.ContextEntry.Value;
            _note = _fanFicSelectorViewModel.FanFicSearcherViewModel.NoteEntry.Value;
            _warn = _fanFicSelectorViewModel.FanFicSearcherViewModel.WarnsEntry.Value;
            _excludeNote = _fanFicSelectorViewModel.FanFicSearcherViewModel.ExcludeNoteEntry.Value;
            _excludeWarn = _fanFicSelectorViewModel.FanFicSearcherViewModel.ExcludeWarnsEntry.Value;
        }

        private void _ReadFanFic(FanFicItemViewModel fanFicData)
        {
            if (fanFicData != null)
            {
                FullStoryData fanFicStory = _scrapersManager.GetFanFicFullStory(fanFicData.Uri);
                if (fanFicStory == null) return; //TODO: Implement message

                CurrentCategoryViewModel = InitializeReadingPage(fanFicStory);
                
            }            

        }

        private UserControl InitializeReadingPage(FullStoryData fanFicStory)
        {
            _pageReader = new ReaderPageViewModel(fanFicStory.Text);
            _pageReader.CloseReaderPage += _pageReader_CloseReaderPage;
            _readerPage = new ReaderPage(_pageReader);

            return _readerPage;
        }

        private void _pageReader_CloseReaderPage()
        {
            _pageReader.CloseReaderPage -= _pageReader_CloseReaderPage;
            _pageReader = null;
            _readerPage = null;
            CurrentCategoryViewModel = _fanFicsPage;
        }

        private void _SaveAsPDF(FanFicItemViewModel fanFicData)
        {
            if (fanFicData != null)
            {
                FullStoryData fanFicStory = _scrapersManager.GetFanFicFullStory(fanFicData.Uri);
                if (fanFicStory == null) return; //TODO: Implement message

                //TODO: Advise before saving that it will take time and can continue working
                System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
                saveFile.Filter = "PDF File (*.pdf)|*.pdf";
                saveFile.FileName = string.Format("{0}.pdf", fanFicData.Title);
                saveFile.ShowDialog();

                if (saveFile.FileName != string.Empty)
                {
                    PDFManager pdf = new PDFManager();
                    pdf.SaveHtmlToPDF(fanFicStory.Text, fanFicStory.Css, saveFile.FileName);
                }
                
            }            
        }

        private void _GotoLastPage()
        {
            _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage = _fanFicSelectorViewModel.PageNavigatorViewModel.MaxPages;
            ReadFanFicsSearchParams();
            _fanFicSelectorViewModel.FanFics = _scrapersManager.GetFanFicStories(_selectedSubCategory.FanFicsPageUri, _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage, 
                _rating, _genre, _storyLength, _storyStatus, _coupleType, _character1, _character2, _couple, _context, _note, _warn, 
                _excludeNote, _excludeWarn);
            _fanFicSelectorViewModel.PageNavigatorViewModel.MaxPages = _scrapersManager.GetFanFicPages();

        }

        private void _GotoNextPage()
        {
            _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage++;
            ReadFanFicsSearchParams();
            _fanFicSelectorViewModel.FanFics = _scrapersManager.GetFanFicStories(_selectedSubCategory.FanFicsPageUri, _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage, 
                _rating, _genre, _storyLength, _storyStatus, _coupleType, _character1, _character2, _couple, _context, _note, _warn, 
                _excludeNote, _excludeWarn);
            _fanFicSelectorViewModel.PageNavigatorViewModel.MaxPages = _scrapersManager.GetFanFicPages();
        }

        private void _GotoPreviousPage()
        {
            _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage--;
            ReadFanFicsSearchParams();
            _fanFicSelectorViewModel.FanFics = _scrapersManager.GetFanFicStories(_selectedSubCategory.FanFicsPageUri, _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage, 
                _rating, _genre, _storyLength, _storyStatus, _coupleType, _character1, _character2, _couple, _context, _note, _warn, 
                _excludeNote, _excludeWarn);
            _fanFicSelectorViewModel.PageNavigatorViewModel.MaxPages = _scrapersManager.GetFanFicPages();
        }

        private void _GotoFirstPage()
        {
            _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage = 1;
            ReadFanFicsSearchParams();
            _fanFicSelectorViewModel.FanFics = _scrapersManager.GetFanFicStories(_selectedSubCategory.FanFicsPageUri, _fanFicSelectorViewModel.PageNavigatorViewModel.CurrentPage, 
                _rating, _genre, _storyLength, _storyStatus, _coupleType, _character1, _character2, _couple, _context, _note, _warn, 
                _excludeNote, _excludeWarn);
            _fanFicSelectorViewModel.PageNavigatorViewModel.MaxPages = _scrapersManager.GetFanFicPages();
        }

        private void _categoryPage_SubCategorySelectionChanged(SubCategoryItemDTO subCategoryItemDTO)
        {
            if (subCategoryItemDTO == null || subCategoryItemDTO.FanFicsPageUri == string.Empty)
                return;

            _selectedSubCategory = subCategoryItemDTO;

            CurrentCategoryViewModel = InitiateFanFicPage(subCategoryItemDTO.FanFicsPageUri);
            _fanFicPageViewModel.CategoryName = _categoryPageViewModel.CategoryName;
            _fanFicPageViewModel.FanFicPageName = subCategoryItemDTO.SubCategoryName;
        }

        public CategorySelectorViewModel CategorySelector { get => _categorySelectorViewModel; }

        public UserControl CurrentCategoryViewModel
        {
            get
            {
                return _currentCategoryViewModel;
            }
            set
            {
                if (_currentCategoryViewModel != value)
                {
                    _currentCategoryViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public CategoryPageViewModel CategoryPageViewModel { get => _categoryPageViewModel; }
        public ScrapersManager ScrapersManager { get => _scrapersManager; }
    }
}
